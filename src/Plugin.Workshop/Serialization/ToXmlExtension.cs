using System.Xml.Linq;
using BuildSoft.UBSM;
using BuildSoft.UBSM.Analysis.Fire;
using BuildSoft.UBSM.Analysis.Loads;
using BuildSoft.UBSM.Analysis.Results;
using BuildSoft.UBSM.General;
using BuildSoft.UBSM.Math;
using BuildSoft.UBSM.Physical;
using BuildSoft.UBSM.Physical.Connections;
using BuildSoft.UBSM.Physical.Geometry;
using BuildSoft.UBSM.Visualisation;

namespace Plugin.Workshop.Serialization
{
    public static class ToXmlExtension
    {
        /// <summary>
        /// Automatically generated converter method for <see cref="Structure" />.
        /// </summary>
        public static XElement ToXml(this Structure structure, string nodeName)
        {
            var defaultValues = new Structure();
            var structureNode = new XElement(nodeName);
            structureNode.Add(new XAttribute("Version", "1.1"));
            if (!structure.Name.IsEqualTo(defaultValues.Name))
            {
                structureNode.Add(structure.Name.ToXml("Name"));
            }

            if (!structure.ID.IsEqualTo(defaultValues.ID))
            {
                structureNode.Add(new XAttribute("ID", structure.ID.ToString<System.Guid>()));
            }

            if (!structure.PhysicalModel.IsEqualTo(defaultValues.PhysicalModel))
            {
                structureNode.Add(structure.PhysicalModel.ToXml("PhysicalModel"));
            }

            if (!structure.AnalysisModels.IsEqualTo(defaultValues.AnalysisModels))
            {
                if (structure.AnalysisModels.Count != 0)
                {
                    var analysisModelsNode = new XElement("AnalysisModels");
                    foreach (var item in structure.AnalysisModels)
                    {
                        analysisModelsNode.Add(ToXml(item, "Model"));
                    }
                    structureNode.Add(analysisModelsNode);
                }
            }

            if (!structure.Visualisation.IsEqualTo(defaultValues.Visualisation))
            {
                structureNode.Add(structure.Visualisation.ToXml("Visualisation"));
            }

            return structureNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Color" />.
        /// </summary>
        public static XElement ToXml(this Color color, string nodeName)
        {
            var defaultValues = new Color();
            var colorNode = new XElement(nodeName);
            if (!color.R.IsEqualTo(defaultValues.R))
            {
                colorNode.Add(new XElement("R", color.R));
            }

            if (!color.G.IsEqualTo(defaultValues.G))
            {
                colorNode.Add(new XElement("G", color.G));
            }

            if (!color.B.IsEqualTo(defaultValues.B))
            {
                colorNode.Add(new XElement("B", color.B));
            }

            if (!color.Alpha.IsEqualTo(defaultValues.Alpha))
            {
                colorNode.Add(new XElement("Alpha", color.Alpha));
            }

            return colorNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Layer" />.
        /// </summary>
        public static XElement ToXml(this Layer layer, string nodeName)
        {
            var defaultValues = new Layer();
            var layerNode = new XElement(nodeName);
            if (!layer.ID.IsEqualTo(defaultValues.ID))
            {
                layerNode.Add(new XAttribute("ID", layer.ID.ToString<int>()));
            }

            if (!layer.Locked.IsEqualTo(defaultValues.Locked))
            {
                layerNode.Add(new XElement("Locked", layer.Locked));
            }

            if (!layer.Hidden.IsEqualTo(defaultValues.Hidden))
            {
                layerNode.Add(new XElement("Hidden", layer.Hidden));
            }

            if (!layer.DefaultSelectedColor.IsEqualTo(defaultValues.DefaultSelectedColor))
            {
                layerNode.Add(layer.DefaultSelectedColor.ToXml("DefaultSelectedColor"));
            }

            if (!layer.DefaultColor.IsEqualTo(defaultValues.DefaultColor))
            {
                layerNode.Add(layer.DefaultColor.ToXml("DefaultColor"));
            }

            if (!layer.Name.IsEqualTo(defaultValues.Name))
            {
                layerNode.Add(layer.Name.ToXml("Name"));
            }

            return layerNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ElementInformation" />.
        /// </summary>
        public static XElement ToXml(this ElementInformation elementinformation, string nodeName)
        {
            var defaultValues = new ElementInformation();
            var elementInformationNode = new XElement(nodeName);
            if (!elementinformation.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                elementInformationNode.Add(new XElement("ReferenceID", elementinformation.ReferenceID));
            }

            if (!elementinformation.SelectedColor.IsEqualTo(defaultValues.SelectedColor))
            {
                elementInformationNode.Add(elementinformation.SelectedColor.ToXml("SelectedColor"));
            }

            if (!elementinformation.Color.IsEqualTo(defaultValues.Color))
            {
                elementInformationNode.Add(elementinformation.Color.ToXml("Color"));
            }

            if (!elementinformation.Visibility.IsEqualTo(defaultValues.Visibility))
            {
                elementInformationNode.Add(new XElement("Visibility", elementinformation.Visibility));
            }

            if (!elementinformation.LayerID.IsEqualTo(defaultValues.LayerID))
            {
                elementInformationNode.Add(new XElement("LayerID", elementinformation.LayerID));
            }

            if (!elementinformation.ExtensionData.IsEqualTo(defaultValues.ExtensionData))
            {
                elementInformationNode.Add(elementinformation.ExtensionData.ToXml("ExtensionData"));
            }

            return elementInformationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PhysicalVisualisation" />.
        /// </summary>
        public static XElement ToXml(this PhysicalVisualisation physicalvisualisation, string nodeName)
        {
            var defaultValues = new PhysicalVisualisation();
            var physicalVisualisationNode = new XElement(nodeName);
            if (!physicalvisualisation.Bars.IsEqualTo(defaultValues.Bars))
            {
                if (physicalvisualisation.Bars.Count != 0)
                {
                    var barsNode = new XElement("Bars");
                    foreach (var item in physicalvisualisation.Bars)
                    {
                        barsNode.Add(ToXml(item, "ElementInformation"));
                    }
                    physicalVisualisationNode.Add(barsNode);
                }
            }

            if (!physicalvisualisation.PolyBars.IsEqualTo(defaultValues.PolyBars))
            {
                if (physicalvisualisation.PolyBars.Count != 0)
                {
                    var polyBarsNode = new XElement("PolyBars");
                    foreach (var item in physicalvisualisation.PolyBars)
                    {
                        polyBarsNode.Add(ToXml(item, "ElementInformation"));
                    }
                    physicalVisualisationNode.Add(polyBarsNode);
                }
            }

            if (!physicalvisualisation.Plates.IsEqualTo(defaultValues.Plates))
            {
                if (physicalvisualisation.Plates.Count != 0)
                {
                    var platesNode = new XElement("Plates");
                    foreach (var item in physicalvisualisation.Plates)
                    {
                        platesNode.Add(ToXml(item, "ElementInformation"));
                    }
                    physicalVisualisationNode.Add(platesNode);
                }
            }

            if (!physicalvisualisation.Footings.IsEqualTo(defaultValues.Footings))
            {
                if (physicalvisualisation.Footings.Count != 0)
                {
                    var footingsNode = new XElement("Footings");
                    foreach (var item in physicalvisualisation.Footings)
                    {
                        footingsNode.Add(ToXml(item, "ElementInformation"));
                    }
                    physicalVisualisationNode.Add(footingsNode);
                }
            }

            return physicalVisualisationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnalysisVisualisation" />.
        /// </summary>
        public static XElement ToXml(this AnalysisVisualisation analysisvisualisation, string nodeName)
        {
            var defaultValues = new AnalysisVisualisation();
            var analysisVisualisationNode = new XElement(nodeName);
            if (!analysisvisualisation.ModelID.IsEqualTo(defaultValues.ModelID))
            {
                analysisVisualisationNode.Add(new XElement("ModelID", analysisvisualisation.ModelID));
            }

            if (!analysisvisualisation.Points.IsEqualTo(defaultValues.Points))
            {
                if (analysisvisualisation.Points.Count != 0)
                {
                    var pointsNode = new XElement("Points");
                    foreach (var item in analysisvisualisation.Points)
                    {
                        pointsNode.Add(ToXml(item, "ElementInformation"));
                    }
                    analysisVisualisationNode.Add(pointsNode);
                }
            }

            if (!analysisvisualisation.Bars.IsEqualTo(defaultValues.Bars))
            {
                if (analysisvisualisation.Bars.Count != 0)
                {
                    var barsNode = new XElement("Bars");
                    foreach (var item in analysisvisualisation.Bars)
                    {
                        barsNode.Add(ToXml(item, "ElementInformation"));
                    }
                    analysisVisualisationNode.Add(barsNode);
                }
            }

            if (!analysisvisualisation.Plates.IsEqualTo(defaultValues.Plates))
            {
                if (analysisvisualisation.Plates.Count != 0)
                {
                    var platesNode = new XElement("Plates");
                    foreach (var item in analysisvisualisation.Plates)
                    {
                        platesNode.Add(ToXml(item, "ElementInformation"));
                    }
                    analysisVisualisationNode.Add(platesNode);
                }
            }

            return analysisVisualisationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DisplayOptions" />.
        /// </summary>
        public static XElement ToXml(this DisplayOptions displayoptions, string nodeName)
        {
            var defaultValues = new DisplayOptions();
            var displayOptionsNode = new XElement(nodeName);
            if (!displayoptions.Layers.IsEqualTo(defaultValues.Layers))
            {
                if (displayoptions.Layers.Count != 0)
                {
                    var layersNode = new XElement("Layers");
                    foreach (var item in displayoptions.Layers)
                    {
                        layersNode.Add(ToXml(item, "Layer"));
                    }
                    displayOptionsNode.Add(layersNode);
                }
            }

            if (!displayoptions.PhysicalModelInformation.IsEqualTo(defaultValues.PhysicalModelInformation))
            {
                displayOptionsNode.Add(displayoptions.PhysicalModelInformation.ToXml("PhysicalModelInformation"));
            }

            if (!displayoptions.AnalysisModelInformation.IsEqualTo(defaultValues.AnalysisModelInformation))
            {
                if (displayoptions.AnalysisModelInformation.Count != 0)
                {
                    var analysisModelInformationNode = new XElement("AnalysisModelInformation");
                    foreach (var item in displayoptions.AnalysisModelInformation)
                    {
                        analysisModelInformationNode.Add(ToXml(item, "AnalysisVisualisation"));
                    }
                    displayOptionsNode.Add(analysisModelInformationNode);
                }
            }

            return displayOptionsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Model" />.
        /// </summary>
        public static XElement ToXml(this Model model, string nodeName)
        {
            var defaultValues = new Model();
            var modelNode = new XElement(nodeName);
            if (!model.Name.IsEqualTo(defaultValues.Name))
            {
                modelNode.Add(model.Name.ToXml("Name"));
            }

            if (!model.ID.IsEqualTo(defaultValues.ID))
            {
                modelNode.Add(new XAttribute("ID", model.ID.ToString<System.Guid>()));
            }

            if (!model.Materials.IsEqualTo(defaultValues.Materials))
            {
                if (model.Materials.Count != 0)
                {
                    var materialsNode = new XElement("Materials");
                    foreach (var item in model.Materials)
                    {
                        materialsNode.Add(ToXml(item, "Material"));
                    }
                    modelNode.Add(materialsNode);
                }
            }

            if (!model.ParametricSections.IsEqualTo(defaultValues.ParametricSections))
            {
                if (model.ParametricSections.Count != 0)
                {
                    var parametricSectionsNode = new XElement("ParametricSections");
                    foreach (var item in model.ParametricSections)
                    {
                        parametricSectionsNode.Add(ToXml(item, "ParametricSection"));
                    }
                    modelNode.Add(parametricSectionsNode);
                }
            }

            if (!model.CustomSections.IsEqualTo(defaultValues.CustomSections))
            {
                if (model.CustomSections.Count != 0)
                {
                    var customSectionsNode = new XElement("CustomSections");
                    foreach (var item in model.CustomSections)
                    {
                        customSectionsNode.Add(ToXml(item, "CustomSection"));
                    }
                    modelNode.Add(customSectionsNode);
                }
            }

            if (!model.VariableSections.IsEqualTo(defaultValues.VariableSections))
            {
                if (model.VariableSections.Count != 0)
                {
                    var variableSectionsNode = new XElement("VariableSections");
                    foreach (var item in model.VariableSections)
                    {
                        variableSectionsNode.Add(ToXml(item, "VariableSection"));
                    }
                    modelNode.Add(variableSectionsNode);
                }
            }

            if (!model.PlateSections.IsEqualTo(defaultValues.PlateSections))
            {
                if (model.PlateSections.Count != 0)
                {
                    var plateSectionsNode = new XElement("PlateSections");
                    foreach (var item in model.PlateSections)
                    {
                        plateSectionsNode.Add(ToXml(item, "PlateSection"));
                    }
                    modelNode.Add(plateSectionsNode);
                }
            }

            if (!model.Bars.IsEqualTo(defaultValues.Bars))
            {
                if (model.Bars.Count != 0)
                {
                    var barsNode = new XElement("Bars");
                    foreach (var item in model.Bars)
                    {
                        barsNode.Add(ToXml(item, "Bar"));
                    }
                    modelNode.Add(barsNode);
                }
            }

            if (!model.PolyBars.IsEqualTo(defaultValues.PolyBars))
            {
                if (model.PolyBars.Count != 0)
                {
                    var polyBarsNode = new XElement("PolyBars");
                    foreach (var item in model.PolyBars)
                    {
                        polyBarsNode.Add(ToXml(item, "PolyBar"));
                    }
                    modelNode.Add(polyBarsNode);
                }
            }

            if (!model.Plates.IsEqualTo(defaultValues.Plates))
            {
                if (model.Plates.Count != 0)
                {
                    var platesNode = new XElement("Plates");
                    foreach (var item in model.Plates)
                    {
                        platesNode.Add(ToXml(item, "Plate"));
                    }
                    modelNode.Add(platesNode);
                }
            }

            if (!model.PadFootings.IsEqualTo(defaultValues.PadFootings))
            {
                if (model.PadFootings.Count != 0)
                {
                    var padFootingsNode = new XElement("PadFootings");
                    foreach (var item in model.PadFootings)
                    {
                        padFootingsNode.Add(ToXml(item, "PadFooting"));
                    }
                    modelNode.Add(padFootingsNode);
                }
            }

            if (!model.Connections.IsEqualTo(defaultValues.Connections))
            {
                if (model.Connections.Count != 0)
                {
                    var connectionsNode = new XElement("Connections");
                    foreach (var item in model.Connections)
                    {
                        connectionsNode.Add(ToXml(item, "Connection"));
                    }
                    modelNode.Add(connectionsNode);
                }
            }

            if (!model.Bolts.IsEqualTo(defaultValues.Bolts))
            {
                if (model.Bolts.Count != 0)
                {
                    var boltsNode = new XElement("Bolts");
                    foreach (var item in model.Bolts)
                    {
                        boltsNode.Add(ToXml(item, "Bolt"));
                    }
                    modelNode.Add(boltsNode);
                }
            }

            if (!model.Nuts.IsEqualTo(defaultValues.Nuts))
            {
                if (model.Nuts.Count != 0)
                {
                    var nutsNode = new XElement("Nuts");
                    foreach (var item in model.Nuts)
                    {
                        nutsNode.Add(ToXml(item, "Nut"));
                    }
                    modelNode.Add(nutsNode);
                }
            }

            if (!model.Washers.IsEqualTo(defaultValues.Washers))
            {
                if (model.Washers.Count != 0)
                {
                    var washersNode = new XElement("Washers");
                    foreach (var item in model.Washers)
                    {
                        washersNode.Add(ToXml(item, "Washer"));
                    }
                    modelNode.Add(washersNode);
                }
            }

            if (!model.AnchorBolts.IsEqualTo(defaultValues.AnchorBolts))
            {
                if (model.AnchorBolts.Count != 0)
                {
                    var anchorBoltsNode = new XElement("AnchorBolts");
                    foreach (var item in model.AnchorBolts)
                    {
                        anchorBoltsNode.Add(ToXml(item, "AnchorBolt"));
                    }
                    modelNode.Add(anchorBoltsNode);
                }
            }

            if (!model.BoltAssemblies.IsEqualTo(defaultValues.BoltAssemblies))
            {
                if (model.BoltAssemblies.Count != 0)
                {
                    var boltAssembliesNode = new XElement("BoltAssemblies");
                    foreach (var item in model.BoltAssemblies)
                    {
                        boltAssembliesNode.Add(ToXml(item, "BoltAssembly"));
                    }
                    modelNode.Add(boltAssembliesNode);
                }
            }

            if (!model.AnchorBoltAssemblies.IsEqualTo(defaultValues.AnchorBoltAssemblies))
            {
                if (model.AnchorBoltAssemblies.Count != 0)
                {
                    var anchorBoltAssembliesNode = new XElement("AnchorBoltAssemblies");
                    foreach (var item in model.AnchorBoltAssemblies)
                    {
                        anchorBoltAssembliesNode.Add(ToXml(item, "AnchorBoltAssembly"));
                    }
                    modelNode.Add(anchorBoltAssembliesNode);
                }
            }

            return modelNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Material" />.
        /// </summary>
        public static XElement ToXml(this Material material, string nodeName)
        {
            var defaultValues = new Material();
            var materialNode = new XElement(nodeName);
            if (!material.ID.IsEqualTo(defaultValues.ID))
            {
                materialNode.Add(new XAttribute("ID", material.ID.ToString<System.Guid>()));
            }

            if (!material.Name.IsEqualTo(defaultValues.Name))
            {
                materialNode.Add(material.Name.ToXml("Name"));
            }

            if (!material.MaterialType.IsEqualTo(defaultValues.MaterialType))
            {
                materialNode.Add(new XElement("MaterialType", material.MaterialType));
            }

            if (!material.Version.IsEqualTo(defaultValues.Version))
            {
                materialNode.Add(new XElement("Version", material.Version));
            }

            if (!material.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                materialNode.Add(new XElement("LastChanged", material.LastChanged));
            }

            if (!material.Status.IsEqualTo(defaultValues.Status))
            {
                materialNode.Add(new XElement("Status", material.Status));
            }

            if (!material.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                materialNode.Add(new XElement("ReadOnly", material.ReadOnly));
            }

            return materialNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Measurement" />.
        /// </summary>
        public static XElement ToXml(this Measurement measurement, string nodeName)
        {
            var defaultValues = new Measurement();
            var measurementNode = new XElement(nodeName);
            if (!measurement.ID.IsEqualTo(defaultValues.ID))
            {
                measurementNode.Add(new XAttribute("ID", measurement.ID.ToString<int>()));
            }

            if (!measurement.Name.IsEqualTo(defaultValues.Name))
            {
                measurementNode.Add(new XAttribute("Name", measurement.Name.ToString<string>()));
            }

            if (!measurement.Value.IsEqualTo(defaultValues.Value))
            {
                measurementNode.Add(new XAttribute("Value", measurement.Value.ToString<double>()));
            }

            if (!measurement.Quantity.IsEqualTo(defaultValues.Quantity))
            {
                measurementNode.Add(new XAttribute("Quantity", measurement.Quantity.ToString<Quantity>()));
            }

            return measurementNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ParametricSection" />.
        /// </summary>
        public static XElement ToXml(this ParametricSection parametricsection, string nodeName)
        {
            var defaultValues = new ParametricSection();
            var parametricSectionNode = new XElement(nodeName);
            if (!parametricsection.ID.IsEqualTo(defaultValues.ID))
            {
                parametricSectionNode.Add(new XAttribute("ID", parametricsection.ID.ToString<System.Guid>()));
            }

            if (!parametricsection.Name.IsEqualTo(defaultValues.Name))
            {
                parametricSectionNode.Add(parametricsection.Name.ToXml("Name"));
            }

            if (!parametricsection.SectionType.IsEqualTo(defaultValues.SectionType))
            {
                parametricSectionNode.Add(new XElement("SectionType", parametricsection.SectionType));
            }

            if (!parametricsection.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                parametricSectionNode.Add(new XElement("MaterialID", parametricsection.MaterialID));
            }

            if (!parametricsection.ProductionMethod.IsEqualTo(defaultValues.ProductionMethod))
            {
                parametricSectionNode.Add(new XElement("ProductionMethod", parametricsection.ProductionMethod));
            }

            if (!parametricsection.Measurements.IsEqualTo(defaultValues.Measurements))
            {
                if (parametricsection.Measurements.Count != 0)
                {
                    var measurementsNode = new XElement("Measurements");
                    foreach (var item in parametricsection.Measurements)
                    {
                        measurementsNode.Add(ToXml(item, "Measurement"));
                    }
                    parametricSectionNode.Add(measurementsNode);
                }
            }

            if (!parametricsection.UserDefinedGeometryInstructions.IsEqualTo(defaultValues.UserDefinedGeometryInstructions))
            {
                if (parametricsection.UserDefinedGeometryInstructions.Count != 0)
                {
                    var userDefinedGeometryInstructionsNode = new XElement("UserDefinedGeometryInstructions");
                    foreach (var item in parametricsection.UserDefinedGeometryInstructions)
                    {
                        userDefinedGeometryInstructionsNode.Add(new XElement("Item", item.ToString<string>()));
                    }
                    parametricSectionNode.Add(userDefinedGeometryInstructionsNode);
                }
            }

            if (!parametricsection.Version.IsEqualTo(defaultValues.Version))
            {
                parametricSectionNode.Add(new XElement("Version", parametricsection.Version));
            }

            if (!parametricsection.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                parametricSectionNode.Add(new XElement("LastChanged", parametricsection.LastChanged));
            }

            if (!parametricsection.Status.IsEqualTo(defaultValues.Status))
            {
                parametricSectionNode.Add(new XElement("Status", parametricsection.Status));
            }

            if (!parametricsection.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                parametricSectionNode.Add(new XElement("ReadOnly", parametricsection.ReadOnly));
            }

            return parametricSectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PointRegion" />.
        /// </summary>
        public static XElement ToXml(this PointRegion pointregion, string nodeName)
        {
            var defaultValues = new PointRegion();
            var pointRegionNode = new XElement(nodeName);
            if (!pointregion.ID.IsEqualTo(defaultValues.ID))
            {
                pointRegionNode.Add(new XAttribute("ID", pointregion.ID.ToString<int>()));
            }

            if (!pointregion.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                pointRegionNode.Add(new XElement("MaterialID", pointregion.MaterialID));
            }

            if (!pointregion.Radius.IsEqualTo(defaultValues.Radius))
            {
                pointRegionNode.Add(new XElement("Radius", pointregion.Radius));
            }

            if (!pointregion.Location.IsEqualTo(defaultValues.Location))
            {
                pointRegionNode.Add(pointregion.Location.ToXml("Location"));
            }

            if (!pointregion.IsOpening.IsEqualTo(defaultValues.IsOpening))
            {
                pointRegionNode.Add(new XElement("IsOpening", pointregion.IsOpening));
            }

            if (!pointregion.Tags.IsEqualTo(defaultValues.Tags))
            {
                if (pointregion.Tags.Count != 0)
                {
                    var tagsNode = new XElement("Tags");
                    foreach (var item in pointregion.Tags)
                    {
                        tagsNode.Add(ToXml(item, "Tag"));
                    }
                    pointRegionNode.Add(tagsNode);
                }
            }

            return pointRegionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LineRegion" />.
        /// </summary>
        public static XElement ToXml(this LineRegion lineregion, string nodeName)
        {
            var defaultValues = new LineRegion();
            var lineRegionNode = new XElement(nodeName);
            if (!lineregion.ID.IsEqualTo(defaultValues.ID))
            {
                lineRegionNode.Add(new XAttribute("ID", lineregion.ID.ToString<int>()));
            }

            if (!lineregion.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                lineRegionNode.Add(new XElement("MaterialID", lineregion.MaterialID));
            }

            if (!lineregion.IsOpening.IsEqualTo(defaultValues.IsOpening))
            {
                lineRegionNode.Add(new XElement("IsOpening", lineregion.IsOpening));
            }

            if (!lineregion.Curve.IsEqualTo(defaultValues.Curve))
            {
                lineRegionNode.Add(lineregion.Curve.ToXml("Curve"));
            }

            if (!lineregion.Thickness.IsEqualTo(defaultValues.Thickness))
            {
                lineRegionNode.Add(new XElement("Thickness", lineregion.Thickness));
            }

            if (!lineregion.Tags.IsEqualTo(defaultValues.Tags))
            {
                if (lineregion.Tags.Count != 0)
                {
                    var tagsNode = new XElement("Tags");
                    foreach (var item in lineregion.Tags)
                    {
                        tagsNode.Add(ToXml(item, "Tag"));
                    }
                    lineRegionNode.Add(tagsNode);
                }
            }

            return lineRegionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SurfaceRegion" />.
        /// </summary>
        public static XElement ToXml(this SurfaceRegion surfaceregion, string nodeName)
        {
            var defaultValues = new SurfaceRegion();
            var surfaceRegionNode = new XElement(nodeName);
            if (!surfaceregion.ID.IsEqualTo(defaultValues.ID))
            {
                surfaceRegionNode.Add(new XAttribute("ID", surfaceregion.ID.ToString<int>()));
            }

            if (!surfaceregion.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                surfaceRegionNode.Add(new XElement("MaterialID", surfaceregion.MaterialID));
            }

            if (!surfaceregion.Contour.IsEqualTo(defaultValues.Contour))
            {
                if (surfaceregion.Contour.Count != 0)
                {
                    var contourNode = new XElement("Contour");
                    foreach (var item in surfaceregion.Contour)
                    {
                        contourNode.Add(ToXml(item, "BezierCurve2D"));
                    }
                    surfaceRegionNode.Add(contourNode);
                }
            }

            if (!surfaceregion.Triangles.IsEqualTo(defaultValues.Triangles))
            {
                if (surfaceregion.Triangles.Count != 0)
                {
                    var trianglesNode = new XElement("Triangles");
                    foreach (var item in surfaceregion.Triangles)
                    {
                        trianglesNode.Add(ToXml(item, "Triangle2D"));
                    }
                    surfaceRegionNode.Add(trianglesNode);
                }
            }

            if (!surfaceregion.IsOpening.IsEqualTo(defaultValues.IsOpening))
            {
                surfaceRegionNode.Add(new XElement("IsOpening", surfaceregion.IsOpening));
            }

            if (!surfaceregion.Tags.IsEqualTo(defaultValues.Tags))
            {
                if (surfaceregion.Tags.Count != 0)
                {
                    var tagsNode = new XElement("Tags");
                    foreach (var item in surfaceregion.Tags)
                    {
                        tagsNode.Add(ToXml(item, "Tag"));
                    }
                    surfaceRegionNode.Add(tagsNode);
                }
            }

            return surfaceRegionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSectionPart" />.
        /// </summary>
        public static XElement ToXml(this CustomSectionPart customsectionpart, string nodeName)
        {
            var defaultValues = new CustomSectionPart();
            var customSectionPartNode = new XElement(nodeName);
            if (!customsectionpart.ID.IsEqualTo(defaultValues.ID))
            {
                customSectionPartNode.Add(new XAttribute("ID", customsectionpart.ID.ToString<int>()));
            }

            if (!customsectionpart.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                customSectionPartNode.Add(new XElement("SectionID", customsectionpart.SectionID));
            }

            if (!customsectionpart.Version.IsEqualTo(defaultValues.Version))
            {
                customSectionPartNode.Add(new XElement("Version", customsectionpart.Version));
            }

            if (!customsectionpart.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                customSectionPartNode.Add(customsectionpart.ReferencePoint.ToXml("ReferencePoint"));
            }

            if (!customsectionpart.Angle.IsEqualTo(defaultValues.Angle))
            {
                customSectionPartNode.Add(new XElement("Angle", customsectionpart.Angle));
            }

            if (!customsectionpart.IsOpening.IsEqualTo(defaultValues.IsOpening))
            {
                customSectionPartNode.Add(new XElement("IsOpening", customsectionpart.IsOpening));
            }

            if (!customsectionpart.MirroredZ.IsEqualTo(defaultValues.MirroredZ))
            {
                customSectionPartNode.Add(new XElement("MirroredZ", customsectionpart.MirroredZ));
            }

            if (!customsectionpart.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (customsectionpart.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in customsectionpart.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    customSectionPartNode.Add(materialOverridesNode);
                }
            }

            if (!customsectionpart.Tags.IsEqualTo(defaultValues.Tags))
            {
                if (customsectionpart.Tags.Count != 0)
                {
                    var tagsNode = new XElement("Tags");
                    foreach (var item in customsectionpart.Tags)
                    {
                        tagsNode.Add(ToXml(item, "Tag"));
                    }
                    customSectionPartNode.Add(tagsNode);
                }
            }

            return customSectionPartNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSection" />.
        /// </summary>
        public static XElement ToXml(this CustomSection customsection, string nodeName)
        {
            var defaultValues = new CustomSection();
            var customSectionNode = new XElement(nodeName);
            if (!customsection.ID.IsEqualTo(defaultValues.ID))
            {
                customSectionNode.Add(new XAttribute("ID", customsection.ID.ToString<System.Guid>()));
            }

            if (!customsection.Name.IsEqualTo(defaultValues.Name))
            {
                customSectionNode.Add(customsection.Name.ToXml("Name"));
            }

            if (!customsection.ProductionMethod.IsEqualTo(defaultValues.ProductionMethod))
            {
                customSectionNode.Add(new XElement("ProductionMethod", customsection.ProductionMethod));
            }

            if (!customsection.Points.IsEqualTo(defaultValues.Points))
            {
                if (customsection.Points.Count != 0)
                {
                    var pointsNode = new XElement("Points");
                    foreach (var item in customsection.Points)
                    {
                        pointsNode.Add(ToXml(item, "PointRegion"));
                    }
                    customSectionNode.Add(pointsNode);
                }
            }

            if (!customsection.Lines.IsEqualTo(defaultValues.Lines))
            {
                if (customsection.Lines.Count != 0)
                {
                    var linesNode = new XElement("Lines");
                    foreach (var item in customsection.Lines)
                    {
                        linesNode.Add(ToXml(item, "LineRegion"));
                    }
                    customSectionNode.Add(linesNode);
                }
            }

            if (!customsection.Surfaces.IsEqualTo(defaultValues.Surfaces))
            {
                if (customsection.Surfaces.Count != 0)
                {
                    var surfacesNode = new XElement("Surfaces");
                    foreach (var item in customsection.Surfaces)
                    {
                        surfacesNode.Add(ToXml(item, "SurfaceRegion"));
                    }
                    customSectionNode.Add(surfacesNode);
                }
            }

            if (!customsection.Sections.IsEqualTo(defaultValues.Sections))
            {
                if (customsection.Sections.Count != 0)
                {
                    var sectionsNode = new XElement("Sections");
                    foreach (var item in customsection.Sections)
                    {
                        sectionsNode.Add(ToXml(item, "CustomSectionPart"));
                    }
                    customSectionNode.Add(sectionsNode);
                }
            }

            if (!customsection.Version.IsEqualTo(defaultValues.Version))
            {
                customSectionNode.Add(new XElement("Version", customsection.Version));
            }

            if (!customsection.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                customSectionNode.Add(new XElement("LastChanged", customsection.LastChanged));
            }

            if (!customsection.Status.IsEqualTo(defaultValues.Status))
            {
                customSectionNode.Add(new XElement("Status", customsection.Status));
            }

            if (!customsection.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                customSectionNode.Add(new XElement("ReadOnly", customsection.ReadOnly));
            }

            return customSectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CorrespondingPoint" />.
        /// </summary>
        public static XElement ToXml(this CorrespondingPoint correspondingpoint, string nodeName)
        {
            var defaultValues = new CorrespondingPoint();
            var correspondingPointNode = new XElement(nodeName);
            if (!correspondingpoint.ID.IsEqualTo(defaultValues.ID))
            {
                correspondingPointNode.Add(new XAttribute("ID", correspondingpoint.ID.ToString<int>()));
            }

            if (!correspondingpoint.IsReversed.IsEqualTo(defaultValues.IsReversed))
            {
                correspondingPointNode.Add(new XElement("IsReversed", correspondingpoint.IsReversed));
            }

            if (!correspondingpoint.BeginPoint.IsEqualTo(defaultValues.BeginPoint))
            {
                correspondingPointNode.Add(correspondingpoint.BeginPoint.ToXml("BeginPoint"));
            }

            if (!correspondingpoint.EndPoints.IsEqualTo(defaultValues.EndPoints))
            {
                if (correspondingpoint.EndPoints.Count != 0)
                {
                    var endPointsNode = new XElement("EndPoints");
                    foreach (var item in correspondingpoint.EndPoints)
                    {
                        endPointsNode.Add(ToXml(item, "Vector2"));
                    }
                    correspondingPointNode.Add(endPointsNode);
                }
            }

            return correspondingPointNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SectionConnection" />.
        /// </summary>
        public static XElement ToXml(this SectionConnection sectionconnection, string nodeName)
        {
            var defaultValues = new SectionConnection();
            var sectionConnectionNode = new XElement(nodeName);
            if (!sectionconnection.ID.IsEqualTo(defaultValues.ID))
            {
                sectionConnectionNode.Add(new XAttribute("ID", sectionconnection.ID.ToString<int>()));
            }

            if (!sectionconnection.IsPredefined.IsEqualTo(defaultValues.IsPredefined))
            {
                sectionConnectionNode.Add(new XElement("IsPredefined", sectionconnection.IsPredefined));
            }

            if (!sectionconnection.CustomDefinition.IsEqualTo(defaultValues.CustomDefinition))
            {
                if (sectionconnection.CustomDefinition.Count != 0)
                {
                    var customDefinitionNode = new XElement("CustomDefinition");
                    foreach (var item in sectionconnection.CustomDefinition)
                    {
                        customDefinitionNode.Add(ToXml(item, "CorrespondingPoint"));
                    }
                    sectionConnectionNode.Add(customDefinitionNode);
                }
            }

            return sectionConnectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="VariableSection" />.
        /// </summary>
        public static XElement ToXml(this VariableSection variablesection, string nodeName)
        {
            var defaultValues = new VariableSection();
            var variableSectionNode = new XElement(nodeName);
            if (!variablesection.ID.IsEqualTo(defaultValues.ID))
            {
                variableSectionNode.Add(new XAttribute("ID", variablesection.ID.ToString<System.Guid>()));
            }

            if (!variablesection.Name.IsEqualTo(defaultValues.Name))
            {
                variableSectionNode.Add(variablesection.Name.ToXml("Name"));
            }

            if (!variablesection.BeginSectionID.IsEqualTo(defaultValues.BeginSectionID))
            {
                variableSectionNode.Add(new XElement("BeginSectionID", variablesection.BeginSectionID));
            }

            if (!variablesection.BeginSectionVersion.IsEqualTo(defaultValues.BeginSectionVersion))
            {
                variableSectionNode.Add(new XElement("BeginSectionVersion", variablesection.BeginSectionVersion));
            }

            if (!variablesection.EndSectionID.IsEqualTo(defaultValues.EndSectionID))
            {
                variableSectionNode.Add(new XElement("EndSectionID", variablesection.EndSectionID));
            }

            if (!variablesection.EndSectionVersion.IsEqualTo(defaultValues.EndSectionVersion))
            {
                variableSectionNode.Add(new XElement("EndSectionVersion", variablesection.EndSectionVersion));
            }

            if (!variablesection.Connection.IsEqualTo(defaultValues.Connection))
            {
                variableSectionNode.Add(variablesection.Connection.ToXml("Connection"));
            }

            if (!variablesection.Rotation.IsEqualTo(defaultValues.Rotation))
            {
                variableSectionNode.Add(new XElement("Rotation", variablesection.Rotation));
            }

            if (!variablesection.Version.IsEqualTo(defaultValues.Version))
            {
                variableSectionNode.Add(new XElement("Version", variablesection.Version));
            }

            if (!variablesection.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                variableSectionNode.Add(new XElement("LastChanged", variablesection.LastChanged));
            }

            if (!variablesection.Status.IsEqualTo(defaultValues.Status))
            {
                variableSectionNode.Add(new XElement("Status", variablesection.Status));
            }

            if (!variablesection.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                variableSectionNode.Add(new XElement("ReadOnly", variablesection.ReadOnly));
            }

            return variableSectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlateSection" />.
        /// </summary>
        public static XElement ToXml(this PlateSection platesection, string nodeName)
        {
            var defaultValues = new PlateSection();
            var plateSectionNode = new XElement(nodeName);
            if (!platesection.ID.IsEqualTo(defaultValues.ID))
            {
                plateSectionNode.Add(new XAttribute("ID", platesection.ID.ToString<System.Guid>()));
            }

            if (!platesection.Name.IsEqualTo(defaultValues.Name))
            {
                plateSectionNode.Add(platesection.Name.ToXml("Name"));
            }

            if (!platesection.SectionXID.IsEqualTo(defaultValues.SectionXID))
            {
                plateSectionNode.Add(new XElement("SectionXID", platesection.SectionXID));
            }

            if (!platesection.SectionZID.IsEqualTo(defaultValues.SectionZID))
            {
                plateSectionNode.Add(new XElement("SectionZID", platesection.SectionZID));
            }

            if (!platesection.SectionZAnchorPlane.IsEqualTo(defaultValues.SectionZAnchorPlane))
            {
                plateSectionNode.Add(new XElement("SectionZAnchorPlane", platesection.SectionZAnchorPlane));
            }

            if (!platesection.OffsetSectionZInYLocalDir.IsEqualTo(defaultValues.OffsetSectionZInYLocalDir))
            {
                plateSectionNode.Add(new XElement("OffsetSectionZInYLocalDir", platesection.OffsetSectionZInYLocalDir));
            }

            if (!platesection.Version.IsEqualTo(defaultValues.Version))
            {
                plateSectionNode.Add(new XElement("Version", platesection.Version));
            }

            if (!platesection.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                plateSectionNode.Add(new XElement("LastChanged", platesection.LastChanged));
            }

            if (!platesection.Status.IsEqualTo(defaultValues.Status))
            {
                plateSectionNode.Add(new XElement("Status", platesection.Status));
            }

            if (!platesection.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                plateSectionNode.Add(new XElement("ReadOnly", platesection.ReadOnly));
            }

            return plateSectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnchorBolt" />.
        /// </summary>
        public static XElement ToXml(this AnchorBolt anchorbolt, string nodeName)
        {
            var defaultValues = new AnchorBolt();
            var anchorBoltNode = new XElement(nodeName);
            if (!anchorbolt.ID.IsEqualTo(defaultValues.ID))
            {
                anchorBoltNode.Add(new XAttribute("ID", anchorbolt.ID.ToString<System.Guid>()));
            }

            if (!anchorbolt.Name.IsEqualTo(defaultValues.Name))
            {
                anchorBoltNode.Add(anchorbolt.Name.ToXml("Name"));
            }

            if (!anchorbolt.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                anchorBoltNode.Add(new XElement("MaterialID", anchorbolt.MaterialID));
            }

            if (!anchorbolt.Diameter.IsEqualTo(defaultValues.Diameter))
            {
                anchorBoltNode.Add(new XElement("Diameter", anchorbolt.Diameter));
            }

            if (!anchorbolt.Length.IsEqualTo(defaultValues.Length))
            {
                anchorBoltNode.Add(new XElement("Length", anchorbolt.Length));
            }

            if (!anchorbolt.ThreadMethod.IsEqualTo(defaultValues.ThreadMethod))
            {
                anchorBoltNode.Add(new XElement("ThreadMethod", anchorbolt.ThreadMethod));
            }

            if (!anchorbolt.ThreadType.IsEqualTo(defaultValues.ThreadType))
            {
                anchorBoltNode.Add(new XElement("ThreadType", anchorbolt.ThreadType));
            }

            if (!anchorbolt.ThreadLength.IsEqualTo(defaultValues.ThreadLength))
            {
                anchorBoltNode.Add(new XElement("ThreadLength", anchorbolt.ThreadLength));
            }

            if (!anchorbolt.ThreadPitch.IsEqualTo(defaultValues.ThreadPitch))
            {
                anchorBoltNode.Add(new XElement("ThreadPitch", anchorbolt.ThreadPitch));
            }

            if (!anchorbolt.AnchorType.IsEqualTo(defaultValues.AnchorType))
            {
                anchorBoltNode.Add(new XElement("AnchorType", anchorbolt.AnchorType));
            }

            if (!anchorbolt.Information.IsEqualTo(defaultValues.Information))
            {
                anchorBoltNode.Add(anchorbolt.Information.ToXml("Information"));
            }

            if (!anchorbolt.Version.IsEqualTo(defaultValues.Version))
            {
                anchorBoltNode.Add(new XElement("Version", anchorbolt.Version));
            }

            if (!anchorbolt.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                anchorBoltNode.Add(new XElement("LastChanged", anchorbolt.LastChanged));
            }

            if (!anchorbolt.Status.IsEqualTo(defaultValues.Status))
            {
                anchorBoltNode.Add(new XElement("Status", anchorbolt.Status));
            }

            if (!anchorbolt.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                anchorBoltNode.Add(new XElement("ReadOnly", anchorbolt.ReadOnly));
            }

            return anchorBoltNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AnchorBoltAssembly" />.
        /// </summary>
        public static XElement ToXml(this AnchorBoltAssembly anchorboltassembly, string nodeName)
        {
            var defaultValues = new AnchorBoltAssembly();
            var anchorBoltAssemblyNode = new XElement(nodeName);
            if (!anchorboltassembly.ID.IsEqualTo(defaultValues.ID))
            {
                anchorBoltAssemblyNode.Add(new XAttribute("ID", anchorboltassembly.ID.ToString<int>()));
            }

            if (!anchorboltassembly.Name.IsEqualTo(defaultValues.Name))
            {
                anchorBoltAssemblyNode.Add(anchorboltassembly.Name.ToXml("Name"));
            }

            if (!anchorboltassembly.AnchorBoltID.IsEqualTo(defaultValues.AnchorBoltID))
            {
                anchorBoltAssemblyNode.Add(new XElement("AnchorBoltID", anchorboltassembly.AnchorBoltID));
            }

            if (!anchorboltassembly.NutIDsBasePlateBefore.IsEqualTo(defaultValues.NutIDsBasePlateBefore))
            {
                if (anchorboltassembly.NutIDsBasePlateBefore.Count != 0)
                {
                    var nutIDsBasePlateBeforeNode = new XElement("NutIDsBasePlateBefore");
                    foreach (var item in anchorboltassembly.NutIDsBasePlateBefore)
                    {
                        nutIDsBasePlateBeforeNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(nutIDsBasePlateBeforeNode);
                }
            }

            if (!anchorboltassembly.NutIDsBasePlateBehind.IsEqualTo(defaultValues.NutIDsBasePlateBehind))
            {
                if (anchorboltassembly.NutIDsBasePlateBehind.Count != 0)
                {
                    var nutIDsBasePlateBehindNode = new XElement("NutIDsBasePlateBehind");
                    foreach (var item in anchorboltassembly.NutIDsBasePlateBehind)
                    {
                        nutIDsBasePlateBehindNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(nutIDsBasePlateBehindNode);
                }
            }

            if (!anchorboltassembly.NutIDsAnchorPlateBefore.IsEqualTo(defaultValues.NutIDsAnchorPlateBefore))
            {
                if (anchorboltassembly.NutIDsAnchorPlateBefore.Count != 0)
                {
                    var nutIDsAnchorPlateBeforeNode = new XElement("NutIDsAnchorPlateBefore");
                    foreach (var item in anchorboltassembly.NutIDsAnchorPlateBefore)
                    {
                        nutIDsAnchorPlateBeforeNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(nutIDsAnchorPlateBeforeNode);
                }
            }

            if (!anchorboltassembly.NutIDsAnchorPlateBehind.IsEqualTo(defaultValues.NutIDsAnchorPlateBehind))
            {
                if (anchorboltassembly.NutIDsAnchorPlateBehind.Count != 0)
                {
                    var nutIDsAnchorPlateBehindNode = new XElement("NutIDsAnchorPlateBehind");
                    foreach (var item in anchorboltassembly.NutIDsAnchorPlateBehind)
                    {
                        nutIDsAnchorPlateBehindNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(nutIDsAnchorPlateBehindNode);
                }
            }

            if (!anchorboltassembly.WasherIDsBasePlateBefore.IsEqualTo(defaultValues.WasherIDsBasePlateBefore))
            {
                if (anchorboltassembly.WasherIDsBasePlateBefore.Count != 0)
                {
                    var washerIDsBasePlateBeforeNode = new XElement("WasherIDsBasePlateBefore");
                    foreach (var item in anchorboltassembly.WasherIDsBasePlateBefore)
                    {
                        washerIDsBasePlateBeforeNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(washerIDsBasePlateBeforeNode);
                }
            }

            if (!anchorboltassembly.WasherIDsBasePlateBehind.IsEqualTo(defaultValues.WasherIDsBasePlateBehind))
            {
                if (anchorboltassembly.WasherIDsBasePlateBehind.Count != 0)
                {
                    var washerIDsBasePlateBehindNode = new XElement("WasherIDsBasePlateBehind");
                    foreach (var item in anchorboltassembly.WasherIDsBasePlateBehind)
                    {
                        washerIDsBasePlateBehindNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(washerIDsBasePlateBehindNode);
                }
            }

            if (!anchorboltassembly.WasherIDsAnchorPlateBefore.IsEqualTo(defaultValues.WasherIDsAnchorPlateBefore))
            {
                if (anchorboltassembly.WasherIDsAnchorPlateBefore.Count != 0)
                {
                    var washerIDsAnchorPlateBeforeNode = new XElement("WasherIDsAnchorPlateBefore");
                    foreach (var item in anchorboltassembly.WasherIDsAnchorPlateBefore)
                    {
                        washerIDsAnchorPlateBeforeNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(washerIDsAnchorPlateBeforeNode);
                }
            }

            if (!anchorboltassembly.WasherIDsAnchorPlateBehind.IsEqualTo(defaultValues.WasherIDsAnchorPlateBehind))
            {
                if (anchorboltassembly.WasherIDsAnchorPlateBehind.Count != 0)
                {
                    var washerIDsAnchorPlateBehindNode = new XElement("WasherIDsAnchorPlateBehind");
                    foreach (var item in anchorboltassembly.WasherIDsAnchorPlateBehind)
                    {
                        washerIDsAnchorPlateBehindNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    anchorBoltAssemblyNode.Add(washerIDsAnchorPlateBehindNode);
                }
            }

            if (!anchorboltassembly.Information.IsEqualTo(defaultValues.Information))
            {
                anchorBoltAssemblyNode.Add(anchorboltassembly.Information.ToXml("Information"));
            }

            if (!anchorboltassembly.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (anchorboltassembly.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in anchorboltassembly.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    anchorBoltAssemblyNode.Add(materialOverridesNode);
                }
            }

            return anchorBoltAssemblyNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bolt" />.
        /// </summary>
        public static XElement ToXml(this Bolt bolt, string nodeName)
        {
            var defaultValues = new Bolt();
            var boltNode = new XElement(nodeName);
            if (!bolt.ID.IsEqualTo(defaultValues.ID))
            {
                boltNode.Add(new XAttribute("ID", bolt.ID.ToString<System.Guid>()));
            }

            if (!bolt.Name.IsEqualTo(defaultValues.Name))
            {
                boltNode.Add(bolt.Name.ToXml("Name"));
            }

            if (!bolt.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                boltNode.Add(new XElement("MaterialID", bolt.MaterialID));
            }

            if (!bolt.Diameter.IsEqualTo(defaultValues.Diameter))
            {
                boltNode.Add(new XElement("Diameter", bolt.Diameter));
            }

            if (!bolt.Length.IsEqualTo(defaultValues.Length))
            {
                boltNode.Add(new XElement("Length", bolt.Length));
            }

            if (!bolt.ThreadLength.IsEqualTo(defaultValues.ThreadLength))
            {
                boltNode.Add(new XElement("ThreadLength", bolt.ThreadLength));
            }

            if (!bolt.HeadType.IsEqualTo(defaultValues.HeadType))
            {
                boltNode.Add(new XElement("HeadType", bolt.HeadType));
            }

            if (!bolt.ThreadMethod.IsEqualTo(defaultValues.ThreadMethod))
            {
                boltNode.Add(new XElement("ThreadMethod", bolt.ThreadMethod));
            }

            if (!bolt.ThreadType.IsEqualTo(defaultValues.ThreadType))
            {
                boltNode.Add(new XElement("ThreadType", bolt.ThreadType));
            }

            if (!bolt.ThreadPitch.IsEqualTo(defaultValues.ThreadPitch))
            {
                boltNode.Add(new XElement("ThreadPitch", bolt.ThreadPitch));
            }

            if (!bolt.Information.IsEqualTo(defaultValues.Information))
            {
                boltNode.Add(bolt.Information.ToXml("Information"));
            }

            if (!bolt.Version.IsEqualTo(defaultValues.Version))
            {
                boltNode.Add(new XElement("Version", bolt.Version));
            }

            if (!bolt.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                boltNode.Add(new XElement("LastChanged", bolt.LastChanged));
            }

            if (!bolt.Status.IsEqualTo(defaultValues.Status))
            {
                boltNode.Add(new XElement("Status", bolt.Status));
            }

            if (!bolt.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                boltNode.Add(new XElement("ReadOnly", bolt.ReadOnly));
            }

            return boltNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BoltAssembly" />.
        /// </summary>
        public static XElement ToXml(this BoltAssembly boltassembly, string nodeName)
        {
            var defaultValues = new BoltAssembly();
            var boltAssemblyNode = new XElement(nodeName);
            if (!boltassembly.ID.IsEqualTo(defaultValues.ID))
            {
                boltAssemblyNode.Add(new XAttribute("ID", boltassembly.ID.ToString<int>()));
            }

            if (!boltassembly.Name.IsEqualTo(defaultValues.Name))
            {
                boltAssemblyNode.Add(boltassembly.Name.ToXml("Name"));
            }

            if (!boltassembly.BoltID.IsEqualTo(defaultValues.BoltID))
            {
                boltAssemblyNode.Add(new XElement("BoltID", boltassembly.BoltID));
            }

            if (!boltassembly.NutIDs.IsEqualTo(defaultValues.NutIDs))
            {
                if (boltassembly.NutIDs.Count != 0)
                {
                    var nutIDsNode = new XElement("NutIDs");
                    foreach (var item in boltassembly.NutIDs)
                    {
                        nutIDsNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    boltAssemblyNode.Add(nutIDsNode);
                }
            }

            if (!boltassembly.WasherIDsBolt.IsEqualTo(defaultValues.WasherIDsBolt))
            {
                if (boltassembly.WasherIDsBolt.Count != 0)
                {
                    var washerIDsBoltNode = new XElement("WasherIDsBolt");
                    foreach (var item in boltassembly.WasherIDsBolt)
                    {
                        washerIDsBoltNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    boltAssemblyNode.Add(washerIDsBoltNode);
                }
            }

            if (!boltassembly.WasherIDsNut.IsEqualTo(defaultValues.WasherIDsNut))
            {
                if (boltassembly.WasherIDsNut.Count != 0)
                {
                    var washerIDsNutNode = new XElement("WasherIDsNut");
                    foreach (var item in boltassembly.WasherIDsNut)
                    {
                        washerIDsNutNode.Add(new XElement("Item", item.ToString<System.Guid>()));
                    }
                    boltAssemblyNode.Add(washerIDsNutNode);
                }
            }

            if (!boltassembly.Information.IsEqualTo(defaultValues.Information))
            {
                boltAssemblyNode.Add(boltassembly.Information.ToXml("Information"));
            }

            if (!boltassembly.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (boltassembly.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in boltassembly.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    boltAssemblyNode.Add(materialOverridesNode);
                }
            }

            return boltAssemblyNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Connection" />.
        /// </summary>
        public static XElement ToXml(this Connection connection, string nodeName)
        {
            var defaultValues = new Connection();
            var connectionNode = new XElement(nodeName);
            if (!connection.ID.IsEqualTo(defaultValues.ID))
            {
                connectionNode.Add(new XAttribute("ID", connection.ID.ToString<int>()));
            }

            if (!connection.Name.IsEqualTo(defaultValues.Name))
            {
                connectionNode.Add(connection.Name.ToXml("Name"));
            }

            if (!connection.BarIDs.IsEqualTo(defaultValues.BarIDs))
            {
                if (connection.BarIDs.Count != 0)
                {
                    var barIDsNode = new XElement("BarIDs");
                    foreach (var item in connection.BarIDs)
                    {
                        barIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    connectionNode.Add(barIDsNode);
                }
            }

            if (!connection.PolyBarIDs.IsEqualTo(defaultValues.PolyBarIDs))
            {
                if (connection.PolyBarIDs.Count != 0)
                {
                    var polyBarIDsNode = new XElement("PolyBarIDs");
                    foreach (var item in connection.PolyBarIDs)
                    {
                        polyBarIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    connectionNode.Add(polyBarIDsNode);
                }
            }

            if (!connection.PlateIDs.IsEqualTo(defaultValues.PlateIDs))
            {
                if (connection.PlateIDs.Count != 0)
                {
                    var plateIDsNode = new XElement("PlateIDs");
                    foreach (var item in connection.PlateIDs)
                    {
                        plateIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    connectionNode.Add(plateIDsNode);
                }
            }

            if (!connection.PadFootingIDs.IsEqualTo(defaultValues.PadFootingIDs))
            {
                if (connection.PadFootingIDs.Count != 0)
                {
                    var padFootingIDsNode = new XElement("PadFootingIDs");
                    foreach (var item in connection.PadFootingIDs)
                    {
                        padFootingIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    connectionNode.Add(padFootingIDsNode);
                }
            }

            if (!connection.FastenerGroups.IsEqualTo(defaultValues.FastenerGroups))
            {
                if (connection.FastenerGroups.Count != 0)
                {
                    var fastenerGroupsNode = new XElement("FastenerGroups");
                    foreach (var item in connection.FastenerGroups)
                    {
                        fastenerGroupsNode.Add(ToXml(item, "FastenerGroup"));
                    }
                    connectionNode.Add(fastenerGroupsNode);
                }
            }

            if (!connection.GroutFillings.IsEqualTo(defaultValues.GroutFillings))
            {
                if (connection.GroutFillings.Count != 0)
                {
                    var groutFillingsNode = new XElement("GroutFillings");
                    foreach (var item in connection.GroutFillings)
                    {
                        groutFillingsNode.Add(ToXml(item, "Grout"));
                    }
                    connectionNode.Add(groutFillingsNode);
                }
            }

            if (!connection.Welds.IsEqualTo(defaultValues.Welds))
            {
                if (connection.Welds.Count != 0)
                {
                    var weldsNode = new XElement("Welds");
                    foreach (var item in connection.Welds)
                    {
                        weldsNode.Add(ToXml(item, "Weld"));
                    }
                    connectionNode.Add(weldsNode);
                }
            }

            if (!connection.ConnectionBars.IsEqualTo(defaultValues.ConnectionBars))
            {
                if (connection.ConnectionBars.Count != 0)
                {
                    var connectionBarsNode = new XElement("ConnectionBars");
                    foreach (var item in connection.ConnectionBars)
                    {
                        connectionBarsNode.Add(ToXml(item, "Bar"));
                    }
                    connectionNode.Add(connectionBarsNode);
                }
            }

            if (!connection.ConnectionPlates.IsEqualTo(defaultValues.ConnectionPlates))
            {
                if (connection.ConnectionPlates.Count != 0)
                {
                    var connectionPlatesNode = new XElement("ConnectionPlates");
                    foreach (var item in connection.ConnectionPlates)
                    {
                        connectionPlatesNode.Add(ToXml(item, "SimplePlate"));
                    }
                    connectionNode.Add(connectionPlatesNode);
                }
            }

            if (!connection.Haunches.IsEqualTo(defaultValues.Haunches))
            {
                if (connection.Haunches.Count != 0)
                {
                    var haunchesNode = new XElement("Haunches");
                    foreach (var item in connection.Haunches)
                    {
                        haunchesNode.Add(ToXml(item, "Haunch"));
                    }
                    connectionNode.Add(haunchesNode);
                }
            }

            if (!connection.ConnectionPartItems.IsEqualTo(defaultValues.ConnectionPartItems))
            {
                if (connection.ConnectionPartItems.Count != 0)
                {
                    var connectionPartItemsNode = new XElement("ConnectionPartItems");
                    foreach (var item in connection.ConnectionPartItems)
                    {
                        connectionPartItemsNode.Add(ToXml(item, "ConnectionPartItem"));
                    }
                    connectionNode.Add(connectionPartItemsNode);
                }
            }

            if (!connection.ContactSurfaces.IsEqualTo(defaultValues.ContactSurfaces))
            {
                if (connection.ContactSurfaces.Count != 0)
                {
                    var contactSurfacesNode = new XElement("ContactSurfaces");
                    foreach (var item in connection.ContactSurfaces)
                    {
                        contactSurfacesNode.Add(ToXml(item, "ContactSurface"));
                    }
                    connectionNode.Add(contactSurfacesNode);
                }
            }

            if (!connection.Information.IsEqualTo(defaultValues.Information))
            {
                connectionNode.Add(connection.Information.ToXml("Information"));
            }

            return connectionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ContactSurface" />.
        /// </summary>
        public static XElement ToXml(this ContactSurface contactsurface, string nodeName)
        {
            var defaultValues = new ContactSurface();
            var contactSurfaceNode = new XElement(nodeName);
            if (!contactsurface.ID.IsEqualTo(defaultValues.ID))
            {
                contactSurfaceNode.Add(new XAttribute("ID", contactsurface.ID.ToString<int>()));
            }

            if (!contactsurface.Part1ID.IsEqualTo(defaultValues.Part1ID))
            {
                contactSurfaceNode.Add(new XElement("Part1ID", contactsurface.Part1ID));
            }

            if (!contactsurface.Part1Type.IsEqualTo(defaultValues.Part1Type))
            {
                contactSurfaceNode.Add(new XElement("Part1Type", contactsurface.Part1Type));
            }

            if (!contactsurface.Part2ID.IsEqualTo(defaultValues.Part2ID))
            {
                contactSurfaceNode.Add(new XElement("Part2ID", contactsurface.Part2ID));
            }

            if (!contactsurface.Part2Type.IsEqualTo(defaultValues.Part2Type))
            {
                contactSurfaceNode.Add(new XElement("Part2Type", contactsurface.Part2Type));
            }

            if (!contactsurface.SurfaceType.IsEqualTo(defaultValues.SurfaceType))
            {
                contactSurfaceNode.Add(new XElement("SurfaceType", contactsurface.SurfaceType));
            }

            if (!contactsurface.FrictionCoefficient.IsEqualTo(defaultValues.FrictionCoefficient))
            {
                contactSurfaceNode.Add(new XElement("FrictionCoefficient", contactsurface.FrictionCoefficient));
            }

            if (!contactsurface.Information.IsEqualTo(defaultValues.Information))
            {
                contactSurfaceNode.Add(contactsurface.Information.ToXml("Information"));
            }

            return contactSurfaceNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="FastenerGroup" />.
        /// </summary>
        public static XElement ToXml(this FastenerGroup fastenergroup, string nodeName)
        {
            var defaultValues = new FastenerGroup();
            var fastenerGroupNode = new XElement(nodeName);
            if (!fastenergroup.ID.IsEqualTo(defaultValues.ID))
            {
                fastenerGroupNode.Add(new XAttribute("ID", fastenergroup.ID.ToString<int>()));
            }

            if (!fastenergroup.HoleGroupIDs.IsEqualTo(defaultValues.HoleGroupIDs))
            {
                if (fastenergroup.HoleGroupIDs.Count != 0)
                {
                    var holeGroupIDsNode = new XElement("HoleGroupIDs");
                    foreach (var item in fastenergroup.HoleGroupIDs)
                    {
                        holeGroupIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    fastenerGroupNode.Add(holeGroupIDsNode);
                }
            }

            if (!fastenergroup.CoordinateSystemType.IsEqualTo(defaultValues.CoordinateSystemType))
            {
                fastenerGroupNode.Add(new XElement("CoordinateSystemType", fastenergroup.CoordinateSystemType));
            }

            if (!fastenergroup.Positions.IsEqualTo(defaultValues.Positions))
            {
                if (fastenergroup.Positions.Count != 0)
                {
                    var positionsNode = new XElement("Positions");
                    foreach (var item in fastenergroup.Positions)
                    {
                        positionsNode.Add(ToXml(item, "Vector2"));
                    }
                    fastenerGroupNode.Add(positionsNode);
                }
            }

            if (!fastenergroup.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                fastenerGroupNode.Add(fastenergroup.LocalCS.ToXml("LocalCS"));
            }

            if (!fastenergroup.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                fastenerGroupNode.Add(fastenergroup.ReferencePoint.ToXml("ReferencePoint"));
            }

            if (!fastenergroup.FastenerAssemblyType.IsEqualTo(defaultValues.FastenerAssemblyType))
            {
                fastenerGroupNode.Add(new XElement("FastenerAssemblyType", fastenergroup.FastenerAssemblyType));
            }

            if (!fastenergroup.FastenerAssemblyID.IsEqualTo(defaultValues.FastenerAssemblyID))
            {
                fastenerGroupNode.Add(new XElement("FastenerAssemblyID", fastenergroup.FastenerAssemblyID));
            }

            if (!fastenergroup.AssemblySite.IsEqualTo(defaultValues.AssemblySite))
            {
                fastenerGroupNode.Add(new XElement("AssemblySite", fastenergroup.AssemblySite));
            }

            if (!fastenergroup.Preloaded.IsEqualTo(defaultValues.Preloaded))
            {
                fastenerGroupNode.Add(new XElement("Preloaded", fastenergroup.Preloaded));
            }

            if (!fastenergroup.Information.IsEqualTo(defaultValues.Information))
            {
                fastenerGroupNode.Add(fastenergroup.Information.ToXml("Information"));
            }

            return fastenerGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Grout" />.
        /// </summary>
        public static XElement ToXml(this Grout grout, string nodeName)
        {
            var defaultValues = new Grout();
            var groutNode = new XElement(nodeName);
            if (!grout.Geometry.IsEqualTo(defaultValues.Geometry))
            {
                groutNode.Add(grout.Geometry.ToXml("Geometry"));
            }

            if (!grout.Information.IsEqualTo(defaultValues.Information))
            {
                groutNode.Add(grout.Information.ToXml("Information"));
            }

            return groutNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Nut" />.
        /// </summary>
        public static XElement ToXml(this Nut nut, string nodeName)
        {
            var defaultValues = new Nut();
            var nutNode = new XElement(nodeName);
            if (!nut.ID.IsEqualTo(defaultValues.ID))
            {
                nutNode.Add(new XAttribute("ID", nut.ID.ToString<System.Guid>()));
            }

            if (!nut.Name.IsEqualTo(defaultValues.Name))
            {
                nutNode.Add(nut.Name.ToXml("Name"));
            }

            if (!nut.Diameter.IsEqualTo(defaultValues.Diameter))
            {
                nutNode.Add(new XElement("Diameter", nut.Diameter));
            }

            if (!nut.ThreadPitch.IsEqualTo(defaultValues.ThreadPitch))
            {
                nutNode.Add(new XElement("ThreadPitch", nut.ThreadPitch));
            }

            if (!nut.ThreadMethod.IsEqualTo(defaultValues.ThreadMethod))
            {
                nutNode.Add(new XElement("ThreadMethod", nut.ThreadMethod));
            }

            if (!nut.ThreadType.IsEqualTo(defaultValues.ThreadType))
            {
                nutNode.Add(new XElement("ThreadType", nut.ThreadType));
            }

            if (!nut.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                nutNode.Add(new XElement("MaterialID", nut.MaterialID));
            }

            if (!nut.NutType.IsEqualTo(defaultValues.NutType))
            {
                nutNode.Add(new XElement("NutType", nut.NutType));
            }

            if (!nut.Information.IsEqualTo(defaultValues.Information))
            {
                nutNode.Add(nut.Information.ToXml("Information"));
            }

            if (!nut.Version.IsEqualTo(defaultValues.Version))
            {
                nutNode.Add(new XElement("Version", nut.Version));
            }

            if (!nut.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                nutNode.Add(new XElement("LastChanged", nut.LastChanged));
            }

            if (!nut.Status.IsEqualTo(defaultValues.Status))
            {
                nutNode.Add(new XElement("Status", nut.Status));
            }

            if (!nut.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                nutNode.Add(new XElement("ReadOnly", nut.ReadOnly));
            }

            return nutNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Washer" />.
        /// </summary>
        public static XElement ToXml(this Washer washer, string nodeName)
        {
            var defaultValues = new Washer();
            var washerNode = new XElement(nodeName);
            if (!washer.ID.IsEqualTo(defaultValues.ID))
            {
                washerNode.Add(new XAttribute("ID", washer.ID.ToString<System.Guid>()));
            }

            if (!washer.Name.IsEqualTo(defaultValues.Name))
            {
                washerNode.Add(washer.Name.ToXml("Name"));
            }

            if (!washer.Diameter.IsEqualTo(defaultValues.Diameter))
            {
                washerNode.Add(new XElement("Diameter", washer.Diameter));
            }

            if (!washer.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                washerNode.Add(new XElement("MaterialID", washer.MaterialID));
            }

            if (!washer.WasherType.IsEqualTo(defaultValues.WasherType))
            {
                washerNode.Add(new XElement("WasherType", washer.WasherType));
            }

            if (!washer.Information.IsEqualTo(defaultValues.Information))
            {
                washerNode.Add(washer.Information.ToXml("Information"));
            }

            if (!washer.Version.IsEqualTo(defaultValues.Version))
            {
                washerNode.Add(new XElement("Version", washer.Version));
            }

            if (!washer.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                washerNode.Add(new XElement("LastChanged", washer.LastChanged));
            }

            if (!washer.Status.IsEqualTo(defaultValues.Status))
            {
                washerNode.Add(new XElement("Status", washer.Status));
            }

            if (!washer.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                washerNode.Add(new XElement("ReadOnly", washer.ReadOnly));
            }

            return washerNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Weld" />.
        /// </summary>
        public static XElement ToXml(this Weld weld, string nodeName)
        {
            var defaultValues = new Weld();
            var weldNode = new XElement(nodeName);
            if (!weld.ID.IsEqualTo(defaultValues.ID))
            {
                weldNode.Add(new XAttribute("ID", weld.ID.ToString<int>()));
            }

            if (!weld.Name.IsEqualTo(defaultValues.Name))
            {
                weldNode.Add(weld.Name.ToXml("Name"));
            }

            if (!weld.ElectrodeType.IsEqualTo(defaultValues.ElectrodeType))
            {
                weldNode.Add(new XElement("ElectrodeType", weld.ElectrodeType));
            }

            if (!weld.Path3D.IsEqualTo(defaultValues.Path3D))
            {
                if (weld.Path3D.Count != 0)
                {
                    var path3DNode = new XElement("Path3D");
                    foreach (var item in weld.Path3D)
                    {
                        path3DNode.Add(ToXml(item, "PolylineVertex"));
                    }
                    weldNode.Add(path3DNode);
                }
            }

            if (!weld.MainPartID.IsEqualTo(defaultValues.MainPartID))
            {
                weldNode.Add(new XElement("MainPartID", weld.MainPartID));
            }

            if (!weld.MainPartType.IsEqualTo(defaultValues.MainPartType))
            {
                weldNode.Add(new XElement("MainPartType", weld.MainPartType));
            }

            if (!weld.SecPartID.IsEqualTo(defaultValues.SecPartID))
            {
                weldNode.Add(new XElement("SecPartID", weld.SecPartID));
            }

            if (!weld.SecPartType.IsEqualTo(defaultValues.SecPartType))
            {
                weldNode.Add(new XElement("SecPartType", weld.SecPartType));
            }

            if (!weld.AroundWeld.IsEqualTo(defaultValues.AroundWeld))
            {
                weldNode.Add(new XElement("AroundWeld", weld.AroundWeld));
            }

            if (!weld.WeldingSite.IsEqualTo(defaultValues.WeldingSite))
            {
                weldNode.Add(new XElement("WeldingSite", weld.WeldingSite));
            }

            if (!weld.WeldProcess.IsEqualTo(defaultValues.WeldProcess))
            {
                weldNode.Add(new XElement("WeldProcess", weld.WeldProcess));
            }

            if (!weld.PreparationType.IsEqualTo(defaultValues.PreparationType))
            {
                weldNode.Add(new XElement("PreparationType", weld.PreparationType));
            }

            if (!weld.WeldType.IsEqualTo(defaultValues.WeldType))
            {
                weldNode.Add(new XElement("WeldType", weld.WeldType));
            }

            if (!weld.Information.IsEqualTo(defaultValues.Information))
            {
                weldNode.Add(weld.Information.ToXml("Information"));
            }

            return weldNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Haunch" />.
        /// </summary>
        public static XElement ToXml(this Haunch haunch, string nodeName)
        {
            var defaultValues = new Haunch();
            var haunchNode = new XElement(nodeName);
            if (!haunch.ID.IsEqualTo(defaultValues.ID))
            {
                haunchNode.Add(new XAttribute("ID", haunch.ID.ToString<int>()));
            }

            if (!haunch.ConnectionBarIDs.IsEqualTo(defaultValues.ConnectionBarIDs))
            {
                if (haunch.ConnectionBarIDs.Count != 0)
                {
                    var connectionBarIDsNode = new XElement("ConnectionBarIDs");
                    foreach (var item in haunch.ConnectionBarIDs)
                    {
                        connectionBarIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    haunchNode.Add(connectionBarIDsNode);
                }
            }

            if (!haunch.ConnectionPlateIDs.IsEqualTo(defaultValues.ConnectionPlateIDs))
            {
                if (haunch.ConnectionPlateIDs.Count != 0)
                {
                    var connectionPlateIDsNode = new XElement("ConnectionPlateIDs");
                    foreach (var item in haunch.ConnectionPlateIDs)
                    {
                        connectionPlateIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    haunchNode.Add(connectionPlateIDsNode);
                }
            }

            return haunchNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ConnectionPartItem" />.
        /// </summary>
        public static XElement ToXml(this ConnectionPartItem connectionpartitem, string nodeName)
        {
            var defaultValues = new ConnectionPartItem();
            var connectionPartItemNode = new XElement(nodeName);
            if (!connectionpartitem.PartID.IsEqualTo(defaultValues.PartID))
            {
                connectionPartItemNode.Add(new XElement("PartID", connectionpartitem.PartID));
            }

            if (!connectionpartitem.PartType.IsEqualTo(defaultValues.PartType))
            {
                connectionPartItemNode.Add(new XElement("PartType", connectionpartitem.PartType));
            }

            if (!connectionpartitem.Modifiers.IsEqualTo(defaultValues.Modifiers))
            {
                connectionPartItemNode.Add(connectionpartitem.Modifiers.ToXml("Modifiers"));
            }

            return connectionPartItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Information" />.
        /// </summary>
        public static XElement ToXml(this Information information, string nodeName)
        {
            var informationNode = new XElement(nodeName);

            return informationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Eccentricity" />.
        /// </summary>
        public static XElement ToXml(this Eccentricity eccentricity, string nodeName)
        {
            var defaultValues = new Eccentricity();
            var eccentricityNode = new XElement(nodeName);
            if (!eccentricity.GlobalOffset.IsEqualTo(defaultValues.GlobalOffset))
            {
                eccentricityNode.Add(eccentricity.GlobalOffset.ToXml("GlobalOffset"));
            }

            if (!eccentricity.LocalOffset.IsEqualTo(defaultValues.LocalOffset))
            {
                eccentricityNode.Add(eccentricity.LocalOffset.ToXml("LocalOffset"));
            }

            return eccentricityNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarPosition" />.
        /// </summary>
        public static XElement ToXml(this BarPosition barposition, string nodeName)
        {
            var defaultValues = new BarPosition();
            var barPositionNode = new XElement(nodeName);
            if (!barposition.Location.IsEqualTo(defaultValues.Location))
            {
                barPositionNode.Add(barposition.Location.ToXml("Location"));
            }

            if (!barposition.Eccentricity.IsEqualTo(defaultValues.Eccentricity))
            {
                barPositionNode.Add(barposition.Eccentricity.ToXml("Eccentricity"));
            }

            return barPositionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Chamfer" />.
        /// </summary>
        public static XElement ToXml(this Chamfer chamfer, string nodeName)
        {
            var defaultValues = new Chamfer();
            var chamferNode = new XElement(nodeName);
            if (!chamfer.ChamferType.IsEqualTo(defaultValues.ChamferType))
            {
                chamferNode.Add(new XElement("ChamferType", chamfer.ChamferType));
            }

            if (!chamfer.MainDimension.IsEqualTo(defaultValues.MainDimension))
            {
                chamferNode.Add(new XElement("MainDimension", chamfer.MainDimension));
            }

            if (!chamfer.SecondaryDimension.IsEqualTo(defaultValues.SecondaryDimension))
            {
                chamferNode.Add(new XElement("SecondaryDimension", chamfer.SecondaryDimension));
            }

            return chamferNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PolylineVertex" />.
        /// </summary>
        public static XElement ToXml(this PolylineVertex polylinevertex, string nodeName)
        {
            var defaultValues = new PolylineVertex();
            var polylineVertexNode = new XElement(nodeName);
            if (!polylinevertex.Location.IsEqualTo(defaultValues.Location))
            {
                polylineVertexNode.Add(polylinevertex.Location.ToXml("Location"));
            }

            if (!polylinevertex.GlobalOffset.IsEqualTo(defaultValues.GlobalOffset))
            {
                polylineVertexNode.Add(polylinevertex.GlobalOffset.ToXml("GlobalOffset"));
            }

            if (!polylinevertex.Chamfer.IsEqualTo(defaultValues.Chamfer))
            {
                polylineVertexNode.Add(polylinevertex.Chamfer.ToXml("Chamfer"));
            }

            return polylineVertexNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PolygonVertex" />.
        /// </summary>
        public static XElement ToXml(this PolygonVertex polygonvertex, string nodeName)
        {
            var defaultValues = new PolygonVertex();
            var polygonVertexNode = new XElement(nodeName);
            if (!polygonvertex.Location.IsEqualTo(defaultValues.Location))
            {
                polygonVertexNode.Add(polygonvertex.Location.ToXml("Location"));
            }

            if (!polygonvertex.Chamfer.IsEqualTo(defaultValues.Chamfer))
            {
                polygonVertexNode.Add(polygonvertex.Chamfer.ToXml("Chamfer"));
            }

            return polygonVertexNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarDirectrix" />.
        /// </summary>
        public static XElement ToXml(this BarDirectrix bardirectrix, string nodeName)
        {
            var defaultValues = new BarDirectrix();
            var barDirectrixNode = new XElement(nodeName);
            if (!bardirectrix.DirectrixType.IsEqualTo(defaultValues.DirectrixType))
            {
                barDirectrixNode.Add(new XElement("DirectrixType", bardirectrix.DirectrixType));
            }

            if (!bardirectrix.RadiusOfCurvature.IsEqualTo(defaultValues.RadiusOfCurvature))
            {
                barDirectrixNode.Add(new XElement("RadiusOfCurvature", bardirectrix.RadiusOfCurvature));
            }

            return barDirectrixNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bar" />.
        /// </summary>
        public static XElement ToXml(this Bar bar, string nodeName)
        {
            var defaultValues = new Bar();
            var barNode = new XElement(nodeName);
            if (!bar.ID.IsEqualTo(defaultValues.ID))
            {
                barNode.Add(new XAttribute("ID", bar.ID.ToString<int>()));
            }

            if (!bar.Name.IsEqualTo(defaultValues.Name))
            {
                barNode.Add(bar.Name.ToXml("Name"));
            }

            if (!bar.Begin.IsEqualTo(defaultValues.Begin))
            {
                barNode.Add(bar.Begin.ToXml("Begin"));
            }

            if (!bar.End.IsEqualTo(defaultValues.End))
            {
                barNode.Add(bar.End.ToXml("End"));
            }

            if (!bar.CardinalPoint.IsEqualTo(defaultValues.CardinalPoint))
            {
                barNode.Add(new XElement("CardinalPoint", bar.CardinalPoint));
            }

            if (!bar.Directrix.IsEqualTo(defaultValues.Directrix))
            {
                barNode.Add(bar.Directrix.ToXml("Directrix"));
            }

            if (!bar.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                barNode.Add(bar.LocalCS.ToXml("LocalCS"));
            }

            if (!bar.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                barNode.Add(new XElement("SectionID", bar.SectionID));
            }

            if (!bar.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (bar.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in bar.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    barNode.Add(materialOverridesNode);
                }
            }

            if (!bar.SectionMirroredAroundZAxis.IsEqualTo(defaultValues.SectionMirroredAroundZAxis))
            {
                barNode.Add(new XElement("SectionMirroredAroundZAxis", bar.SectionMirroredAroundZAxis));
            }

            if (!bar.Modifiers.IsEqualTo(defaultValues.Modifiers))
            {
                barNode.Add(bar.Modifiers.ToXml("Modifiers"));
            }

            if (!bar.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                barNode.Add(bar.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return barNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PolyBar" />.
        /// </summary>
        public static XElement ToXml(this PolyBar polybar, string nodeName)
        {
            var defaultValues = new PolyBar();
            var polyBarNode = new XElement(nodeName);
            if (!polybar.ID.IsEqualTo(defaultValues.ID))
            {
                polyBarNode.Add(new XAttribute("ID", polybar.ID.ToString<int>()));
            }

            if (!polybar.Name.IsEqualTo(defaultValues.Name))
            {
                polyBarNode.Add(polybar.Name.ToXml("Name"));
            }

            if (!polybar.Begin.IsEqualTo(defaultValues.Begin))
            {
                polyBarNode.Add(polybar.Begin.ToXml("Begin"));
            }

            if (!polybar.End.IsEqualTo(defaultValues.End))
            {
                polyBarNode.Add(polybar.End.ToXml("End"));
            }

            if (!polybar.CardinalPoint.IsEqualTo(defaultValues.CardinalPoint))
            {
                polyBarNode.Add(new XElement("CardinalPoint", polybar.CardinalPoint));
            }

            if (!polybar.InnerVertices.IsEqualTo(defaultValues.InnerVertices))
            {
                if (polybar.InnerVertices.Count != 0)
                {
                    var innerVerticesNode = new XElement("InnerVertices");
                    foreach (var item in polybar.InnerVertices)
                    {
                        innerVerticesNode.Add(ToXml(item, "PolylineVertex"));
                    }
                    polyBarNode.Add(innerVerticesNode);
                }
            }

            if (!polybar.LocalCSs.IsEqualTo(defaultValues.LocalCSs))
            {
                if (polybar.LocalCSs.Count != 0)
                {
                    var localCSsNode = new XElement("LocalCSs");
                    foreach (var item in polybar.LocalCSs)
                    {
                        localCSsNode.Add(ToXml(item, "CoordinateSystem"));
                    }
                    polyBarNode.Add(localCSsNode);
                }
            }

            if (!polybar.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                polyBarNode.Add(new XElement("SectionID", polybar.SectionID));
            }

            if (!polybar.SectionMirroredAroundZAxis.IsEqualTo(defaultValues.SectionMirroredAroundZAxis))
            {
                polyBarNode.Add(new XElement("SectionMirroredAroundZAxis", polybar.SectionMirroredAroundZAxis));
            }

            if (!polybar.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (polybar.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in polybar.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    polyBarNode.Add(materialOverridesNode);
                }
            }

            if (!polybar.Modifiers.IsEqualTo(defaultValues.Modifiers))
            {
                polyBarNode.Add(polybar.Modifiers.ToXml("Modifiers"));
            }

            if (!polybar.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                polyBarNode.Add(polybar.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return polyBarNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Polygon" />.
        /// </summary>
        public static XElement ToXml(this Polygon polygon, string nodeName)
        {
            var defaultValues = new Polygon();
            var polygonNode = new XElement(nodeName);
            if (!polygon.IsCircle.IsEqualTo(defaultValues.IsCircle))
            {
                polygonNode.Add(new XElement("IsCircle", polygon.IsCircle));
            }

            if (!polygon.CircleCentre.IsEqualTo(defaultValues.CircleCentre))
            {
                polygonNode.Add(polygon.CircleCentre.ToXml("CircleCentre"));
            }

            if (!polygon.CircleDiameter.IsEqualTo(defaultValues.CircleDiameter))
            {
                polygonNode.Add(new XElement("CircleDiameter", polygon.CircleDiameter));
            }

            if (!polygon.Vertices.IsEqualTo(defaultValues.Vertices))
            {
                if (polygon.Vertices.Count != 0)
                {
                    var verticesNode = new XElement("Vertices");
                    foreach (var item in polygon.Vertices)
                    {
                        verticesNode.Add(ToXml(item, "PolygonVertex"));
                    }
                    polygonNode.Add(verticesNode);
                }
            }

            return polygonNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Plate" />.
        /// </summary>
        public static XElement ToXml(this Plate plate, string nodeName)
        {
            var defaultValues = new Plate();
            var plateNode = new XElement(nodeName);
            if (!plate.ID.IsEqualTo(defaultValues.ID))
            {
                plateNode.Add(new XAttribute("ID", plate.ID.ToString<int>()));
            }

            if (!plate.Name.IsEqualTo(defaultValues.Name))
            {
                plateNode.Add(plate.Name.ToXml("Name"));
            }

            if (!plate.OuterPolygon.IsEqualTo(defaultValues.OuterPolygon))
            {
                plateNode.Add(plate.OuterPolygon.ToXml("OuterPolygon"));
            }

            if (!plate.BoundingBoxAnchorPlane.IsEqualTo(defaultValues.BoundingBoxAnchorPlane))
            {
                plateNode.Add(new XElement("BoundingBoxAnchorPlane", plate.BoundingBoxAnchorPlane));
            }

            if (!plate.BoundingBoxOffsetY.IsEqualTo(defaultValues.BoundingBoxOffsetY))
            {
                plateNode.Add(new XElement("BoundingBoxOffsetY", plate.BoundingBoxOffsetY));
            }

            if (!plate.Eccentricity.IsEqualTo(defaultValues.Eccentricity))
            {
                plateNode.Add(plate.Eccentricity.ToXml("Eccentricity"));
            }

            if (!plate.CutOutPolygons.IsEqualTo(defaultValues.CutOutPolygons))
            {
                if (plate.CutOutPolygons.Count != 0)
                {
                    var cutOutPolygonsNode = new XElement("CutOutPolygons");
                    foreach (var item in plate.CutOutPolygons)
                    {
                        cutOutPolygonsNode.Add(ToXml(item, "Polygon"));
                    }
                    plateNode.Add(cutOutPolygonsNode);
                }
            }

            if (!plate.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                plateNode.Add(plate.LocalCS.ToXml("LocalCS"));
            }

            if (!plate.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                plateNode.Add(plate.ReferencePoint.ToXml("ReferencePoint"));
            }

            if (!plate.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                plateNode.Add(new XElement("SectionID", plate.SectionID));
            }

            if (!plate.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (plate.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in plate.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    plateNode.Add(materialOverridesNode);
                }
            }

            if (!plate.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                plateNode.Add(plate.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return plateNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PadFootingPart" />.
        /// </summary>
        public static XElement ToXml(this PadFootingPart padfootingpart, string nodeName)
        {
            var defaultValues = new PadFootingPart();
            var padFootingPartNode = new XElement(nodeName);
            if (!padfootingpart.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                padFootingPartNode.Add(new XElement("SectionID", padfootingpart.SectionID));
            }

            if (!padfootingpart.SectionMirroredAroundZAxis.IsEqualTo(defaultValues.SectionMirroredAroundZAxis))
            {
                padFootingPartNode.Add(new XElement("SectionMirroredAroundZAxis", padfootingpart.SectionMirroredAroundZAxis));
            }

            if (!padfootingpart.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (padfootingpart.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in padfootingpart.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    padFootingPartNode.Add(materialOverridesNode);
                }
            }

            if (!padfootingpart.Height.IsEqualTo(defaultValues.Height))
            {
                padFootingPartNode.Add(new XElement("Height", padfootingpart.Height));
            }

            return padFootingPartNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PadFooting" />.
        /// </summary>
        public static XElement ToXml(this PadFooting padfooting, string nodeName)
        {
            var defaultValues = new PadFooting();
            var padFootingNode = new XElement(nodeName);
            if (!padfooting.ID.IsEqualTo(defaultValues.ID))
            {
                padFootingNode.Add(new XAttribute("ID", padfooting.ID.ToString<int>()));
            }

            if (!padfooting.Name.IsEqualTo(defaultValues.Name))
            {
                padFootingNode.Add(padfooting.Name.ToXml("Name"));
            }

            if (!padfooting.ReferencePointPosition.IsEqualTo(defaultValues.ReferencePointPosition))
            {
                padFootingNode.Add(padfooting.ReferencePointPosition.ToXml("ReferencePointPosition"));
            }

            if (!padfooting.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                padFootingNode.Add(padfooting.LocalCS.ToXml("LocalCS"));
            }

            if (!padfooting.PadFootingType.IsEqualTo(defaultValues.PadFootingType))
            {
                padFootingNode.Add(new XElement("PadFootingType", padfooting.PadFootingType));
            }

            if (!padfooting.Parts.IsEqualTo(defaultValues.Parts))
            {
                if (padfooting.Parts.Count != 0)
                {
                    var partsNode = new XElement("Parts");
                    foreach (var item in padfooting.Parts)
                    {
                        partsNode.Add(ToXml(item, "PadFootingPart"));
                    }
                    padFootingNode.Add(partsNode);
                }
            }

            if (!padfooting.CardinalPoint.IsEqualTo(defaultValues.CardinalPoint))
            {
                padFootingNode.Add(new XElement("CardinalPoint", padfooting.CardinalPoint));
            }

            if (!padfooting.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                padFootingNode.Add(padfooting.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return padFootingNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SimplePlate" />.
        /// </summary>
        public static XElement ToXml(this SimplePlate simpleplate, string nodeName)
        {
            var defaultValues = new SimplePlate();
            var simplePlateNode = new XElement(nodeName);
            if (!simpleplate.ID.IsEqualTo(defaultValues.ID))
            {
                simplePlateNode.Add(new XAttribute("ID", simpleplate.ID.ToString<int>()));
            }

            if (!simpleplate.Name.IsEqualTo(defaultValues.Name))
            {
                simplePlateNode.Add(simpleplate.Name.ToXml("Name"));
            }

            if (!simpleplate.OuterPolygon.IsEqualTo(defaultValues.OuterPolygon))
            {
                simplePlateNode.Add(simpleplate.OuterPolygon.ToXml("OuterPolygon"));
            }

            if (!simpleplate.AnchorPlane.IsEqualTo(defaultValues.AnchorPlane))
            {
                simplePlateNode.Add(new XElement("AnchorPlane", simpleplate.AnchorPlane));
            }

            if (!simpleplate.OffsetY.IsEqualTo(defaultValues.OffsetY))
            {
                simplePlateNode.Add(new XElement("OffsetY", simpleplate.OffsetY));
            }

            if (!simpleplate.Eccentricity.IsEqualTo(defaultValues.Eccentricity))
            {
                simplePlateNode.Add(simpleplate.Eccentricity.ToXml("Eccentricity"));
            }

            if (!simpleplate.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                simplePlateNode.Add(simpleplate.LocalCS.ToXml("LocalCS"));
            }

            if (!simpleplate.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                simplePlateNode.Add(simpleplate.ReferencePoint.ToXml("ReferencePoint"));
            }

            if (!simpleplate.Thickness.IsEqualTo(defaultValues.Thickness))
            {
                simplePlateNode.Add(new XElement("Thickness", simpleplate.Thickness));
            }

            if (!simpleplate.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                simplePlateNode.Add(new XElement("MaterialID", simpleplate.MaterialID));
            }

            if (!simpleplate.Modifiers.IsEqualTo(defaultValues.Modifiers))
            {
                simplePlateNode.Add(simpleplate.Modifiers.ToXml("Modifiers"));
            }

            return simplePlateNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PlaneModifier" />.
        /// </summary>
        public static XElement ToXml(this PlaneModifier planemodifier, string nodeName)
        {
            var defaultValues = new PlaneModifier();
            var planeModifierNode = new XElement(nodeName);
            if (!planemodifier.PlaneModifierType.IsEqualTo(defaultValues.PlaneModifierType))
            {
                planeModifierNode.Add(new XElement("PlaneModifierType", planemodifier.PlaneModifierType));
            }

            if (!planemodifier.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                planeModifierNode.Add(planemodifier.LocalCS.ToXml("LocalCS"));
            }

            if (!planemodifier.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                planeModifierNode.Add(planemodifier.ReferencePoint.ToXml("ReferencePoint"));
            }

            return planeModifierNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PartModifiers" />.
        /// </summary>
        public static XElement ToXml(this PartModifiers partmodifiers, string nodeName)
        {
            var defaultValues = new PartModifiers();
            var partModifiersNode = new XElement(nodeName);
            if (!partmodifiers.PlaneModifiers.IsEqualTo(defaultValues.PlaneModifiers))
            {
                if (partmodifiers.PlaneModifiers.Count != 0)
                {
                    var planeModifiersNode = new XElement("PlaneModifiers");
                    foreach (var item in partmodifiers.PlaneModifiers)
                    {
                        planeModifiersNode.Add(ToXml(item, "PlaneModifier"));
                    }
                    partModifiersNode.Add(planeModifiersNode);
                }
            }

            if (!partmodifiers.ContourCuts.IsEqualTo(defaultValues.ContourCuts))
            {
                if (partmodifiers.ContourCuts.Count != 0)
                {
                    var contourCutsNode = new XElement("ContourCuts");
                    foreach (var item in partmodifiers.ContourCuts)
                    {
                        contourCutsNode.Add(ToXml(item, "SimplePlate"));
                    }
                    partModifiersNode.Add(contourCutsNode);
                }
            }

            if (!partmodifiers.HoleGroups.IsEqualTo(defaultValues.HoleGroups))
            {
                if (partmodifiers.HoleGroups.Count != 0)
                {
                    var holeGroupsNode = new XElement("HoleGroups");
                    foreach (var item in partmodifiers.HoleGroups)
                    {
                        holeGroupsNode.Add(ToXml(item, "HoleGroup"));
                    }
                    partModifiersNode.Add(holeGroupsNode);
                }
            }

            return partModifiersNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="HoleGroup" />.
        /// </summary>
        public static XElement ToXml(this HoleGroup holegroup, string nodeName)
        {
            var defaultValues = new HoleGroup();
            var holeGroupNode = new XElement(nodeName);
            if (!holegroup.ID.IsEqualTo(defaultValues.ID))
            {
                holeGroupNode.Add(new XAttribute("ID", holegroup.ID.ToString<int>()));
            }

            if (!holegroup.CoordinateSystemType.IsEqualTo(defaultValues.CoordinateSystemType))
            {
                holeGroupNode.Add(new XElement("CoordinateSystemType", holegroup.CoordinateSystemType));
            }

            if (!holegroup.Positions.IsEqualTo(defaultValues.Positions))
            {
                if (holegroup.Positions.Count != 0)
                {
                    var positionsNode = new XElement("Positions");
                    foreach (var item in holegroup.Positions)
                    {
                        positionsNode.Add(ToXml(item, "Vector2"));
                    }
                    holeGroupNode.Add(positionsNode);
                }
            }

            if (!holegroup.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                holeGroupNode.Add(holegroup.LocalCS.ToXml("LocalCS"));
            }

            if (!holegroup.ReferencePoint.IsEqualTo(defaultValues.ReferencePoint))
            {
                holeGroupNode.Add(holegroup.ReferencePoint.ToXml("ReferencePoint"));
            }

            if (!holegroup.HoleType.IsEqualTo(defaultValues.HoleType))
            {
                holeGroupNode.Add(new XElement("HoleType", holegroup.HoleType));
            }

            if (!holegroup.HoleDiameter.IsEqualTo(defaultValues.HoleDiameter))
            {
                holeGroupNode.Add(new XElement("HoleDiameter", holegroup.HoleDiameter));
            }

            if (!holegroup.Information.IsEqualTo(defaultValues.Information))
            {
                holeGroupNode.Add(holegroup.Information.ToXml("Information"));
            }

            return holeGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Vector2" />.
        /// </summary>
        public static XElement ToXml(this Vector2 vector2, string nodeName)
        {
            var defaultValues = new Vector2();
            var vector2Node = new XElement(nodeName);
            if (!vector2.X.IsEqualTo(defaultValues.X))
            {
                vector2Node.Add(new XAttribute("X", vector2.X.ToString<double>()));
            }

            if (!vector2.Y.IsEqualTo(defaultValues.Y))
            {
                vector2Node.Add(new XAttribute("Y", vector2.Y.ToString<double>()));
            }

            return vector2Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Vector3" />.
        /// </summary>
        public static XElement ToXml(this Vector3 vector3, string nodeName)
        {
            var defaultValues = new Vector3();
            var vector3Node = new XElement(nodeName);
            if (!vector3.X.IsEqualTo(defaultValues.X))
            {
                vector3Node.Add(new XAttribute("X", vector3.X.ToString<double>()));
            }

            if (!vector3.Y.IsEqualTo(defaultValues.Y))
            {
                vector3Node.Add(new XAttribute("Y", vector3.Y.ToString<double>()));
            }

            if (!vector3.Z.IsEqualTo(defaultValues.Z))
            {
                vector3Node.Add(new XAttribute("Z", vector3.Z.ToString<double>()));
            }

            return vector3Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CoordinateSystem" />.
        /// </summary>
        public static XElement ToXml(this CoordinateSystem coordinatesystem, string nodeName)
        {
            var defaultValues = new CoordinateSystem();
            var coordinateSystemNode = new XElement(nodeName);
            if (!coordinatesystem.X.IsEqualTo(defaultValues.X))
            {
                coordinateSystemNode.Add(coordinatesystem.X.ToXml("X"));
            }

            if (!coordinatesystem.Y.IsEqualTo(defaultValues.Y))
            {
                coordinateSystemNode.Add(coordinatesystem.Y.ToXml("Y"));
            }

            if (!coordinatesystem.Z.IsEqualTo(defaultValues.Z))
            {
                coordinateSystemNode.Add(coordinatesystem.Z.ToXml("Z"));
            }

            return coordinateSystemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Matrix2x2" />.
        /// </summary>
        public static XElement ToXml(this Matrix2x2 matrix2X2, string nodeName)
        {
            var defaultValues = new Matrix2x2();
            var matrix2X2Node = new XElement(nodeName);
            if (!matrix2X2.Cell11.IsEqualTo(defaultValues.Cell11))
            {
                matrix2X2Node.Add(new XElement("Cell11", matrix2X2.Cell11));
            }

            if (!matrix2X2.Cell12.IsEqualTo(defaultValues.Cell12))
            {
                matrix2X2Node.Add(new XElement("Cell12", matrix2X2.Cell12));
            }

            if (!matrix2X2.Cell21.IsEqualTo(defaultValues.Cell21))
            {
                matrix2X2Node.Add(new XElement("Cell21", matrix2X2.Cell21));
            }

            if (!matrix2X2.Cell22.IsEqualTo(defaultValues.Cell22))
            {
                matrix2X2Node.Add(new XElement("Cell22", matrix2X2.Cell22));
            }

            return matrix2X2Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Matrix3x3" />.
        /// </summary>
        public static XElement ToXml(this Matrix3x3 matrix3X3, string nodeName)
        {
            var defaultValues = new Matrix3x3();
            var matrix3X3Node = new XElement(nodeName);
            if (!matrix3X3.Cell11.IsEqualTo(defaultValues.Cell11))
            {
                matrix3X3Node.Add(new XElement("Cell11", matrix3X3.Cell11));
            }

            if (!matrix3X3.Cell12.IsEqualTo(defaultValues.Cell12))
            {
                matrix3X3Node.Add(new XElement("Cell12", matrix3X3.Cell12));
            }

            if (!matrix3X3.Cell13.IsEqualTo(defaultValues.Cell13))
            {
                matrix3X3Node.Add(new XElement("Cell13", matrix3X3.Cell13));
            }

            if (!matrix3X3.Cell21.IsEqualTo(defaultValues.Cell21))
            {
                matrix3X3Node.Add(new XElement("Cell21", matrix3X3.Cell21));
            }

            if (!matrix3X3.Cell22.IsEqualTo(defaultValues.Cell22))
            {
                matrix3X3Node.Add(new XElement("Cell22", matrix3X3.Cell22));
            }

            if (!matrix3X3.Cell23.IsEqualTo(defaultValues.Cell23))
            {
                matrix3X3Node.Add(new XElement("Cell23", matrix3X3.Cell23));
            }

            if (!matrix3X3.Cell31.IsEqualTo(defaultValues.Cell31))
            {
                matrix3X3Node.Add(new XElement("Cell31", matrix3X3.Cell31));
            }

            if (!matrix3X3.Cell32.IsEqualTo(defaultValues.Cell32))
            {
                matrix3X3Node.Add(new XElement("Cell32", matrix3X3.Cell32));
            }

            if (!matrix3X3.Cell33.IsEqualTo(defaultValues.Cell33))
            {
                matrix3X3Node.Add(new XElement("Cell33", matrix3X3.Cell33));
            }

            return matrix3X3Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle2D" />.
        /// </summary>
        public static XElement ToXml(this Triangle2D triangle2d, string nodeName)
        {
            var defaultValues = new Triangle2D();
            var triangle2DNode = new XElement(nodeName);
            if (!triangle2d.P1.IsEqualTo(defaultValues.P1))
            {
                triangle2DNode.Add(triangle2d.P1.ToXml("P1"));
            }

            if (!triangle2d.P2.IsEqualTo(defaultValues.P2))
            {
                triangle2DNode.Add(triangle2d.P2.ToXml("P2"));
            }

            if (!triangle2d.P3.IsEqualTo(defaultValues.P3))
            {
                triangle2DNode.Add(triangle2d.P3.ToXml("P3"));
            }

            return triangle2DNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle3D" />.
        /// </summary>
        public static XElement ToXml(this Triangle3D triangle3d, string nodeName)
        {
            var defaultValues = new Triangle3D();
            var triangle3DNode = new XElement(nodeName);
            if (!triangle3d.P1.IsEqualTo(defaultValues.P1))
            {
                triangle3DNode.Add(triangle3d.P1.ToXml("P1"));
            }

            if (!triangle3d.P2.IsEqualTo(defaultValues.P2))
            {
                triangle3DNode.Add(triangle3d.P2.ToXml("P2"));
            }

            if (!triangle3d.P3.IsEqualTo(defaultValues.P3))
            {
                triangle3DNode.Add(triangle3d.P3.ToXml("P3"));
            }

            return triangle3DNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="MultiLinear" />.
        /// </summary>
        public static XElement ToXml(this MultiLinear multilinear, string nodeName)
        {
            var defaultValues = new MultiLinear();
            var multiLinearNode = new XElement(nodeName);
            if (!multilinear.Name.IsEqualTo(defaultValues.Name))
            {
                multiLinearNode.Add(multilinear.Name.ToXml("Name"));
            }

            if (!multilinear.DataPoints.IsEqualTo(defaultValues.DataPoints))
            {
                if (multilinear.DataPoints.Count != 0)
                {
                    var dataPointsNode = new XElement("DataPoints");
                    foreach (var item in multilinear.DataPoints)
                    {
                        dataPointsNode.Add(ToXml(item, "Vector2"));
                    }
                    multiLinearNode.Add(dataPointsNode);
                }
            }

            return multiLinearNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BezierCurve2D" />.
        /// </summary>
        public static XElement ToXml(this BezierCurve2D beziercurve2d, string nodeName)
        {
            var defaultValues = new BezierCurve2D();
            var bezierCurve2DNode = new XElement(nodeName);
            if (!beziercurve2d.BeginPoint.IsEqualTo(defaultValues.BeginPoint))
            {
                bezierCurve2DNode.Add(beziercurve2d.BeginPoint.ToXml("BeginPoint"));
            }

            if (!beziercurve2d.BeginControlPoint.IsEqualTo(defaultValues.BeginControlPoint))
            {
                bezierCurve2DNode.Add(beziercurve2d.BeginControlPoint.ToXml("BeginControlPoint"));
            }

            if (!beziercurve2d.EndControlPoint.IsEqualTo(defaultValues.EndControlPoint))
            {
                bezierCurve2DNode.Add(beziercurve2d.EndControlPoint.ToXml("EndControlPoint"));
            }

            if (!beziercurve2d.EndPoint.IsEqualTo(defaultValues.EndPoint))
            {
                bezierCurve2DNode.Add(beziercurve2d.EndPoint.ToXml("EndPoint"));
            }

            return bezierCurve2DNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyStringValue" />.
        /// </summary>
        public static XElement ToXml(this KeyStringValue keystringvalue, string nodeName)
        {
            var defaultValues = new KeyStringValue();
            var keyStringValueNode = new XElement(nodeName);
            if (!keystringvalue.Key.IsEqualTo(defaultValues.Key))
            {
                keyStringValueNode.Add(new XAttribute("Key", keystringvalue.Key.ToString<string>()));
            }

            if (!keystringvalue.Value.IsEqualTo(defaultValues.Value))
            {
                keyStringValueNode.Add(new XAttribute("Value", keystringvalue.Value.ToString<string>()));
            }

            return keyStringValueNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyDoubleValue" />.
        /// </summary>
        public static XElement ToXml(this KeyDoubleValue keydoublevalue, string nodeName)
        {
            var defaultValues = new KeyDoubleValue();
            var keyDoubleValueNode = new XElement(nodeName);
            if (!keydoublevalue.Key.IsEqualTo(defaultValues.Key))
            {
                keyDoubleValueNode.Add(new XAttribute("Key", keydoublevalue.Key.ToString<string>()));
            }

            if (!keydoublevalue.Value.IsEqualTo(defaultValues.Value))
            {
                keyDoubleValueNode.Add(new XAttribute("Value", keydoublevalue.Value.ToString<double>()));
            }

            return keyDoubleValueNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyBoolValue" />.
        /// </summary>
        public static XElement ToXml(this KeyBoolValue keyboolvalue, string nodeName)
        {
            var defaultValues = new KeyBoolValue();
            var keyBoolValueNode = new XElement(nodeName);
            if (!keyboolvalue.Key.IsEqualTo(defaultValues.Key))
            {
                keyBoolValueNode.Add(new XAttribute("Key", keyboolvalue.Key.ToString<string>()));
            }

            if (!keyboolvalue.Value.IsEqualTo(defaultValues.Value))
            {
                keyBoolValueNode.Add(new XAttribute("Value", keyboolvalue.Value.ToString<bool>()));
            }

            return keyBoolValueNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="AliasedString" />.
        /// </summary>
        public static XElement ToXml(this AliasedString aliasedstring, string nodeName)
        {
            var defaultValues = new AliasedString();
            var aliasedStringNode = new XElement(nodeName);
            if (!aliasedstring.Default.IsEqualTo(defaultValues.Default))
            {
                aliasedStringNode.Add(new XAttribute("Default", aliasedstring.Default.ToString<string>()));
            }

            if (!aliasedstring.Aliases.IsEqualTo(defaultValues.Aliases))
            {
                if (aliasedstring.Aliases.Count != 0)
                {
                    var aliasesNode = new XElement("Aliases");
                    foreach (var item in aliasedstring.Aliases)
                    {
                        aliasesNode.Add(ToXml(item, "KeyStringValue"));
                    }
                    aliasedStringNode.Add(aliasesNode);
                }
            }

            return aliasedStringNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyIntegerValue" />.
        /// </summary>
        public static XElement ToXml(this KeyIntegerValue keyintegervalue, string nodeName)
        {
            var defaultValues = new KeyIntegerValue();
            var keyIntegerValueNode = new XElement(nodeName);
            if (!keyintegervalue.Key.IsEqualTo(defaultValues.Key))
            {
                keyIntegerValueNode.Add(new XAttribute("Key", keyintegervalue.Key.ToString<string>()));
            }

            if (!keyintegervalue.Value.IsEqualTo(defaultValues.Value))
            {
                keyIntegerValueNode.Add(new XAttribute("Value", keyintegervalue.Value.ToString<int>()));
            }

            return keyIntegerValueNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="GuidMapItem" />.
        /// </summary>
        public static XElement ToXml(this GuidMapItem guidmapitem, string nodeName)
        {
            var defaultValues = new GuidMapItem();
            var guidMapItemNode = new XElement(nodeName);
            if (!guidmapitem.BaseID.IsEqualTo(defaultValues.BaseID))
            {
                guidMapItemNode.Add(new XElement("BaseID", guidmapitem.BaseID));
            }

            if (!guidmapitem.ReplacedWith.IsEqualTo(defaultValues.ReplacedWith))
            {
                guidMapItemNode.Add(new XElement("ReplacedWith", guidmapitem.ReplacedWith));
            }

            return guidMapItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="KeyValues" />.
        /// </summary>
        public static XElement ToXml(this KeyValues keyvalues, string nodeName)
        {
            var defaultValues = new KeyValues();
            var keyValuesNode = new XElement(nodeName);
            if (!keyvalues.DoubleValues.IsEqualTo(defaultValues.DoubleValues))
            {
                if (keyvalues.DoubleValues.Count != 0)
                {
                    var doubleValuesNode = new XElement("DoubleValues");
                    foreach (var item in keyvalues.DoubleValues)
                    {
                        doubleValuesNode.Add(ToXml(item, "KeyDoubleValue"));
                    }
                    keyValuesNode.Add(doubleValuesNode);
                }
            }

            if (!keyvalues.IntegerValues.IsEqualTo(defaultValues.IntegerValues))
            {
                if (keyvalues.IntegerValues.Count != 0)
                {
                    var integerValuesNode = new XElement("IntegerValues");
                    foreach (var item in keyvalues.IntegerValues)
                    {
                        integerValuesNode.Add(ToXml(item, "KeyIntegerValue"));
                    }
                    keyValuesNode.Add(integerValuesNode);
                }
            }

            if (!keyvalues.StringValues.IsEqualTo(defaultValues.StringValues))
            {
                if (keyvalues.StringValues.Count != 0)
                {
                    var stringValuesNode = new XElement("StringValues");
                    foreach (var item in keyvalues.StringValues)
                    {
                        stringValuesNode.Add(ToXml(item, "KeyStringValue"));
                    }
                    keyValuesNode.Add(stringValuesNode);
                }
            }

            if (!keyvalues.BoolValues.IsEqualTo(defaultValues.BoolValues))
            {
                if (keyvalues.BoolValues.Count != 0)
                {
                    var boolValuesNode = new XElement("BoolValues");
                    foreach (var item in keyvalues.BoolValues)
                    {
                        boolValuesNode.Add(ToXml(item, "KeyBoolValue"));
                    }
                    keyValuesNode.Add(boolValuesNode);
                }
            }

            return keyValuesNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Tag" />.
        /// </summary>
        public static XElement ToXml(this Tag tag, string nodeName)
        {
            var defaultValues = new Tag();
            var tagNode = new XElement(nodeName);
            if (!tag.ID.IsEqualTo(defaultValues.ID))
            {
                tagNode.Add(new XAttribute("ID", tag.ID.ToString<System.Guid>()));
            }

            if (!tag.Name.IsEqualTo(defaultValues.Name))
            {
                tagNode.Add(tag.Name.ToXml("Name"));
            }

            return tagNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Function" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Function function, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Function();
            var functionNode = new XElement(nodeName);
            if (!function.ID.IsEqualTo(defaultValues.ID))
            {
                functionNode.Add(new XAttribute("ID", function.ID.ToString<int>()));
            }

            if (!function.InterpolationMethod.IsEqualTo(defaultValues.InterpolationMethod))
            {
                functionNode.Add(new XElement("InterpolationMethod", function.InterpolationMethod));
            }

            if (!function.QuantityX.IsEqualTo(defaultValues.QuantityX))
            {
                functionNode.Add(new XElement("QuantityX", function.QuantityX));
            }

            if (!function.QuantityY.IsEqualTo(defaultValues.QuantityY))
            {
                functionNode.Add(new XElement("QuantityY", function.QuantityY));
            }

            if (!function.Points.IsEqualTo(defaultValues.Points))
            {
                functionNode.Add(function.Points.ToXml("Points"));
            }

            return functionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyFunction" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.PropertyFunction propertyfunction, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.PropertyFunction();
            var propertyFunctionNode = new XElement(nodeName);
            if (!propertyfunction.ID.IsEqualTo(defaultValues.ID))
            {
                propertyFunctionNode.Add(new XAttribute("ID", propertyfunction.ID.ToString<int>()));
            }

            if (!propertyfunction.InterpolationMethod.IsEqualTo(defaultValues.InterpolationMethod))
            {
                propertyFunctionNode.Add(new XElement("InterpolationMethod", propertyfunction.InterpolationMethod));
            }

            if (!propertyfunction.Key.IsEqualTo(defaultValues.Key))
            {
                propertyFunctionNode.Add(new XElement("Key", propertyfunction.Key));
            }

            if (!propertyfunction.Points.IsEqualTo(defaultValues.Points))
            {
                if (propertyfunction.Points.Count != 0)
                {
                    var pointsNode = new XElement("Points");
                    foreach (var item in propertyfunction.Points)
                    {
                        pointsNode.Add(ToXml(item, "Vector2"));
                    }
                    propertyFunctionNode.Add(pointsNode);
                }
            }

            return propertyFunctionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.MaterialProperties" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.MaterialProperties materialproperties, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.MaterialProperties();
            var materialPropertiesNode = new XElement(nodeName);
            if (!materialproperties.ID.IsEqualTo(defaultValues.ID))
            {
                materialPropertiesNode.Add(new XAttribute("ID", materialproperties.ID.ToString<int>()));
            }

            if (!materialproperties.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                materialPropertiesNode.Add(new XElement("MaterialID", materialproperties.MaterialID));
            }

            if (!materialproperties.IsFireCoating.IsEqualTo(defaultValues.IsFireCoating))
            {
                materialPropertiesNode.Add(new XElement("IsFireCoating", materialproperties.IsFireCoating));
            }

            if (!materialproperties.IsStructural.IsEqualTo(defaultValues.IsStructural))
            {
                materialPropertiesNode.Add(new XElement("IsStructural", materialproperties.IsStructural));
            }

            if (!materialproperties.PropertyGroups.IsEqualTo(defaultValues.PropertyGroups))
            {
                if (materialproperties.PropertyGroups.Count != 0)
                {
                    var propertyGroupsNode = new XElement("PropertyGroups");
                    foreach (var item in materialproperties.PropertyGroups)
                    {
                        propertyGroupsNode.Add(ToXml(item, "MaterialPropertyGroup"));
                    }
                    materialPropertiesNode.Add(propertyGroupsNode);
                }
            }

            return materialPropertiesNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.MaterialPropertyGroup" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.MaterialPropertyGroup materialpropertygroup, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.MaterialPropertyGroup();
            var materialPropertyGroupNode = new XElement(nodeName);
            if (!materialpropertygroup.ID.IsEqualTo(defaultValues.ID))
            {
                materialPropertyGroupNode.Add(new XAttribute("ID", materialpropertygroup.ID.ToString<int>()));
            }

            if (!materialpropertygroup.Standard.IsEqualTo(defaultValues.Standard))
            {
                materialPropertyGroupNode.Add(new XElement("Standard", materialpropertygroup.Standard));
            }

            if (!materialpropertygroup.UserDefined.IsEqualTo(defaultValues.UserDefined))
            {
                materialPropertyGroupNode.Add(new XElement("UserDefined", materialpropertygroup.UserDefined));
            }

            if (!materialpropertygroup.Values.IsEqualTo(defaultValues.Values))
            {
                if (materialpropertygroup.Values.Count != 0)
                {
                    var valuesNode = new XElement("Values");
                    foreach (var item in materialpropertygroup.Values)
                    {
                        valuesNode.Add(ToXml(item, "PropertyValue"));
                    }
                    materialPropertyGroupNode.Add(valuesNode);
                }
            }

            if (!materialpropertygroup.Flags.IsEqualTo(defaultValues.Flags))
            {
                if (materialpropertygroup.Flags.Count != 0)
                {
                    var flagsNode = new XElement("Flags");
                    foreach (var item in materialpropertygroup.Flags)
                    {
                        flagsNode.Add(ToXml(item, "PropertyFlag"));
                    }
                    materialPropertyGroupNode.Add(flagsNode);
                }
            }

            if (!materialpropertygroup.Texts.IsEqualTo(defaultValues.Texts))
            {
                if (materialpropertygroup.Texts.Count != 0)
                {
                    var textsNode = new XElement("Texts");
                    foreach (var item in materialpropertygroup.Texts)
                    {
                        textsNode.Add(ToXml(item, "PropertyText"));
                    }
                    materialPropertyGroupNode.Add(textsNode);
                }
            }

            if (!materialpropertygroup.Functions.IsEqualTo(defaultValues.Functions))
            {
                if (materialpropertygroup.Functions.Count != 0)
                {
                    var functionsNode = new XElement("Functions");
                    foreach (var item in materialpropertygroup.Functions)
                    {
                        functionsNode.Add(ToXml(item, "PropertyFunction"));
                    }
                    materialPropertyGroupNode.Add(functionsNode);
                }
            }

            return materialPropertyGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.SectionPropertyGroup" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.SectionPropertyGroup sectionpropertygroup, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.SectionPropertyGroup();
            var sectionPropertyGroupNode = new XElement(nodeName);
            if (!sectionpropertygroup.ID.IsEqualTo(defaultValues.ID))
            {
                sectionPropertyGroupNode.Add(new XAttribute("ID", sectionpropertygroup.ID.ToString<int>()));
            }

            if (!sectionpropertygroup.Standard.IsEqualTo(defaultValues.Standard))
            {
                sectionPropertyGroupNode.Add(new XElement("Standard", sectionpropertygroup.Standard));
            }

            if (!sectionpropertygroup.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (sectionpropertygroup.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in sectionpropertygroup.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    sectionPropertyGroupNode.Add(materialOverridesNode);
                }
            }

            if (!sectionpropertygroup.Description.IsEqualTo(defaultValues.Description))
            {
                sectionPropertyGroupNode.Add(sectionpropertygroup.Description.ToXml("Description"));
            }

            if (!sectionpropertygroup.UserDefined.IsEqualTo(defaultValues.UserDefined))
            {
                sectionPropertyGroupNode.Add(new XElement("UserDefined", sectionpropertygroup.UserDefined));
            }

            if (!sectionpropertygroup.Values.IsEqualTo(defaultValues.Values))
            {
                if (sectionpropertygroup.Values.Count != 0)
                {
                    var valuesNode = new XElement("Values");
                    foreach (var item in sectionpropertygroup.Values)
                    {
                        valuesNode.Add(ToXml(item, "PropertyValue"));
                    }
                    sectionPropertyGroupNode.Add(valuesNode);
                }
            }

            if (!sectionpropertygroup.Flags.IsEqualTo(defaultValues.Flags))
            {
                if (sectionpropertygroup.Flags.Count != 0)
                {
                    var flagsNode = new XElement("Flags");
                    foreach (var item in sectionpropertygroup.Flags)
                    {
                        flagsNode.Add(ToXml(item, "PropertyFlag"));
                    }
                    sectionPropertyGroupNode.Add(flagsNode);
                }
            }

            if (!sectionpropertygroup.Texts.IsEqualTo(defaultValues.Texts))
            {
                if (sectionpropertygroup.Texts.Count != 0)
                {
                    var textsNode = new XElement("Texts");
                    foreach (var item in sectionpropertygroup.Texts)
                    {
                        textsNode.Add(ToXml(item, "PropertyText"));
                    }
                    sectionPropertyGroupNode.Add(textsNode);
                }
            }

            if (!sectionpropertygroup.Functions.IsEqualTo(defaultValues.Functions))
            {
                if (sectionpropertygroup.Functions.Count != 0)
                {
                    var functionsNode = new XElement("Functions");
                    foreach (var item in sectionpropertygroup.Functions)
                    {
                        functionsNode.Add(ToXml(item, "PropertyFunction"));
                    }
                    sectionPropertyGroupNode.Add(functionsNode);
                }
            }

            return sectionPropertyGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyValue" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.PropertyValue propertyvalue, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.PropertyValue();
            var propertyValueNode = new XElement(nodeName);
            if (!propertyvalue.ID.IsEqualTo(defaultValues.ID))
            {
                propertyValueNode.Add(new XAttribute("ID", propertyvalue.ID.ToString<int>()));
            }

            if (!propertyvalue.Key.IsEqualTo(defaultValues.Key))
            {
                propertyValueNode.Add(new XElement("Key", propertyvalue.Key));
            }

            if (!propertyvalue.Value.IsEqualTo(defaultValues.Value))
            {
                propertyValueNode.Add(new XElement("Value", propertyvalue.Value));
            }

            return propertyValueNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyText" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.PropertyText propertytext, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.PropertyText();
            var propertyTextNode = new XElement(nodeName);
            if (!propertytext.ID.IsEqualTo(defaultValues.ID))
            {
                propertyTextNode.Add(new XAttribute("ID", propertytext.ID.ToString<int>()));
            }

            if (!propertytext.Key.IsEqualTo(defaultValues.Key))
            {
                propertyTextNode.Add(new XElement("Key", propertytext.Key));
            }

            if (!propertytext.Value.IsEqualTo(defaultValues.Value))
            {
                propertyTextNode.Add(new XElement("Value", propertytext.Value));
            }

            return propertyTextNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.PropertyFlag" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.PropertyFlag propertyflag, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.PropertyFlag();
            var propertyFlagNode = new XElement(nodeName);
            if (!propertyflag.ID.IsEqualTo(defaultValues.ID))
            {
                propertyFlagNode.Add(new XAttribute("ID", propertyflag.ID.ToString<int>()));
            }

            if (!propertyflag.Key.IsEqualTo(defaultValues.Key))
            {
                propertyFlagNode.Add(new XElement("Key", propertyflag.Key));
            }

            if (!propertyflag.Value.IsEqualTo(defaultValues.Value))
            {
                propertyFlagNode.Add(new XElement("Value", propertyflag.Value));
            }

            return propertyFlagNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Settings settings, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Settings();
            var settingsNode = new XElement(nodeName);
            if (!settings.General.IsEqualTo(defaultValues.General))
            {
                settingsNode.Add(settings.General.ToXml("General"));
            }

            if (!settings.StandardChecks.IsEqualTo(defaultValues.StandardChecks))
            {
                if (settings.StandardChecks.Count != 0)
                {
                    var standardChecksNode = new XElement("StandardChecks");
                    foreach (var item in settings.StandardChecks)
                    {
                        standardChecksNode.Add(ToXml(item, "StandardCheck"));
                    }
                    settingsNode.Add(standardChecksNode);
                }
            }

            return settingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.StandardCheck" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.StandardCheck standardcheck, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.StandardCheck();
            var standardCheckNode = new XElement(nodeName);
            if (!standardcheck.Standard.IsEqualTo(defaultValues.Standard))
            {
                standardCheckNode.Add(new XElement("Standard", standardcheck.Standard));
            }

            if (!standardcheck.General.IsEqualTo(defaultValues.General))
            {
                standardCheckNode.Add(standardcheck.General.ToXml("General"));
            }

            if (!standardcheck.Bars.IsEqualTo(defaultValues.Bars))
            {
                if (standardcheck.Bars.Count != 0)
                {
                    var barsNode = new XElement("Bars");
                    foreach (var item in standardcheck.Bars)
                    {
                        barsNode.Add(ToXml(item, "ElementSettings"));
                    }
                    standardCheckNode.Add(barsNode);
                }
            }

            if (!standardcheck.Plates.IsEqualTo(defaultValues.Plates))
            {
                if (standardcheck.Plates.Count != 0)
                {
                    var platesNode = new XElement("Plates");
                    foreach (var item in standardcheck.Plates)
                    {
                        platesNode.Add(ToXml(item, "ElementSettings"));
                    }
                    standardCheckNode.Add(platesNode);
                }
            }

            return standardCheckNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Model" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Model model, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Model();
            var modelNode = new XElement(nodeName);
            if (!model.Name.IsEqualTo(defaultValues.Name))
            {
                modelNode.Add(model.Name.ToXml("Name"));
            }

            if (!model.ID.IsEqualTo(defaultValues.ID))
            {
                modelNode.Add(new XAttribute("ID", model.ID.ToString<System.Guid>()));
            }

            if (!model.Functions.IsEqualTo(defaultValues.Functions))
            {
                if (model.Functions.Count != 0)
                {
                    var functionsNode = new XElement("Functions");
                    foreach (var item in model.Functions)
                    {
                        functionsNode.Add(ToXml(item, "Function"));
                    }
                    modelNode.Add(functionsNode);
                }
            }

            if (!model.SoilProfiles.IsEqualTo(defaultValues.SoilProfiles))
            {
                if (model.SoilProfiles.Count != 0)
                {
                    var soilProfilesNode = new XElement("SoilProfiles");
                    foreach (var item in model.SoilProfiles)
                    {
                        soilProfilesNode.Add(ToXml(item, "SoilProfile"));
                    }
                    modelNode.Add(soilProfilesNode);
                }
            }

            if (!model.MaterialProperties.IsEqualTo(defaultValues.MaterialProperties))
            {
                if (model.MaterialProperties.Count != 0)
                {
                    var materialPropertiesNode = new XElement("MaterialProperties");
                    foreach (var item in model.MaterialProperties)
                    {
                        materialPropertiesNode.Add(ToXml(item, "MaterialProperties"));
                    }
                    modelNode.Add(materialPropertiesNode);
                }
            }

            if (!model.SectionProperties.IsEqualTo(defaultValues.SectionProperties))
            {
                if (model.SectionProperties.Count != 0)
                {
                    var sectionPropertiesNode = new XElement("SectionProperties");
                    foreach (var item in model.SectionProperties)
                    {
                        sectionPropertiesNode.Add(ToXml(item, "SectionProperties"));
                    }
                    modelNode.Add(sectionPropertiesNode);
                }
            }

            if (!model.Points.IsEqualTo(defaultValues.Points))
            {
                if (model.Points.Count != 0)
                {
                    var pointsNode = new XElement("Points");
                    foreach (var item in model.Points)
                    {
                        pointsNode.Add(ToXml(item, "Point"));
                    }
                    modelNode.Add(pointsNode);
                }
            }

            if (!model.Bars.IsEqualTo(defaultValues.Bars))
            {
                if (model.Bars.Count != 0)
                {
                    var barsNode = new XElement("Bars");
                    foreach (var item in model.Bars)
                    {
                        barsNode.Add(ToXml(item, "Bar"));
                    }
                    modelNode.Add(barsNode);
                }
            }

            if (!model.Plates.IsEqualTo(defaultValues.Plates))
            {
                if (model.Plates.Count != 0)
                {
                    var platesNode = new XElement("Plates");
                    foreach (var item in model.Plates)
                    {
                        platesNode.Add(ToXml(item, "Plate"));
                    }
                    modelNode.Add(platesNode);
                }
            }

            if (!model.BarGroups.IsEqualTo(defaultValues.BarGroups))
            {
                if (model.BarGroups.Count != 0)
                {
                    var barGroupsNode = new XElement("BarGroups");
                    foreach (var item in model.BarGroups)
                    {
                        barGroupsNode.Add(ToXml(item, "BarGroup"));
                    }
                    modelNode.Add(barGroupsNode);
                }
            }

            if (!model.PlateGroups.IsEqualTo(defaultValues.PlateGroups))
            {
                if (model.PlateGroups.Count != 0)
                {
                    var plateGroupsNode = new XElement("PlateGroups");
                    foreach (var item in model.PlateGroups)
                    {
                        plateGroupsNode.Add(ToXml(item, "PlateGroup"));
                    }
                    modelNode.Add(plateGroupsNode);
                }
            }

            if (!model.Loads.IsEqualTo(defaultValues.Loads))
            {
                modelNode.Add(model.Loads.ToXml("Loads"));
            }

            if (!model.GeometryMeshes.IsEqualTo(defaultValues.GeometryMeshes))
            {
                if (model.GeometryMeshes.Count != 0)
                {
                    var geometryMeshesNode = new XElement("GeometryMeshes");
                    foreach (var item in model.GeometryMeshes)
                    {
                        geometryMeshesNode.Add(ToXml(item, "GeometryMesh"));
                    }
                    modelNode.Add(geometryMeshesNode);
                }
            }

            if (!model.SectionMeshes.IsEqualTo(defaultValues.SectionMeshes))
            {
                if (model.SectionMeshes.Count != 0)
                {
                    var sectionMeshesNode = new XElement("SectionMeshes");
                    foreach (var item in model.SectionMeshes)
                    {
                        sectionMeshesNode.Add(ToXml(item, "SectionMesh"));
                    }
                    modelNode.Add(sectionMeshesNode);
                }
            }

            if (!model.Results.IsEqualTo(defaultValues.Results))
            {
                if (model.Results.Count != 0)
                {
                    var resultsNode = new XElement("Results");
                    foreach (var item in model.Results)
                    {
                        resultsNode.Add(ToXml(item, "ResultSet"));
                    }
                    modelNode.Add(resultsNode);
                }
            }

            if (!model.ConnectionsVerification.IsEqualTo(defaultValues.ConnectionsVerification))
            {
                if (model.ConnectionsVerification.Count != 0)
                {
                    var connectionsVerificationNode = new XElement("ConnectionsVerification");
                    foreach (var item in model.ConnectionsVerification)
                    {
                        connectionsVerificationNode.Add(ToXml(item, "ItemVerification"));
                    }
                    modelNode.Add(connectionsVerificationNode);
                }
            }

            if (!model.MeshSettings.IsEqualTo(defaultValues.MeshSettings))
            {
                if (model.MeshSettings.Count != 0)
                {
                    var meshSettingsNode = new XElement("MeshSettings");
                    foreach (var item in model.MeshSettings)
                    {
                        meshSettingsNode.Add(ToXml(item, "Settings"));
                    }
                    modelNode.Add(meshSettingsNode);
                }
            }

            if (!model.AnalysisSettings.IsEqualTo(defaultValues.AnalysisSettings))
            {
                modelNode.Add(model.AnalysisSettings.ToXml("AnalysisSettings"));
            }

            if (!model.FireSettings.IsEqualTo(defaultValues.FireSettings))
            {
                modelNode.Add(model.FireSettings.ToXml("FireSettings"));
            }

            return modelNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.SectionProperties" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.SectionProperties sectionproperties, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.SectionProperties();
            var sectionPropertiesNode = new XElement(nodeName);
            if (!sectionproperties.ID.IsEqualTo(defaultValues.ID))
            {
                sectionPropertiesNode.Add(new XAttribute("ID", sectionproperties.ID.ToString<int>()));
            }

            if (!sectionproperties.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                sectionPropertiesNode.Add(new XElement("SectionID", sectionproperties.SectionID));
            }

            if (!sectionproperties.PropertyGroups.IsEqualTo(defaultValues.PropertyGroups))
            {
                if (sectionproperties.PropertyGroups.Count != 0)
                {
                    var propertyGroupsNode = new XElement("PropertyGroups");
                    foreach (var item in sectionproperties.PropertyGroups)
                    {
                        propertyGroupsNode.Add(ToXml(item, "SectionPropertyGroup"));
                    }
                    sectionPropertiesNode.Add(propertyGroupsNode);
                }
            }

            return sectionPropertiesNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.ElementSettings" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.ElementSettings elementsettings, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.ElementSettings();
            var elementSettingsNode = new XElement(nodeName);
            if (!elementsettings.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                elementSettingsNode.Add(new XElement("ReferenceID", elementsettings.ReferenceID));
            }

            if (!elementsettings.Values.IsEqualTo(defaultValues.Values))
            {
                elementSettingsNode.Add(elementsettings.Values.ToXml("Values"));
            }

            return elementSettingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static XElement ToXml(this Settings settings, string nodeName)
        {
            var defaultValues = new Settings();
            var settingsNode = new XElement(nodeName);
            if (!settings.PredefinedFireConfigurations.IsEqualTo(defaultValues.PredefinedFireConfigurations))
            {
                if (settings.PredefinedFireConfigurations.Count != 0)
                {
                    var predefinedFireConfigurationsNode = new XElement("PredefinedFireConfigurations");
                    foreach (var item in settings.PredefinedFireConfigurations)
                    {
                        predefinedFireConfigurationsNode.Add(ToXml(item, "PredefinedFireConfiguration"));
                    }
                    settingsNode.Add(predefinedFireConfigurationsNode);
                }
            }

            if (!settings.CustomFireConfigurations.IsEqualTo(defaultValues.CustomFireConfigurations))
            {
                if (settings.CustomFireConfigurations.Count != 0)
                {
                    var customFireConfigurationsNode = new XElement("CustomFireConfigurations");
                    foreach (var item in settings.CustomFireConfigurations)
                    {
                        customFireConfigurationsNode.Add(ToXml(item, "CustomFireConfiguration"));
                    }
                    settingsNode.Add(customFireConfigurationsNode);
                }
            }

            if (!settings.BarFireInformations.IsEqualTo(defaultValues.BarFireInformations))
            {
                if (settings.BarFireInformations.Count != 0)
                {
                    var barFireInformationsNode = new XElement("BarFireInformations");
                    foreach (var item in settings.BarFireInformations)
                    {
                        barFireInformationsNode.Add(ToXml(item, "BarFireInfo"));
                    }
                    settingsNode.Add(barFireInformationsNode);
                }
            }

            return settingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PredefinedFireConfiguration" />.
        /// </summary>
        public static XElement ToXml(this PredefinedFireConfiguration predefinedfireconfiguration, string nodeName)
        {
            var defaultValues = new PredefinedFireConfiguration();
            var predefinedFireConfigurationNode = new XElement(nodeName);
            if (!predefinedfireconfiguration.ID.IsEqualTo(defaultValues.ID))
            {
                predefinedFireConfigurationNode.Add(new XAttribute("ID", predefinedfireconfiguration.ID.ToString<int>()));
            }

            if (!predefinedfireconfiguration.ProtectionType.IsEqualTo(defaultValues.ProtectionType))
            {
                predefinedFireConfigurationNode.Add(new XElement("ProtectionType", predefinedfireconfiguration.ProtectionType));
            }

            if (!predefinedfireconfiguration.Thickness.IsEqualTo(defaultValues.Thickness))
            {
                predefinedFireConfigurationNode.Add(new XElement("Thickness", predefinedfireconfiguration.Thickness));
            }

            if (!predefinedfireconfiguration.MaterialID.IsEqualTo(defaultValues.MaterialID))
            {
                predefinedFireConfigurationNode.Add(new XElement("MaterialID", predefinedfireconfiguration.MaterialID));
            }

            return predefinedFireConfigurationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="FireExposureZone" />.
        /// </summary>
        public static XElement ToXml(this FireExposureZone fireexposurezone, string nodeName)
        {
            var defaultValues = new FireExposureZone();
            var fireExposureZoneNode = new XElement(nodeName);
            if (!fireexposurezone.Vertices.IsEqualTo(defaultValues.Vertices))
            {
                if (fireexposurezone.Vertices.Count != 0)
                {
                    var verticesNode = new XElement("Vertices");
                    foreach (var item in fireexposurezone.Vertices)
                    {
                        verticesNode.Add(ToXml(item, "Vector2"));
                    }
                    fireExposureZoneNode.Add(verticesNode);
                }
            }

            return fireExposureZoneNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomFireConfiguration" />.
        /// </summary>
        public static XElement ToXml(this CustomFireConfiguration customfireconfiguration, string nodeName)
        {
            var defaultValues = new CustomFireConfiguration();
            var customFireConfigurationNode = new XElement(nodeName);
            if (!customfireconfiguration.ID.IsEqualTo(defaultValues.ID))
            {
                customFireConfigurationNode.Add(new XAttribute("ID", customfireconfiguration.ID.ToString<int>()));
            }

            if (!customfireconfiguration.FireExposureZones.IsEqualTo(defaultValues.FireExposureZones))
            {
                if (customfireconfiguration.FireExposureZones.Count != 0)
                {
                    var fireExposureZonesNode = new XElement("FireExposureZones");
                    foreach (var item in customfireconfiguration.FireExposureZones)
                    {
                        fireExposureZonesNode.Add(ToXml(item, "FireExposureZone"));
                    }
                    customFireConfigurationNode.Add(fireExposureZonesNode);
                }
            }

            if (!customfireconfiguration.AdiabaticLines.IsEqualTo(defaultValues.AdiabaticLines))
            {
                if (customfireconfiguration.AdiabaticLines.Count != 0)
                {
                    var adiabaticLinesNode = new XElement("AdiabaticLines");
                    foreach (var item in customfireconfiguration.AdiabaticLines)
                    {
                        adiabaticLinesNode.Add(ToXml(item, "BezierCurve2D"));
                    }
                    customFireConfigurationNode.Add(adiabaticLinesNode);
                }
            }

            if (!customfireconfiguration.CustomFireSection.IsEqualTo(defaultValues.CustomFireSection))
            {
                customFireConfigurationNode.Add(new XElement("CustomFireSection", customfireconfiguration.CustomFireSection));
            }

            return customFireConfigurationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BarFireInfo" />.
        /// </summary>
        public static XElement ToXml(this BarFireInfo barfireinfo, string nodeName)
        {
            var defaultValues = new BarFireInfo();
            var barFireInfoNode = new XElement(nodeName);
            if (!barfireinfo.BarID.IsEqualTo(defaultValues.BarID))
            {
                barFireInfoNode.Add(new XElement("BarID", barfireinfo.BarID));
            }

            if (!barfireinfo.FireExposureCurve.IsEqualTo(defaultValues.FireExposureCurve))
            {
                barFireInfoNode.Add(new XElement("FireExposureCurve", barfireinfo.FireExposureCurve));
            }

            if (!barfireinfo.CustomFireCurveID.IsEqualTo(defaultValues.CustomFireCurveID))
            {
                barFireInfoNode.Add(new XElement("CustomFireCurveID", barfireinfo.CustomFireCurveID));
            }

            if (!barfireinfo.FireExposureTime.IsEqualTo(defaultValues.FireExposureTime))
            {
                barFireInfoNode.Add(new XElement("FireExposureTime", barfireinfo.FireExposureTime));
            }

            if (!barfireinfo.ConfigurationID.IsEqualTo(defaultValues.ConfigurationID))
            {
                barFireInfoNode.Add(new XElement("ConfigurationID", barfireinfo.ConfigurationID));
            }

            return barFireInfoNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ResultSet" />.
        /// </summary>
        public static XElement ToXml(this ResultSet resultset, string nodeName)
        {
            var defaultValues = new ResultSet();
            var resultSetNode = new XElement(nodeName);
            if (!resultset.MeshID.IsEqualTo(defaultValues.MeshID))
            {
                resultSetNode.Add(new XElement("MeshID", resultset.MeshID));
            }

            if (!resultset.RecordMap.IsEqualTo(defaultValues.RecordMap))
            {
                resultSetNode.Add(resultset.RecordMap.ToXml("RecordMap"));
            }

            if (!resultset.Name.IsEqualTo(defaultValues.Name))
            {
                resultSetNode.Add(resultset.Name.ToXml("Name"));
            }

            if (!resultset.ResultType.IsEqualTo(defaultValues.ResultType))
            {
                resultSetNode.Add(new XElement("ResultType", resultset.ResultType));
            }

            if (!resultset.ResultID.IsEqualTo(defaultValues.ResultID))
            {
                resultSetNode.Add(new XElement("ResultID", resultset.ResultID));
            }

            if (!resultset.Tables.IsEqualTo(defaultValues.Tables))
            {
                if (resultset.Tables.Count != 0)
                {
                    var tablesNode = new XElement("Tables");
                    foreach (var item in resultset.Tables)
                    {
                        tablesNode.Add(ToXml(item, "TableGroup"));
                    }
                    resultSetNode.Add(tablesNode);
                }
            }

            if (!resultset.Options.IsEqualTo(defaultValues.Options))
            {
                resultSetNode.Add(resultset.Options.ToXml("Options"));
            }

            return resultSetNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Check" />.
        /// </summary>
        public static XElement ToXml(this Check check, string nodeName)
        {
            var defaultValues = new Check();
            var checkNode = new XElement(nodeName);
            if (!check.Name.IsEqualTo(defaultValues.Name))
            {
                checkNode.Add(check.Name.ToXml("Name"));
            }

            if (!check.Standard.IsEqualTo(defaultValues.Standard))
            {
                checkNode.Add(new XElement("Standard", check.Standard));
            }

            if (!check.Status.IsEqualTo(defaultValues.Status))
            {
                checkNode.Add(new XElement("Status", check.Status));
            }

            if (!check.UnityCheck.IsEqualTo(defaultValues.UnityCheck))
            {
                checkNode.Add(new XElement("UnityCheck", check.UnityCheck));
            }

            if (!check.Options.IsEqualTo(defaultValues.Options))
            {
                checkNode.Add(check.Options.ToXml("Options"));
            }

            return checkNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ItemVerification" />.
        /// </summary>
        public static XElement ToXml(this ItemVerification itemverification, string nodeName)
        {
            var defaultValues = new ItemVerification();
            var itemVerificationNode = new XElement(nodeName);
            if (!itemverification.ItemID.IsEqualTo(defaultValues.ItemID))
            {
                itemVerificationNode.Add(new XElement("ItemID", itemverification.ItemID));
            }

            if (!itemverification.ToolName.IsEqualTo(defaultValues.ToolName))
            {
                itemVerificationNode.Add(new XElement("ToolName", itemverification.ToolName));
            }

            if (!itemverification.EngineerName.IsEqualTo(defaultValues.EngineerName))
            {
                itemVerificationNode.Add(new XElement("EngineerName", itemverification.EngineerName));
            }

            if (!itemverification.Date.IsEqualTo(defaultValues.Date))
            {
                itemVerificationNode.Add(new XElement("Date", itemverification.Date));
            }

            if (!itemverification.Checks.IsEqualTo(defaultValues.Checks))
            {
                if (itemverification.Checks.Count != 0)
                {
                    var checksNode = new XElement("Checks");
                    foreach (var item in itemverification.Checks)
                    {
                        checksNode.Add(ToXml(item, "Check"));
                    }
                    itemVerificationNode.Add(checksNode);
                }
            }

            return itemVerificationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="NodeMappingItem" />.
        /// </summary>
        public static XElement ToXml(this NodeMappingItem nodemappingitem, string nodeName)
        {
            var defaultValues = new NodeMappingItem();
            var nodeMappingItemNode = new XElement(nodeName);
            if (!nodemappingitem.SourceID.IsEqualTo(defaultValues.SourceID))
            {
                nodeMappingItemNode.Add(new XElement("SourceID", nodemappingitem.SourceID));
            }

            if (!nodemappingitem.RecordIndex.IsEqualTo(defaultValues.RecordIndex))
            {
                nodeMappingItemNode.Add(new XElement("RecordIndex", nodemappingitem.RecordIndex));
            }

            return nodeMappingItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Line2MappingItem" />.
        /// </summary>
        public static XElement ToXml(this Line2MappingItem line2Mappingitem, string nodeName)
        {
            var defaultValues = new Line2MappingItem();
            var line2MappingItemNode = new XElement(nodeName);
            if (!line2Mappingitem.SourceID.IsEqualTo(defaultValues.SourceID))
            {
                line2MappingItemNode.Add(new XElement("SourceID", line2Mappingitem.SourceID));
            }

            if (!line2Mappingitem.RecordIndex1.IsEqualTo(defaultValues.RecordIndex1))
            {
                line2MappingItemNode.Add(new XElement("RecordIndex1", line2Mappingitem.RecordIndex1));
            }

            if (!line2Mappingitem.RecordIndex2.IsEqualTo(defaultValues.RecordIndex2))
            {
                line2MappingItemNode.Add(new XElement("RecordIndex2", line2Mappingitem.RecordIndex2));
            }

            return line2MappingItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Line3MappingItem" />.
        /// </summary>
        public static XElement ToXml(this Line3MappingItem line3Mappingitem, string nodeName)
        {
            var defaultValues = new Line3MappingItem();
            var line3MappingItemNode = new XElement(nodeName);
            if (!line3Mappingitem.SourceID.IsEqualTo(defaultValues.SourceID))
            {
                line3MappingItemNode.Add(new XElement("SourceID", line3Mappingitem.SourceID));
            }

            if (!line3Mappingitem.RecordIndex1.IsEqualTo(defaultValues.RecordIndex1))
            {
                line3MappingItemNode.Add(new XElement("RecordIndex1", line3Mappingitem.RecordIndex1));
            }

            if (!line3Mappingitem.RecordIndex2.IsEqualTo(defaultValues.RecordIndex2))
            {
                line3MappingItemNode.Add(new XElement("RecordIndex2", line3Mappingitem.RecordIndex2));
            }

            if (!line3Mappingitem.RecordIndex12.IsEqualTo(defaultValues.RecordIndex12))
            {
                line3MappingItemNode.Add(new XElement("RecordIndex12", line3Mappingitem.RecordIndex12));
            }

            return line3MappingItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle3MappingItem" />.
        /// </summary>
        public static XElement ToXml(this Triangle3MappingItem triangle3Mappingitem, string nodeName)
        {
            var defaultValues = new Triangle3MappingItem();
            var triangle3MappingItemNode = new XElement(nodeName);
            if (!triangle3Mappingitem.SourceID.IsEqualTo(defaultValues.SourceID))
            {
                triangle3MappingItemNode.Add(new XElement("SourceID", triangle3Mappingitem.SourceID));
            }

            if (!triangle3Mappingitem.RecordIndex1.IsEqualTo(defaultValues.RecordIndex1))
            {
                triangle3MappingItemNode.Add(new XElement("RecordIndex1", triangle3Mappingitem.RecordIndex1));
            }

            if (!triangle3Mappingitem.RecordIndex2.IsEqualTo(defaultValues.RecordIndex2))
            {
                triangle3MappingItemNode.Add(new XElement("RecordIndex2", triangle3Mappingitem.RecordIndex2));
            }

            if (!triangle3Mappingitem.RecordIndex3.IsEqualTo(defaultValues.RecordIndex3))
            {
                triangle3MappingItemNode.Add(new XElement("RecordIndex3", triangle3Mappingitem.RecordIndex3));
            }

            return triangle3MappingItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Triangle6MappingItem" />.
        /// </summary>
        public static XElement ToXml(this Triangle6MappingItem triangle6Mappingitem, string nodeName)
        {
            var defaultValues = new Triangle6MappingItem();
            var triangle6MappingItemNode = new XElement(nodeName);
            if (!triangle6Mappingitem.SourceID.IsEqualTo(defaultValues.SourceID))
            {
                triangle6MappingItemNode.Add(new XElement("SourceID", triangle6Mappingitem.SourceID));
            }

            if (!triangle6Mappingitem.RecordIndex1.IsEqualTo(defaultValues.RecordIndex1))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex1", triangle6Mappingitem.RecordIndex1));
            }

            if (!triangle6Mappingitem.RecordIndex2.IsEqualTo(defaultValues.RecordIndex2))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex2", triangle6Mappingitem.RecordIndex2));
            }

            if (!triangle6Mappingitem.RecordIndex3.IsEqualTo(defaultValues.RecordIndex3))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex3", triangle6Mappingitem.RecordIndex3));
            }

            if (!triangle6Mappingitem.RecordIndex12.IsEqualTo(defaultValues.RecordIndex12))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex12", triangle6Mappingitem.RecordIndex12));
            }

            if (!triangle6Mappingitem.RecordIndex23.IsEqualTo(defaultValues.RecordIndex23))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex23", triangle6Mappingitem.RecordIndex23));
            }

            if (!triangle6Mappingitem.RecordIndex31.IsEqualTo(defaultValues.RecordIndex31))
            {
                triangle6MappingItemNode.Add(new XElement("RecordIndex31", triangle6Mappingitem.RecordIndex31));
            }

            return triangle6MappingItemNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="MeshMap" />.
        /// </summary>
        public static XElement ToXml(this MeshMap meshmap, string nodeName)
        {
            var defaultValues = new MeshMap();
            var meshMapNode = new XElement(nodeName);
            if (!meshmap.NodeMap.IsEqualTo(defaultValues.NodeMap))
            {
                if (meshmap.NodeMap.Count != 0)
                {
                    var nodeMapNode = new XElement("NodeMap");
                    foreach (var item in meshmap.NodeMap)
                    {
                        nodeMapNode.Add(ToXml(item, "NodeMappingItem"));
                    }
                    meshMapNode.Add(nodeMapNode);
                }
            }

            if (!meshmap.Line2Map.IsEqualTo(defaultValues.Line2Map))
            {
                if (meshmap.Line2Map.Count != 0)
                {
                    var line2MapNode = new XElement("Line2Map");
                    foreach (var item in meshmap.Line2Map)
                    {
                        line2MapNode.Add(ToXml(item, "Line2MappingItem"));
                    }
                    meshMapNode.Add(line2MapNode);
                }
            }

            if (!meshmap.Line3Map.IsEqualTo(defaultValues.Line3Map))
            {
                if (meshmap.Line3Map.Count != 0)
                {
                    var line3MapNode = new XElement("Line3Map");
                    foreach (var item in meshmap.Line3Map)
                    {
                        line3MapNode.Add(ToXml(item, "Line3MappingItem"));
                    }
                    meshMapNode.Add(line3MapNode);
                }
            }

            if (!meshmap.Triangle3Map.IsEqualTo(defaultValues.Triangle3Map))
            {
                if (meshmap.Triangle3Map.Count != 0)
                {
                    var triangle3MapNode = new XElement("Triangle3Map");
                    foreach (var item in meshmap.Triangle3Map)
                    {
                        triangle3MapNode.Add(ToXml(item, "Triangle3MappingItem"));
                    }
                    meshMapNode.Add(triangle3MapNode);
                }
            }

            if (!meshmap.Triangle6Map.IsEqualTo(defaultValues.Triangle6Map))
            {
                if (meshmap.Triangle6Map.Count != 0)
                {
                    var triangle6MapNode = new XElement("Triangle6Map");
                    foreach (var item in meshmap.Triangle6Map)
                    {
                        triangle6MapNode.Add(ToXml(item, "Triangle6MappingItem"));
                    }
                    meshMapNode.Add(triangle6MapNode);
                }
            }

            return meshMapNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Table" />.
        /// </summary>
        public static XElement ToXml(this Table table, string nodeName)
        {
            var defaultValues = new Table();
            var tableNode = new XElement(nodeName);
            if (!table.OutputType.IsEqualTo(defaultValues.OutputType))
            {
                tableNode.Add(new XElement("OutputType", table.OutputType));
            }

            if (!table.Name.IsEqualTo(defaultValues.Name))
            {
                tableNode.Add(table.Name.ToXml("Name"));
            }

            if (!table.RelativePath.IsEqualTo(defaultValues.RelativePath))
            {
                tableNode.Add(new XElement("RelativePath", table.RelativePath));
            }

            return tableNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TableGroup" />.
        /// </summary>
        public static XElement ToXml(this TableGroup tablegroup, string nodeName)
        {
            var defaultValues = new TableGroup();
            var tableGroupNode = new XElement(nodeName);
            if (!tablegroup.ResultGroup.IsEqualTo(defaultValues.ResultGroup))
            {
                tableGroupNode.Add(new XElement("ResultGroup", tablegroup.ResultGroup));
            }

            if (!tablegroup.Tables.IsEqualTo(defaultValues.Tables))
            {
                if (tablegroup.Tables.Count != 0)
                {
                    var tablesNode = new XElement("Tables");
                    foreach (var item in tablegroup.Tables)
                    {
                        tablesNode.Add(ToXml(item, "Table"));
                    }
                    tableGroupNode.Add(tablesNode);
                }
            }

            return tableGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Axle" />.
        /// </summary>
        public static XElement ToXml(this Axle axle, string nodeName)
        {
            var defaultValues = new Axle();
            var axleNode = new XElement(nodeName);
            if (!axle.Distance.IsEqualTo(defaultValues.Distance))
            {
                axleNode.Add(new XElement("Distance", axle.Distance));
            }

            if (!axle.F.IsEqualTo(defaultValues.F))
            {
                axleNode.Add(axle.F.ToXml("F"));
            }

            if (!axle.M.IsEqualTo(defaultValues.M))
            {
                axleNode.Add(axle.M.ToXml("M"));
            }

            return axleNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CombinationGroup" />.
        /// </summary>
        public static XElement ToXml(this CombinationGroup combinationgroup, string nodeName)
        {
            var defaultValues = new CombinationGroup();
            var combinationGroupNode = new XElement(nodeName);
            if (!combinationgroup.ID.IsEqualTo(defaultValues.ID))
            {
                combinationGroupNode.Add(new XAttribute("ID", combinationgroup.ID.ToString<int>()));
            }

            if (!combinationgroup.Name.IsEqualTo(defaultValues.Name))
            {
                combinationGroupNode.Add(combinationgroup.Name.ToXml("Name"));
            }

            if (!combinationgroup.Standard.IsEqualTo(defaultValues.Standard))
            {
                combinationGroupNode.Add(new XElement("Standard", combinationgroup.Standard));
            }

            if (!combinationgroup.Category.IsEqualTo(defaultValues.Category))
            {
                combinationGroupNode.Add(new XElement("Category", combinationgroup.Category));
            }

            if (!combinationgroup.Combinations.IsEqualTo(defaultValues.Combinations))
            {
                if (combinationgroup.Combinations.Count != 0)
                {
                    var combinationsNode = new XElement("Combinations");
                    foreach (var item in combinationgroup.Combinations)
                    {
                        combinationsNode.Add(ToXml(item, "Combination"));
                    }
                    combinationGroupNode.Add(combinationsNode);
                }
            }

            return combinationGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CraneLoadSettings" />.
        /// </summary>
        public static XElement ToXml(this CraneLoadSettings craneloadsettings, string nodeName)
        {
            var defaultValues = new CraneLoadSettings();
            var craneLoadSettingsNode = new XElement(nodeName);
            if (!craneloadsettings.SampleCount.IsEqualTo(defaultValues.SampleCount))
            {
                craneLoadSettingsNode.Add(new XElement("SampleCount", craneloadsettings.SampleCount));
            }

            if (!craneloadsettings.LoadDefinition.IsEqualTo(defaultValues.LoadDefinition))
            {
                if (craneloadsettings.LoadDefinition.Count != 0)
                {
                    var loadDefinitionNode = new XElement("LoadDefinition");
                    foreach (var item in craneloadsettings.LoadDefinition)
                    {
                        loadDefinitionNode.Add(ToXml(item, "CraneLoad"));
                    }
                    craneLoadSettingsNode.Add(loadDefinitionNode);
                }
            }

            return craneLoadSettingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CustomSpectrum" />.
        /// </summary>
        public static XElement ToXml(this CustomSpectrum customspectrum, string nodeName)
        {
            var defaultValues = new CustomSpectrum();
            var customSpectrumNode = new XElement(nodeName);
            if (!customspectrum.Acceleration.IsEqualTo(defaultValues.Acceleration))
            {
                customSpectrumNode.Add(new XElement("Acceleration", customspectrum.Acceleration));
            }

            if (!customspectrum.DisplacementFactor.IsEqualTo(defaultValues.DisplacementFactor))
            {
                customSpectrumNode.Add(new XElement("DisplacementFactor", customspectrum.DisplacementFactor));
            }

            if (!customspectrum.ReferencePeriod.IsEqualTo(defaultValues.ReferencePeriod))
            {
                customSpectrumNode.Add(new XElement("ReferencePeriod", customspectrum.ReferencePeriod));
            }

            if (!customspectrum.IsSpline.IsEqualTo(defaultValues.IsSpline))
            {
                customSpectrumNode.Add(new XElement("IsSpline", customspectrum.IsSpline));
            }

            if (!customspectrum.Points.IsEqualTo(defaultValues.Points))
            {
                if (customspectrum.Points.Count != 0)
                {
                    var pointsNode = new XElement("Points");
                    foreach (var item in customspectrum.Points)
                    {
                        pointsNode.Add(ToXml(item, "Vector2"));
                    }
                    customSpectrumNode.Add(pointsNode);
                }
            }

            return customSpectrumNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicBehaviour" />.
        /// </summary>
        public static XElement ToXml(this DynamicBehaviour dynamicbehaviour, string nodeName)
        {
            var defaultValues = new DynamicBehaviour();
            var dynamicBehaviourNode = new XElement(nodeName);
            if (!dynamicbehaviour.BehaviourType.IsEqualTo(defaultValues.BehaviourType))
            {
                dynamicBehaviourNode.Add(new XElement("BehaviourType", dynamicbehaviour.BehaviourType));
            }

            if (!dynamicbehaviour.SupportAccelerationSettings.IsEqualTo(defaultValues.SupportAccelerationSettings))
            {
                dynamicBehaviourNode.Add(dynamicbehaviour.SupportAccelerationSettings.ToXml("SupportAccelerationSettings"));
            }

            if (!dynamicbehaviour.FunctionType.IsEqualTo(defaultValues.FunctionType))
            {
                dynamicBehaviourNode.Add(new XElement("FunctionType", dynamicbehaviour.FunctionType));
            }

            if (!dynamicbehaviour.Parameters.IsEqualTo(defaultValues.Parameters))
            {
                if (dynamicbehaviour.Parameters.Count != 0)
                {
                    var parametersNode = new XElement("Parameters");
                    foreach (var item in dynamicbehaviour.Parameters)
                    {
                        parametersNode.Add(ToXml(item, "KeyDoubleValue"));
                    }
                    dynamicBehaviourNode.Add(parametersNode);
                }
            }

            return dynamicBehaviourNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicDomain" />.
        /// </summary>
        public static XElement ToXml(this DynamicDomain dynamicdomain, string nodeName)
        {
            var defaultValues = new DynamicDomain();
            var dynamicDomainNode = new XElement(nodeName);
            if (!dynamicdomain.Periodic.IsEqualTo(defaultValues.Periodic))
            {
                dynamicDomainNode.Add(new XElement("Periodic", dynamicdomain.Periodic));
            }

            if (!dynamicdomain.Synchronized.IsEqualTo(defaultValues.Synchronized))
            {
                dynamicDomainNode.Add(new XElement("Synchronized", dynamicdomain.Synchronized));
            }

            if (!dynamicdomain.UseAbsolutePeriod.IsEqualTo(defaultValues.UseAbsolutePeriod))
            {
                dynamicDomainNode.Add(new XElement("UseAbsolutePeriod", dynamicdomain.UseAbsolutePeriod));
            }

            if (!dynamicdomain.AbsolutePeriod.IsEqualTo(defaultValues.AbsolutePeriod))
            {
                dynamicDomainNode.Add(new XElement("AbsolutePeriod", dynamicdomain.AbsolutePeriod));
            }

            if (!dynamicdomain.RelativePeriodReferenceMode.IsEqualTo(defaultValues.RelativePeriodReferenceMode))
            {
                dynamicDomainNode.Add(new XElement("RelativePeriodReferenceMode", dynamicdomain.RelativePeriodReferenceMode));
            }

            if (!dynamicdomain.RelativePeriodFraction.IsEqualTo(defaultValues.RelativePeriodFraction))
            {
                dynamicDomainNode.Add(new XElement("RelativePeriodFraction", dynamicdomain.RelativePeriodFraction));
            }

            if (!dynamicdomain.SamplePoints.IsEqualTo(defaultValues.SamplePoints))
            {
                dynamicDomainNode.Add(new XElement("SamplePoints", dynamicdomain.SamplePoints));
            }

            if (!dynamicdomain.EnforceMinimumSamplePointsPerPeriod.IsEqualTo(defaultValues.EnforceMinimumSamplePointsPerPeriod))
            {
                dynamicDomainNode.Add(new XElement("EnforceMinimumSamplePointsPerPeriod", dynamicdomain.EnforceMinimumSamplePointsPerPeriod));
            }

            if (!dynamicdomain.MinimumSamplePointsPerPeriod.IsEqualTo(defaultValues.MinimumSamplePointsPerPeriod))
            {
                dynamicDomainNode.Add(new XElement("MinimumSamplePointsPerPeriod", dynamicdomain.MinimumSamplePointsPerPeriod));
            }

            if (!dynamicdomain.ResultPoints.IsEqualTo(defaultValues.ResultPoints))
            {
                dynamicDomainNode.Add(new XElement("ResultPoints", dynamicdomain.ResultPoints));
            }

            if (!dynamicdomain.ApplyQSC.IsEqualTo(defaultValues.ApplyQSC))
            {
                dynamicDomainNode.Add(new XElement("ApplyQSC", dynamicdomain.ApplyQSC));
            }

            return dynamicDomainNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicLoadCase" />.
        /// </summary>
        public static XElement ToXml(this DynamicLoadCase dynamicloadcase, string nodeName)
        {
            var defaultValues = new DynamicLoadCase();
            var dynamicLoadCaseNode = new XElement(nodeName);
            if (!dynamicloadcase.ID.IsEqualTo(defaultValues.ID))
            {
                dynamicLoadCaseNode.Add(new XAttribute("ID", dynamicloadcase.ID.ToString<int>()));
            }

            if (!dynamicloadcase.Disabled.IsEqualTo(defaultValues.Disabled))
            {
                dynamicLoadCaseNode.Add(new XElement("Disabled", dynamicloadcase.Disabled));
            }

            if (!dynamicloadcase.AllSubLoadCasesTogether.IsEqualTo(defaultValues.AllSubLoadCasesTogether))
            {
                dynamicLoadCaseNode.Add(new XElement("AllSubLoadCasesTogether", dynamicloadcase.AllSubLoadCasesTogether));
            }

            if (!dynamicloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                dynamicLoadCaseNode.Add(dynamicloadcase.Name.ToXml("Name"));
            }

            if (!dynamicloadcase.DomainInformation.IsEqualTo(defaultValues.DomainInformation))
            {
                dynamicLoadCaseNode.Add(dynamicloadcase.DomainInformation.ToXml("DomainInformation"));
            }

            if (!dynamicloadcase.LoadCaseType.IsEqualTo(defaultValues.LoadCaseType))
            {
                dynamicLoadCaseNode.Add(new XElement("LoadCaseType", dynamicloadcase.LoadCaseType));
            }

            if (!dynamicloadcase.LoadCaseTypeDescription.IsEqualTo(defaultValues.LoadCaseTypeDescription))
            {
                dynamicLoadCaseNode.Add(new XElement("LoadCaseTypeDescription", dynamicloadcase.LoadCaseTypeDescription));
            }

            if (!dynamicloadcase.Parameters.IsEqualTo(defaultValues.Parameters))
            {
                if (dynamicloadcase.Parameters.Count != 0)
                {
                    var parametersNode = new XElement("Parameters");
                    foreach (var item in dynamicloadcase.Parameters)
                    {
                        parametersNode.Add(ToXml(item, "LoadCaseParameters"));
                    }
                    dynamicLoadCaseNode.Add(parametersNode);
                }
            }

            if (!dynamicloadcase.SubLoadCases.IsEqualTo(defaultValues.SubLoadCases))
            {
                if (dynamicloadcase.SubLoadCases.Count != 0)
                {
                    var subLoadCasesNode = new XElement("SubLoadCases");
                    foreach (var item in dynamicloadcase.SubLoadCases)
                    {
                        subLoadCasesNode.Add(ToXml(item, "DynamicSubLoadCase"));
                    }
                    dynamicLoadCaseNode.Add(subLoadCasesNode);
                }
            }

            return dynamicLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Incompatibility" />.
        /// </summary>
        public static XElement ToXml(this Incompatibility incompatibility, string nodeName)
        {
            var defaultValues = new Incompatibility();
            var incompatibilityNode = new XElement(nodeName);
            if (!incompatibility.ID1.IsEqualTo(defaultValues.ID1))
            {
                incompatibilityNode.Add(new XElement("ID1", incompatibility.ID1));
            }

            if (!incompatibility.ID2.IsEqualTo(defaultValues.ID2))
            {
                incompatibilityNode.Add(new XElement("ID2", incompatibility.ID2));
            }

            return incompatibilityNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LineLoad" />.
        /// </summary>
        public static XElement ToXml(this LineLoad lineload, string nodeName)
        {
            var defaultValues = new LineLoad();
            var lineLoadNode = new XElement(nodeName);
            if (!lineload.ReferenceType.IsEqualTo(defaultValues.ReferenceType))
            {
                lineLoadNode.Add(new XElement("ReferenceType", lineload.ReferenceType));
            }

            if (!lineload.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                lineLoadNode.Add(new XElement("ReferenceID", lineload.ReferenceID));
            }

            if (!lineload.ParticipatingMembers.IsEqualTo(defaultValues.ParticipatingMembers))
            {
                if (lineload.ParticipatingMembers.Count != 0)
                {
                    var participatingMembersNode = new XElement("ParticipatingMembers");
                    foreach (var item in lineload.ParticipatingMembers)
                    {
                        participatingMembersNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    lineLoadNode.Add(participatingMembersNode);
                }
            }

            if (!lineload.F1.IsEqualTo(defaultValues.F1))
            {
                lineLoadNode.Add(lineload.F1.ToXml("F1"));
            }

            if (!lineload.M1.IsEqualTo(defaultValues.M1))
            {
                lineLoadNode.Add(lineload.M1.ToXml("M1"));
            }

            if (!lineload.Distance1.IsEqualTo(defaultValues.Distance1))
            {
                lineLoadNode.Add(new XElement("Distance1", lineload.Distance1));
            }

            if (!lineload.F2.IsEqualTo(defaultValues.F2))
            {
                lineLoadNode.Add(lineload.F2.ToXml("F2"));
            }

            if (!lineload.M2.IsEqualTo(defaultValues.M2))
            {
                lineLoadNode.Add(lineload.M2.ToXml("M2"));
            }

            if (!lineload.Distance2.IsEqualTo(defaultValues.Distance2))
            {
                lineLoadNode.Add(new XElement("Distance2", lineload.Distance2));
            }

            if (!lineload.LoadType.IsEqualTo(defaultValues.LoadType))
            {
                lineLoadNode.Add(new XElement("LoadType", lineload.LoadType));
            }

            return lineLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LoadCaseParameters" />.
        /// </summary>
        public static XElement ToXml(this LoadCaseParameters loadcaseparameters, string nodeName)
        {
            var defaultValues = new LoadCaseParameters();
            var loadCaseParametersNode = new XElement(nodeName);
            if (!loadcaseparameters.Standard.IsEqualTo(defaultValues.Standard))
            {
                loadCaseParametersNode.Add(new XElement("Standard", loadcaseparameters.Standard));
            }

            if (!loadcaseparameters.Values.IsEqualTo(defaultValues.Values))
            {
                loadCaseParametersNode.Add(loadcaseparameters.Values.ToXml("Values"));
            }

            return loadCaseParametersNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="PointLoad" />.
        /// </summary>
        public static XElement ToXml(this PointLoad pointload, string nodeName)
        {
            var defaultValues = new PointLoad();
            var pointLoadNode = new XElement(nodeName);
            if (!pointload.ReferenceType.IsEqualTo(defaultValues.ReferenceType))
            {
                pointLoadNode.Add(new XElement("ReferenceType", pointload.ReferenceType));
            }

            if (!pointload.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                pointLoadNode.Add(new XElement("ReferenceID", pointload.ReferenceID));
            }

            if (!pointload.ParticipatingMembers.IsEqualTo(defaultValues.ParticipatingMembers))
            {
                if (pointload.ParticipatingMembers.Count != 0)
                {
                    var participatingMembersNode = new XElement("ParticipatingMembers");
                    foreach (var item in pointload.ParticipatingMembers)
                    {
                        participatingMembersNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    pointLoadNode.Add(participatingMembersNode);
                }
            }

            if (!pointload.F.IsEqualTo(defaultValues.F))
            {
                pointLoadNode.Add(pointload.F.ToXml("F"));
            }

            if (!pointload.M.IsEqualTo(defaultValues.M))
            {
                pointLoadNode.Add(pointload.M.ToXml("M"));
            }

            if (!pointload.Distance.IsEqualTo(defaultValues.Distance))
            {
                pointLoadNode.Add(new XElement("Distance", pointload.Distance));
            }

            if (!pointload.IsAlignedWithLocalCS.IsEqualTo(defaultValues.IsAlignedWithLocalCS))
            {
                pointLoadNode.Add(new XElement("IsAlignedWithLocalCS", pointload.IsAlignedWithLocalCS));
            }

            return pointLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SeismicLoadCase" />.
        /// </summary>
        public static XElement ToXml(this SeismicLoadCase seismicloadcase, string nodeName)
        {
            var defaultValues = new SeismicLoadCase();
            var seismicLoadCaseNode = new XElement(nodeName);
            if (!seismicloadcase.ID.IsEqualTo(defaultValues.ID))
            {
                seismicLoadCaseNode.Add(new XAttribute("ID", seismicloadcase.ID.ToString<int>()));
            }

            if (!seismicloadcase.Disabled.IsEqualTo(defaultValues.Disabled))
            {
                seismicLoadCaseNode.Add(new XElement("Disabled", seismicloadcase.Disabled));
            }

            if (!seismicloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                seismicLoadCaseNode.Add(seismicloadcase.Name.ToXml("Name"));
            }

            if (!seismicloadcase.Settings.IsEqualTo(defaultValues.Settings))
            {
                seismicLoadCaseNode.Add(seismicloadcase.Settings.ToXml("Settings"));
            }

            return seismicLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SeismicLoadCaseParameters" />.
        /// </summary>
        public static XElement ToXml(this SeismicLoadCaseParameters seismicloadcaseparameters, string nodeName)
        {
            var defaultValues = new SeismicLoadCaseParameters();
            var seismicLoadCaseParametersNode = new XElement(nodeName);
            if (!seismicloadcaseparameters.Standard.IsEqualTo(defaultValues.Standard))
            {
                seismicLoadCaseParametersNode.Add(new XElement("Standard", seismicloadcaseparameters.Standard));
            }

            if (!seismicloadcaseparameters.Settings.IsEqualTo(defaultValues.Settings))
            {
                seismicLoadCaseParametersNode.Add(seismicloadcaseparameters.Settings.ToXml("Settings"));
            }

            if (!seismicloadcaseparameters.CustomU.IsEqualTo(defaultValues.CustomU))
            {
                seismicLoadCaseParametersNode.Add(seismicloadcaseparameters.CustomU.ToXml("CustomU"));
            }

            if (!seismicloadcaseparameters.CustomV.IsEqualTo(defaultValues.CustomV))
            {
                seismicLoadCaseParametersNode.Add(seismicloadcaseparameters.CustomV.ToXml("CustomV"));
            }

            if (!seismicloadcaseparameters.CustomW.IsEqualTo(defaultValues.CustomW))
            {
                seismicLoadCaseParametersNode.Add(seismicloadcaseparameters.CustomW.ToXml("CustomW"));
            }

            return seismicLoadCaseParametersNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SnowLoadSettings" />.
        /// </summary>
        public static XElement ToXml(this SnowLoadSettings snowloadsettings, string nodeName)
        {
            var defaultValues = new SnowLoadSettings();
            var snowLoadSettingsNode = new XElement(nodeName);
            if (!snowloadsettings.Standard.IsEqualTo(defaultValues.Standard))
            {
                snowLoadSettingsNode.Add(new XElement("Standard", snowloadsettings.Standard));
            }

            if (!snowloadsettings.Values.IsEqualTo(defaultValues.Values))
            {
                snowLoadSettingsNode.Add(snowloadsettings.Values.ToXml("Values"));
            }

            return snowLoadSettingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="StaticLoadCase" />.
        /// </summary>
        public static XElement ToXml(this StaticLoadCase staticloadcase, string nodeName)
        {
            var defaultValues = new StaticLoadCase();
            var staticLoadCaseNode = new XElement(nodeName);
            if (!staticloadcase.ID.IsEqualTo(defaultValues.ID))
            {
                staticLoadCaseNode.Add(new XAttribute("ID", staticloadcase.ID.ToString<int>()));
            }

            if (!staticloadcase.Disabled.IsEqualTo(defaultValues.Disabled))
            {
                staticLoadCaseNode.Add(new XElement("Disabled", staticloadcase.Disabled));
            }

            if (!staticloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                staticLoadCaseNode.Add(staticloadcase.Name.ToXml("Name"));
            }

            if (!staticloadcase.AllSubLoadCasesTogether.IsEqualTo(defaultValues.AllSubLoadCasesTogether))
            {
                staticLoadCaseNode.Add(new XElement("AllSubLoadCasesTogether", staticloadcase.AllSubLoadCasesTogether));
            }

            if (!staticloadcase.LoadCaseType.IsEqualTo(defaultValues.LoadCaseType))
            {
                staticLoadCaseNode.Add(new XElement("LoadCaseType", staticloadcase.LoadCaseType));
            }

            if (!staticloadcase.LoadCaseTypeDescription.IsEqualTo(defaultValues.LoadCaseTypeDescription))
            {
                staticLoadCaseNode.Add(new XElement("LoadCaseTypeDescription", staticloadcase.LoadCaseTypeDescription));
            }

            if (!staticloadcase.Parameters.IsEqualTo(defaultValues.Parameters))
            {
                if (staticloadcase.Parameters.Count != 0)
                {
                    var parametersNode = new XElement("Parameters");
                    foreach (var item in staticloadcase.Parameters)
                    {
                        parametersNode.Add(ToXml(item, "LoadCaseParameters"));
                    }
                    staticLoadCaseNode.Add(parametersNode);
                }
            }

            if (!staticloadcase.SubLoadCases.IsEqualTo(defaultValues.SubLoadCases))
            {
                if (staticloadcase.SubLoadCases.Count != 0)
                {
                    var subLoadCasesNode = new XElement("SubLoadCases");
                    foreach (var item in staticloadcase.SubLoadCases)
                    {
                        subLoadCasesNode.Add(ToXml(item, "StaticSubLoadCase"));
                    }
                    staticLoadCaseNode.Add(subLoadCasesNode);
                }
            }

            if (!staticloadcase.CraneLoadSettings.IsEqualTo(defaultValues.CraneLoadSettings))
            {
                staticLoadCaseNode.Add(staticloadcase.CraneLoadSettings.ToXml("CraneLoadSettings"));
            }

            if (!staticloadcase.WindLoadSettings.IsEqualTo(defaultValues.WindLoadSettings))
            {
                staticLoadCaseNode.Add(staticloadcase.WindLoadSettings.ToXml("WindLoadSettings"));
            }

            if (!staticloadcase.SnowLoadSettings.IsEqualTo(defaultValues.SnowLoadSettings))
            {
                staticLoadCaseNode.Add(staticloadcase.SnowLoadSettings.ToXml("SnowLoadSettings"));
            }

            return staticLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SupportAccelerationParameters" />.
        /// </summary>
        public static XElement ToXml(this SupportAccelerationParameters supportaccelerationparameters, string nodeName)
        {
            var defaultValues = new SupportAccelerationParameters();
            var supportAccelerationParametersNode = new XElement(nodeName);
            if (!supportaccelerationparameters.Acceleration.IsEqualTo(defaultValues.Acceleration))
            {
                supportAccelerationParametersNode.Add(new XElement("Acceleration", supportaccelerationparameters.Acceleration));
            }

            if (!supportaccelerationparameters.Direction.IsEqualTo(defaultValues.Direction))
            {
                supportAccelerationParametersNode.Add(supportaccelerationparameters.Direction.ToXml("Direction"));
            }

            return supportAccelerationParametersNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="SurfaceLoad" />.
        /// </summary>
        public static XElement ToXml(this SurfaceLoad surfaceload, string nodeName)
        {
            var defaultValues = new SurfaceLoad();
            var surfaceLoadNode = new XElement(nodeName);
            if (!surfaceload.ReferenceType.IsEqualTo(defaultValues.ReferenceType))
            {
                surfaceLoadNode.Add(new XElement("ReferenceType", surfaceload.ReferenceType));
            }

            if (!surfaceload.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                surfaceLoadNode.Add(new XElement("ReferenceID", surfaceload.ReferenceID));
            }

            if (!surfaceload.P1.IsEqualTo(defaultValues.P1))
            {
                surfaceLoadNode.Add(surfaceload.P1.ToXml("P1"));
            }

            if (!surfaceload.F1.IsEqualTo(defaultValues.F1))
            {
                surfaceLoadNode.Add(surfaceload.F1.ToXml("F1"));
            }

            if (!surfaceload.P2.IsEqualTo(defaultValues.P2))
            {
                surfaceLoadNode.Add(surfaceload.P2.ToXml("P2"));
            }

            if (!surfaceload.F2.IsEqualTo(defaultValues.F2))
            {
                surfaceLoadNode.Add(surfaceload.F2.ToXml("F2"));
            }

            if (!surfaceload.P3.IsEqualTo(defaultValues.P3))
            {
                surfaceLoadNode.Add(surfaceload.P3.ToXml("P3"));
            }

            if (!surfaceload.F3.IsEqualTo(defaultValues.F3))
            {
                surfaceLoadNode.Add(surfaceload.F3.ToXml("F3"));
            }

            if (!surfaceload.LoadType.IsEqualTo(defaultValues.LoadType))
            {
                surfaceLoadNode.Add(new XElement("LoadType", surfaceload.LoadType));
            }

            return surfaceLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureLineLoad" />.
        /// </summary>
        public static XElement ToXml(this TemperatureLineLoad temperaturelineload, string nodeName)
        {
            var defaultValues = new TemperatureLineLoad();
            var temperatureLineLoadNode = new XElement(nodeName);
            if (!temperaturelineload.ReferenceType.IsEqualTo(defaultValues.ReferenceType))
            {
                temperatureLineLoadNode.Add(new XElement("ReferenceType", temperaturelineload.ReferenceType));
            }

            if (!temperaturelineload.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                temperatureLineLoadNode.Add(new XElement("ReferenceID", temperaturelineload.ReferenceID));
            }

            if (!temperaturelineload.Uniform.IsEqualTo(defaultValues.Uniform))
            {
                temperatureLineLoadNode.Add(new XElement("Uniform", temperaturelineload.Uniform));
            }

            if (!temperaturelineload.GradientY.IsEqualTo(defaultValues.GradientY))
            {
                temperatureLineLoadNode.Add(new XElement("GradientY", temperaturelineload.GradientY));
            }

            if (!temperaturelineload.GradientZ.IsEqualTo(defaultValues.GradientZ))
            {
                temperatureLineLoadNode.Add(new XElement("GradientZ", temperaturelineload.GradientZ));
            }

            return temperatureLineLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureLoadCase" />.
        /// </summary>
        public static XElement ToXml(this TemperatureLoadCase temperatureloadcase, string nodeName)
        {
            var defaultValues = new TemperatureLoadCase();
            var temperatureLoadCaseNode = new XElement(nodeName);
            if (!temperatureloadcase.ID.IsEqualTo(defaultValues.ID))
            {
                temperatureLoadCaseNode.Add(new XAttribute("ID", temperatureloadcase.ID.ToString<int>()));
            }

            if (!temperatureloadcase.Disabled.IsEqualTo(defaultValues.Disabled))
            {
                temperatureLoadCaseNode.Add(new XElement("Disabled", temperatureloadcase.Disabled));
            }

            if (!temperatureloadcase.AllSubLoadCasesTogether.IsEqualTo(defaultValues.AllSubLoadCasesTogether))
            {
                temperatureLoadCaseNode.Add(new XElement("AllSubLoadCasesTogether", temperatureloadcase.AllSubLoadCasesTogether));
            }

            if (!temperatureloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                temperatureLoadCaseNode.Add(temperatureloadcase.Name.ToXml("Name"));
            }

            if (!temperatureloadcase.SubLoadCases.IsEqualTo(defaultValues.SubLoadCases))
            {
                if (temperatureloadcase.SubLoadCases.Count != 0)
                {
                    var subLoadCasesNode = new XElement("SubLoadCases");
                    foreach (var item in temperatureloadcase.SubLoadCases)
                    {
                        subLoadCasesNode.Add(ToXml(item, "TemperatureSubLoadCase"));
                    }
                    temperatureLoadCaseNode.Add(subLoadCasesNode);
                }
            }

            if (!temperatureloadcase.Parameters.IsEqualTo(defaultValues.Parameters))
            {
                if (temperatureloadcase.Parameters.Count != 0)
                {
                    var parametersNode = new XElement("Parameters");
                    foreach (var item in temperatureloadcase.Parameters)
                    {
                        parametersNode.Add(ToXml(item, "LoadCaseParameters"));
                    }
                    temperatureLoadCaseNode.Add(parametersNode);
                }
            }

            return temperatureLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureSurfaceLoad" />.
        /// </summary>
        public static XElement ToXml(this TemperatureSurfaceLoad temperaturesurfaceload, string nodeName)
        {
            var defaultValues = new TemperatureSurfaceLoad();
            var temperatureSurfaceLoadNode = new XElement(nodeName);
            if (!temperaturesurfaceload.ReferenceType.IsEqualTo(defaultValues.ReferenceType))
            {
                temperatureSurfaceLoadNode.Add(new XElement("ReferenceType", temperaturesurfaceload.ReferenceType));
            }

            if (!temperaturesurfaceload.ReferenceID.IsEqualTo(defaultValues.ReferenceID))
            {
                temperatureSurfaceLoadNode.Add(new XElement("ReferenceID", temperaturesurfaceload.ReferenceID));
            }

            if (!temperaturesurfaceload.Uniform.IsEqualTo(defaultValues.Uniform))
            {
                temperatureSurfaceLoadNode.Add(new XElement("Uniform", temperaturesurfaceload.Uniform));
            }

            if (!temperaturesurfaceload.Gradient.IsEqualTo(defaultValues.Gradient))
            {
                temperatureSurfaceLoadNode.Add(new XElement("Gradient", temperaturesurfaceload.Gradient));
            }

            return temperatureSurfaceLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Track" />.
        /// </summary>
        public static XElement ToXml(this Track track, string nodeName)
        {
            var defaultValues = new Track();
            var trackNode = new XElement(nodeName);
            if (!track.MirroredTrain.IsEqualTo(defaultValues.MirroredTrain))
            {
                trackNode.Add(new XElement("MirroredTrain", track.MirroredTrain));
            }

            if (!track.StartOffset.IsEqualTo(defaultValues.StartOffset))
            {
                trackNode.Add(new XElement("StartOffset", track.StartOffset));
            }

            if (!track.EndOffset.IsEqualTo(defaultValues.EndOffset))
            {
                trackNode.Add(new XElement("EndOffset", track.EndOffset));
            }

            if (!track.BarGroupID.IsEqualTo(defaultValues.BarGroupID))
            {
                trackNode.Add(new XElement("BarGroupID", track.BarGroupID));
            }

            if (!track.SynchronizationPointIDs.IsEqualTo(defaultValues.SynchronizationPointIDs))
            {
                if (track.SynchronizationPointIDs.Count != 0)
                {
                    var synchronizationPointIDsNode = new XElement("SynchronizationPointIDs");
                    foreach (var item in track.SynchronizationPointIDs)
                    {
                        synchronizationPointIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    trackNode.Add(synchronizationPointIDsNode);
                }
            }

            return trackNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TrainLoad" />.
        /// </summary>
        public static XElement ToXml(this TrainLoad trainload, string nodeName)
        {
            var defaultValues = new TrainLoad();
            var trainLoadNode = new XElement(nodeName);
            if (!trainload.ID.IsEqualTo(defaultValues.ID))
            {
                trainLoadNode.Add(new XAttribute("ID", trainload.ID.ToString<System.Guid>()));
            }

            if (!trainload.Name.IsEqualTo(defaultValues.Name))
            {
                trainLoadNode.Add(trainload.Name.ToXml("Name"));
            }

            if (!trainload.Length.IsEqualTo(defaultValues.Length))
            {
                trainLoadNode.Add(new XElement("Length", trainload.Length));
            }

            if (!trainload.IsAlignedWithLocalCS.IsEqualTo(defaultValues.IsAlignedWithLocalCS))
            {
                trainLoadNode.Add(new XElement("IsAlignedWithLocalCS", trainload.IsAlignedWithLocalCS));
            }

            if (!trainload.Axles.IsEqualTo(defaultValues.Axles))
            {
                if (trainload.Axles.Count != 0)
                {
                    var axlesNode = new XElement("Axles");
                    foreach (var item in trainload.Axles)
                    {
                        axlesNode.Add(ToXml(item, "Axle"));
                    }
                    trainLoadNode.Add(axlesNode);
                }
            }

            if (!trainload.Version.IsEqualTo(defaultValues.Version))
            {
                trainLoadNode.Add(new XElement("Version", trainload.Version));
            }

            if (!trainload.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                trainLoadNode.Add(new XElement("LastChanged", trainload.LastChanged));
            }

            if (!trainload.Status.IsEqualTo(defaultValues.Status))
            {
                trainLoadNode.Add(new XElement("Status", trainload.Status));
            }

            if (!trainload.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                trainLoadNode.Add(new XElement("ReadOnly", trainload.ReadOnly));
            }

            return trainLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="WindLoadSettings" />.
        /// </summary>
        public static XElement ToXml(this WindLoadSettings windloadsettings, string nodeName)
        {
            var defaultValues = new WindLoadSettings();
            var windLoadSettingsNode = new XElement(nodeName);
            if (!windloadsettings.Standard.IsEqualTo(defaultValues.Standard))
            {
                windLoadSettingsNode.Add(new XElement("Standard", windloadsettings.Standard));
            }

            if (!windloadsettings.Values.IsEqualTo(defaultValues.Values))
            {
                windLoadSettingsNode.Add(windloadsettings.Values.ToXml("Values"));
            }

            return windLoadSettingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="ModelLoads" />.
        /// </summary>
        public static XElement ToXml(this ModelLoads modelloads, string nodeName)
        {
            var defaultValues = new ModelLoads();
            var modelLoadsNode = new XElement(nodeName);
            if (!modelloads.TrainLoads.IsEqualTo(defaultValues.TrainLoads))
            {
                if (modelloads.TrainLoads.Count != 0)
                {
                    var trainLoadsNode = new XElement("TrainLoads");
                    foreach (var item in modelloads.TrainLoads)
                    {
                        trainLoadsNode.Add(ToXml(item, "TrainLoad"));
                    }
                    modelLoadsNode.Add(trainLoadsNode);
                }
            }

            if (!modelloads.LoadCaseInteraction.IsEqualTo(defaultValues.LoadCaseInteraction))
            {
                modelLoadsNode.Add(modelloads.LoadCaseInteraction.ToXml("LoadCaseInteraction"));
            }

            if (!modelloads.StaticLoadCases.IsEqualTo(defaultValues.StaticLoadCases))
            {
                if (modelloads.StaticLoadCases.Count != 0)
                {
                    var staticLoadCasesNode = new XElement("StaticLoadCases");
                    foreach (var item in modelloads.StaticLoadCases)
                    {
                        staticLoadCasesNode.Add(ToXml(item, "StaticLoadCase"));
                    }
                    modelLoadsNode.Add(staticLoadCasesNode);
                }
            }

            if (!modelloads.DynamicLoadCases.IsEqualTo(defaultValues.DynamicLoadCases))
            {
                if (modelloads.DynamicLoadCases.Count != 0)
                {
                    var dynamicLoadCasesNode = new XElement("DynamicLoadCases");
                    foreach (var item in modelloads.DynamicLoadCases)
                    {
                        dynamicLoadCasesNode.Add(ToXml(item, "DynamicLoadCase"));
                    }
                    modelLoadsNode.Add(dynamicLoadCasesNode);
                }
            }

            if (!modelloads.SeismicLoadCases.IsEqualTo(defaultValues.SeismicLoadCases))
            {
                if (modelloads.SeismicLoadCases.Count != 0)
                {
                    var seismicLoadCasesNode = new XElement("SeismicLoadCases");
                    foreach (var item in modelloads.SeismicLoadCases)
                    {
                        seismicLoadCasesNode.Add(ToXml(item, "SeismicLoadCase"));
                    }
                    modelLoadsNode.Add(seismicLoadCasesNode);
                }
            }

            if (!modelloads.TemperatureLoadCases.IsEqualTo(defaultValues.TemperatureLoadCases))
            {
                if (modelloads.TemperatureLoadCases.Count != 0)
                {
                    var temperatureLoadCasesNode = new XElement("TemperatureLoadCases");
                    foreach (var item in modelloads.TemperatureLoadCases)
                    {
                        temperatureLoadCasesNode.Add(ToXml(item, "TemperatureLoadCase"));
                    }
                    modelLoadsNode.Add(temperatureLoadCasesNode);
                }
            }

            if (!modelloads.CombinationTree.IsEqualTo(defaultValues.CombinationTree))
            {
                if (modelloads.CombinationTree.Count != 0)
                {
                    var combinationTreeNode = new XElement("CombinationTree");
                    foreach (var item in modelloads.CombinationTree)
                    {
                        combinationTreeNode.Add(ToXml(item, "CombinationGroup"));
                    }
                    modelLoadsNode.Add(combinationTreeNode);
                }
            }

            return modelLoadsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LinkedLoadCases" />.
        /// </summary>
        public static XElement ToXml(this LinkedLoadCases linkedloadcases, string nodeName)
        {
            var defaultValues = new LinkedLoadCases();
            var linkedLoadCasesNode = new XElement(nodeName);
            if (!linkedloadcases.IDs.IsEqualTo(defaultValues.IDs))
            {
                if (linkedloadcases.IDs.Count != 0)
                {
                    var dsNode = new XElement("IDs");
                    foreach (var item in linkedloadcases.IDs)
                    {
                        dsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    linkedLoadCasesNode.Add(dsNode);
                }
            }

            return linkedLoadCasesNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="LoadCaseInteraction" />.
        /// </summary>
        public static XElement ToXml(this LoadCaseInteraction loadcaseinteraction, string nodeName)
        {
            var defaultValues = new LoadCaseInteraction();
            var loadCaseInteractionNode = new XElement(nodeName);
            if (!loadcaseinteraction.Incompatible.IsEqualTo(defaultValues.Incompatible))
            {
                if (loadcaseinteraction.Incompatible.Count != 0)
                {
                    var incompatibleNode = new XElement("Incompatible");
                    foreach (var item in loadcaseinteraction.Incompatible)
                    {
                        incompatibleNode.Add(ToXml(item, "Incompatibility"));
                    }
                    loadCaseInteractionNode.Add(incompatibleNode);
                }
            }

            if (!loadcaseinteraction.Linked.IsEqualTo(defaultValues.Linked))
            {
                if (loadcaseinteraction.Linked.Count != 0)
                {
                    var linkedNode = new XElement("Linked");
                    foreach (var item in loadcaseinteraction.Linked)
                    {
                        linkedNode.Add(ToXml(item, "LinkedLoadCases"));
                    }
                    loadCaseInteractionNode.Add(linkedNode);
                }
            }

            return loadCaseInteractionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="StaticSubLoadCase" />.
        /// </summary>
        public static XElement ToXml(this StaticSubLoadCase staticsubloadcase, string nodeName)
        {
            var defaultValues = new StaticSubLoadCase();
            var staticSubLoadCaseNode = new XElement(nodeName);
            if (!staticsubloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                staticSubLoadCaseNode.Add(staticsubloadcase.Name.ToXml("Name"));
            }

            if (!staticsubloadcase.PointLoads.IsEqualTo(defaultValues.PointLoads))
            {
                if (staticsubloadcase.PointLoads.Count != 0)
                {
                    var pointLoadsNode = new XElement("PointLoads");
                    foreach (var item in staticsubloadcase.PointLoads)
                    {
                        pointLoadsNode.Add(ToXml(item, "PointLoad"));
                    }
                    staticSubLoadCaseNode.Add(pointLoadsNode);
                }
            }

            if (!staticsubloadcase.LineLoads.IsEqualTo(defaultValues.LineLoads))
            {
                if (staticsubloadcase.LineLoads.Count != 0)
                {
                    var lineLoadsNode = new XElement("LineLoads");
                    foreach (var item in staticsubloadcase.LineLoads)
                    {
                        lineLoadsNode.Add(ToXml(item, "LineLoad"));
                    }
                    staticSubLoadCaseNode.Add(lineLoadsNode);
                }
            }

            if (!staticsubloadcase.SurfaceLoads.IsEqualTo(defaultValues.SurfaceLoads))
            {
                if (staticsubloadcase.SurfaceLoads.Count != 0)
                {
                    var surfaceLoadsNode = new XElement("SurfaceLoads");
                    foreach (var item in staticsubloadcase.SurfaceLoads)
                    {
                        surfaceLoadsNode.Add(ToXml(item, "SurfaceLoad"));
                    }
                    staticSubLoadCaseNode.Add(surfaceLoadsNode);
                }
            }

            return staticSubLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CraneLoad" />.
        /// </summary>
        public static XElement ToXml(this CraneLoad craneload, string nodeName)
        {
            var defaultValues = new CraneLoad();
            var craneLoadNode = new XElement(nodeName);
            if (!craneload.TrainID.IsEqualTo(defaultValues.TrainID))
            {
                craneLoadNode.Add(new XElement("TrainID", craneload.TrainID));
            }

            if (!craneload.Tracks.IsEqualTo(defaultValues.Tracks))
            {
                if (craneload.Tracks.Count != 0)
                {
                    var tracksNode = new XElement("Tracks");
                    foreach (var item in craneload.Tracks)
                    {
                        tracksNode.Add(ToXml(item, "Track"));
                    }
                    craneLoadNode.Add(tracksNode);
                }
            }

            return craneLoadNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="DynamicSubLoadCase" />.
        /// </summary>
        public static XElement ToXml(this DynamicSubLoadCase dynamicsubloadcase, string nodeName)
        {
            var defaultValues = new DynamicSubLoadCase();
            var dynamicSubLoadCaseNode = new XElement(nodeName);
            if (!dynamicsubloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                dynamicSubLoadCaseNode.Add(dynamicsubloadcase.Name.ToXml("Name"));
            }

            if (!dynamicsubloadcase.Behaviour.IsEqualTo(defaultValues.Behaviour))
            {
                dynamicSubLoadCaseNode.Add(dynamicsubloadcase.Behaviour.ToXml("Behaviour"));
            }

            if (!dynamicsubloadcase.PointLoads.IsEqualTo(defaultValues.PointLoads))
            {
                if (dynamicsubloadcase.PointLoads.Count != 0)
                {
                    var pointLoadsNode = new XElement("PointLoads");
                    foreach (var item in dynamicsubloadcase.PointLoads)
                    {
                        pointLoadsNode.Add(ToXml(item, "PointLoad"));
                    }
                    dynamicSubLoadCaseNode.Add(pointLoadsNode);
                }
            }

            if (!dynamicsubloadcase.LineLoads.IsEqualTo(defaultValues.LineLoads))
            {
                if (dynamicsubloadcase.LineLoads.Count != 0)
                {
                    var lineLoadsNode = new XElement("LineLoads");
                    foreach (var item in dynamicsubloadcase.LineLoads)
                    {
                        lineLoadsNode.Add(ToXml(item, "LineLoad"));
                    }
                    dynamicSubLoadCaseNode.Add(lineLoadsNode);
                }
            }

            if (!dynamicsubloadcase.SurfaceLoads.IsEqualTo(defaultValues.SurfaceLoads))
            {
                if (dynamicsubloadcase.SurfaceLoads.Count != 0)
                {
                    var surfaceLoadsNode = new XElement("SurfaceLoads");
                    foreach (var item in dynamicsubloadcase.SurfaceLoads)
                    {
                        surfaceLoadsNode.Add(ToXml(item, "SurfaceLoad"));
                    }
                    dynamicSubLoadCaseNode.Add(surfaceLoadsNode);
                }
            }

            return dynamicSubLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="TemperatureSubLoadCase" />.
        /// </summary>
        public static XElement ToXml(this TemperatureSubLoadCase temperaturesubloadcase, string nodeName)
        {
            var defaultValues = new TemperatureSubLoadCase();
            var temperatureSubLoadCaseNode = new XElement(nodeName);
            if (!temperaturesubloadcase.Name.IsEqualTo(defaultValues.Name))
            {
                temperatureSubLoadCaseNode.Add(temperaturesubloadcase.Name.ToXml("Name"));
            }

            if (!temperaturesubloadcase.LineLoads.IsEqualTo(defaultValues.LineLoads))
            {
                if (temperaturesubloadcase.LineLoads.Count != 0)
                {
                    var lineLoadsNode = new XElement("LineLoads");
                    foreach (var item in temperaturesubloadcase.LineLoads)
                    {
                        lineLoadsNode.Add(ToXml(item, "TemperatureLineLoad"));
                    }
                    temperatureSubLoadCaseNode.Add(lineLoadsNode);
                }
            }

            if (!temperaturesubloadcase.SurfaceLoads.IsEqualTo(defaultValues.SurfaceLoads))
            {
                if (temperaturesubloadcase.SurfaceLoads.Count != 0)
                {
                    var surfaceLoadsNode = new XElement("SurfaceLoads");
                    foreach (var item in temperaturesubloadcase.SurfaceLoads)
                    {
                        surfaceLoadsNode.Add(ToXml(item, "TemperatureSurfaceLoad"));
                    }
                    temperatureSubLoadCaseNode.Add(surfaceLoadsNode);
                }
            }

            return temperatureSubLoadCaseNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Combination" />.
        /// </summary>
        public static XElement ToXml(this Combination combination, string nodeName)
        {
            var defaultValues = new Combination();
            var combinationNode = new XElement(nodeName);
            if (!combination.ID.IsEqualTo(defaultValues.ID))
            {
                combinationNode.Add(new XAttribute("ID", combination.ID.ToString<int>()));
            }

            if (!combination.Name.IsEqualTo(defaultValues.Name))
            {
                combinationNode.Add(combination.Name.ToXml("Name"));
            }

            if (!combination.Coefficients.IsEqualTo(defaultValues.Coefficients))
            {
                if (combination.Coefficients.Count != 0)
                {
                    var coefficientsNode = new XElement("Coefficients");
                    foreach (var item in combination.Coefficients)
                    {
                        coefficientsNode.Add(ToXml(item, "CombinationCoefficient"));
                    }
                    combinationNode.Add(coefficientsNode);
                }
            }

            return combinationNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="CombinationCoefficient" />.
        /// </summary>
        public static XElement ToXml(this CombinationCoefficient combinationcoefficient, string nodeName)
        {
            var defaultValues = new CombinationCoefficient();
            var combinationCoefficientNode = new XElement(nodeName);
            if (!combinationcoefficient.LoadCaseID.IsEqualTo(defaultValues.LoadCaseID))
            {
                combinationCoefficientNode.Add(new XAttribute("LoadCaseID", combinationcoefficient.LoadCaseID.ToString<int>()));
            }

            if (!combinationcoefficient.Value.IsEqualTo(defaultValues.Value))
            {
                if (combinationcoefficient.Value.Count != 0)
                {
                    var valueNode = new XElement("Value");
                    foreach (var item in combinationcoefficient.Value)
                    {
                        valueNode.Add(new XElement("Item", item.ToString<double>()));
                    }
                    combinationCoefficientNode.Add(valueNode);
                }
            }

            return combinationCoefficientNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Settings" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Settings settings, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Settings();
            var settingsNode = new XElement(nodeName);
            if (!settings.ElementType.IsEqualTo(defaultValues.ElementType))
            {
                settingsNode.Add(new XElement("ElementType", settings.ElementType));
            }

            if (!settings.IDs.IsEqualTo(defaultValues.IDs))
            {
                if (settings.IDs.Count != 0)
                {
                    var dsNode = new XElement("IDs");
                    foreach (var item in settings.IDs)
                    {
                        dsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    settingsNode.Add(dsNode);
                }
            }

            if (!settings.MeshSettings.IsEqualTo(defaultValues.MeshSettings))
            {
                settingsNode.Add(settings.MeshSettings.ToXml("MeshSettings"));
            }

            return settingsNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Line2" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Line2 line2, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Line2();
            var line2Node = new XElement(nodeName);
            if (!line2.ID.IsEqualTo(defaultValues.ID))
            {
                line2Node.Add(new XAttribute("ID", line2.ID.ToString<int>()));
            }

            if (!line2.IsRigidLink.IsEqualTo(defaultValues.IsRigidLink))
            {
                line2Node.Add(new XElement("IsRigidLink", line2.IsRigidLink));
            }

            if (!line2.Node1.IsEqualTo(defaultValues.Node1))
            {
                line2Node.Add(new XElement("Node1", line2.Node1));
            }

            if (!line2.Node2.IsEqualTo(defaultValues.Node2))
            {
                line2Node.Add(new XElement("Node2", line2.Node2));
            }

            if (!line2.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                line2Node.Add(line2.LocalCS.ToXml("LocalCS"));
            }

            return line2Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Line3" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Line3 line3, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Line3();
            var line3Node = new XElement(nodeName);
            if (!line3.ID.IsEqualTo(defaultValues.ID))
            {
                line3Node.Add(new XAttribute("ID", line3.ID.ToString<int>()));
            }

            if (!line3.IsRigidLink.IsEqualTo(defaultValues.IsRigidLink))
            {
                line3Node.Add(new XElement("IsRigidLink", line3.IsRigidLink));
            }

            if (!line3.Node1.IsEqualTo(defaultValues.Node1))
            {
                line3Node.Add(new XElement("Node1", line3.Node1));
            }

            if (!line3.Node2.IsEqualTo(defaultValues.Node2))
            {
                line3Node.Add(new XElement("Node2", line3.Node2));
            }

            if (!line3.Node12.IsEqualTo(defaultValues.Node12))
            {
                line3Node.Add(new XElement("Node12", line3.Node12));
            }

            if (!line3.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                line3Node.Add(line3.LocalCS.ToXml("LocalCS"));
            }

            return line3Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Node" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Node node, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Node();
            var nodeNode = new XElement(nodeName);
            if (!node.ID.IsEqualTo(defaultValues.ID))
            {
                nodeNode.Add(new XAttribute("ID", node.ID.ToString<int>()));
            }

            if (!node.Location.IsEqualTo(defaultValues.Location))
            {
                nodeNode.Add(node.Location.ToXml("Location"));
            }

            return nodeNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Triangle3" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Triangle3 triangle3, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Triangle3();
            var triangle3Node = new XElement(nodeName);
            if (!triangle3.ID.IsEqualTo(defaultValues.ID))
            {
                triangle3Node.Add(new XAttribute("ID", triangle3.ID.ToString<int>()));
            }

            if (!triangle3.Node1.IsEqualTo(defaultValues.Node1))
            {
                triangle3Node.Add(new XElement("Node1", triangle3.Node1));
            }

            if (!triangle3.Node2.IsEqualTo(defaultValues.Node2))
            {
                triangle3Node.Add(new XElement("Node2", triangle3.Node2));
            }

            if (!triangle3.Node3.IsEqualTo(defaultValues.Node3))
            {
                triangle3Node.Add(new XElement("Node3", triangle3.Node3));
            }

            if (!triangle3.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                triangle3Node.Add(triangle3.LocalCS.ToXml("LocalCS"));
            }

            return triangle3Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.Triangle6" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.Triangle6 triangle6, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.Triangle6();
            var triangle6Node = new XElement(nodeName);
            if (!triangle6.ID.IsEqualTo(defaultValues.ID))
            {
                triangle6Node.Add(new XAttribute("ID", triangle6.ID.ToString<int>()));
            }

            if (!triangle6.Node1.IsEqualTo(defaultValues.Node1))
            {
                triangle6Node.Add(new XElement("Node1", triangle6.Node1));
            }

            if (!triangle6.Node2.IsEqualTo(defaultValues.Node2))
            {
                triangle6Node.Add(new XElement("Node2", triangle6.Node2));
            }

            if (!triangle6.Node3.IsEqualTo(defaultValues.Node3))
            {
                triangle6Node.Add(new XElement("Node3", triangle6.Node3));
            }

            if (!triangle6.Node12.IsEqualTo(defaultValues.Node12))
            {
                triangle6Node.Add(new XElement("Node12", triangle6.Node12));
            }

            if (!triangle6.Node23.IsEqualTo(defaultValues.Node23))
            {
                triangle6Node.Add(new XElement("Node23", triangle6.Node23));
            }

            if (!triangle6.Node31.IsEqualTo(defaultValues.Node31))
            {
                triangle6Node.Add(new XElement("Node31", triangle6.Node31));
            }

            if (!triangle6.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                triangle6Node.Add(triangle6.LocalCS.ToXml("LocalCS"));
            }

            return triangle6Node;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.GeometryMesh" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.GeometryMesh geometrymesh, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.GeometryMesh();
            var geometryMeshNode = new XElement(nodeName);
            if (!geometrymesh.ID.IsEqualTo(defaultValues.ID))
            {
                geometryMeshNode.Add(new XAttribute("ID", geometrymesh.ID.ToString<int>()));
            }

            if (!geometrymesh.ElementMeshes.IsEqualTo(defaultValues.ElementMeshes))
            {
                if (geometrymesh.ElementMeshes.Count != 0)
                {
                    var elementMeshesNode = new XElement("ElementMeshes");
                    foreach (var item in geometrymesh.ElementMeshes)
                    {
                        elementMeshesNode.Add(ToXml(item, "ElementMesh"));
                    }
                    geometryMeshNode.Add(elementMeshesNode);
                }
            }

            return geometryMeshNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.ElementMesh" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.ElementMesh elementmesh, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.ElementMesh();
            var elementMeshNode = new XElement(nodeName);
            if (!elementmesh.ElementType.IsEqualTo(defaultValues.ElementType))
            {
                elementMeshNode.Add(new XElement("ElementType", elementmesh.ElementType));
            }

            if (!elementmesh.ElementID.IsEqualTo(defaultValues.ElementID))
            {
                elementMeshNode.Add(new XElement("ElementID", elementmesh.ElementID));
            }

            if (!elementmesh.Nodes.IsEqualTo(defaultValues.Nodes))
            {
                if (elementmesh.Nodes.Count != 0)
                {
                    var nodesNode = new XElement("Nodes");
                    foreach (var item in elementmesh.Nodes)
                    {
                        nodesNode.Add(ToXml(item, "Node"));
                    }
                    elementMeshNode.Add(nodesNode);
                }
            }

            if (!elementmesh.Lines.IsEqualTo(defaultValues.Lines))
            {
                if (elementmesh.Lines.Count != 0)
                {
                    var linesNode = new XElement("Lines");
                    foreach (var item in elementmesh.Lines)
                    {
                        linesNode.Add(ToXml(item, "Line2"));
                    }
                    elementMeshNode.Add(linesNode);
                }
            }

            if (!elementmesh.QuadraticLines.IsEqualTo(defaultValues.QuadraticLines))
            {
                if (elementmesh.QuadraticLines.Count != 0)
                {
                    var quadraticLinesNode = new XElement("QuadraticLines");
                    foreach (var item in elementmesh.QuadraticLines)
                    {
                        quadraticLinesNode.Add(ToXml(item, "Line3"));
                    }
                    elementMeshNode.Add(quadraticLinesNode);
                }
            }

            if (!elementmesh.Triangles.IsEqualTo(defaultValues.Triangles))
            {
                if (elementmesh.Triangles.Count != 0)
                {
                    var trianglesNode = new XElement("Triangles");
                    foreach (var item in elementmesh.Triangles)
                    {
                        trianglesNode.Add(ToXml(item, "Triangle3"));
                    }
                    elementMeshNode.Add(trianglesNode);
                }
            }

            if (!elementmesh.QuadraticTriangles.IsEqualTo(defaultValues.QuadraticTriangles))
            {
                if (elementmesh.QuadraticTriangles.Count != 0)
                {
                    var quadraticTrianglesNode = new XElement("QuadraticTriangles");
                    foreach (var item in elementmesh.QuadraticTriangles)
                    {
                        quadraticTrianglesNode.Add(ToXml(item, "Triangle6"));
                    }
                    elementMeshNode.Add(quadraticTrianglesNode);
                }
            }

            return elementMeshNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Mesh.SectionMesh" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Mesh.SectionMesh sectionmesh, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Mesh.SectionMesh();
            var sectionMeshNode = new XElement(nodeName);
            if (!sectionmesh.ID.IsEqualTo(defaultValues.ID))
            {
                sectionMeshNode.Add(new XAttribute("ID", sectionmesh.ID.ToString<int>()));
            }

            if (!sectionmesh.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                sectionMeshNode.Add(new XElement("SectionID", sectionmesh.SectionID));
            }

            if (!sectionmesh.Nodes.IsEqualTo(defaultValues.Nodes))
            {
                if (sectionmesh.Nodes.Count != 0)
                {
                    var nodesNode = new XElement("Nodes");
                    foreach (var item in sectionmesh.Nodes)
                    {
                        nodesNode.Add(ToXml(item, "Node"));
                    }
                    sectionMeshNode.Add(nodesNode);
                }
            }

            if (!sectionmesh.Lines.IsEqualTo(defaultValues.Lines))
            {
                if (sectionmesh.Lines.Count != 0)
                {
                    var linesNode = new XElement("Lines");
                    foreach (var item in sectionmesh.Lines)
                    {
                        linesNode.Add(ToXml(item, "Line2"));
                    }
                    sectionMeshNode.Add(linesNode);
                }
            }

            if (!sectionmesh.QuadraticLines.IsEqualTo(defaultValues.QuadraticLines))
            {
                if (sectionmesh.QuadraticLines.Count != 0)
                {
                    var quadraticLinesNode = new XElement("QuadraticLines");
                    foreach (var item in sectionmesh.QuadraticLines)
                    {
                        quadraticLinesNode.Add(ToXml(item, "Line3"));
                    }
                    sectionMeshNode.Add(quadraticLinesNode);
                }
            }

            if (!sectionmesh.Triangles.IsEqualTo(defaultValues.Triangles))
            {
                if (sectionmesh.Triangles.Count != 0)
                {
                    var trianglesNode = new XElement("Triangles");
                    foreach (var item in sectionmesh.Triangles)
                    {
                        trianglesNode.Add(ToXml(item, "Triangle3"));
                    }
                    sectionMeshNode.Add(trianglesNode);
                }
            }

            if (!sectionmesh.QuadraticTriangles.IsEqualTo(defaultValues.QuadraticTriangles))
            {
                if (sectionmesh.QuadraticTriangles.Count != 0)
                {
                    var quadraticTrianglesNode = new XElement("QuadraticTriangles");
                    foreach (var item in sectionmesh.QuadraticTriangles)
                    {
                        quadraticTrianglesNode.Add(ToXml(item, "Triangle6"));
                    }
                    sectionMeshNode.Add(quadraticTrianglesNode);
                }
            }

            return sectionMeshNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.BoundaryCondition" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.BoundaryCondition boundarycondition, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.BoundaryCondition();
            var boundaryConditionNode = new XElement(nodeName);
            if (!boundarycondition.BoundaryConditionType.IsEqualTo(defaultValues.BoundaryConditionType))
            {
                boundaryConditionNode.Add(new XAttribute("BoundaryConditionType", boundarycondition.BoundaryConditionType.ToString<BuildSoft.UBSM.Analysis.Geometry.BoundaryConditionType>()));
            }

            if (!boundarycondition.ReleaseMode.IsEqualTo(defaultValues.ReleaseMode))
            {
                boundaryConditionNode.Add(new XAttribute("ReleaseMode", boundarycondition.ReleaseMode.ToString<BuildSoft.UBSM.Analysis.Geometry.ReleaseMode>()));
            }

            if (!boundarycondition.WithFunction.IsEqualTo(defaultValues.WithFunction))
            {
                boundaryConditionNode.Add(new XAttribute("WithFunction", boundarycondition.WithFunction.ToString<bool>()));
            }

            if (!boundarycondition.FunctionID.IsEqualTo(defaultValues.FunctionID))
            {
                boundaryConditionNode.Add(new XAttribute("FunctionID", boundarycondition.FunctionID.ToString<int>()));
            }

            if (!boundarycondition.IsFixed.IsEqualTo(defaultValues.IsFixed))
            {
                boundaryConditionNode.Add(new XAttribute("IsFixed", boundarycondition.IsFixed.ToString<bool>()));
            }

            if (!boundarycondition.LinearSpring.IsEqualTo(defaultValues.LinearSpring))
            {
                boundaryConditionNode.Add(new XAttribute("LinearSpring", boundarycondition.LinearSpring.ToString<double>()));
            }

            return boundaryConditionNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.SoilLayer" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.SoilLayer soillayer, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.SoilLayer();
            var soilLayerNode = new XElement(nodeName);
            if (!soillayer.ID.IsEqualTo(defaultValues.ID))
            {
                soilLayerNode.Add(new XAttribute("ID", soillayer.ID.ToString<int>()));
            }

            if (!soillayer.Thickness.IsEqualTo(defaultValues.Thickness))
            {
                soilLayerNode.Add(new XElement("Thickness", soillayer.Thickness));
            }

            if (!soillayer.Properties.IsEqualTo(defaultValues.Properties))
            {
                if (soillayer.Properties.Count != 0)
                {
                    var propertiesNode = new XElement("Properties");
                    foreach (var item in soillayer.Properties)
                    {
                        propertiesNode.Add(ToXml(item, "PropertyValue"));
                    }
                    soilLayerNode.Add(propertiesNode);
                }
            }

            return soilLayerNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.SoilProfile" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.SoilProfile soilprofile, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.SoilProfile();
            var soilProfileNode = new XElement(nodeName);
            if (!soilprofile.ID.IsEqualTo(defaultValues.ID))
            {
                soilProfileNode.Add(new XAttribute("ID", soilprofile.ID.ToString<System.Guid>()));
            }

            if (!soilprofile.ProfileType.IsEqualTo(defaultValues.ProfileType))
            {
                soilProfileNode.Add(new XElement("ProfileType", soilprofile.ProfileType));
            }

            if (!soilprofile.Name.IsEqualTo(defaultValues.Name))
            {
                soilProfileNode.Add(soilprofile.Name.ToXml("Name"));
            }

            if (!soilprofile.BottomLayerFixed.IsEqualTo(defaultValues.BottomLayerFixed))
            {
                soilProfileNode.Add(new XElement("BottomLayerFixed", soilprofile.BottomLayerFixed));
            }

            if (!soilprofile.Layers.IsEqualTo(defaultValues.Layers))
            {
                if (soilprofile.Layers.Count != 0)
                {
                    var layersNode = new XElement("Layers");
                    foreach (var item in soilprofile.Layers)
                    {
                        layersNode.Add(ToXml(item, "SoilLayer"));
                    }
                    soilProfileNode.Add(layersNode);
                }
            }

            if (!soilprofile.Version.IsEqualTo(defaultValues.Version))
            {
                soilProfileNode.Add(new XElement("Version", soilprofile.Version));
            }

            if (!soilprofile.LastChanged.IsEqualTo(defaultValues.LastChanged))
            {
                soilProfileNode.Add(new XElement("LastChanged", soilprofile.LastChanged));
            }

            if (!soilprofile.Status.IsEqualTo(defaultValues.Status))
            {
                soilProfileNode.Add(new XElement("Status", soilprofile.Status));
            }

            if (!soilprofile.ReadOnly.IsEqualTo(defaultValues.ReadOnly))
            {
                soilProfileNode.Add(new XElement("ReadOnly", soilprofile.ReadOnly));
            }

            return soilProfileNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.SoilSupport" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.SoilSupport soilsupport, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.SoilSupport();
            var soilSupportNode = new XElement(nodeName);
            if (!soilsupport.ProfileID.IsEqualTo(defaultValues.ProfileID))
            {
                soilSupportNode.Add(new XElement("ProfileID", soilsupport.ProfileID));
            }

            if (!soilsupport.ReferenceHeight.IsEqualTo(defaultValues.ReferenceHeight))
            {
                soilSupportNode.Add(new XElement("ReferenceHeight", soilsupport.ReferenceHeight));
            }

            if (!soilsupport.FreaticDepth.IsEqualTo(defaultValues.FreaticDepth))
            {
                soilSupportNode.Add(new XElement("FreaticDepth", soilsupport.FreaticDepth));
            }

            if (!soilsupport.ResistsToTension.IsEqualTo(defaultValues.ResistsToTension))
            {
                soilSupportNode.Add(new XElement("ResistsToTension", soilsupport.ResistsToTension));
            }

            return soilSupportNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.Point" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.Point point, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.Point();
            var pointNode = new XElement(nodeName);
            if (!point.ID.IsEqualTo(defaultValues.ID))
            {
                pointNode.Add(new XAttribute("ID", point.ID.ToString<int>()));
            }

            if (!point.Name.IsEqualTo(defaultValues.Name))
            {
                pointNode.Add(point.Name.ToXml("Name"));
            }

            if (!point.Location.IsEqualTo(defaultValues.Location))
            {
                pointNode.Add(point.Location.ToXml("Location"));
            }

            if (!point.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                pointNode.Add(point.LocalCS.ToXml("LocalCS"));
            }

            if (!point.IsSupportedAlongLocalCS.IsEqualTo(defaultValues.IsSupportedAlongLocalCS))
            {
                pointNode.Add(new XElement("IsSupportedAlongLocalCS", point.IsSupportedAlongLocalCS));
            }

            if (!point.Tx.IsEqualTo(defaultValues.Tx))
            {
                pointNode.Add(point.Tx.ToXml("Tx"));
            }

            if (!point.Ty.IsEqualTo(defaultValues.Ty))
            {
                pointNode.Add(point.Ty.ToXml("Ty"));
            }

            if (!point.Tz.IsEqualTo(defaultValues.Tz))
            {
                pointNode.Add(point.Tz.ToXml("Tz"));
            }

            if (!point.Rx.IsEqualTo(defaultValues.Rx))
            {
                pointNode.Add(point.Rx.ToXml("Rx"));
            }

            if (!point.Ry.IsEqualTo(defaultValues.Ry))
            {
                pointNode.Add(point.Ry.ToXml("Ry"));
            }

            if (!point.Rz.IsEqualTo(defaultValues.Rz))
            {
                pointNode.Add(point.Rz.ToXml("Rz"));
            }

            if (!point.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                pointNode.Add(point.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return pointNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.BarEndConnectivity" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.BarEndConnectivity barendconnectivity, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.BarEndConnectivity();
            var barEndConnectivityNode = new XElement(nodeName);
            if (!barendconnectivity.Nx.IsEqualTo(defaultValues.Nx))
            {
                barEndConnectivityNode.Add(barendconnectivity.Nx.ToXml("Nx"));
            }

            if (!barendconnectivity.Vy.IsEqualTo(defaultValues.Vy))
            {
                barEndConnectivityNode.Add(barendconnectivity.Vy.ToXml("Vy"));
            }

            if (!barendconnectivity.Vz.IsEqualTo(defaultValues.Vz))
            {
                barEndConnectivityNode.Add(barendconnectivity.Vz.ToXml("Vz"));
            }

            if (!barendconnectivity.Mx.IsEqualTo(defaultValues.Mx))
            {
                barEndConnectivityNode.Add(barendconnectivity.Mx.ToXml("Mx"));
            }

            if (!barendconnectivity.My.IsEqualTo(defaultValues.My))
            {
                barEndConnectivityNode.Add(barendconnectivity.My.ToXml("My"));
            }

            if (!barendconnectivity.Mz.IsEqualTo(defaultValues.Mz))
            {
                barEndConnectivityNode.Add(barendconnectivity.Mz.ToXml("Mz"));
            }

            return barEndConnectivityNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.BarEnd" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.BarEnd barend, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.BarEnd();
            var barEndNode = new XElement(nodeName);
            if (!barend.PointID.IsEqualTo(defaultValues.PointID))
            {
                barEndNode.Add(new XElement("PointID", barend.PointID));
            }

            if (!barend.GlobalOffset.IsEqualTo(defaultValues.GlobalOffset))
            {
                barEndNode.Add(barend.GlobalOffset.ToXml("GlobalOffset"));
            }

            if (!barend.LocalOffset.IsEqualTo(defaultValues.LocalOffset))
            {
                barEndNode.Add(barend.LocalOffset.ToXml("LocalOffset"));
            }

            if (!barend.CardinalPoint.IsEqualTo(defaultValues.CardinalPoint))
            {
                barEndNode.Add(new XElement("CardinalPoint", barend.CardinalPoint));
            }

            if (!barend.Connectivity.IsEqualTo(defaultValues.Connectivity))
            {
                barEndNode.Add(barend.Connectivity.ToXml("Connectivity"));
            }

            return barEndNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Bar" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.Bar bar, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.Bar();
            var barNode = new XElement(nodeName);
            if (!bar.ID.IsEqualTo(defaultValues.ID))
            {
                barNode.Add(new XAttribute("ID", bar.ID.ToString<int>()));
            }

            if (!bar.PhysicalID.IsEqualTo(defaultValues.PhysicalID))
            {
                barNode.Add(new XElement("PhysicalID", bar.PhysicalID));
            }

            if (!bar.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                barNode.Add(new XElement("SectionID", bar.SectionID));
            }

            if (!bar.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (bar.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in bar.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    barNode.Add(materialOverridesNode);
                }
            }

            if (!bar.Name.IsEqualTo(defaultValues.Name))
            {
                barNode.Add(bar.Name.ToXml("Name"));
            }

            if (!bar.BarType.IsEqualTo(defaultValues.BarType))
            {
                barNode.Add(new XElement("BarType", bar.BarType));
            }

            if (!bar.PhysicalParentType.IsEqualTo(defaultValues.PhysicalParentType))
            {
                barNode.Add(new XElement("PhysicalParentType", bar.PhysicalParentType));
            }

            if (!bar.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                barNode.Add(bar.LocalCS.ToXml("LocalCS"));
            }

            if (!bar.Begin.IsEqualTo(defaultValues.Begin))
            {
                barNode.Add(bar.Begin.ToXml("Begin"));
            }

            if (!bar.End.IsEqualTo(defaultValues.End))
            {
                barNode.Add(bar.End.ToXml("End"));
            }

            if (!bar.IsSupportedAlongLocalCS.IsEqualTo(defaultValues.IsSupportedAlongLocalCS))
            {
                barNode.Add(new XElement("IsSupportedAlongLocalCS", bar.IsSupportedAlongLocalCS));
            }

            if (!bar.SupportAngle.IsEqualTo(defaultValues.SupportAngle))
            {
                barNode.Add(new XElement("SupportAngle", bar.SupportAngle));
            }

            if (!bar.SectionMirroredAroundZAxis.IsEqualTo(defaultValues.SectionMirroredAroundZAxis))
            {
                barNode.Add(new XElement("SectionMirroredAroundZAxis", bar.SectionMirroredAroundZAxis));
            }

            if (!bar.SupportType.IsEqualTo(defaultValues.SupportType))
            {
                barNode.Add(new XElement("SupportType", bar.SupportType));
            }

            if (!bar.Tx.IsEqualTo(defaultValues.Tx))
            {
                barNode.Add(bar.Tx.ToXml("Tx"));
            }

            if (!bar.Ty.IsEqualTo(defaultValues.Ty))
            {
                barNode.Add(bar.Ty.ToXml("Ty"));
            }

            if (!bar.Tz.IsEqualTo(defaultValues.Tz))
            {
                barNode.Add(bar.Tz.ToXml("Tz"));
            }

            if (!bar.Rx.IsEqualTo(defaultValues.Rx))
            {
                barNode.Add(bar.Rx.ToXml("Rx"));
            }

            if (!bar.Ry.IsEqualTo(defaultValues.Ry))
            {
                barNode.Add(bar.Ry.ToXml("Ry"));
            }

            if (!bar.Rz.IsEqualTo(defaultValues.Rz))
            {
                barNode.Add(bar.Rz.ToXml("Rz"));
            }

            if (!bar.Soil.IsEqualTo(defaultValues.Soil))
            {
                barNode.Add(bar.Soil.ToXml("Soil"));
            }

            if (!bar.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                barNode.Add(bar.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return barNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Plate" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.Plate plate, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.Plate();
            var plateNode = new XElement(nodeName);
            if (!plate.ID.IsEqualTo(defaultValues.ID))
            {
                plateNode.Add(new XAttribute("ID", plate.ID.ToString<int>()));
            }

            if (!plate.PhysicalID.IsEqualTo(defaultValues.PhysicalID))
            {
                plateNode.Add(new XElement("PhysicalID", plate.PhysicalID));
            }

            if (!plate.SectionID.IsEqualTo(defaultValues.SectionID))
            {
                plateNode.Add(new XElement("SectionID", plate.SectionID));
            }

            if (!plate.MaterialOverrides.IsEqualTo(defaultValues.MaterialOverrides))
            {
                if (plate.MaterialOverrides.Count != 0)
                {
                    var materialOverridesNode = new XElement("MaterialOverrides");
                    foreach (var item in plate.MaterialOverrides)
                    {
                        materialOverridesNode.Add(ToXml(item, "GuidMapItem"));
                    }
                    plateNode.Add(materialOverridesNode);
                }
            }

            if (!plate.PhysicalParentType.IsEqualTo(defaultValues.PhysicalParentType))
            {
                plateNode.Add(new XElement("PhysicalParentType", plate.PhysicalParentType));
            }

            if (!plate.Name.IsEqualTo(defaultValues.Name))
            {
                plateNode.Add(plate.Name.ToXml("Name"));
            }

            if (!plate.LocalCS.IsEqualTo(defaultValues.LocalCS))
            {
                plateNode.Add(plate.LocalCS.ToXml("LocalCS"));
            }

            if (!plate.InternalOpenings.IsEqualTo(defaultValues.InternalOpenings))
            {
                if (plate.InternalOpenings.Count != 0)
                {
                    var internalOpeningsNode = new XElement("InternalOpenings");
                    foreach (var item in plate.InternalOpenings)
                    {
                        internalOpeningsNode.Add(ToXml(item, "Polygon"));
                    }
                    plateNode.Add(internalOpeningsNode);
                }
            }

            if (!plate.Edges.IsEqualTo(defaultValues.Edges))
            {
                if (plate.Edges.Count != 0)
                {
                    var edgesNode = new XElement("Edges");
                    foreach (var item in plate.Edges)
                    {
                        edgesNode.Add(ToXml(item, "PlateEdge"));
                    }
                    plateNode.Add(edgesNode);
                }
            }

            if (!plate.IsSupportedAlongLocalCS.IsEqualTo(defaultValues.IsSupportedAlongLocalCS))
            {
                plateNode.Add(new XElement("IsSupportedAlongLocalCS", plate.IsSupportedAlongLocalCS));
            }

            if (!plate.SupportType.IsEqualTo(defaultValues.SupportType))
            {
                plateNode.Add(new XElement("SupportType", plate.SupportType));
            }

            if (!plate.Tx.IsEqualTo(defaultValues.Tx))
            {
                plateNode.Add(plate.Tx.ToXml("Tx"));
            }

            if (!plate.Ty.IsEqualTo(defaultValues.Ty))
            {
                plateNode.Add(plate.Ty.ToXml("Ty"));
            }

            if (!plate.Tz.IsEqualTo(defaultValues.Tz))
            {
                plateNode.Add(plate.Tz.ToXml("Tz"));
            }

            if (!plate.Soil.IsEqualTo(defaultValues.Soil))
            {
                plateNode.Add(plate.Soil.ToXml("Soil"));
            }

            if (!plate.AdditionalParameters.IsEqualTo(defaultValues.AdditionalParameters))
            {
                plateNode.Add(plate.AdditionalParameters.ToXml("AdditionalParameters"));
            }

            return plateNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.PlateEdgeConnectivity" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.PlateEdgeConnectivity plateedgeconnectivity, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.PlateEdgeConnectivity();
            var plateEdgeConnectivityNode = new XElement(nodeName);
            if (!plateedgeconnectivity.Normal.IsEqualTo(defaultValues.Normal))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.Normal.ToXml("Normal"));
            }

            if (!plateedgeconnectivity.InPlaneShear.IsEqualTo(defaultValues.InPlaneShear))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.InPlaneShear.ToXml("InPlaneShear"));
            }

            if (!plateedgeconnectivity.OutOfPlaneShear.IsEqualTo(defaultValues.OutOfPlaneShear))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.OutOfPlaneShear.ToXml("OutOfPlaneShear"));
            }

            if (!plateedgeconnectivity.Mx.IsEqualTo(defaultValues.Mx))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.Mx.ToXml("Mx"));
            }

            if (!plateedgeconnectivity.My.IsEqualTo(defaultValues.My))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.My.ToXml("My"));
            }

            if (!plateedgeconnectivity.Mz.IsEqualTo(defaultValues.Mz))
            {
                plateEdgeConnectivityNode.Add(plateedgeconnectivity.Mz.ToXml("Mz"));
            }

            return plateEdgeConnectivityNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.BarGroup" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.BarGroup bargroup, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.BarGroup();
            var barGroupNode = new XElement(nodeName);
            if (!bargroup.ID.IsEqualTo(defaultValues.ID))
            {
                barGroupNode.Add(new XAttribute("ID", bargroup.ID.ToString<int>()));
            }

            if (!bargroup.Name.IsEqualTo(defaultValues.Name))
            {
                barGroupNode.Add(bargroup.Name.ToXml("Name"));
            }

            if (!bargroup.GroupType.IsEqualTo(defaultValues.GroupType))
            {
                barGroupNode.Add(new XElement("GroupType", bargroup.GroupType));
            }

            if (!bargroup.BarIDs.IsEqualTo(defaultValues.BarIDs))
            {
                if (bargroup.BarIDs.Count != 0)
                {
                    var barIDsNode = new XElement("BarIDs");
                    foreach (var item in bargroup.BarIDs)
                    {
                        barIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    barGroupNode.Add(barIDsNode);
                }
            }

            return barGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.PlateGroup" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.PlateGroup plategroup, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.PlateGroup();
            var plateGroupNode = new XElement(nodeName);
            if (!plategroup.ID.IsEqualTo(defaultValues.ID))
            {
                plateGroupNode.Add(new XAttribute("ID", plategroup.ID.ToString<int>()));
            }

            if (!plategroup.Name.IsEqualTo(defaultValues.Name))
            {
                plateGroupNode.Add(plategroup.Name.ToXml("Name"));
            }

            if (!plategroup.GroupType.IsEqualTo(defaultValues.GroupType))
            {
                plateGroupNode.Add(new XElement("GroupType", plategroup.GroupType));
            }

            if (!plategroup.PlateIDs.IsEqualTo(defaultValues.PlateIDs))
            {
                if (plategroup.PlateIDs.Count != 0)
                {
                    var plateIDsNode = new XElement("PlateIDs");
                    foreach (var item in plategroup.PlateIDs)
                    {
                        plateIDsNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    plateGroupNode.Add(plateIDsNode);
                }
            }

            return plateGroupNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="BuildSoft.UBSM.Analysis.Geometry.PlateEdge" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.PlateEdge plateedge, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.PlateEdge();
            var plateEdgeNode = new XElement(nodeName);
            if (!plateedge.BeginPointID.IsEqualTo(defaultValues.BeginPointID))
            {
                plateEdgeNode.Add(new XElement("BeginPointID", plateedge.BeginPointID));
            }

            if (!plateedge.Connectivity.IsEqualTo(defaultValues.Connectivity))
            {
                plateEdgeNode.Add(plateedge.Connectivity.ToXml("Connectivity"));
            }

            return plateEdgeNode;
        }

        /// <summary>
        /// Automatically generated converter method for <see cref="Polygon" />.
        /// </summary>
        public static XElement ToXml(this BuildSoft.UBSM.Analysis.Geometry.Polygon polygon, string nodeName)
        {
            var defaultValues = new BuildSoft.UBSM.Analysis.Geometry.Polygon();
            var polygonNode = new XElement(nodeName);
            if (!polygon.Vertices.IsEqualTo(defaultValues.Vertices))
            {
                if (polygon.Vertices.Count != 0)
                {
                    var verticesNode = new XElement("Vertices");
                    foreach (var item in polygon.Vertices)
                    {
                        verticesNode.Add(new XElement("Item", item.ToString<int>()));
                    }
                    polygonNode.Add(verticesNode);
                }
            }

            return polygonNode;
        }
    }
}
