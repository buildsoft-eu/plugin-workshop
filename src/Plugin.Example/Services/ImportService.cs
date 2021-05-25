using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildSoft.BIMExpert.Plugin;
using BuildSoft.Convert;
using BuildSoft.Linq;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Analysis.Geometry;
using BuildSoft.UBSM.General;
using BuildSoft.UBSM.Math;
using BuildSoft.UBSM.Physical;
using BuildSoft.UBSM.Physical.Geometry;
using Example.API;
using Plugin.Example.Models;
using ApiMaterial = Example.API.Material;
using ApiSection = Example.API.Section;
using Bar = BuildSoft.UBSM.Physical.Geometry.Bar;
using Material = BuildSoft.UBSM.Physical.Material;
using Model = BuildSoft.UBSM.Analysis.Model;
using Text = Plugin.Example.Localization.Import;

namespace Plugin.Example.Services
{
    public class ImportService
    {
        private readonly IApiLoader _apiLoader;
        private readonly IConflictResolver<ApiMaterial, Database.MaterialOverviewItem> _materialConflictResolver;
        private readonly IConflictResolver<Section, Database.ParametricSectionOverviewItem> _sectionConflictResolver;
        private readonly IUbsmDatabase _database;
        private readonly IdGenerator _idGenerator;
        private readonly Settings _settings;

        private const double ProgressStart = 0.0;
        private const double ModelLoaded = 5.0;
        private const double MaterialsLoaded = 10.0;
        private const double MaterialConflictsDetermined = 15.0;
        private const double MaterialsMapped = 20.0;
        private const double SectionsLoaded = 25.0;
        private const double SectionConflictsDetermined = 30.0;
        private const double SectionsMapped = 35.0;
        private const double MaterialDetailsObtained = 45.0;
        private const double SectionDetailsObtained = 55.0;
        private const double Finished = 100.0;

        private double _currentProgressValue;
        private string _currentProgressText = "";

        public ImportService(
            IApiLoader apiLoader,
            IConflictResolver<ApiMaterial, Database.MaterialOverviewItem> materialConflictResolver,
            IConflictResolver<ApiSection, Database.ParametricSectionOverviewItem> sectionConflictResolver,
            IUbsmDatabase database,
            IdGenerator idGenerator,
            Settings settings)
        {
            _apiLoader = apiLoader;
            _materialConflictResolver = materialConflictResolver;
            _sectionConflictResolver = sectionConflictResolver;
            _database = database;
            _idGenerator = idGenerator;
            _settings = settings;
        }

