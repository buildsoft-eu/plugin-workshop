namespace Example.API
{
    /// <summary>
    /// Only symmetric I-sections are supported.
    /// </summary>
    public class Section
    {
        public string Name { get; set; }
        /// <summary>
        /// Height in millimeters.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Width in millimeters.
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Thickness of the flange in millimeters.
        /// </summary>
        public double FlangeThickness { get; set; }
        /// <summary>
        /// Thickness of the web in millimeters.
        /// </summary>
        public double WebThickness { get; set; }
        /// <summary>
        /// Rounding radius in millimeters.
        /// </summary>
        public double RoundingRadius { get; set; }
    }
}
