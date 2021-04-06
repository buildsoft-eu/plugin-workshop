using System;
using System.Linq;
using System.Xml.Linq;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Analysis.Fire;
using BuildSoft.UBSM.Analysis.Geometry;
using BuildSoft.UBSM.Analysis.Loads;
using BuildSoft.UBSM.Analysis.Results;
using BuildSoft.UBSM.General;
using BuildSoft.UBSM.Math;
using BuildSoft.UBSM.Physical;
using BuildSoft.UBSM.Physical.Connections;
using BuildSoft.UBSM.Visualisation;

namespace Plugin.Workshop.Serialization
{
    public static class FromXmlExtension
    {
        /// <summary>
        /// Automatically generated converter method for <see cref="Structure" />.
        /// </summary>
        public static Structure ToStructure(this XElement structureNode)
        {
            var structure = new Structure();
            if (structureNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                structure.Name = ToAliasedString(structureNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (structureNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                structure.ID = XmlUtilities.ConvertType<Guid>(structureNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (structureNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalModel", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                structure.PhysicalModel = ToPhysicalModel(structureNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalModel", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (structureNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnalysisModels", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in structureNode.Elements().Where(x => string.Compare(x.Name.ToString(), "AnalysisModels", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    structure.AnalysisModels.Add(ToAnalysisModel(elem));
                }
            }
            if (structureNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Visualisation", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                structure.Visualisation = ToDisplayOptions(structureNode.Elements().First(x => string.Compare(x.Name.ToString(), "Visualisation", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return structure;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Color" />.
        /// </summary>
        public static Color ToColor(this XElement colorNode)
        {
            var color = new Color();
            if (colorNode.Elements().Any(x => string.Compare(x.Name.ToString(), "R", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                color.R = XmlUtilities.ConvertType<int>(colorNode.Elements().First(x => string.Compare(x.Name.ToString(), "R", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (colorNode.Elements().Any(x => string.Compare(x.Name.ToString(), "G", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                color.G = XmlUtilities.ConvertType<int>(colorNode.Elements().First(x => string.Compare(x.Name.ToString(), "G", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (colorNode.Elements().Any(x => string.Compare(x.Name.ToString(), "B", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                color.B = XmlUtilities.ConvertType<int>(colorNode.Elements().First(x => string.Compare(x.Name.ToString(), "B", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (colorNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Alpha", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                color.Alpha = XmlUtilities.ConvertType<int>(colorNode.Elements().First(x => string.Compare(x.Name.ToString(), "Alpha", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return color;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Layer" />.
        /// </summary>
        public static Layer ToLayer(this XElement layerNode)
        {
            var layer = new Layer();
            if (layerNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.ID = XmlUtilities.ConvertType<int>(layerNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (layerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Locked", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.Locked = XmlUtilities.ConvertType<bool>(layerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Locked", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (layerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Hidden", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.Hidden = XmlUtilities.ConvertType<bool>(layerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Hidden", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (layerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DefaultSelectedColor", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.DefaultSelectedColor = ToColor(layerNode.Elements().First(x => string.Compare(x.Name.ToString(), "DefaultSelectedColor", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (layerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DefaultColor", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.DefaultColor = ToColor(layerNode.Elements().First(x => string.Compare(x.Name.ToString(), "DefaultColor", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (layerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                layer.Name = ToAliasedString(layerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return layer;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ElementInformation" />.
        /// </summary>
        public static ElementInformation ToElementInformation(this XElement elementinformationNode)
        {
            var elementinformation = new ElementInformation();
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.ReferenceID = XmlUtilities.ConvertType<int>(elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SelectedColor", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.SelectedColor = ToColor(elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "SelectedColor", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Color", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.Color = ToColor(elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "Color", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Visibility", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.Visibility = (Visibility)Enum.Parse(typeof(Visibility), elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "Visibility", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LayerID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.LayerID = XmlUtilities.ConvertType<int>(elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "LayerID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementinformationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ExtensionData", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementinformation.ExtensionData = ToKeyValues(elementinformationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ExtensionData", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return elementinformation;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PhysicalVisualisation" />.
        /// </summary>
        public static PhysicalVisualisation ToPhysicalVisualisation(this XElement physicalvisualisationNode)
        {
            var physicalvisualisation = new PhysicalVisualisation();
            if (physicalvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in physicalvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    physicalvisualisation.Bars.Add(ToElementInformation(elem));
                }
            }
            if (physicalvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PolyBars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in physicalvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PolyBars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    physicalvisualisation.PolyBars.Add(ToElementInformation(elem));
                }
            }
            if (physicalvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in physicalvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    physicalvisualisation.Plates.Add(ToElementInformation(elem));
                }
            }
            if (physicalvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Footings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in physicalvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Footings", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    physicalvisualisation.Footings.Add(ToElementInformation(elem));
                }
            }

            return physicalvisualisation;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnalysisVisualisation" />.
        /// </summary>
        public static AnalysisVisualisation ToAnalysisVisualisation(this XElement analysisvisualisationNode)
        {
            var analysisvisualisation = new AnalysisVisualisation();
            if (analysisvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ModelID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                analysisvisualisation.ModelID = XmlUtilities.ConvertType<Guid>(analysisvisualisationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ModelID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (analysisvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in analysisvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    analysisvisualisation.Points.Add(ToElementInformation(elem));
                }
            }
            if (analysisvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in analysisvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    analysisvisualisation.Bars.Add(ToElementInformation(elem));
                }
            }
            if (analysisvisualisationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in analysisvisualisationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    analysisvisualisation.Plates.Add(ToElementInformation(elem));
                }
            }

            return analysisvisualisation;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DisplayOptions" />.
        /// </summary>
        public static DisplayOptions ToDisplayOptions(this XElement displayoptionsNode)
        {
            var displayoptions = new DisplayOptions();
            if (displayoptionsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Layers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in displayoptionsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Layers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    displayoptions.Layers.Add(ToLayer(elem));
                }
            }
            if (displayoptionsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalModelInformation", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                displayoptions.PhysicalModelInformation = ToPhysicalVisualisation(displayoptionsNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalModelInformation", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (displayoptionsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnalysisModelInformation", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in displayoptionsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "AnalysisModelInformation", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    displayoptions.AnalysisModelInformation.Add(ToAnalysisVisualisation(elem));
                }
            }

            return displayoptions;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Model" />.
        /// </summary>
        public static Model ToPhysicalModel(this XElement modelNode)
        {
            var model = new Model();
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.Name = ToAliasedString(modelNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (modelNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.ID = XmlUtilities.ConvertType<Guid>(modelNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Materials", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Materials", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Materials.Add(ToMaterial(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ParametricSections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ParametricSections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.ParametricSections.Add(ToParametricSection(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomSections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "CustomSections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.CustomSections.Add(ToCustomSection(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "VariableSections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "VariableSections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.VariableSections.Add(ToVariableSection(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlateSections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PlateSections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.PlateSections.Add(ToPlateSection(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Bars.Add(ToPhysicalGeometryBar(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PolyBars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PolyBars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.PolyBars.Add(ToPolyBar(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Plates.Add(ToPhysicalGeometryPlate(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PadFootings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PadFootings", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.PadFootings.Add(ToPadFooting(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Connections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Connections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Connections.Add(ToConnection(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bolts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bolts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Bolts.Add(ToBolt(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Nuts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Nuts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Nuts.Add(ToNut(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Washers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Washers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Washers.Add(ToWasher(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnchorBolts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "AnchorBolts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.AnchorBolts.Add(ToAnchorBolt(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BoltAssemblies", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BoltAssemblies", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.BoltAssemblies.Add(ToBoltAssembly(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnchorBoltAssemblies", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "AnchorBoltAssemblies", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.AnchorBoltAssemblies.Add(ToAnchorBoltAssembly(elem));
                }
            }

            return model;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Material" />.
        /// </summary>
        public static Material ToMaterial(this XElement materialNode)
        {
            var material = new Material();
            if (materialNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.ID = XmlUtilities.ConvertType<Guid>(materialNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.Name = ToAliasedString(materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.MaterialType = (MaterialType)Enum.Parse(typeof(MaterialType), materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.Version = XmlUtilities.ConvertType<int>(materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.LastChanged = XmlUtilities.ConvertType<DateTime>(materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                material.ReadOnly = XmlUtilities.ConvertType<bool>(materialNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return material;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Measurement" />.
        /// </summary>
        public static Measurement ToMeasurement(this XElement measurementNode)
        {
            var measurement = new Measurement();
            if (measurementNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                measurement.ID = XmlUtilities.ConvertType<int>(measurementNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (measurementNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                measurement.Name = XmlUtilities.ConvertType<string>(measurementNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (measurementNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                measurement.Value = XmlUtilities.ConvertType<double>(measurementNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (measurementNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Quantity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                measurement.Quantity = (Quantity)Enum.Parse(typeof(Quantity), measurementNode.Attributes().
                Where(x => string.Compare(x.Name.ToString(), "Quantity", StringComparison.InvariantCultureIgnoreCase) == 0).First().Value);
            }

            return measurement;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ParametricSection" />.
        /// </summary>
        public static ParametricSection ToParametricSection(this XElement parametricsectionNode)
        {
            var parametricsection = new ParametricSection();
            if (parametricsectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.ID = XmlUtilities.ConvertType<Guid>(parametricsectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.Name = ToAliasedString(parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.SectionType = (ParametricSectionType)Enum.Parse(typeof(ParametricSectionType), parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.MaterialID = XmlUtilities.ConvertType<Guid>(parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ProductionMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.ProductionMethod = (ProductionMethodType)Enum.Parse(typeof(ProductionMethodType), parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ProductionMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Measurements", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in parametricsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Measurements", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    parametricsection.Measurements.Add(ToMeasurement(elem));
                }
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "UserDefinedGeometryInstructions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in parametricsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "UserDefinedGeometryInstructions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    parametricsection.UserDefinedGeometryInstructions.Add(XmlUtilities.ConvertType<string>(elem.Value));
                }
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.Version = XmlUtilities.ConvertType<int>(parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.LastChanged = XmlUtilities.ConvertType<DateTime>(parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (parametricsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                parametricsection.ReadOnly = XmlUtilities.ConvertType<bool>(parametricsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return parametricsection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PointRegion" />.
        /// </summary>
        public static PointRegion ToPointRegion(this XElement pointregionNode)
        {
            var pointregion = new PointRegion();
            if (pointregionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointregion.ID = XmlUtilities.ConvertType<int>(pointregionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointregion.MaterialID = XmlUtilities.ConvertType<Guid>(pointregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Radius", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointregion.Radius = XmlUtilities.ConvertType<double>(pointregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Radius", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointregion.Location = ToVector2(pointregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointregion.IsOpening = XmlUtilities.ConvertType<bool>(pointregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in pointregionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    pointregion.Tags.Add(ToTag(elem));
                }
            }

            return pointregion;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LineRegion" />.
        /// </summary>
        public static LineRegion ToLineRegion(this XElement lineregionNode)
        {
            var lineregion = new LineRegion();
            if (lineregionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineregion.ID = XmlUtilities.ConvertType<int>(lineregionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineregion.MaterialID = XmlUtilities.ConvertType<Guid>(lineregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineregion.IsOpening = XmlUtilities.ConvertType<bool>(lineregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Curve", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineregion.Curve = ToBezierCurve2D(lineregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Curve", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (lineregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineregion.Thickness = XmlUtilities.ConvertType<double>(lineregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in lineregionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    lineregion.Tags.Add(ToTag(elem));
                }
            }

            return lineregion;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SurfaceRegion" />.
        /// </summary>
        public static SurfaceRegion ToSurfaceRegion(this XElement surfaceregionNode)
        {
            var surfaceregion = new SurfaceRegion();
            if (surfaceregionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceregion.ID = XmlUtilities.ConvertType<int>(surfaceregionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (surfaceregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceregion.MaterialID = XmlUtilities.ConvertType<Guid>(surfaceregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (surfaceregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Contour", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in surfaceregionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Contour", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    surfaceregion.Contour.Add(ToBezierCurve2D(elem));
                }
            }
            if (surfaceregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in surfaceregionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    surfaceregion.Triangles.Add(ToTriangle2D(elem));
                }
            }
            if (surfaceregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceregion.IsOpening = XmlUtilities.ConvertType<bool>(surfaceregionNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (surfaceregionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in surfaceregionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    surfaceregion.Tags.Add(ToTag(elem));
                }
            }

            return surfaceregion;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSectionPart" />.
        /// </summary>
        public static CustomSectionPart ToCustomSectionPart(this XElement customsectionpartNode)
        {
            var customsectionpart = new CustomSectionPart();
            if (customsectionpartNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.ID = XmlUtilities.ConvertType<int>(customsectionpartNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.SectionID = XmlUtilities.ConvertType<Guid>(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.Version = XmlUtilities.ConvertType<int>(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.ReferencePoint = ToVector2(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Angle", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.Angle = XmlUtilities.ConvertType<double>(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "Angle", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.IsOpening = XmlUtilities.ConvertType<bool>(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsOpening", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MirroredZ", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsectionpart.MirroredZ = XmlUtilities.ConvertType<bool>(customsectionpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "MirroredZ", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionpartNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsectionpart.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (customsectionpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionpartNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsectionpart.Tags.Add(ToTag(elem));
                }
            }

            return customsectionpart;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSection" />.
        /// </summary>
        public static CustomSection ToCustomSection(this XElement customsectionNode)
        {
            var customsection = new CustomSection();
            if (customsectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.ID = XmlUtilities.ConvertType<Guid>(customsectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.Name = ToAliasedString(customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ProductionMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.ProductionMethod = (ProductionMethodType)Enum.Parse(typeof(ProductionMethodType), customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ProductionMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsection.Points.Add(ToPointRegion(elem));
                }
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsection.Lines.Add(ToLineRegion(elem));
                }
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Surfaces", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Surfaces", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsection.Surfaces.Add(ToSurfaceRegion(elem));
                }
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Sections", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customsectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Sections", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customsection.Sections.Add(ToCustomSectionPart(elem));
                }
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.Version = XmlUtilities.ConvertType<int>(customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.LastChanged = XmlUtilities.ConvertType<DateTime>(customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customsectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customsection.ReadOnly = XmlUtilities.ConvertType<bool>(customsectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return customsection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CorrespondingPoint" />.
        /// </summary>
        public static CorrespondingPoint ToCorrespondingPoint(this XElement correspondingpointNode)
        {
            var correspondingpoint = new CorrespondingPoint();
            if (correspondingpointNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                correspondingpoint.ID = XmlUtilities.ConvertType<int>(correspondingpointNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (correspondingpointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsReversed", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                correspondingpoint.IsReversed = XmlUtilities.ConvertType<bool>(correspondingpointNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsReversed", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (correspondingpointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                correspondingpoint.BeginPoint = ToVector2(correspondingpointNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginPoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (correspondingpointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndPoints", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in correspondingpointNode.Elements().Where(x => string.Compare(x.Name.ToString(), "EndPoints", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    correspondingpoint.EndPoints.Add(ToVector2(elem));
                }
            }

            return correspondingpoint;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SectionConnection" />.
        /// </summary>
        public static SectionConnection ToSectionConnection(this XElement sectionconnectionNode)
        {
            var sectionconnection = new SectionConnection();
            if (sectionconnectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionconnection.ID = XmlUtilities.ConvertType<int>(sectionconnectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionconnectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsPredefined", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionconnection.IsPredefined = XmlUtilities.ConvertType<bool>(sectionconnectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsPredefined", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionconnectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomDefinition", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionconnectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "CustomDefinition", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionconnection.CustomDefinition.Add(ToCorrespondingPoint(elem));
                }
            }

            return sectionconnection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="VariableSection" />.
        /// </summary>
        public static VariableSection ToVariableSection(this XElement variablesectionNode)
        {
            var variablesection = new VariableSection();
            if (variablesectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.ID = XmlUtilities.ConvertType<Guid>(variablesectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.Name = ToAliasedString(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginSectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.BeginSectionID = XmlUtilities.ConvertType<Guid>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginSectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginSectionVersion", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.BeginSectionVersion = XmlUtilities.ConvertType<int>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginSectionVersion", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndSectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.EndSectionID = XmlUtilities.ConvertType<Guid>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "EndSectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndSectionVersion", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.EndSectionVersion = XmlUtilities.ConvertType<int>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "EndSectionVersion", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Connection", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.Connection = ToSectionConnection(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Connection", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Rotation", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.Rotation = XmlUtilities.ConvertType<double>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Rotation", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.Version = XmlUtilities.ConvertType<int>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.LastChanged = XmlUtilities.ConvertType<DateTime>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (variablesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                variablesection.ReadOnly = XmlUtilities.ConvertType<bool>(variablesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return variablesection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlateSection" />.
        /// </summary>
        public static PlateSection ToPlateSection(this XElement platesectionNode)
        {
            var platesection = new PlateSection();
            if (platesectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.ID = XmlUtilities.ConvertType<Guid>(platesectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.Name = ToAliasedString(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionXID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.SectionXID = XmlUtilities.ConvertType<Guid>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionXID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionZID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.SectionZID = XmlUtilities.ConvertType<Guid>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionZID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionZAnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.SectionZAnchorPlane = (BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane), platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionZAnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OffsetSectionZInYLocalDir", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.OffsetSectionZInYLocalDir = XmlUtilities.ConvertType<double>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "OffsetSectionZInYLocalDir", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.Version = XmlUtilities.ConvertType<int>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.LastChanged = XmlUtilities.ConvertType<DateTime>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (platesectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                platesection.ReadOnly = XmlUtilities.ConvertType<bool>(platesectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return platesection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnchorBolt" />.
        /// </summary>
        public static AnchorBolt ToAnchorBolt(this XElement anchorboltNode)
        {
            var anchorbolt = new AnchorBolt();
            if (anchorboltNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ID = XmlUtilities.ConvertType<Guid>(anchorboltNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Name = ToAliasedString(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.MaterialID = XmlUtilities.ConvertType<Guid>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Diameter = XmlUtilities.ConvertType<double>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Length = XmlUtilities.ConvertType<double>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ThreadMethod = (ThreadMethod)Enum.Parse(typeof(ThreadMethod), anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ThreadType = (ThreadType)Enum.Parse(typeof(ThreadType), anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadLength", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ThreadLength = XmlUtilities.ConvertType<double>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadLength", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ThreadPitch = XmlUtilities.ConvertType<double>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnchorType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.AnchorType = (AnchorType)Enum.Parse(typeof(AnchorType), anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "AnchorType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Information = ToKeyValues(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Version = XmlUtilities.ConvertType<int>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.LastChanged = XmlUtilities.ConvertType<DateTime>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorbolt.ReadOnly = XmlUtilities.ConvertType<bool>(anchorboltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return anchorbolt;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnchorBoltAssembly" />.
        /// </summary>
        public static AnchorBoltAssembly ToAnchorBoltAssembly(this XElement anchorboltassemblyNode)
        {
            var anchorboltassembly = new AnchorBoltAssembly();
            if (anchorboltassemblyNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorboltassembly.ID = XmlUtilities.ConvertType<int>(anchorboltassemblyNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorboltassembly.Name = ToAliasedString(anchorboltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnchorBoltID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorboltassembly.AnchorBoltID = XmlUtilities.ConvertType<Guid>(anchorboltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "AnchorBoltID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutIDsBasePlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NutIDsBasePlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.NutIDsBasePlateBefore.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutIDsBasePlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NutIDsBasePlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.NutIDsBasePlateBehind.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutIDsAnchorPlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NutIDsAnchorPlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.NutIDsAnchorPlateBefore.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutIDsAnchorPlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NutIDsAnchorPlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.NutIDsAnchorPlateBehind.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsBasePlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsBasePlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.WasherIDsBasePlateBefore.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsBasePlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsBasePlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.WasherIDsBasePlateBehind.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsAnchorPlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsAnchorPlateBefore", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.WasherIDsAnchorPlateBefore.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsAnchorPlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsAnchorPlateBehind", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.WasherIDsAnchorPlateBehind.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                anchorboltassembly.Information = ToKeyValues(anchorboltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (anchorboltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in anchorboltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    anchorboltassembly.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }

            return anchorboltassembly;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bolt" />.
        /// </summary>
        public static Bolt ToBolt(this XElement boltNode)
        {
            var bolt = new Bolt();
            if (boltNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ID = XmlUtilities.ConvertType<Guid>(boltNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Name = ToAliasedString(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.MaterialID = XmlUtilities.ConvertType<Guid>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Diameter = XmlUtilities.ConvertType<double>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Length = XmlUtilities.ConvertType<double>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadLength", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ThreadLength = XmlUtilities.ConvertType<double>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadLength", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "HeadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.HeadType = (BoltHeadType)Enum.Parse(typeof(BoltHeadType), boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "HeadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ThreadMethod = (ThreadMethod)Enum.Parse(typeof(ThreadMethod), boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ThreadType = (ThreadType)Enum.Parse(typeof(ThreadType), boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ThreadPitch = XmlUtilities.ConvertType<double>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Information = ToKeyValues(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Version = XmlUtilities.ConvertType<int>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.LastChanged = XmlUtilities.ConvertType<DateTime>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bolt.ReadOnly = XmlUtilities.ConvertType<bool>(boltNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return bolt;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BoltAssembly" />.
        /// </summary>
        public static BoltAssembly ToBoltAssembly(this XElement boltassemblyNode)
        {
            var boltassembly = new BoltAssembly();
            if (boltassemblyNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boltassembly.ID = XmlUtilities.ConvertType<int>(boltassemblyNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boltassembly.Name = ToAliasedString(boltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BoltID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boltassembly.BoltID = XmlUtilities.ConvertType<Guid>(boltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "BoltID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in boltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NutIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    boltassembly.NutIDs.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsBolt", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in boltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsBolt", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    boltassembly.WasherIDsBolt.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherIDsNut", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in boltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "WasherIDsNut", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    boltassembly.WasherIDsNut.Add(XmlUtilities.ConvertType<Guid>(elem.Value));
                }
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boltassembly.Information = ToKeyValues(boltassemblyNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (boltassemblyNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in boltassemblyNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    boltassembly.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }

            return boltassembly;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Connection" />.
        /// </summary>
        public static Connection ToConnection(this XElement connectionNode)
        {
            var connection = new Connection();
            if (connectionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connection.ID = XmlUtilities.ConvertType<int>(connectionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connection.Name = ToAliasedString(connectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BarIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.BarIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PolyBarIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PolyBarIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.PolyBarIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.PlateIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PadFootingIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PadFootingIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.PadFootingIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FastenerGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "FastenerGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.FastenerGroups.Add(ToFastenerGroup(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GroutFillings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "GroutFillings", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.GroutFillings.Add(ToGrout(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Welds", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Welds", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.Welds.Add(ToWeld(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionBars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionBars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.ConnectionBars.Add(ToPhysicalGeometryBar(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionPlates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionPlates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.ConnectionPlates.Add(ToSimplePlate(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Haunches", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Haunches", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.Haunches.Add(ToHaunch(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionPartItems", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionPartItems", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.ConnectionPartItems.Add(ToConnectionPartItem(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ContactSurfaces", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in connectionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ContactSurfaces", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    connection.ContactSurfaces.Add(ToContactSurface(elem));
                }
            }
            if (connectionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connection.Information = ToKeyValues(connectionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return connection;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ContactSurface" />.
        /// </summary>
        public static ContactSurface ToContactSurface(this XElement contactsurfaceNode)
        {
            var contactsurface = new ContactSurface();
            if (contactsurfaceNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.ID = XmlUtilities.ConvertType<int>(contactsurfaceNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Part1ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.Part1ID = XmlUtilities.ConvertType<int>(contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "Part1ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Part1Type", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.Part1Type = (PartType)Enum.Parse(typeof(PartType), contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "Part1Type", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Part2ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.Part2ID = XmlUtilities.ConvertType<int>(contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "Part2ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Part2Type", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.Part2Type = (PartType)Enum.Parse(typeof(PartType), contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "Part2Type", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SurfaceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.SurfaceType = (SurfaceType)Enum.Parse(typeof(SurfaceType), contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "SurfaceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FrictionCoefficient", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.FrictionCoefficient = XmlUtilities.ConvertType<double>(contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "FrictionCoefficient", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (contactsurfaceNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                contactsurface.Information = ToKeyValues(contactsurfaceNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return contactsurface;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="FastenerGroup" />.
        /// </summary>
        public static FastenerGroup ToFastenerGroup(this XElement fastenergroupNode)
        {
            var fastenergroup = new FastenerGroup();
            if (fastenergroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.ID = XmlUtilities.ConvertType<int>(fastenergroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "HoleGroupIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in fastenergroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "HoleGroupIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    fastenergroup.HoleGroupIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CoordinateSystemType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.CoordinateSystemType = (CoordinateSystemType)Enum.Parse(typeof(CoordinateSystemType), fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "CoordinateSystemType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Positions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in fastenergroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Positions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    fastenergroup.Positions.Add(ToVector2(elem));
                }
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.LocalCS = ToCoordinateSystem(fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.ReferencePoint = ToVector3(fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FastenerAssemblyType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.FastenerAssemblyType = (FastenerAssemblyType)Enum.Parse(typeof(FastenerAssemblyType), fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "FastenerAssemblyType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FastenerAssemblyID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.FastenerAssemblyID = XmlUtilities.ConvertType<int>(fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "FastenerAssemblyID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AssemblySite", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.AssemblySite = (AssemblySite)Enum.Parse(typeof(AssemblySite), fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "AssemblySite", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Preloaded", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.Preloaded = XmlUtilities.ConvertType<bool>(fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Preloaded", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (fastenergroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                fastenergroup.Information = ToKeyValues(fastenergroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return fastenergroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Grout" />.
        /// </summary>
        public static Grout ToGrout(this XElement groutNode)
        {
            var grout = new Grout();
            if (groutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Geometry", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                grout.Geometry = ToSimplePlate(groutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Geometry", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (groutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                grout.Information = ToKeyValues(groutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return grout;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Nut" />.
        /// </summary>
        public static Nut ToNut(this XElement nutNode)
        {
            var nut = new Nut();
            if (nutNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.ID = XmlUtilities.ConvertType<Guid>(nutNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.Name = ToAliasedString(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.Diameter = XmlUtilities.ConvertType<double>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.ThreadPitch = XmlUtilities.ConvertType<double>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadPitch", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.ThreadMethod = (ThreadMethod)Enum.Parse(typeof(ThreadMethod), nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.ThreadType = (ThreadType)Enum.Parse(typeof(ThreadType), nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "ThreadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.MaterialID = XmlUtilities.ConvertType<Guid>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NutType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.NutType = (NutType)Enum.Parse(typeof(NutType), nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "NutType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.Information = ToKeyValues(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.Version = XmlUtilities.ConvertType<int>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.LastChanged = XmlUtilities.ConvertType<DateTime>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nutNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nut.ReadOnly = XmlUtilities.ConvertType<bool>(nutNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return nut;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Washer" />.
        /// </summary>
        public static Washer ToWasher(this XElement washerNode)
        {
            var washer = new Washer();
            if (washerNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.ID = XmlUtilities.ConvertType<Guid>(washerNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.Name = ToAliasedString(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.Diameter = XmlUtilities.ConvertType<double>(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Diameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.MaterialID = XmlUtilities.ConvertType<Guid>(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WasherType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.WasherType = (WasherType)Enum.Parse(typeof(WasherType), washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "WasherType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.Information = ToKeyValues(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.Version = XmlUtilities.ConvertType<int>(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.LastChanged = XmlUtilities.ConvertType<DateTime>(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (washerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                washer.ReadOnly = XmlUtilities.ConvertType<bool>(washerNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return washer;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Weld" />.
        /// </summary>
        public static Weld ToWeld(this XElement weldNode)
        {
            var weld = new Weld();
            if (weldNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.ID = XmlUtilities.ConvertType<int>(weldNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.Name = ToAliasedString(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ElectrodeType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.ElectrodeType = XmlUtilities.ConvertType<string>(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "ElectrodeType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Path3D", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in weldNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Path3D", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    weld.Path3D.Add(ToPolylineVertex(elem));
                }
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MainPartID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.MainPartID = XmlUtilities.ConvertType<int>(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "MainPartID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MainPartType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.MainPartType = (PartType)Enum.Parse(typeof(PartType), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "MainPartType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SecPartID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.SecPartID = XmlUtilities.ConvertType<int>(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "SecPartID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SecPartType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.SecPartType = (PartType)Enum.Parse(typeof(PartType), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "SecPartType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AroundWeld", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.AroundWeld = XmlUtilities.ConvertType<bool>(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "AroundWeld", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WeldingSite", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.WeldingSite = (AssemblySite)Enum.Parse(typeof(AssemblySite), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "WeldingSite", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WeldProcess", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.WeldProcess = (WeldProcess)Enum.Parse(typeof(WeldProcess), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "WeldProcess", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PreparationType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.PreparationType = (PreparationType)Enum.Parse(typeof(PreparationType), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "PreparationType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WeldType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.WeldType = (WeldType)Enum.Parse(typeof(WeldType), weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "WeldType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (weldNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                weld.Information = ToKeyValues(weldNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return weld;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Haunch" />.
        /// </summary>
        public static Haunch ToHaunch(this XElement haunchNode)
        {
            var haunch = new Haunch();
            if (haunchNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                haunch.ID = XmlUtilities.ConvertType<int>(haunchNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (haunchNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionBarIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in haunchNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionBarIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    haunch.ConnectionBarIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (haunchNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionPlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in haunchNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionPlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    haunch.ConnectionPlateIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return haunch;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ConnectionPartItem" />.
        /// </summary>
        public static ConnectionPartItem ToConnectionPartItem(this XElement connectionpartitemNode)
        {
            var connectionpartitem = new ConnectionPartItem();
            if (connectionpartitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PartID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connectionpartitem.PartID = XmlUtilities.ConvertType<int>(connectionpartitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "PartID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (connectionpartitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PartType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connectionpartitem.PartType = (PartType)Enum.Parse(typeof(PartType), connectionpartitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "PartType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (connectionpartitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                connectionpartitem.Modifiers = ToPartModifiers(connectionpartitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return connectionpartitem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Information" />.
        /// </summary>
        public static Information ToInformation(this XElement informationNode)
        {
            var information = new Information();

            return information;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.Eccentricity" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.Eccentricity ToEccentricity(this XElement eccentricityNode)
        {
            var eccentricity = new BuildSoft.UBSM.Physical.Geometry.Eccentricity();
            if (eccentricityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                eccentricity.GlobalOffset = ToVector3(eccentricityNode.Elements().First(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (eccentricityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                eccentricity.LocalOffset = ToVector3(eccentricityNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalOffset", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return eccentricity;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.BarPosition" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.BarPosition ToBarPosition(this XElement barpositionNode)
        {
            var barposition = new BuildSoft.UBSM.Physical.Geometry.BarPosition();
            if (barpositionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barposition.Location = ToVector3(barpositionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barpositionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barposition.Eccentricity = ToEccentricity(barpositionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return barposition;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.Chamfer" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.Chamfer ToChamfer(this XElement chamferNode)
        {
            var chamfer = new BuildSoft.UBSM.Physical.Geometry.Chamfer();
            if (chamferNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ChamferType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                chamfer.ChamferType = (BuildSoft.UBSM.Physical.Geometry.ChamferType)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.ChamferType), chamferNode.Elements().First(x => string.Compare(x.Name.ToString(), "ChamferType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (chamferNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MainDimension", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                chamfer.MainDimension = XmlUtilities.ConvertType<double>(chamferNode.Elements().First(x => string.Compare(x.Name.ToString(), "MainDimension", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (chamferNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SecondaryDimension", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                chamfer.SecondaryDimension = XmlUtilities.ConvertType<double>(chamferNode.Elements().First(x => string.Compare(x.Name.ToString(), "SecondaryDimension", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return chamfer;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PolylineVertex" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PolylineVertex ToPolylineVertex(this XElement polylinevertexNode)
        {
            var polylinevertex = new BuildSoft.UBSM.Physical.Geometry.PolylineVertex();
            if (polylinevertexNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polylinevertex.Location = ToVector3(polylinevertexNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polylinevertexNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polylinevertex.GlobalOffset = ToVector3(polylinevertexNode.Elements().First(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polylinevertexNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Chamfer", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polylinevertex.Chamfer = ToChamfer(polylinevertexNode.Elements().First(x => string.Compare(x.Name.ToString(), "Chamfer", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return polylinevertex;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PolygonVertex" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PolygonVertex ToPolygonVertex(this XElement polygonvertexNode)
        {
            var polygonvertex = new BuildSoft.UBSM.Physical.Geometry.PolygonVertex();
            if (polygonvertexNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polygonvertex.Location = ToVector2(polygonvertexNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polygonvertexNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Chamfer", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polygonvertex.Chamfer = ToChamfer(polygonvertexNode.Elements().First(x => string.Compare(x.Name.ToString(), "Chamfer", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return polygonvertex;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.BarDirectrix" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.BarDirectrix ToBarDirectrix(this XElement bardirectrixNode)
        {
            var bardirectrix = new BuildSoft.UBSM.Physical.Geometry.BarDirectrix();
            if (bardirectrixNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DirectrixType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bardirectrix.DirectrixType = (BuildSoft.UBSM.Physical.Geometry.BarDirectrixType)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.BarDirectrixType), bardirectrixNode.Elements().First(x => string.Compare(x.Name.ToString(), "DirectrixType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (bardirectrixNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RadiusOfCurvature", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bardirectrix.RadiusOfCurvature = XmlUtilities.ConvertType<double>(bardirectrixNode.Elements().First(x => string.Compare(x.Name.ToString(), "RadiusOfCurvature", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return bardirectrix;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bar" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.Bar ToPhysicalGeometryBar(this XElement barNode)
        {
            var bar = new BuildSoft.UBSM.Physical.Geometry.Bar();
            if (barNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.ID = XmlUtilities.ConvertType<int>(barNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Name = ToAliasedString(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Begin = ToBarPosition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.End = ToBarPosition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.CardinalPoint = (BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint), barNode.Elements().First(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Directrix", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Directrix = ToBarDirectrix(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Directrix", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.LocalCS = ToCoordinateSystem(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SectionID = XmlUtilities.ConvertType<Guid>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in barNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    bar.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SectionMirroredAroundZAxis = XmlUtilities.ConvertType<bool>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Modifiers = ToPartModifiers(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.AdditionalParameters = ToKeyValues(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return bar;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PolyBar" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PolyBar ToPolyBar(this XElement polybarNode)
        {
            var polybar = new BuildSoft.UBSM.Physical.Geometry.PolyBar();
            if (polybarNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.ID = XmlUtilities.ConvertType<int>(polybarNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.Name = ToAliasedString(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.Begin = ToBarPosition(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.End = ToBarPosition(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.CardinalPoint = (BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint), polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "InnerVertices", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in polybarNode.Elements().Where(x => string.Compare(x.Name.ToString(), "InnerVertices", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    polybar.InnerVertices.Add(ToPolylineVertex(elem));
                }
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCSs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in polybarNode.Elements().Where(x => string.Compare(x.Name.ToString(), "LocalCSs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    polybar.LocalCSs.Add(ToCoordinateSystem(elem));
                }
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.SectionID = XmlUtilities.ConvertType<Guid>(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.SectionMirroredAroundZAxis = XmlUtilities.ConvertType<bool>(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in polybarNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    polybar.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.Modifiers = ToPartModifiers(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polybarNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polybar.AdditionalParameters = ToKeyValues(polybarNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return polybar;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Polygon" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.Polygon ToPhysicalGeometryPolygon(this XElement polygonNode)
        {
            var polygon = new BuildSoft.UBSM.Physical.Geometry.Polygon();
            if (polygonNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsCircle", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polygon.IsCircle = XmlUtilities.ConvertType<bool>(polygonNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsCircle", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polygonNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CircleCentre", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polygon.CircleCentre = ToVector2(polygonNode.Elements().First(x => string.Compare(x.Name.ToString(), "CircleCentre", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (polygonNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CircleDiameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                polygon.CircleDiameter = XmlUtilities.ConvertType<double>(polygonNode.Elements().First(x => string.Compare(x.Name.ToString(), "CircleDiameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (polygonNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in polygonNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    polygon.Vertices.Add(ToPolygonVertex(elem));
                }
            }

            return polygon;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Plate" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.Plate ToPhysicalGeometryPlate(this XElement plateNode)
        {
            var plate = new BuildSoft.UBSM.Physical.Geometry.Plate();
            if (plateNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.ID = XmlUtilities.ConvertType<int>(plateNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Name = ToAliasedString(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OuterPolygon", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.OuterPolygon = ToPhysicalGeometryPolygon(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "OuterPolygon", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BoundingBoxAnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.BoundingBoxAnchorPlane = (BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane), plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "BoundingBoxAnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BoundingBoxOffsetY", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.BoundingBoxOffsetY = XmlUtilities.ConvertType<double>(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "BoundingBoxOffsetY", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Eccentricity = ToEccentricity(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CutOutPolygons", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plateNode.Elements().Where(x => string.Compare(x.Name.ToString(), "CutOutPolygons", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plate.CutOutPolygons.Add(ToPhysicalGeometryPolygon(elem));
                }
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.LocalCS = ToCoordinateSystem(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.ReferencePoint = ToVector3(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.SectionID = XmlUtilities.ConvertType<Guid>(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plateNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plate.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.AdditionalParameters = ToKeyValues(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return plate;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PadFootingPart" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PadFootingPart ToPadFootingPart(this XElement padfootingpartNode)
        {
            var padfootingpart = new BuildSoft.UBSM.Physical.Geometry.PadFootingPart();
            if (padfootingpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfootingpart.SectionID = XmlUtilities.ConvertType<Guid>(padfootingpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (padfootingpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfootingpart.SectionMirroredAroundZAxis = XmlUtilities.ConvertType<bool>(padfootingpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (padfootingpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in padfootingpartNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    padfootingpart.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (padfootingpartNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Height", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfootingpart.Height = XmlUtilities.ConvertType<double>(padfootingpartNode.Elements().First(x => string.Compare(x.Name.ToString(), "Height", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return padfootingpart;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PadFooting" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PadFooting ToPadFooting(this XElement padfootingNode)
        {
            var padfooting = new BuildSoft.UBSM.Physical.Geometry.PadFooting();
            if (padfootingNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.ID = XmlUtilities.ConvertType<int>(padfootingNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.Name = ToAliasedString(padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePointPosition", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.ReferencePointPosition = ToBarPosition(padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePointPosition", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.LocalCS = ToCoordinateSystem(padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PadFootingType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.PadFootingType = (BuildSoft.UBSM.Physical.Geometry.PadFootingType)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.PadFootingType), padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "PadFootingType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Parts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in padfootingNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Parts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    padfooting.Parts.Add(ToPadFootingPart(elem));
                }
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.CardinalPoint = (BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.BarCardinalPoint), padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (padfootingNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                padfooting.AdditionalParameters = ToKeyValues(padfootingNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return padfooting;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.SimplePlate" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.SimplePlate ToSimplePlate(this XElement simpleplateNode)
        {
            var simpleplate = new BuildSoft.UBSM.Physical.Geometry.SimplePlate();
            if (simpleplateNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.ID = XmlUtilities.ConvertType<int>(simpleplateNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.Name = ToAliasedString(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OuterPolygon", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.OuterPolygon = ToPhysicalGeometryPolygon(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "OuterPolygon", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.AnchorPlane = (BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.PlateAnchorPlane), simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "AnchorPlane", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OffsetY", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.OffsetY = XmlUtilities.ConvertType<double>(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "OffsetY", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.Eccentricity = ToEccentricity(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Eccentricity", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.LocalCS = ToCoordinateSystem(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.ReferencePoint = ToVector3(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.Thickness = XmlUtilities.ConvertType<double>(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.MaterialID = XmlUtilities.ConvertType<Guid>(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (simpleplateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                simpleplate.Modifiers = ToPartModifiers(simpleplateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Modifiers", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return simpleplate;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PlaneModifier" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PlaneModifier ToPlaneModifier(this XElement planemodifierNode)
        {
            var planemodifier = new BuildSoft.UBSM.Physical.Geometry.PlaneModifier();
            if (planemodifierNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlaneModifierType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                planemodifier.PlaneModifierType = (BuildSoft.UBSM.Physical.Geometry.PlaneModifierType)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.PlaneModifierType), planemodifierNode.Elements().First(x => string.Compare(x.Name.ToString(), "PlaneModifierType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (planemodifierNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                planemodifier.LocalCS = ToCoordinateSystem(planemodifierNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (planemodifierNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                planemodifier.ReferencePoint = ToVector3(planemodifierNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return planemodifier;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.PartModifiers" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.PartModifiers ToPartModifiers(this XElement partmodifiersNode)
        {
            var partmodifiers = new BuildSoft.UBSM.Physical.Geometry.PartModifiers();
            if (partmodifiersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlaneModifiers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in partmodifiersNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PlaneModifiers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    partmodifiers.PlaneModifiers.Add(ToPlaneModifier(elem));
                }
            }
            if (partmodifiersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ContourCuts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in partmodifiersNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ContourCuts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    partmodifiers.ContourCuts.Add(ToSimplePlate(elem));
                }
            }
            if (partmodifiersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "HoleGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in partmodifiersNode.Elements().Where(x => string.Compare(x.Name.ToString(), "HoleGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    partmodifiers.HoleGroups.Add(ToHoleGroup(elem));
                }
            }

            return partmodifiers;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Physical.Geometry.HoleGroup" />.
        /// </summary>
        public static BuildSoft.UBSM.Physical.Geometry.HoleGroup ToHoleGroup(this XElement holegroupNode)
        {
            var holegroup = new BuildSoft.UBSM.Physical.Geometry.HoleGroup();
            if (holegroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.ID = XmlUtilities.ConvertType<int>(holegroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CoordinateSystemType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.CoordinateSystemType = (CoordinateSystemType)Enum.Parse(typeof(CoordinateSystemType), holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "CoordinateSystemType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Positions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in holegroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Positions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    holegroup.Positions.Add(ToVector2(elem));
                }
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.LocalCS = ToCoordinateSystem(holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.ReferencePoint = ToVector3(holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "HoleType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.HoleType = (BuildSoft.UBSM.Physical.Geometry.HoleType)Enum.Parse(typeof(BuildSoft.UBSM.Physical.Geometry.HoleType), holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "HoleType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "HoleDiameter", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.HoleDiameter = XmlUtilities.ConvertType<double>(holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "HoleDiameter", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (holegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                holegroup.Information = ToKeyValues(holegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Information", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return holegroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Vector2" />.
        /// </summary>
        public static Vector2 ToVector2(this XElement vector2Node)
        {
            var vector2 = new Vector2();
            if (vector2Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                vector2.X = XmlUtilities.ConvertType<double>(vector2Node.Attributes().First(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (vector2Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                vector2.Y = XmlUtilities.ConvertType<double>(vector2Node.Attributes().First(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return vector2;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Vector3" />.
        /// </summary>
        public static Vector3 ToVector3(this XElement vector3Node)
        {
            var vector3 = new Vector3();
            if (vector3Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                vector3.X = XmlUtilities.ConvertType<double>(vector3Node.Attributes().First(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (vector3Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                vector3.Y = XmlUtilities.ConvertType<double>(vector3Node.Attributes().First(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (vector3Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "Z", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                vector3.Z = XmlUtilities.ConvertType<double>(vector3Node.Attributes().First(x => string.Compare(x.Name.ToString(), "Z", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return vector3;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CoordinateSystem" />.
        /// </summary>
        public static CoordinateSystem ToCoordinateSystem(this XElement coordinatesystemNode)
        {
            var coordinatesystem = new CoordinateSystem();
            if (coordinatesystemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                coordinatesystem.X = ToVector3(coordinatesystemNode.Elements().First(x => string.Compare(x.Name.ToString(), "X", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (coordinatesystemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                coordinatesystem.Y = ToVector3(coordinatesystemNode.Elements().First(x => string.Compare(x.Name.ToString(), "Y", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (coordinatesystemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Z", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                coordinatesystem.Z = ToVector3(coordinatesystemNode.Elements().First(x => string.Compare(x.Name.ToString(), "Z", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return coordinatesystem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Matrix2x2" />.
        /// </summary>
        public static Matrix2x2 ToMatrix2x2(this XElement matrix2X2Node)
        {
            var matrix2X2 = new Matrix2x2();
            if (matrix2X2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell11", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix2X2.Cell11 = XmlUtilities.ConvertType<double>(matrix2X2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell11", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix2X2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix2X2.Cell12 = XmlUtilities.ConvertType<double>(matrix2X2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix2X2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell21", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix2X2.Cell21 = XmlUtilities.ConvertType<double>(matrix2X2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell21", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix2X2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell22", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix2X2.Cell22 = XmlUtilities.ConvertType<double>(matrix2X2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell22", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return matrix2X2;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Matrix3x3" />.
        /// </summary>
        public static Matrix3x3 ToMatrix3x3(this XElement matrix3X3Node)
        {
            var matrix3X3 = new Matrix3x3();
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell11", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell11 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell11", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell12 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell13", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell13 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell13", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell21", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell21 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell21", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell22", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell22 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell22", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell23", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell23 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell23", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell31", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell31 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell31", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell32", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell32 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell32", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (matrix3X3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Cell33", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                matrix3X3.Cell33 = XmlUtilities.ConvertType<double>(matrix3X3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Cell33", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return matrix3X3;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle2D" />.
        /// </summary>
        public static Triangle2D ToTriangle2D(this XElement triangle2dNode)
        {
            var triangle2d = new Triangle2D();
            if (triangle2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle2d.P1 = ToVector2(triangle2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (triangle2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle2d.P2 = ToVector2(triangle2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (triangle2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle2d.P3 = ToVector2(triangle2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return triangle2d;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle3D" />.
        /// </summary>
        public static Triangle3D ToTriangle3D(this XElement triangle3dNode)
        {
            var triangle3d = new Triangle3D();
            if (triangle3dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3d.P1 = ToVector3(triangle3dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (triangle3dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3d.P2 = ToVector3(triangle3dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (triangle3dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3d.P3 = ToVector3(triangle3dNode.Elements().First(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return triangle3d;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="MultiLinear" />.
        /// </summary>
        public static MultiLinear ToMultiLinear(this XElement multilinearNode)
        {
            var multilinear = new MultiLinear();
            if (multilinearNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                multilinear.Name = ToAliasedString(multilinearNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (multilinearNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DataPoints", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in multilinearNode.Elements().Where(x => string.Compare(x.Name.ToString(), "DataPoints", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    multilinear.DataPoints.Add(ToVector2(elem));
                }
            }

            return multilinear;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BezierCurve2D" />.
        /// </summary>
        public static BezierCurve2D ToBezierCurve2D(this XElement beziercurve2dNode)
        {
            var beziercurve2d = new BezierCurve2D();
            if (beziercurve2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                beziercurve2d.BeginPoint = ToVector2(beziercurve2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginPoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (beziercurve2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginControlPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                beziercurve2d.BeginControlPoint = ToVector2(beziercurve2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginControlPoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (beziercurve2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndControlPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                beziercurve2d.EndControlPoint = ToVector2(beziercurve2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "EndControlPoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (beziercurve2dNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                beziercurve2d.EndPoint = ToVector2(beziercurve2dNode.Elements().First(x => string.Compare(x.Name.ToString(), "EndPoint", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return beziercurve2d;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyStringValue" />.
        /// </summary>
        public static KeyStringValue ToKeyStringValue(this XElement keystringvalueNode)
        {
            var keystringvalue = new KeyStringValue();
            if (keystringvalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keystringvalue.Key = XmlUtilities.ConvertType<string>(keystringvalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (keystringvalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keystringvalue.Value = XmlUtilities.ConvertType<string>(keystringvalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return keystringvalue;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyDoubleValue" />.
        /// </summary>
        public static KeyDoubleValue ToKeyDoubleValue(this XElement keydoublevalueNode)
        {
            var keydoublevalue = new KeyDoubleValue();
            if (keydoublevalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keydoublevalue.Key = XmlUtilities.ConvertType<string>(keydoublevalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (keydoublevalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keydoublevalue.Value = XmlUtilities.ConvertType<double>(keydoublevalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return keydoublevalue;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyBoolValue" />.
        /// </summary>
        public static KeyBoolValue ToKeyBoolValue(this XElement keyboolvalueNode)
        {
            var keyboolvalue = new KeyBoolValue();
            if (keyboolvalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keyboolvalue.Key = XmlUtilities.ConvertType<string>(keyboolvalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (keyboolvalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keyboolvalue.Value = XmlUtilities.ConvertType<bool>(keyboolvalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return keyboolvalue;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AliasedString" />.
        /// </summary>
        public static AliasedString ToAliasedString(this XElement aliasedstringNode)
        {
            var aliasedstring = new AliasedString();
            if (aliasedstringNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Default", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                aliasedstring.Default = XmlUtilities.ConvertType<string>(aliasedstringNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Default", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (aliasedstringNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Aliases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in aliasedstringNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Aliases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    aliasedstring.Aliases.Add(ToKeyStringValue(elem));
                }
            }

            return aliasedstring;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyIntegerValue" />.
        /// </summary>
        public static KeyIntegerValue ToKeyIntegerValue(this XElement keyintegervalueNode)
        {
            var keyintegervalue = new KeyIntegerValue();
            if (keyintegervalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keyintegervalue.Key = XmlUtilities.ConvertType<string>(keyintegervalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (keyintegervalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                keyintegervalue.Value = XmlUtilities.ConvertType<int>(keyintegervalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return keyintegervalue;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="GuidMapItem" />.
        /// </summary>
        public static GuidMapItem ToGuidMapItem(this XElement guidmapitemNode)
        {
            var guidmapitem = new GuidMapItem();
            if (guidmapitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BaseID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                guidmapitem.BaseID = XmlUtilities.ConvertType<Guid>(guidmapitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "BaseID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (guidmapitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReplacedWith", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                guidmapitem.ReplacedWith = XmlUtilities.ConvertType<Guid>(guidmapitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReplacedWith", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return guidmapitem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyValues" />.
        /// </summary>
        public static KeyValues ToKeyValues(this XElement keyvaluesNode)
        {
            var keyvalues = new KeyValues();
            if (keyvaluesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DoubleValues", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in keyvaluesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "DoubleValues", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    keyvalues.DoubleValues.Add(ToKeyDoubleValue(elem));
                }
            }
            if (keyvaluesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IntegerValues", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in keyvaluesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "IntegerValues", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    keyvalues.IntegerValues.Add(ToKeyIntegerValue(elem));
                }
            }
            if (keyvaluesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "StringValues", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in keyvaluesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "StringValues", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    keyvalues.StringValues.Add(ToKeyStringValue(elem));
                }
            }
            if (keyvaluesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BoolValues", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in keyvaluesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BoolValues", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    keyvalues.BoolValues.Add(ToKeyBoolValue(elem));
                }
            }

            return keyvalues;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Tag" />.
        /// </summary>
        public static Tag ToTag(this XElement tagNode)
        {
            var tag = new Tag();
            if (tagNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                tag.ID = XmlUtilities.ConvertType<Guid>(tagNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (tagNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                tag.Name = ToAliasedString(tagNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return tag;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Function" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Function ToFunction(this XElement functionNode)
        {
            var function = new BuildSoft.UBSM.Analysis.Function();
            if (functionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                function.ID = XmlUtilities.ConvertType<int>(functionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (functionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "InterpolationMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                function.InterpolationMethod = (Interpolation)Enum.Parse(typeof(Interpolation), functionNode.Elements().First(x => string.Compare(x.Name.ToString(), "InterpolationMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (functionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuantityX", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                function.QuantityX = (Quantity)Enum.Parse(typeof(Quantity), functionNode.Elements().First(x => string.Compare(x.Name.ToString(), "QuantityX", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (functionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuantityY", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                function.QuantityY = (Quantity)Enum.Parse(typeof(Quantity), functionNode.Elements().First(x => string.Compare(x.Name.ToString(), "QuantityY", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (functionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                function.Points = ToMultiLinear(functionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return function;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyFunction" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.PropertyFunction ToPropertyFunction(this XElement propertyfunctionNode)
        {
            var propertyfunction = new BuildSoft.UBSM.Analysis.PropertyFunction();
            if (propertyfunctionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyfunction.ID = XmlUtilities.ConvertType<int>(propertyfunctionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyfunctionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "InterpolationMethod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyfunction.InterpolationMethod = (Interpolation)Enum.Parse(typeof(Interpolation), propertyfunctionNode.Elements().First(x => string.Compare(x.Name.ToString(), "InterpolationMethod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyfunctionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyfunction.Key = XmlUtilities.ConvertType<string>(propertyfunctionNode.Elements().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyfunctionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in propertyfunctionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    propertyfunction.Points.Add(ToVector2(elem));
                }
            }

            return propertyfunction;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.MaterialProperties" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.MaterialProperties ToMaterialProperties(this XElement materialpropertiesNode)
        {
            var materialproperties = new BuildSoft.UBSM.Analysis.MaterialProperties();
            if (materialpropertiesNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialproperties.ID = XmlUtilities.ConvertType<int>(materialpropertiesNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialproperties.MaterialID = XmlUtilities.ConvertType<Guid>(materialpropertiesNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsFireCoating", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialproperties.IsFireCoating = XmlUtilities.ConvertType<bool>(materialpropertiesNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsFireCoating", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsStructural", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialproperties.IsStructural = XmlUtilities.ConvertType<bool>(materialpropertiesNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsStructural", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PropertyGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in materialpropertiesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PropertyGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    materialproperties.PropertyGroups.Add(ToMaterialPropertyGroup(elem));
                }
            }

            return materialproperties;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.MaterialPropertyGroup" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.MaterialPropertyGroup ToMaterialPropertyGroup(this XElement materialpropertygroupNode)
        {
            var materialpropertygroup = new BuildSoft.UBSM.Analysis.MaterialPropertyGroup();
            if (materialpropertygroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialpropertygroup.ID = XmlUtilities.ConvertType<int>(materialpropertygroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialpropertygroup.Standard = (Standards)Enum.Parse(typeof(Standards), materialpropertygroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "UserDefined", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                materialpropertygroup.UserDefined = XmlUtilities.ConvertType<bool>(materialpropertygroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "UserDefined", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in materialpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    materialpropertygroup.Values.Add(ToPropertyValue(elem));
                }
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Flags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in materialpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Flags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    materialpropertygroup.Flags.Add(ToPropertyFlag(elem));
                }
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Texts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in materialpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Texts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    materialpropertygroup.Texts.Add(ToPropertyText(elem));
                }
            }
            if (materialpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in materialpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    materialpropertygroup.Functions.Add(ToPropertyFunction(elem));
                }
            }

            return materialpropertygroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.SectionPropertyGroup" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.SectionPropertyGroup ToSectionPropertyGroup(this XElement sectionpropertygroupNode)
        {
            var sectionpropertygroup = new BuildSoft.UBSM.Analysis.SectionPropertyGroup();
            if (sectionpropertygroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionpropertygroup.ID = XmlUtilities.ConvertType<int>(sectionpropertygroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionpropertygroup.Standard = (Standards)Enum.Parse(typeof(Standards), sectionpropertygroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionpropertygroup.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Description", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionpropertygroup.Description = ToAliasedString(sectionpropertygroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Description", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "UserDefined", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionpropertygroup.UserDefined = XmlUtilities.ConvertType<bool>(sectionpropertygroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "UserDefined", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionpropertygroup.Values.Add(ToPropertyValue(elem));
                }
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Flags", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Flags", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionpropertygroup.Flags.Add(ToPropertyFlag(elem));
                }
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Texts", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Texts", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionpropertygroup.Texts.Add(ToPropertyText(elem));
                }
            }
            if (sectionpropertygroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertygroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionpropertygroup.Functions.Add(ToPropertyFunction(elem));
                }
            }

            return sectionpropertygroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyValue" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.PropertyValue ToPropertyValue(this XElement propertyvalueNode)
        {
            var propertyvalue = new BuildSoft.UBSM.Analysis.PropertyValue();
            if (propertyvalueNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyvalue.ID = XmlUtilities.ConvertType<int>(propertyvalueNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyvalueNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyvalue.Key = XmlUtilities.ConvertType<string>(propertyvalueNode.Elements().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyvalueNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyvalue.Value = XmlUtilities.ConvertType<double>(propertyvalueNode.Elements().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return propertyvalue;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyText" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.PropertyText ToPropertyText(this XElement propertytextNode)
        {
            var propertytext = new BuildSoft.UBSM.Analysis.PropertyText();
            if (propertytextNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertytext.ID = XmlUtilities.ConvertType<int>(propertytextNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertytextNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertytext.Key = XmlUtilities.ConvertType<string>(propertytextNode.Elements().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertytextNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertytext.Value = XmlUtilities.ConvertType<string>(propertytextNode.Elements().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return propertytext;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyFlag" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.PropertyFlag ToPropertyFlag(this XElement propertyflagNode)
        {
            var propertyflag = new BuildSoft.UBSM.Analysis.PropertyFlag();
            if (propertyflagNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyflag.ID = XmlUtilities.ConvertType<int>(propertyflagNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyflagNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyflag.Key = XmlUtilities.ConvertType<string>(propertyflagNode.Elements().First(x => string.Compare(x.Name.ToString(), "Key", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (propertyflagNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                propertyflag.Value = XmlUtilities.ConvertType<bool>(propertyflagNode.Elements().First(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return propertyflag;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Settings ToAnalysisSettings(this XElement settingsNode)
        {
            var settings = new BuildSoft.UBSM.Analysis.Settings();
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "General", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                settings.General = ToKeyValues(settingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "General", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "StandardChecks", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in settingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "StandardChecks", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    settings.StandardChecks.Add(ToStandardCheck(elem));
                }
            }

            return settings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.StandardCheck" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.StandardCheck ToStandardCheck(this XElement standardcheckNode)
        {
            var standardcheck = new BuildSoft.UBSM.Analysis.StandardCheck();
            if (standardcheckNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                standardcheck.Standard = (Standards)Enum.Parse(typeof(Standards), standardcheckNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (standardcheckNode.Elements().Any(x => string.Compare(x.Name.ToString(), "General", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                standardcheck.General = ToKeyValues(standardcheckNode.Elements().First(x => string.Compare(x.Name.ToString(), "General", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (standardcheckNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in standardcheckNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    standardcheck.Bars.Add(ToElementSettings(elem));
                }
            }
            if (standardcheckNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in standardcheckNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    standardcheck.Plates.Add(ToElementSettings(elem));
                }
            }

            return standardcheck;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Model" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Model ToAnalysisModel(this XElement modelNode)
        {
            var model = new BuildSoft.UBSM.Analysis.Model();
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.Name = ToAliasedString(modelNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (modelNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.ID = XmlUtilities.ConvertType<Guid>(modelNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Functions", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Functions.Add(ToFunction(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SoilProfiles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SoilProfiles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.SoilProfiles.Add(ToSoilProfile(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialProperties", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialProperties", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.MaterialProperties.Add(ToMaterialProperties(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionProperties", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SectionProperties", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.SectionProperties.Add(ToSectionProperties(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Points.Add(ToPoint(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Bars", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Bars.Add(ToAnalysisGeometryBar(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Plates", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Plates.Add(ToAnalysisGeometryPlate(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BarGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.BarGroups.Add(ToBarGroup(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlateGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PlateGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.PlateGroups.Add(ToPlateGroup(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Loads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.Loads = ToModelLoads(modelNode.Elements().First(x => string.Compare(x.Name.ToString(), "Loads", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GeometryMeshes", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "GeometryMeshes", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.GeometryMeshes.Add(ToGeometryMesh(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionMeshes", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SectionMeshes", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.SectionMeshes.Add(ToSectionMesh(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Results", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Results", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.Results.Add(ToResultSet(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConnectionsVerification", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ConnectionsVerification", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.ConnectionsVerification.Add(ToItemVerification(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MeshSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MeshSettings", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    model.MeshSettings.Add(ToAnalysisMeshSettings(elem));
                }
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AnalysisSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.AnalysisSettings = ToAnalysisSettings(modelNode.Elements().First(x => string.Compare(x.Name.ToString(), "AnalysisSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (modelNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FireSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                model.FireSettings = ToAnalysisFireSettings(modelNode.Elements().First(x => string.Compare(x.Name.ToString(), "FireSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return model;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.SectionProperties" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.SectionProperties ToSectionProperties(this XElement sectionpropertiesNode)
        {
            var sectionproperties = new BuildSoft.UBSM.Analysis.SectionProperties();
            if (sectionpropertiesNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionproperties.ID = XmlUtilities.ConvertType<int>(sectionpropertiesNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionproperties.SectionID = XmlUtilities.ConvertType<Guid>(sectionpropertiesNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionpropertiesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PropertyGroups", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionpropertiesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PropertyGroups", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionproperties.PropertyGroups.Add(ToSectionPropertyGroup(elem));
                }
            }

            return sectionproperties;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.ElementSettings" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.ElementSettings ToElementSettings(this XElement elementsettingsNode)
        {
            var elementsettings = new BuildSoft.UBSM.Analysis.ElementSettings();
            if (elementsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementsettings.ReferenceID = XmlUtilities.ConvertType<int>(elementsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementsettings.Values = ToKeyValues(elementsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return elementsettings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static Settings ToAnalysisFireSettings(this XElement settingsNode)
        {
            var settings = new Settings();
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PredefinedFireConfigurations", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in settingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PredefinedFireConfigurations", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    settings.PredefinedFireConfigurations.Add(ToPredefinedFireConfiguration(elem));
                }
            }
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomFireConfigurations", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in settingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "CustomFireConfigurations", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    settings.CustomFireConfigurations.Add(ToCustomFireConfiguration(elem));
                }
            }
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarFireInformations", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in settingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BarFireInformations", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    settings.BarFireInformations.Add(ToBarFireInfo(elem));
                }
            }

            return settings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PredefinedFireConfiguration" />.
        /// </summary>
        public static PredefinedFireConfiguration ToPredefinedFireConfiguration(this XElement predefinedfireconfigurationNode)
        {
            var predefinedfireconfiguration = new PredefinedFireConfiguration();
            if (predefinedfireconfigurationNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                predefinedfireconfiguration.ID = XmlUtilities.ConvertType<int>(predefinedfireconfigurationNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (predefinedfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ProtectionType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                predefinedfireconfiguration.ProtectionType = (FireProtectionType)Enum.Parse(typeof(FireProtectionType), predefinedfireconfigurationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ProtectionType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (predefinedfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                predefinedfireconfiguration.Thickness = XmlUtilities.ConvertType<double>(predefinedfireconfigurationNode.Elements().First(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (predefinedfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                predefinedfireconfiguration.MaterialID = XmlUtilities.ConvertType<Guid>(predefinedfireconfigurationNode.Elements().First(x => string.Compare(x.Name.ToString(), "MaterialID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return predefinedfireconfiguration;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="FireExposureZone" />.
        /// </summary>
        public static FireExposureZone ToFireExposureZone(this XElement fireexposurezoneNode)
        {
            var fireexposurezone = new FireExposureZone();
            if (fireexposurezoneNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in fireexposurezoneNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    fireexposurezone.Vertices.Add(ToVector2(elem));
                }
            }

            return fireexposurezone;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomFireConfiguration" />.
        /// </summary>
        public static CustomFireConfiguration ToCustomFireConfiguration(this XElement customfireconfigurationNode)
        {
            var customfireconfiguration = new CustomFireConfiguration();
            if (customfireconfigurationNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customfireconfiguration.ID = XmlUtilities.ConvertType<int>(customfireconfigurationNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FireExposureZones", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customfireconfigurationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "FireExposureZones", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customfireconfiguration.FireExposureZones.Add(ToFireExposureZone(elem));
                }
            }
            if (customfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdiabaticLines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customfireconfigurationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "AdiabaticLines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customfireconfiguration.AdiabaticLines.Add(ToBezierCurve2D(elem));
                }
            }
            if (customfireconfigurationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomFireSection", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customfireconfiguration.CustomFireSection = XmlUtilities.ConvertType<Guid>(customfireconfigurationNode.Elements().First(x => string.Compare(x.Name.ToString(), "CustomFireSection", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return customfireconfiguration;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarFireInfo" />.
        /// </summary>
        public static BarFireInfo ToBarFireInfo(this XElement barfireinfoNode)
        {
            var barfireinfo = new BarFireInfo();
            if (barfireinfoNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barfireinfo.BarID = XmlUtilities.ConvertType<int>(barfireinfoNode.Elements().First(x => string.Compare(x.Name.ToString(), "BarID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barfireinfoNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FireExposureCurve", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barfireinfo.FireExposureCurve = (FireExposureCurveType)Enum.Parse(typeof(FireExposureCurveType), barfireinfoNode.Elements().First(x => string.Compare(x.Name.ToString(), "FireExposureCurve", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barfireinfoNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomFireCurveID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barfireinfo.CustomFireCurveID = XmlUtilities.ConvertType<int>(barfireinfoNode.Elements().First(x => string.Compare(x.Name.ToString(), "CustomFireCurveID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barfireinfoNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FireExposureTime", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barfireinfo.FireExposureTime = XmlUtilities.ConvertType<double>(barfireinfoNode.Elements().First(x => string.Compare(x.Name.ToString(), "FireExposureTime", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barfireinfoNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ConfigurationID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barfireinfo.ConfigurationID = XmlUtilities.ConvertType<int>(barfireinfoNode.Elements().First(x => string.Compare(x.Name.ToString(), "ConfigurationID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return barfireinfo;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ResultSet" />.
        /// </summary>
        public static ResultSet ToResultSet(this XElement resultsetNode)
        {
            var resultset = new ResultSet();
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MeshID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.MeshID = XmlUtilities.ConvertType<int>(resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "MeshID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordMap", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.RecordMap = ToMeshMap(resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordMap", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.Name = ToAliasedString(resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ResultType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.ResultType = (ResultType)Enum.Parse(typeof(ResultType), resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "ResultType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ResultID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.ResultID = XmlUtilities.ConvertType<int>(resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "ResultID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tables", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in resultsetNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tables", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    resultset.Tables.Add(ToTableGroup(elem));
                }
            }
            if (resultsetNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Options", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                resultset.Options = ToKeyValues(resultsetNode.Elements().First(x => string.Compare(x.Name.ToString(), "Options", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return resultset;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Check" />.
        /// </summary>
        public static Check ToCheck(this XElement checkNode)
        {
            var check = new Check();
            if (checkNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                check.Name = ToAliasedString(checkNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (checkNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                check.Standard = (Standards)Enum.Parse(typeof(Standards), checkNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (checkNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                check.Status = (CheckStatus)Enum.Parse(typeof(CheckStatus), checkNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (checkNode.Elements().Any(x => string.Compare(x.Name.ToString(), "UnityCheck", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                check.UnityCheck = XmlUtilities.ConvertType<double>(checkNode.Elements().First(x => string.Compare(x.Name.ToString(), "UnityCheck", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (checkNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Options", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                check.Options = ToKeyValues(checkNode.Elements().First(x => string.Compare(x.Name.ToString(), "Options", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return check;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ItemVerification" />.
        /// </summary>
        public static ItemVerification ToItemVerification(this XElement itemverificationNode)
        {
            var itemverification = new ItemVerification();
            if (itemverificationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ItemID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                itemverification.ItemID = XmlUtilities.ConvertType<int>(itemverificationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ItemID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (itemverificationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ToolName", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                itemverification.ToolName = XmlUtilities.ConvertType<string>(itemverificationNode.Elements().First(x => string.Compare(x.Name.ToString(), "ToolName", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (itemverificationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EngineerName", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                itemverification.EngineerName = XmlUtilities.ConvertType<string>(itemverificationNode.Elements().First(x => string.Compare(x.Name.ToString(), "EngineerName", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (itemverificationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Date", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                itemverification.Date = XmlUtilities.ConvertType<DateTime>(itemverificationNode.Elements().First(x => string.Compare(x.Name.ToString(), "Date", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (itemverificationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Checks", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in itemverificationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Checks", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    itemverification.Checks.Add(ToCheck(elem));
                }
            }

            return itemverification;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="NodeMappingItem" />.
        /// </summary>
        public static NodeMappingItem ToNodeMappingItem(this XElement nodemappingitemNode)
        {
            var nodemappingitem = new NodeMappingItem();
            if (nodemappingitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nodemappingitem.SourceID = XmlUtilities.ConvertType<int>(nodemappingitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nodemappingitemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                nodemappingitem.RecordIndex = XmlUtilities.ConvertType<int>(nodemappingitemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return nodemappingitem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Line2MappingItem" />.
        /// </summary>
        public static Line2MappingItem ToLine2MappingItem(this XElement line2MappingItemNode)
        {
            var line2MappingItem = new Line2MappingItem();
            if (line2MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2MappingItem.SourceID = XmlUtilities.ConvertType<int>(line2MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2MappingItem.RecordIndex1 = XmlUtilities.ConvertType<int>(line2MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2MappingItem.RecordIndex2 = XmlUtilities.ConvertType<int>(line2MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return line2MappingItem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Line3MappingItem" />.
        /// </summary>
        public static Line3MappingItem ToLine3MappingItem(this XElement line3MappingItemNode)
        {
            var line3MappingItem = new Line3MappingItem();
            if (line3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3MappingItem.SourceID = XmlUtilities.ConvertType<int>(line3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3MappingItem.RecordIndex1 = XmlUtilities.ConvertType<int>(line3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3MappingItem.RecordIndex2 = XmlUtilities.ConvertType<int>(line3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3MappingItem.RecordIndex12 = XmlUtilities.ConvertType<int>(line3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return line3MappingItem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle3MappingItem" />.
        /// </summary>
        public static Triangle3MappingItem ToTriangle3MappingItem(this XElement triangle3MappingItemNode)
        {
            var triangle3MappingItem = new Triangle3MappingItem();
            if (triangle3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3MappingItem.SourceID = XmlUtilities.ConvertType<int>(triangle3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3MappingItem.RecordIndex1 = XmlUtilities.ConvertType<int>(triangle3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3MappingItem.RecordIndex2 = XmlUtilities.ConvertType<int>(triangle3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3MappingItem.RecordIndex3 = XmlUtilities.ConvertType<int>(triangle3MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex3", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return triangle3MappingItem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle6MappingItem" />.
        /// </summary>
        public static Triangle6MappingItem ToTriangle6MappingItem(this XElement triangle6MappingItemNode)
        {
            var triangle6MappingItem = new Triangle6MappingItem();
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.SourceID = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "SourceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex1 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex2 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex3 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex3", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex12 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex23", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex23 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex23", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6MappingItemNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RecordIndex31", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6MappingItem.RecordIndex31 = XmlUtilities.ConvertType<int>(triangle6MappingItemNode.Elements().First(x => string.Compare(x.Name.ToString(), "RecordIndex31", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return triangle6MappingItem;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="MeshMap" />.
        /// </summary>
        public static MeshMap ToMeshMap(this XElement meshmapNode)
        {
            var meshmap = new MeshMap();
            if (meshmapNode.Elements().Any(x => string.Compare(x.Name.ToString(), "NodeMap", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in meshmapNode.Elements().Where(x => string.Compare(x.Name.ToString(), "NodeMap", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    meshmap.NodeMap.Add(ToNodeMappingItem(elem));
                }
            }
            if (meshmapNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Line2Map", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in meshmapNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Line2Map", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    meshmap.Line2Map.Add(ToLine2MappingItem(elem));
                }
            }
            if (meshmapNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Line3Map", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in meshmapNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Line3Map", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    meshmap.Line3Map.Add(ToLine3MappingItem(elem));
                }
            }
            if (meshmapNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Triangle3Map", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in meshmapNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Triangle3Map", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    meshmap.Triangle3Map.Add(ToTriangle3MappingItem(elem));
                }
            }
            if (meshmapNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Triangle6Map", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in meshmapNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Triangle6Map", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    meshmap.Triangle6Map.Add(ToTriangle6MappingItem(elem));
                }
            }

            return meshmap;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Table" />.
        /// </summary>
        public static Table ToTable(this XElement tableNode)
        {
            var table = new Table();
            if (tableNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OutputType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                table.OutputType = (TableOutputType)Enum.Parse(typeof(TableOutputType), tableNode.Elements().First(x => string.Compare(x.Name.ToString(), "OutputType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (tableNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                table.Name = ToAliasedString(tableNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (tableNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RelativePath", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                table.RelativePath = XmlUtilities.ConvertType<string>(tableNode.Elements().First(x => string.Compare(x.Name.ToString(), "RelativePath", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return table;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TableGroup" />.
        /// </summary>
        public static TableGroup ToTableGroup(this XElement tablegroupNode)
        {
            var tablegroup = new TableGroup();
            if (tablegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ResultGroup", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                tablegroup.ResultGroup = (ResultGroup)Enum.Parse(typeof(ResultGroup), tablegroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "ResultGroup", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (tablegroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tables", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in tablegroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tables", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    tablegroup.Tables.Add(ToTable(elem));
                }
            }

            return tablegroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Axle" />.
        /// </summary>
        public static Axle ToAxle(this XElement axleNode)
        {
            var axle = new Axle();
            if (axleNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Distance", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                axle.Distance = XmlUtilities.ConvertType<double>(axleNode.Elements().First(x => string.Compare(x.Name.ToString(), "Distance", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (axleNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                axle.F = ToVector3(axleNode.Elements().First(x => string.Compare(x.Name.ToString(), "F", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (axleNode.Elements().Any(x => string.Compare(x.Name.ToString(), "M", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                axle.M = ToVector3(axleNode.Elements().First(x => string.Compare(x.Name.ToString(), "M", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return axle;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CombinationGroup" />.
        /// </summary>
        public static CombinationGroup ToCombinationGroup(this XElement combinationgroupNode)
        {
            var combinationgroup = new CombinationGroup();
            if (combinationgroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combinationgroup.ID = XmlUtilities.ConvertType<int>(combinationgroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (combinationgroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combinationgroup.Name = ToAliasedString(combinationgroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (combinationgroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combinationgroup.Standard = (Standards)Enum.Parse(typeof(Standards), combinationgroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (combinationgroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Category", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combinationgroup.Category = (CombinationCategory)Enum.Parse(typeof(CombinationCategory), combinationgroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Category", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (combinationgroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Combinations", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in combinationgroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Combinations", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    combinationgroup.Combinations.Add(ToCombination(elem));
                }
            }

            return combinationgroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CraneLoadSettings" />.
        /// </summary>
        public static CraneLoadSettings ToCraneLoadSettings(this XElement craneloadsettingsNode)
        {
            var craneloadsettings = new CraneLoadSettings();
            if (craneloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SampleCount", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                craneloadsettings.SampleCount = XmlUtilities.ConvertType<int>(craneloadsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "SampleCount", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (craneloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadDefinition", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in craneloadsettingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "LoadDefinition", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    craneloadsettings.LoadDefinition.Add(ToCraneLoad(elem));
                }
            }

            return craneloadsettings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSpectrum" />.
        /// </summary>
        public static CustomSpectrum ToCustomSpectrum(this XElement customspectrumNode)
        {
            var customspectrum = new CustomSpectrum();
            if (customspectrumNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Acceleration", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customspectrum.Acceleration = XmlUtilities.ConvertType<double>(customspectrumNode.Elements().First(x => string.Compare(x.Name.ToString(), "Acceleration", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customspectrumNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DisplacementFactor", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customspectrum.DisplacementFactor = XmlUtilities.ConvertType<double>(customspectrumNode.Elements().First(x => string.Compare(x.Name.ToString(), "DisplacementFactor", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customspectrumNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferencePeriod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customspectrum.ReferencePeriod = XmlUtilities.ConvertType<double>(customspectrumNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferencePeriod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customspectrumNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsSpline", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                customspectrum.IsSpline = XmlUtilities.ConvertType<bool>(customspectrumNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsSpline", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (customspectrumNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in customspectrumNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Points", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    customspectrum.Points.Add(ToVector2(elem));
                }
            }

            return customspectrum;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicBehaviour" />.
        /// </summary>
        public static DynamicBehaviour ToDynamicBehaviour(this XElement dynamicbehaviourNode)
        {
            var dynamicbehaviour = new DynamicBehaviour();
            if (dynamicbehaviourNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BehaviourType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicbehaviour.BehaviourType = (DynamicBehaviourType)Enum.Parse(typeof(DynamicBehaviourType), dynamicbehaviourNode.Elements().First(x => string.Compare(x.Name.ToString(), "BehaviourType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicbehaviourNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SupportAccelerationSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicbehaviour.SupportAccelerationSettings = ToSupportAccelerationParameters(dynamicbehaviourNode.Elements().First(x => string.Compare(x.Name.ToString(), "SupportAccelerationSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (dynamicbehaviourNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FunctionType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicbehaviour.FunctionType = XmlUtilities.ConvertType<string>(dynamicbehaviourNode.Elements().First(x => string.Compare(x.Name.ToString(), "FunctionType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicbehaviourNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicbehaviourNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicbehaviour.Parameters.Add(ToKeyDoubleValue(elem));
                }
            }

            return dynamicbehaviour;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicDomain" />.
        /// </summary>
        public static DynamicDomain ToDynamicDomain(this XElement dynamicdomainNode)
        {
            var dynamicdomain = new DynamicDomain();
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Periodic", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.Periodic = XmlUtilities.ConvertType<bool>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "Periodic", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Synchronized", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.Synchronized = XmlUtilities.ConvertType<bool>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "Synchronized", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "UseAbsolutePeriod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.UseAbsolutePeriod = XmlUtilities.ConvertType<bool>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "UseAbsolutePeriod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AbsolutePeriod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.AbsolutePeriod = XmlUtilities.ConvertType<double>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "AbsolutePeriod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RelativePeriodReferenceMode", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.RelativePeriodReferenceMode = XmlUtilities.ConvertType<int>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "RelativePeriodReferenceMode", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "RelativePeriodFraction", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.RelativePeriodFraction = XmlUtilities.ConvertType<double>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "RelativePeriodFraction", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SamplePoints", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.SamplePoints = XmlUtilities.ConvertType<int>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "SamplePoints", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EnforceMinimumSamplePointsPerPeriod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.EnforceMinimumSamplePointsPerPeriod = XmlUtilities.ConvertType<bool>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "EnforceMinimumSamplePointsPerPeriod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MinimumSamplePointsPerPeriod", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.MinimumSamplePointsPerPeriod = XmlUtilities.ConvertType<int>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "MinimumSamplePointsPerPeriod", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ResultPoints", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.ResultPoints = XmlUtilities.ConvertType<int>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "ResultPoints", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicdomainNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ApplyQSC", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicdomain.ApplyQSC = XmlUtilities.ConvertType<bool>(dynamicdomainNode.Elements().First(x => string.Compare(x.Name.ToString(), "ApplyQSC", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return dynamicdomain;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicLoadCase" />.
        /// </summary>
        public static DynamicLoadCase ToDynamicLoadCase(this XElement dynamicloadcaseNode)
        {
            var dynamicloadcase = new DynamicLoadCase();
            if (dynamicloadcaseNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.ID = XmlUtilities.ConvertType<int>(dynamicloadcaseNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.Disabled = XmlUtilities.ConvertType<bool>(dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.AllSubLoadCasesTogether = XmlUtilities.ConvertType<bool>(dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.Name = ToAliasedString(dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DomainInformation", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.DomainInformation = ToDynamicDomain(dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "DomainInformation", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadCaseType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.LoadCaseType = (LoadCaseType)Enum.Parse(typeof(LoadCaseType), dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadCaseType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadCaseTypeDescription", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicloadcase.LoadCaseTypeDescription = XmlUtilities.ConvertType<string>(dynamicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadCaseTypeDescription", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicloadcase.Parameters.Add(ToLoadCaseParameters(elem));
                }
            }
            if (dynamicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicloadcase.SubLoadCases.Add(ToDynamicSubLoadCase(elem));
                }
            }

            return dynamicloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Incompatibility" />.
        /// </summary>
        public static Incompatibility ToIncompatibility(this XElement incompatibilityNode)
        {
            var incompatibility = new Incompatibility();
            if (incompatibilityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ID1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                incompatibility.ID1 = XmlUtilities.ConvertType<int>(incompatibilityNode.Elements().First(x => string.Compare(x.Name.ToString(), "ID1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (incompatibilityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ID2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                incompatibility.ID2 = XmlUtilities.ConvertType<int>(incompatibilityNode.Elements().First(x => string.Compare(x.Name.ToString(), "ID2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return incompatibility;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LineLoad" />.
        /// </summary>
        public static LineLoad ToLineLoad(this XElement lineloadNode)
        {
            var lineload = new LineLoad();
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.ReferenceType = (GeometryReferenceType)Enum.Parse(typeof(GeometryReferenceType), lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.ReferenceID = XmlUtilities.ConvertType<int>(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ParticipatingMembers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in lineloadNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ParticipatingMembers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    lineload.ParticipatingMembers.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.F1 = ToVector3(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "M1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.M1 = ToVector3(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "M1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Distance1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.Distance1 = XmlUtilities.ConvertType<double>(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Distance1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.F2 = ToVector3(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "M2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.M2 = ToVector3(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "M2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Distance2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.Distance2 = XmlUtilities.ConvertType<double>(lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Distance2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (lineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                lineload.LoadType = (LineLoadType)Enum.Parse(typeof(LineLoadType), lineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return lineload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LoadCaseParameters" />.
        /// </summary>
        public static LoadCaseParameters ToLoadCaseParameters(this XElement loadcaseparametersNode)
        {
            var loadcaseparameters = new LoadCaseParameters();
            if (loadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                loadcaseparameters.Standard = (Standards)Enum.Parse(typeof(Standards), loadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (loadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                loadcaseparameters.Values = ToKeyValues(loadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return loadcaseparameters;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PointLoad" />.
        /// </summary>
        public static PointLoad ToPointLoad(this XElement pointloadNode)
        {
            var pointload = new PointLoad();
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.ReferenceType = (GeometryReferenceType)Enum.Parse(typeof(GeometryReferenceType), pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.ReferenceID = XmlUtilities.ConvertType<int>(pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ParticipatingMembers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in pointloadNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ParticipatingMembers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    pointload.ParticipatingMembers.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.F = ToVector3(pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "M", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.M = ToVector3(pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "M", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Distance", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.Distance = XmlUtilities.ConvertType<double>(pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Distance", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsAlignedWithLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                pointload.IsAlignedWithLocalCS = XmlUtilities.ConvertType<bool>(pointloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsAlignedWithLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return pointload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SeismicLoadCase" />.
        /// </summary>
        public static SeismicLoadCase ToSeismicLoadCase(this XElement seismicloadcaseNode)
        {
            var seismicloadcase = new SeismicLoadCase();
            if (seismicloadcaseNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcase.ID = XmlUtilities.ConvertType<int>(seismicloadcaseNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (seismicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcase.Disabled = XmlUtilities.ConvertType<bool>(seismicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (seismicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcase.Name = ToAliasedString(seismicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (seismicloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Settings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcase.Settings = ToSeismicLoadCaseParameters(seismicloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Settings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return seismicloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SeismicLoadCaseParameters" />.
        /// </summary>
        public static SeismicLoadCaseParameters ToSeismicLoadCaseParameters(this XElement seismicloadcaseparametersNode)
        {
            var seismicloadcaseparameters = new SeismicLoadCaseParameters();
            if (seismicloadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcaseparameters.Standard = (Standards)Enum.Parse(typeof(Standards), seismicloadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (seismicloadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Settings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcaseparameters.Settings = ToKeyValues(seismicloadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Settings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (seismicloadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomU", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcaseparameters.CustomU = ToCustomSpectrum(seismicloadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "CustomU", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (seismicloadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomV", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcaseparameters.CustomV = ToCustomSpectrum(seismicloadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "CustomV", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (seismicloadcaseparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CustomW", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                seismicloadcaseparameters.CustomW = ToCustomSpectrum(seismicloadcaseparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "CustomW", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return seismicloadcaseparameters;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SnowLoadSettings" />.
        /// </summary>
        public static SnowLoadSettings ToSnowLoadSettings(this XElement snowloadsettingsNode)
        {
            var snowloadsettings = new SnowLoadSettings();
            if (snowloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                snowloadsettings.Standard = (Standards)Enum.Parse(typeof(Standards), snowloadsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (snowloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                snowloadsettings.Values = ToKeyValues(snowloadsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return snowloadsettings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="StaticLoadCase" />.
        /// </summary>
        public static StaticLoadCase ToStaticLoadCase(this XElement staticloadcaseNode)
        {
            var staticloadcase = new StaticLoadCase();
            if (staticloadcaseNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.ID = XmlUtilities.ConvertType<int>(staticloadcaseNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.Disabled = XmlUtilities.ConvertType<bool>(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.Name = ToAliasedString(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.AllSubLoadCasesTogether = XmlUtilities.ConvertType<bool>(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadCaseType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.LoadCaseType = (LoadCaseType)Enum.Parse(typeof(LoadCaseType), staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadCaseType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadCaseTypeDescription", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.LoadCaseTypeDescription = XmlUtilities.ConvertType<string>(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadCaseTypeDescription", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in staticloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    staticloadcase.Parameters.Add(ToLoadCaseParameters(elem));
                }
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in staticloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    staticloadcase.SubLoadCases.Add(ToStaticSubLoadCase(elem));
                }
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CraneLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.CraneLoadSettings = ToCraneLoadSettings(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "CraneLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "WindLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.WindLoadSettings = ToWindLoadSettings(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "WindLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (staticloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SnowLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticloadcase.SnowLoadSettings = ToSnowLoadSettings(staticloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "SnowLoadSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return staticloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SupportAccelerationParameters" />.
        /// </summary>
        public static SupportAccelerationParameters ToSupportAccelerationParameters(this XElement supportaccelerationparametersNode)
        {
            var supportaccelerationparameters = new SupportAccelerationParameters();
            if (supportaccelerationparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Acceleration", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                supportaccelerationparameters.Acceleration = XmlUtilities.ConvertType<double>(supportaccelerationparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Acceleration", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (supportaccelerationparametersNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Direction", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                supportaccelerationparameters.Direction = ToVector3(supportaccelerationparametersNode.Elements().First(x => string.Compare(x.Name.ToString(), "Direction", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return supportaccelerationparameters;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SurfaceLoad" />.
        /// </summary>
        public static SurfaceLoad ToSurfaceLoad(this XElement surfaceloadNode)
        {
            var surfaceload = new SurfaceLoad();
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.ReferenceType = (GeometryReferenceType)Enum.Parse(typeof(GeometryReferenceType), surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.ReferenceID = XmlUtilities.ConvertType<int>(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.P1 = ToVector2(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "P1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.F1 = ToVector3(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F1", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.P2 = ToVector2(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "P2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.F2 = ToVector3(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F2", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.P3 = ToVector2(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "P3", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "F3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.F3 = ToVector3(surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "F3", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (surfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                surfaceload.LoadType = (SurfaceLoadType)Enum.Parse(typeof(SurfaceLoadType), surfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return surfaceload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureLineLoad" />.
        /// </summary>
        public static TemperatureLineLoad ToTemperatureLineLoad(this XElement temperaturelineloadNode)
        {
            var temperaturelineload = new TemperatureLineLoad();
            if (temperaturelineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturelineload.ReferenceType = (GeometryReferenceType)Enum.Parse(typeof(GeometryReferenceType), temperaturelineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturelineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturelineload.ReferenceID = XmlUtilities.ConvertType<int>(temperaturelineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturelineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Uniform", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturelineload.Uniform = XmlUtilities.ConvertType<double>(temperaturelineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Uniform", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturelineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GradientY", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturelineload.GradientY = XmlUtilities.ConvertType<double>(temperaturelineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "GradientY", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturelineloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GradientZ", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturelineload.GradientZ = XmlUtilities.ConvertType<double>(temperaturelineloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "GradientZ", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return temperaturelineload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureLoadCase" />.
        /// </summary>
        public static TemperatureLoadCase ToTemperatureLoadCase(this XElement temperatureloadcaseNode)
        {
            var temperatureloadcase = new TemperatureLoadCase();
            if (temperatureloadcaseNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperatureloadcase.ID = XmlUtilities.ConvertType<int>(temperatureloadcaseNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperatureloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperatureloadcase.Disabled = XmlUtilities.ConvertType<bool>(temperatureloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Disabled", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperatureloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperatureloadcase.AllSubLoadCasesTogether = XmlUtilities.ConvertType<bool>(temperatureloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "AllSubLoadCasesTogether", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperatureloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperatureloadcase.Name = ToAliasedString(temperatureloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (temperatureloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in temperatureloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SubLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    temperatureloadcase.SubLoadCases.Add(ToTemperatureSubLoadCase(elem));
                }
            }
            if (temperatureloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in temperatureloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Parameters", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    temperatureloadcase.Parameters.Add(ToLoadCaseParameters(elem));
                }
            }

            return temperatureloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureSurfaceLoad" />.
        /// </summary>
        public static TemperatureSurfaceLoad ToTemperatureSurfaceLoad(this XElement temperaturesurfaceloadNode)
        {
            var temperaturesurfaceload = new TemperatureSurfaceLoad();
            if (temperaturesurfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturesurfaceload.ReferenceType = (GeometryReferenceType)Enum.Parse(typeof(GeometryReferenceType), temperaturesurfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturesurfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturesurfaceload.ReferenceID = XmlUtilities.ConvertType<int>(temperaturesurfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturesurfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Uniform", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturesurfaceload.Uniform = XmlUtilities.ConvertType<double>(temperaturesurfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Uniform", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (temperaturesurfaceloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Gradient", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturesurfaceload.Gradient = XmlUtilities.ConvertType<double>(temperaturesurfaceloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Gradient", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return temperaturesurfaceload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Track" />.
        /// </summary>
        public static Track ToTrack(this XElement trackNode)
        {
            var track = new Track();
            if (trackNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MirroredTrain", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                track.MirroredTrain = XmlUtilities.ConvertType<bool>(trackNode.Elements().First(x => string.Compare(x.Name.ToString(), "MirroredTrain", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trackNode.Elements().Any(x => string.Compare(x.Name.ToString(), "StartOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                track.StartOffset = XmlUtilities.ConvertType<double>(trackNode.Elements().First(x => string.Compare(x.Name.ToString(), "StartOffset", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trackNode.Elements().Any(x => string.Compare(x.Name.ToString(), "EndOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                track.EndOffset = XmlUtilities.ConvertType<double>(trackNode.Elements().First(x => string.Compare(x.Name.ToString(), "EndOffset", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trackNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarGroupID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                track.BarGroupID = XmlUtilities.ConvertType<int>(trackNode.Elements().First(x => string.Compare(x.Name.ToString(), "BarGroupID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trackNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SynchronizationPointIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in trackNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SynchronizationPointIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    track.SynchronizationPointIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return track;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TrainLoad" />.
        /// </summary>
        public static TrainLoad ToTrainLoad(this XElement trainloadNode)
        {
            var trainload = new TrainLoad();
            if (trainloadNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.ID = XmlUtilities.ConvertType<Guid>(trainloadNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.Name = ToAliasedString(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.Length = XmlUtilities.ConvertType<double>(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Length", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsAlignedWithLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.IsAlignedWithLocalCS = XmlUtilities.ConvertType<bool>(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsAlignedWithLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Axles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in trainloadNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Axles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    trainload.Axles.Add(ToAxle(elem));
                }
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.Version = XmlUtilities.ConvertType<int>(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.LastChanged = XmlUtilities.ConvertType<DateTime>(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (trainloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                trainload.ReadOnly = XmlUtilities.ConvertType<bool>(trainloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return trainload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="WindLoadSettings" />.
        /// </summary>
        public static WindLoadSettings ToWindLoadSettings(this XElement windloadsettingsNode)
        {
            var windloadsettings = new WindLoadSettings();
            if (windloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                windloadsettings.Standard = (Standards)Enum.Parse(typeof(Standards), windloadsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "Standard", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (windloadsettingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                windloadsettings.Values = ToKeyValues(windloadsettingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "Values", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return windloadsettings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ModelLoads" />.
        /// </summary>
        public static ModelLoads ToModelLoads(this XElement modelloadsNode)
        {
            var modelloads = new ModelLoads();
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "TrainLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "TrainLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.TrainLoads.Add(ToTrainLoad(elem));
                }
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LoadCaseInteraction", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                modelloads.LoadCaseInteraction = ToLoadCaseInteraction(modelloadsNode.Elements().First(x => string.Compare(x.Name.ToString(), "LoadCaseInteraction", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "StaticLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "StaticLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.StaticLoadCases.Add(ToStaticLoadCase(elem));
                }
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "DynamicLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "DynamicLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.DynamicLoadCases.Add(ToDynamicLoadCase(elem));
                }
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SeismicLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SeismicLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.SeismicLoadCases.Add(ToSeismicLoadCase(elem));
                }
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "TemperatureLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "TemperatureLoadCases", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.TemperatureLoadCases.Add(ToTemperatureLoadCase(elem));
                }
            }
            if (modelloadsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CombinationTree", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in modelloadsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "CombinationTree", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    modelloads.CombinationTree.Add(ToCombinationGroup(elem));
                }
            }

            return modelloads;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LinkedLoadCases" />.
        /// </summary>
        public static LinkedLoadCases ToLinkedLoadCases(this XElement linkedloadcasesNode)
        {
            var linkedloadcases = new LinkedLoadCases();
            if (linkedloadcasesNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in linkedloadcasesNode.Elements().Where(x => string.Compare(x.Name.ToString(), "IDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    linkedloadcases.IDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return linkedloadcases;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LoadCaseInteraction" />.
        /// </summary>
        public static LoadCaseInteraction ToLoadCaseInteraction(this XElement loadcaseinteractionNode)
        {
            var loadcaseinteraction = new LoadCaseInteraction();
            if (loadcaseinteractionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Incompatible", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in loadcaseinteractionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Incompatible", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    loadcaseinteraction.Incompatible.Add(ToIncompatibility(elem));
                }
            }
            if (loadcaseinteractionNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Linked", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in loadcaseinteractionNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Linked", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    loadcaseinteraction.Linked.Add(ToLinkedLoadCases(elem));
                }
            }

            return loadcaseinteraction;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="StaticSubLoadCase" />.
        /// </summary>
        public static StaticSubLoadCase ToStaticSubLoadCase(this XElement staticsubloadcaseNode)
        {
            var staticsubloadcase = new StaticSubLoadCase();
            if (staticsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                staticsubloadcase.Name = ToAliasedString(staticsubloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (staticsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PointLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in staticsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PointLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    staticsubloadcase.PointLoads.Add(ToPointLoad(elem));
                }
            }
            if (staticsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in staticsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    staticsubloadcase.LineLoads.Add(ToLineLoad(elem));
                }
            }
            if (staticsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in staticsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    staticsubloadcase.SurfaceLoads.Add(ToSurfaceLoad(elem));
                }
            }

            return staticsubloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CraneLoad" />.
        /// </summary>
        public static CraneLoad ToCraneLoad(this XElement craneloadNode)
        {
            var craneload = new CraneLoad();
            if (craneloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "TrainID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                craneload.TrainID = XmlUtilities.ConvertType<Guid>(craneloadNode.Elements().First(x => string.Compare(x.Name.ToString(), "TrainID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (craneloadNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tracks", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in craneloadNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Tracks", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    craneload.Tracks.Add(ToTrack(elem));
                }
            }

            return craneload;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicSubLoadCase" />.
        /// </summary>
        public static DynamicSubLoadCase ToDynamicSubLoadCase(this XElement dynamicsubloadcaseNode)
        {
            var dynamicsubloadcase = new DynamicSubLoadCase();
            if (dynamicsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicsubloadcase.Name = ToAliasedString(dynamicsubloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (dynamicsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Behaviour", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                dynamicsubloadcase.Behaviour = ToDynamicBehaviour(dynamicsubloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Behaviour", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (dynamicsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PointLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PointLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicsubloadcase.PointLoads.Add(ToPointLoad(elem));
                }
            }
            if (dynamicsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicsubloadcase.LineLoads.Add(ToLineLoad(elem));
                }
            }
            if (dynamicsubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in dynamicsubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    dynamicsubloadcase.SurfaceLoads.Add(ToSurfaceLoad(elem));
                }
            }

            return dynamicsubloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureSubLoadCase" />.
        /// </summary>
        public static TemperatureSubLoadCase ToTemperatureSubLoadCase(this XElement temperaturesubloadcaseNode)
        {
            var temperaturesubloadcase = new TemperatureSubLoadCase();
            if (temperaturesubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                temperaturesubloadcase.Name = ToAliasedString(temperaturesubloadcaseNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (temperaturesubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in temperaturesubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "LineLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    temperaturesubloadcase.LineLoads.Add(ToTemperatureLineLoad(elem));
                }
            }
            if (temperaturesubloadcaseNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in temperaturesubloadcaseNode.Elements().Where(x => string.Compare(x.Name.ToString(), "SurfaceLoads", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    temperaturesubloadcase.SurfaceLoads.Add(ToTemperatureSurfaceLoad(elem));
                }
            }

            return temperaturesubloadcase;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Combination" />.
        /// </summary>
        public static Combination ToCombination(this XElement combinationNode)
        {
            var combination = new Combination();
            if (combinationNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combination.ID = XmlUtilities.ConvertType<int>(combinationNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (combinationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combination.Name = ToAliasedString(combinationNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (combinationNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Coefficients", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in combinationNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Coefficients", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    combination.Coefficients.Add(ToCombinationCoefficient(elem));
                }
            }

            return combination;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CombinationCoefficient" />.
        /// </summary>
        public static CombinationCoefficient ToCombinationCoefficient(this XElement combinationcoefficientNode)
        {
            var combinationcoefficient = new CombinationCoefficient();
            if (combinationcoefficientNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "LoadCaseID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                combinationcoefficient.LoadCaseID = XmlUtilities.ConvertType<int>(combinationcoefficientNode.Attributes().First(x => string.Compare(x.Name.ToString(), "LoadCaseID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (combinationcoefficientNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in combinationcoefficientNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Value", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    combinationcoefficient.Value.Add(XmlUtilities.ConvertType<double>(elem.Value));
                }
            }

            return combinationcoefficient;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Settings ToAnalysisMeshSettings(this XElement settingsNode)
        {
            var settings = new BuildSoft.UBSM.Analysis.Mesh.Settings();
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ElementType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                settings.ElementType = (AnalysisElementType)Enum.Parse(typeof(AnalysisElementType), settingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "ElementType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in settingsNode.Elements().Where(x => string.Compare(x.Name.ToString(), "IDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    settings.IDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }
            if (settingsNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MeshSettings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                settings.MeshSettings = ToKeyValues(settingsNode.Elements().First(x => string.Compare(x.Name.ToString(), "MeshSettings", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return settings;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Line2" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Line2 ToLine2(this XElement line2Node)
        {
            var line2 = new BuildSoft.UBSM.Analysis.Mesh.Line2();
            if (line2Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2.ID = XmlUtilities.ConvertType<int>(line2Node.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "IsRigidLink", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2.IsRigidLink = XmlUtilities.ConvertType<bool>(line2Node.Elements().First(x => string.Compare(x.Name.ToString(), "IsRigidLink", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2.Node1 = XmlUtilities.ConvertType<int>(line2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2.Node2 = XmlUtilities.ConvertType<int>(line2Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line2Node.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line2.LocalCS = ToCoordinateSystem(line2Node.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return line2;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Line3" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Line3 ToLine3(this XElement line3Node)
        {
            var line3 = new BuildSoft.UBSM.Analysis.Mesh.Line3();
            if (line3Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.ID = XmlUtilities.ConvertType<int>(line3Node.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "IsRigidLink", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.IsRigidLink = XmlUtilities.ConvertType<bool>(line3Node.Elements().First(x => string.Compare(x.Name.ToString(), "IsRigidLink", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.Node1 = XmlUtilities.ConvertType<int>(line3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.Node2 = XmlUtilities.ConvertType<int>(line3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.Node12 = XmlUtilities.ConvertType<int>(line3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (line3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                line3.LocalCS = ToCoordinateSystem(line3Node.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return line3;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Node" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Node ToNode(this XElement nodeNode)
        {
            var node = new BuildSoft.UBSM.Analysis.Mesh.Node();
            if (nodeNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                node.ID = XmlUtilities.ConvertType<int>(nodeNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (nodeNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                node.Location = ToVector3(nodeNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Triangle3" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Triangle3 ToTriangle3(this XElement triangle3Node)
        {
            var triangle3 = new BuildSoft.UBSM.Analysis.Mesh.Triangle3();
            if (triangle3Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3.ID = XmlUtilities.ConvertType<int>(triangle3Node.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3.Node1 = XmlUtilities.ConvertType<int>(triangle3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3.Node2 = XmlUtilities.ConvertType<int>(triangle3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3.Node3 = XmlUtilities.ConvertType<int>(triangle3Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node3", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle3Node.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle3.LocalCS = ToCoordinateSystem(triangle3Node.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return triangle3;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Triangle6" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.Triangle6 ToTriangle6(this XElement triangle6Node)
        {
            var triangle6 = new BuildSoft.UBSM.Analysis.Mesh.Triangle6();
            if (triangle6Node.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.ID = XmlUtilities.ConvertType<int>(triangle6Node.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node1 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node1", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node2 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node2", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node3", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node3 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node3", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node12", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node12 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node12", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node23", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node23 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node23", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "Node31", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.Node31 = XmlUtilities.ConvertType<int>(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "Node31", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (triangle6Node.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                triangle6.LocalCS = ToCoordinateSystem(triangle6Node.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return triangle6;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.GeometryMesh" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.GeometryMesh ToGeometryMesh(this XElement geometrymeshNode)
        {
            var geometrymesh = new BuildSoft.UBSM.Analysis.Mesh.GeometryMesh();
            if (geometrymeshNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                geometrymesh.ID = XmlUtilities.ConvertType<int>(geometrymeshNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (geometrymeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ElementMeshes", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in geometrymeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "ElementMeshes", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    geometrymesh.ElementMeshes.Add(ToElementMesh(elem));
                }
            }

            return geometrymesh;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.ElementMesh" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.ElementMesh ToElementMesh(this XElement elementmeshNode)
        {
            var elementmesh = new BuildSoft.UBSM.Analysis.Mesh.ElementMesh();
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ElementType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementmesh.ElementType = (AnalysisElementType)Enum.Parse(typeof(AnalysisElementType), elementmeshNode.Elements().First(x => string.Compare(x.Name.ToString(), "ElementType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ElementID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                elementmesh.ElementID = XmlUtilities.ConvertType<int>(elementmeshNode.Elements().First(x => string.Compare(x.Name.ToString(), "ElementID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Nodes", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in elementmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Nodes", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    elementmesh.Nodes.Add(ToNode(elem));
                }
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in elementmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    elementmesh.Lines.Add(ToLine2(elem));
                }
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuadraticLines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in elementmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "QuadraticLines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    elementmesh.QuadraticLines.Add(ToLine3(elem));
                }
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in elementmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    elementmesh.Triangles.Add(ToTriangle3(elem));
                }
            }
            if (elementmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuadraticTriangles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in elementmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "QuadraticTriangles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    elementmesh.QuadraticTriangles.Add(ToTriangle6(elem));
                }
            }

            return elementmesh;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.SectionMesh" />.
        /// </summary>
        public static BuildSoft.UBSM.Analysis.Mesh.SectionMesh ToSectionMesh(this XElement sectionmeshNode)
        {
            var sectionmesh = new BuildSoft.UBSM.Analysis.Mesh.SectionMesh();
            if (sectionmeshNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionmesh.ID = XmlUtilities.ConvertType<int>(sectionmeshNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                sectionmesh.SectionID = XmlUtilities.ConvertType<Guid>(sectionmeshNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Nodes", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Nodes", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionmesh.Nodes.Add(ToNode(elem));
                }
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Lines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionmesh.Lines.Add(ToLine2(elem));
                }
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuadraticLines", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "QuadraticLines", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionmesh.QuadraticLines.Add(ToLine3(elem));
                }
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Triangles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionmesh.Triangles.Add(ToTriangle3(elem));
                }
            }
            if (sectionmeshNode.Elements().Any(x => string.Compare(x.Name.ToString(), "QuadraticTriangles", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in sectionmeshNode.Elements().Where(x => string.Compare(x.Name.ToString(), "QuadraticTriangles", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    sectionmesh.QuadraticTriangles.Add(ToTriangle6(elem));
                }
            }

            return sectionmesh;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BoundaryCondition" />.
        /// </summary>
        public static BoundaryCondition ToBoundaryCondition(this XElement boundaryconditionNode)
        {
            var boundarycondition = new BoundaryCondition();
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "BoundaryConditionType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.BoundaryConditionType = (BoundaryConditionType)Enum.Parse(typeof(BoundaryConditionType), boundaryconditionNode.Attributes().
                Where(x => string.Compare(x.Name.ToString(), "BoundaryConditionType", StringComparison.InvariantCultureIgnoreCase) == 0).First().Value);
            }
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ReleaseMode", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.ReleaseMode = (ReleaseMode)Enum.Parse(typeof(ReleaseMode), boundaryconditionNode.Attributes().
                Where(x => string.Compare(x.Name.ToString(), "ReleaseMode", StringComparison.InvariantCultureIgnoreCase) == 0).First().Value);
            }
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "WithFunction", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.WithFunction = XmlUtilities.ConvertType<bool>(boundaryconditionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "WithFunction", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "FunctionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.FunctionID = XmlUtilities.ConvertType<int>(boundaryconditionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "FunctionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "IsFixed", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.IsFixed = XmlUtilities.ConvertType<bool>(boundaryconditionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "IsFixed", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (boundaryconditionNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "LinearSpring", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                boundarycondition.LinearSpring = XmlUtilities.ConvertType<double>(boundaryconditionNode.Attributes().First(x => string.Compare(x.Name.ToString(), "LinearSpring", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return boundarycondition;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SoilLayer" />.
        /// </summary>
        public static SoilLayer ToSoilLayer(this XElement soillayerNode)
        {
            var soillayer = new SoilLayer();
            if (soillayerNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soillayer.ID = XmlUtilities.ConvertType<int>(soillayerNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soillayerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soillayer.Thickness = XmlUtilities.ConvertType<double>(soillayerNode.Elements().First(x => string.Compare(x.Name.ToString(), "Thickness", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soillayerNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Properties", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in soillayerNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Properties", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    soillayer.Properties.Add(ToPropertyValue(elem));
                }
            }

            return soillayer;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SoilProfile" />.
        /// </summary>
        public static SoilProfile ToSoilProfile(this XElement soilprofileNode)
        {
            var soilprofile = new SoilProfile();
            if (soilprofileNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.ID = XmlUtilities.ConvertType<Guid>(soilprofileNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ProfileType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.ProfileType = (ProfileType)Enum.Parse(typeof(ProfileType), soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "ProfileType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.Name = ToAliasedString(soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BottomLayerFixed", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.BottomLayerFixed = XmlUtilities.ConvertType<bool>(soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "BottomLayerFixed", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Layers", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in soilprofileNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Layers", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    soilprofile.Layers.Add(ToSoilLayer(elem));
                }
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.Version = XmlUtilities.ConvertType<int>(soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "Version", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.LastChanged = XmlUtilities.ConvertType<DateTime>(soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "LastChanged", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.Status = (DatabaseStatus)Enum.Parse(typeof(DatabaseStatus), soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "Status", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilprofileNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilprofile.ReadOnly = XmlUtilities.ConvertType<bool>(soilprofileNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReadOnly", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return soilprofile;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SoilSupport" />.
        /// </summary>
        public static SoilSupport ToSoilSupport(this XElement soilsupportNode)
        {
            var soilsupport = new SoilSupport();
            if (soilsupportNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ProfileID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilsupport.ProfileID = XmlUtilities.ConvertType<Guid>(soilsupportNode.Elements().First(x => string.Compare(x.Name.ToString(), "ProfileID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilsupportNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ReferenceHeight", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilsupport.ReferenceHeight = XmlUtilities.ConvertType<double>(soilsupportNode.Elements().First(x => string.Compare(x.Name.ToString(), "ReferenceHeight", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilsupportNode.Elements().Any(x => string.Compare(x.Name.ToString(), "FreaticDepth", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilsupport.FreaticDepth = XmlUtilities.ConvertType<double>(soilsupportNode.Elements().First(x => string.Compare(x.Name.ToString(), "FreaticDepth", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (soilsupportNode.Elements().Any(x => string.Compare(x.Name.ToString(), "ResistsToTension", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                soilsupport.ResistsToTension = XmlUtilities.ConvertType<bool>(soilsupportNode.Elements().First(x => string.Compare(x.Name.ToString(), "ResistsToTension", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }

            return soilsupport;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Point" />.
        /// </summary>
        public static Point ToPoint(this XElement pointNode)
        {
            var point = new Point();
            if (pointNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.ID = XmlUtilities.ConvertType<int>(pointNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Name = ToAliasedString(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Location = ToVector3(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Location", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.LocalCS = ToCoordinateSystem(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.IsSupportedAlongLocalCS = XmlUtilities.ConvertType<bool>(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Tx = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Ty = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Tz = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Rx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Rx = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Rx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Ry", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Ry = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Ry", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Rz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.Rz = ToBoundaryCondition(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "Rz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (pointNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                point.AdditionalParameters = ToKeyValues(pointNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return point;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarEndConnectivity" />.
        /// </summary>
        public static BarEndConnectivity ToBarEndConnectivity(this XElement barendconnectivityNode)
        {
            var barendconnectivity = new BarEndConnectivity();
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Nx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.Nx = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Nx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Vy", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.Vy = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Vy", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Vz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.Vz = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Vz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Mx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.Mx = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Mx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "My", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.My = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "My", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Mz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barendconnectivity.Mz = ToBoundaryCondition(barendconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Mz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return barendconnectivity;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarEnd" />.
        /// </summary>
        public static BarEnd ToBarEnd(this XElement barendNode)
        {
            var barend = new BarEnd();
            if (barendNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PointID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barend.PointID = XmlUtilities.ConvertType<int>(barendNode.Elements().First(x => string.Compare(x.Name.ToString(), "PointID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barendNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barend.GlobalOffset = ToVector3(barendNode.Elements().First(x => string.Compare(x.Name.ToString(), "GlobalOffset", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalOffset", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barend.LocalOffset = ToVector3(barendNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalOffset", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barendNode.Elements().Any(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barend.CardinalPoint = (BarCardinalPoint)Enum.Parse(typeof(BarCardinalPoint), barendNode.Elements().First(x => string.Compare(x.Name.ToString(), "CardinalPoint", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barendNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Connectivity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                barend.Connectivity = ToBarEndConnectivity(barendNode.Elements().First(x => string.Compare(x.Name.ToString(), "Connectivity", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return barend;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bar" />.
        /// </summary>
        public static Bar ToAnalysisGeometryBar(this XElement barNode)
        {
            var bar = new Bar();
            if (barNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.ID = XmlUtilities.ConvertType<int>(barNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.PhysicalID = XmlUtilities.ConvertType<int>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SectionID = XmlUtilities.ConvertType<Guid>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in barNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    bar.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Name = ToAliasedString(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.BarType = (BarType)Enum.Parse(typeof(BarType), barNode.Elements().First(x => string.Compare(x.Name.ToString(), "BarType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalParentType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.PhysicalParentType = (PhysicalParentType)Enum.Parse(typeof(PhysicalParentType), barNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalParentType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.LocalCS = ToCoordinateSystem(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Begin = ToBarEnd(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Begin", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.End = ToBarEnd(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "End", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.IsSupportedAlongLocalCS = XmlUtilities.ConvertType<bool>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SupportAngle", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SupportAngle = XmlUtilities.ConvertType<double>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SupportAngle", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SectionMirroredAroundZAxis = XmlUtilities.ConvertType<bool>(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionMirroredAroundZAxis", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SupportType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.SupportType = (SupportType)Enum.Parse(typeof(SupportType), barNode.Elements().First(x => string.Compare(x.Name.ToString(), "SupportType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Tx = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Ty = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Tz = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Rx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Rx = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Rx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Ry", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Ry = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Ry", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Rz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Rz = ToBoundaryCondition(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Rz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Soil", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.Soil = ToSoilSupport(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "Soil", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (barNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bar.AdditionalParameters = ToKeyValues(barNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return bar;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Plate" />.
        /// </summary>
        public static Plate ToAnalysisGeometryPlate(this XElement plateNode)
        {
            var plate = new Plate();
            if (plateNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.ID = XmlUtilities.ConvertType<int>(plateNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.PhysicalID = XmlUtilities.ConvertType<int>(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.SectionID = XmlUtilities.ConvertType<Guid>(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "SectionID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plateNode.Elements().Where(x => string.Compare(x.Name.ToString(), "MaterialOverrides", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plate.MaterialOverrides.Add(ToGuidMapItem(elem));
                }
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PhysicalParentType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.PhysicalParentType = (PhysicalParentType)Enum.Parse(typeof(PhysicalParentType), plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "PhysicalParentType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Name = ToAliasedString(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.LocalCS = ToCoordinateSystem(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "LocalCS", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "InternalOpenings", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plateNode.Elements().Where(x => string.Compare(x.Name.ToString(), "InternalOpenings", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plate.InternalOpenings.Add(ToAnalysisGeometryPolygon(elem));
                }
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Edges", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plateNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Edges", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plate.Edges.Add(ToPlateEdge(elem));
                }
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.IsSupportedAlongLocalCS = XmlUtilities.ConvertType<bool>(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "IsSupportedAlongLocalCS", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "SupportType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.SupportType = (SupportType)Enum.Parse(typeof(SupportType), plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "SupportType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Tx = ToBoundaryCondition(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Ty = ToBoundaryCondition(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Ty", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Tz = ToBoundaryCondition(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Tz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Soil", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.Soil = ToSoilSupport(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "Soil", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateNode.Elements().Any(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plate.AdditionalParameters = ToKeyValues(plateNode.Elements().First(x => string.Compare(x.Name.ToString(), "AdditionalParameters", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return plate;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlateEdgeConnectivity" />.
        /// </summary>
        public static PlateEdgeConnectivity ToPlateEdgeConnectivity(this XElement plateedgeconnectivityNode)
        {
            var plateedgeconnectivity = new PlateEdgeConnectivity();
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Normal", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.Normal = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Normal", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "InPlaneShear", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.InPlaneShear = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "InPlaneShear", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "OutOfPlaneShear", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.OutOfPlaneShear = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "OutOfPlaneShear", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Mx", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.Mx = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Mx", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "My", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.My = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "My", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plateedgeconnectivityNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Mz", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedgeconnectivity.Mz = ToBoundaryCondition(plateedgeconnectivityNode.Elements().First(x => string.Compare(x.Name.ToString(), "Mz", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return plateedgeconnectivity;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarGroup" />.
        /// </summary>
        public static BarGroup ToBarGroup(this XElement bargroupNode)
        {
            var bargroup = new BarGroup();
            if (bargroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bargroup.ID = XmlUtilities.ConvertType<int>(bargroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (bargroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bargroup.Name = ToAliasedString(bargroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (bargroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GroupType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                bargroup.GroupType = (BarGroupType)Enum.Parse(typeof(BarGroupType), bargroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "GroupType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (bargroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BarIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in bargroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "BarIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    bargroup.BarIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return bargroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlateGroup" />.
        /// </summary>
        public static PlateGroup ToPlateGroup(this XElement plategroupNode)
        {
            var plategroup = new PlateGroup();
            if (plategroupNode.Attributes().Any(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plategroup.ID = XmlUtilities.ConvertType<int>(plategroupNode.Attributes().First(x => string.Compare(x.Name.ToString(), "ID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plategroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plategroup.Name = ToAliasedString(plategroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "Name", StringComparison.InvariantCultureIgnoreCase) == 0));
            }
            if (plategroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "GroupType", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plategroup.GroupType = (PlateGroupType)Enum.Parse(typeof(PlateGroupType), plategroupNode.Elements().First(x => string.Compare(x.Name.ToString(), "GroupType", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plategroupNode.Elements().Any(x => string.Compare(x.Name.ToString(), "PlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in plategroupNode.Elements().Where(x => string.Compare(x.Name.ToString(), "PlateIDs", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    plategroup.PlateIDs.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return plategroup;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlateEdge" />.
        /// </summary>
        public static PlateEdge ToPlateEdge(this XElement plateedgeNode)
        {
            var plateedge = new PlateEdge();
            if (plateedgeNode.Elements().Any(x => string.Compare(x.Name.ToString(), "BeginPointID", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedge.BeginPointID = XmlUtilities.ConvertType<int>(plateedgeNode.Elements().First(x => string.Compare(x.Name.ToString(), "BeginPointID", StringComparison.InvariantCultureIgnoreCase) == 0).Value);
            }
            if (plateedgeNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Connectivity", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                plateedge.Connectivity = ToPlateEdgeConnectivity(plateedgeNode.Elements().First(x => string.Compare(x.Name.ToString(), "Connectivity", StringComparison.InvariantCultureIgnoreCase) == 0));
            }

            return plateedge;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Polygon" />.
        /// </summary>
        public static Polygon ToAnalysisGeometryPolygon(this XElement polygonNode)
        {
            var polygon = new Polygon();
            if (polygonNode.Elements().Any(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                foreach (var elem in polygonNode.Elements().Where(x => string.Compare(x.Name.ToString(), "Vertices", StringComparison.InvariantCultureIgnoreCase) == 0).Elements())
                {
                    polygon.Vertices.Add(XmlUtilities.ConvertType<int>(elem.Value));
                }
            }

            return polygon;
        }
    }
}