        public async Task<(Structure, string)> RunAsync(
            Action<string> updateTitle,
            IProgress<(string, double)> progress,
            CancellationToken token)
        {
            updateTitle(Text.LoadModelTitle);
            ReportProgress(progress, Text.FetchModelProgress, ProgressStart);
            var model = await _apiLoader.LoadAsync(token);
            ReportProgress(progress, Text.ModelLoadedProgress, ModelLoaded);

            // material mapping
            updateTitle(Text.MappingMaterialsTitle);
            var apiMaterials = model.Portals
                .SelectMany(g => new[] { g.Beam.Material, g.Column.Material })
                .Distinct(new ApiMaterialEqualityByNameComparer())
                .OrderBy(x => x.Name);
            var mappedMaterials = await GetMaterialMappingAsync(
                apiMaterials,
                progress,
                token);
            ReportProgress(progress, Text.MaterialsMapped, MaterialsMapped);

            // section mapping
            updateTitle(Text.MappingSectionsTitle);
            var apiSections = model.Portals
                .SelectMany(g => new[] { g.Beam.Section, g.Column.Section })
                .Distinct(new ApiSectionEqualityByNameComparer())
                .OrderBy(x => x.Name);
            var mappedSections = await GetSectionMappingAsync(
                apiSections,
                progress,
                token);
            ReportProgress(progress, Text.SectionsMapped, SectionsMapped);

            if (_settings.ExportWithConnections)
            {
                // todo: connection elements mapping
            }

            // map portal to bars
            updateTitle(Text.DatabaseDetailsTitle);
            var ubsmMaterials = new List<Material>();
            var ubsmMaterialProperties = new List<BuildSoft.UBSM.Analysis.MaterialProperties>();
            foreach (var mappedMaterial in mappedMaterials)
            {
                var material = await _database.GetMaterialAsync(mappedMaterial.UbsmId);
                ubsmMaterials.Add(material);
                var properties = await _database.GetMaterialPropertiesAsync(mappedMaterial.UbsmId);
                ubsmMaterialProperties.Add(properties);
            }
            ReportProgress(progress, Text.MaterialDetailsObtained, MaterialDetailsObtained);

            var ubsmSections = new List<ParametricSection>();
            var ubsmSectionProperties = new List<BuildSoft.UBSM.Analysis.SectionProperties>();
            foreach (var mappedSection in mappedSections)
            {
                var section = await _database.GetSectionAsync(mappedSection.UbsmId);
                ubsmSections.Add(section);
                var properties = await _database.GetSectionPropertiesAsync(mappedSection.UbsmId);
                ubsmSectionProperties.Add(properties);
            }
            ReportProgress(progress, Text.SectionDetailsObtained, SectionDetailsObtained);

            updateTitle(string.Format(Text.PortalMappingTitle, model.Portals.Length));
            var ubsmAnalysisPoints = new List<Point>();
            var ubsmPhysicalBars = new List<Bar>();
            var ubsmAnalysisBars = new List<BuildSoft.UBSM.Analysis.Geometry.Bar>();
            var ubsmAnalysisBarGroups = new List<BarGroup>();
            for (var i = 0; i < model.Portals.Length; i++)
            {
                MapPortalToBars(
                    model.Portals[i],
                    i * _settings.PortalDistance,
                    mappedMaterials,
                    mappedSections,
                    ubsmSections,
                    out var portalPhysicalBars,
                    out var portalAnalysisPoints,
                    out var portalAnalysisBars,
                    out var portalBarGroups);

                ubsmPhysicalBars.AddRange(portalPhysicalBars);
                ubsmAnalysisPoints.AddRange(portalAnalysisPoints);
                ubsmAnalysisBars.AddRange(portalAnalysisBars);
                ubsmAnalysisBarGroups.AddRange(portalBarGroups);
            }

            var result = new Structure
            {
                PhysicalModel = new BuildSoft.UBSM.Physical.Model
                {
                    Materials = ubsmMaterials,
                    ParametricSections = ubsmSections,
                    Bars = ubsmPhysicalBars
                },
                AnalysisModels = new List<Model>
                {
                    new()
                    {
                        MaterialProperties = ubsmMaterialProperties,
                        SectionProperties = ubsmSectionProperties,
                        Points = ubsmAnalysisPoints,
                        Bars = ubsmAnalysisBars,
                        BarGroups = ubsmAnalysisBarGroups
                    }
                }
            };

            updateTitle(string.Format(Text.FinishedTitle, model.Portals.Length));
            ReportProgress(progress, Text.Finished, Finished);

            return (result, null);
        }

        private async Task<List<Mapping>> GetMaterialMappingAsync(
            IEnumerable<ApiMaterial> apiMaterials,
            IProgress<(string, double)> progress,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.LoadingMaterials);
            var materials = await _database.GetMaterialsAsync();

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.ProcessingConflicts, MaterialsLoaded);
            var conflicts = await _materialConflictResolver.DetermineConflictsAsync(
                apiMaterials,
                materials);
            if (conflicts.IsNullOrEmpty())
            {
                return new List<Mapping>();
            }

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, MaterialConflictsDetermined);
            var mapping = await _materialConflictResolver.ResolveConflictsAsync(
                conflicts,
                token);
            return mapping.ToList();
        }

        private async Task<List<Mapping>> GetSectionMappingAsync(
            IEnumerable<ApiSection> apiSections,
            IProgress<(string, double)> progress,
            CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.LoadingSections);
            var sections = await _database.GetSectionsAsync();

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, Text.ProcessingConflicts, SectionsLoaded);
            var conflicts = await _sectionConflictResolver.DetermineConflictsAsync(
                apiSections,
                sections);
            if (conflicts.IsNullOrEmpty())
            {
                return new List<Mapping>();
            }

            token.ThrowIfCancellationRequested();
            ReportProgress(progress, SectionConflictsDetermined);
            var mapping = await _sectionConflictResolver.ResolveConflictsAsync(
                conflicts,
                token);
            return mapping.ToList();
        }

        private void MapPortalToBars(
            Geometry portal,
            double zCoordinate,
            IReadOnlyCollection<Mapping> mappedMaterials,
            IReadOnlyCollection<Mapping> mappedSections,
            IReadOnlyCollection<ParametricSection> parametricSections,
            out List<Bar> physicalBars,
            out List<Point> analysisPoints,
            out List<BuildSoft.UBSM.Analysis.Geometry.Bar> analysisBars,
            out List<BarGroup> analysisBarGroups)
        {
            // create basic geometry points
            var h = portal.Height;
            var w = portal.Width;
            var hBeam = portal.Beam.Section.Height.FromMillimeterToMeter();
            var wColumn = portal.Column.Section.Height.FromMillimeterToMeter();

            var columnLeftBottom = new Vector3 { Z = zCoordinate };
            var columnLeftIntersect = new Vector3 { Y = h + 0.5 * hBeam, Z = zCoordinate };
            var columnLeftTop = new Vector3 { Y = h + hBeam, Z = zCoordinate };

            var columnRightBottom = new Vector3 { X = w + wColumn, Z = zCoordinate };
            var columnRightIntersect = new Vector3 { X = w + wColumn, Y = h + 0.5 * hBeam, Z = zCoordinate };
            var columnRightTop = new Vector3 { X = w + wColumn, Y = h + hBeam, Z = zCoordinate };

            var beamLeft = new Vector3 { X = 0.5 * wColumn, Y = h + 0.5 * hBeam, Z = zCoordinate };
            var beamRight = new Vector3 { X = 0.5 * wColumn + w, Y = h + 0.5 * hBeam, Z = zCoordinate };
            var beamMiddle = new Vector3 { X = 0.5 * wColumn + 0.5 * w, Y = h + 0.5 * hBeam, Z = zCoordinate };

            // section and material mapping information
            var beamSectionId = GetSectionInformation(
                mappedMaterials,
                mappedSections,
                parametricSections,
                portal.Beam.Material.Name,
                portal.Beam.Section.Name,
                out var beamMaterialOverrides);

            var columnSectionId = GetSectionInformation(
                mappedMaterials,
                mappedSections,
                parametricSections,
                portal.Column.Material.Name,
                portal.Column.Section.Name,
                out var columnMaterialOverrides);

            // physical bars
            var physBeamId = _idGenerator.CreateNewPhysicalBarId();
            var physColumnLeftId = _idGenerator.CreateNewPhysicalBarId();
            var physColumnRightId = _idGenerator.CreateNewPhysicalBarId();
            physicalBars = new List<Bar>
            {
                new()
                {
                    ID = physBeamId,
                    Name = new AliasedString {Default = $"Beam {physBeamId}"},
                    LocalCS = CreateBeamCoordinateSystem(),
                    Begin = CreateBarPosition(beamLeft),
                    End = CreateBarPosition(beamRight),
                    SectionID = beamSectionId,
                    MaterialOverrides = beamMaterialOverrides
                },
                new()
                {
                    ID = physColumnLeftId,
                    Name = new AliasedString { Default = $"Column {physColumnLeftId}" },
                    LocalCS = CreateColumnCoordinateSystem(),
                    Begin = CreateBarPosition(columnLeftBottom),
                    End = CreateBarPosition(columnLeftTop),
                    SectionID = columnSectionId,
                    MaterialOverrides = columnMaterialOverrides
                },
                new()
                {
                    ID = physColumnRightId,
                    Name = new AliasedString { Default = $"Column {physColumnRightId}" },
                    LocalCS = CreateColumnCoordinateSystem(),
                    Begin = CreateBarPosition(columnRightBottom),
                    End = CreateBarPosition(columnRightTop),
                    SectionID = columnSectionId,
                    MaterialOverrides = columnMaterialOverrides
                }
            };

            // points
            var point1Id = _idGenerator.CreateNewAnalysisPointId();
            var point2Id = _idGenerator.CreateNewAnalysisPointId();
            var point3Id = _idGenerator.CreateNewAnalysisPointId();
            var point4Id = _idGenerator.CreateNewAnalysisPointId();
            var point5Id = _idGenerator.CreateNewAnalysisPointId();

            analysisPoints = new List<Point>
            {
                new ()
                {
                    Name = new AliasedString{Default = "Point CLB"},
                    ID = point1Id,
                    Location = columnLeftBottom,
                    Tx = new BoundaryCondition{ IsFixed = true},
                    Ty = new BoundaryCondition{ IsFixed = true},
                    Tz = new BoundaryCondition{ IsFixed = true}
                },
                new ()
                {
                    Name = new AliasedString{Default = "Point CLT"},
                    ID = point2Id,
                    Location = columnLeftIntersect
                },
                new ()
                {
                    Name = new AliasedString{Default = "Point BM"},
                    ID = point3Id,
                    Location = beamMiddle
                },
                new ()
                {
                    Name = new AliasedString{Default = "Point CRT"},
                    ID = point4Id,
                    Location = columnRightIntersect
                },
                new ()
                {
                    Name = new AliasedString{Default = "Point CRB"},
                    ID = point5Id,
                    Location = columnRightBottom,
                    Tx = new BoundaryCondition{ IsFixed = true},
                    Ty = new BoundaryCondition{ IsFixed = true},
                    Tz = new BoundaryCondition{ IsFixed = true}
                }
            };

            // bars
            var beamLeftId = _idGenerator.CreateNewAnalysisBarId();
            var beamRightId = _idGenerator.CreateNewAnalysisBarId();
            var columnLeftId = _idGenerator.CreateNewAnalysisBarId();
            var columnRightId = _idGenerator.CreateNewAnalysisBarId();

            analysisBars = new List<BuildSoft.UBSM.Analysis.Geometry.Bar>
            {
                new ()
                {
                    ID = beamLeftId,
                    PhysicalID = physBeamId,
                    SectionID = beamSectionId,
                    MaterialOverrides = beamMaterialOverrides,
                    PhysicalParentType = PhysicalParentType.Bar,
                    LocalCS = CreateBeamCoordinateSystem(),
                    Begin = new BarEnd
                    {
                        PointID = point2Id,
                        Connectivity = CreateFixedEndConnectivity()
                    },
                    End = new BarEnd
                    {
                        PointID = point3Id,
                        Connectivity = CreateFixedEndConnectivity()
                    }
                },
                new ()
                {
                    ID = beamRightId,
                    PhysicalID = physBeamId,
                    MaterialOverrides = beamMaterialOverrides,
                    SectionID = beamSectionId,
                    PhysicalParentType = PhysicalParentType.Bar,
                    LocalCS = CreateBeamCoordinateSystem(),
                    Begin = new BarEnd
                    {
                        PointID = point3Id,
                        Connectivity = CreateFixedEndConnectivity()
                    },
                    End = new BarEnd
                    {
                        PointID = point4Id,
                        Connectivity = CreateFixedEndConnectivity()
                    }
                },
                new ()
                {
                    ID = columnLeftId,
                    PhysicalID = physColumnLeftId,
                    SectionID = columnSectionId,
                    MaterialOverrides = columnMaterialOverrides,
                    PhysicalParentType = PhysicalParentType.Bar,
                    LocalCS = CreateColumnCoordinateSystem(),
                    Begin = new BarEnd
                    {
                        PointID = point1Id,
                        Connectivity = CreateFixedEndConnectivity()
                    },
                    End = new BarEnd
                    {
                        PointID = point2Id,
                        Connectivity = CreateFixedEndConnectivity()
                    }
                },
                new ()
                {
                    ID = columnRightId,
                    PhysicalID = physColumnRightId,
                    SectionID = columnSectionId,
                    MaterialOverrides = columnMaterialOverrides,
                    PhysicalParentType = PhysicalParentType.Bar,
                    LocalCS = CreateColumnCoordinateSystem(),
                    Begin = new BarEnd
                    {
                        PointID = point5Id,
                        Connectivity = CreateFixedEndConnectivity()
                    },
                    End = new BarEnd
                    {
                        PointID = point4Id,
                        Connectivity = CreateFixedEndConnectivity()
                    }
                }
            };

            // bar groups
            var bucklingStrongId = _idGenerator.CreateNewBarGroupId();
            var bucklingWeakId = _idGenerator.CreateNewBarGroupId();
            var bucklingLoadsId = _idGenerator.CreateNewBarGroupId();
            var bucklingSectionId = _idGenerator.CreateNewBarGroupId();

            analysisBarGroups = new List<BarGroup>
            {
                new()
                {
                    ID = bucklingStrongId,
                    Name = new AliasedString{Default = "BucklingStrong"},
                    BarIDs = new List<int> { beamLeftId, beamRightId }
                },
                new()
                {
                    ID = bucklingWeakId,
                    Name = new AliasedString{Default = "BucklingWeak"},
                    BarIDs = new List<int> { beamLeftId, beamRightId }
                },
                new()
                {
                    ID = bucklingLoadsId,
                    Name = new AliasedString{Default = "Loads"},
                    BarIDs = new List<int> { beamLeftId, beamRightId }
                },
                new()
                {
                    ID = bucklingSectionId,
                    Name = new AliasedString{Default = "Section"},
                    BarIDs = new List<int> { beamLeftId, beamRightId }
                }
            };
        }

        private static BarEndConnectivity CreateFixedEndConnectivity()
        {
            return new()
            {
                Nx = new BoundaryCondition { IsFixed = true },
                Vy = new BoundaryCondition { IsFixed = true },
                Vz = new BoundaryCondition { IsFixed = true },
                Mx = new BoundaryCondition { IsFixed = true, BoundaryConditionType = BoundaryConditionType.PointRotation },
                My = new BoundaryCondition { IsFixed = true, BoundaryConditionType = BoundaryConditionType.PointRotation },
                Mz = new BoundaryCondition { IsFixed = true, BoundaryConditionType = BoundaryConditionType.PointRotation },
            };
        }

        private static Guid GetSectionInformation(
            IEnumerable<Mapping> mappedMaterials,
            IEnumerable<Mapping> mappedSections,
            IEnumerable<ParametricSection> parametricSections,
            string materialName,
            string sectionName,
            out List<GuidMapItem> materialOverrides)
        {
            var sectionId = mappedSections.First(x => string.Equals(x.ApiName, sectionName)).UbsmId;
            var materialId = mappedMaterials.First(x => string.Equals(x.ApiName, materialName)).UbsmId;
            var sectionDefinedMaterialId = parametricSections.First(ps => ps.ID == sectionId).MaterialID;
            materialOverrides = new List<GuidMapItem>();
            if (materialId != sectionDefinedMaterialId)
            {
                materialOverrides.Add(new GuidMapItem
                {
                    BaseID = sectionDefinedMaterialId,
                    ReplacedWith = materialId
                });
            }

            return sectionId;
        }

        private static CoordinateSystem CreateBeamCoordinateSystem()
        {
            return new()
            {
                X = new Vector3 { X = 1 },
                Y = new Vector3 { Z = -1 },
                Z = new Vector3 { Y = 1 }
            };
        }

        private static CoordinateSystem CreateColumnCoordinateSystem()
        {
            return new()
            {
                X = new Vector3 { Y = 1 },
                Y = new Vector3 { Z = 1 },
                Z = new Vector3 { X = 1 }
            };
        }

        private static BarPosition CreateBarPosition(Vector3 location)
        {
            return new()
            {
                Eccentricity = new Eccentricity
                {
                    GlobalOffset = new Vector3(),
                    LocalOffset = new Vector3()
                },
                Location = location
            };
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            string text)
        {
            ReportProgress(progress, text, _currentProgressValue);
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            double value)
        {
            ReportProgress(progress, _currentProgressText, value);
        }

        private void ReportProgress(
            IProgress<(string, double)> progress,
            string text,
            double value)
        {
            _currentProgressText = text;
            _currentProgressValue = value;
            progress.Report((text, value));
        }
    }
}
