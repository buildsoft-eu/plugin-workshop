namespace Example.API
{
    public class Connection
    {
        /// <summary>
        /// Thickness of the end plate in millimeters.
        /// </summary>
        public double EndPlateThickness { get; set; }
        /// <summary>
        /// Number of bolt rows.
        /// </summary>
        public int BoltRows { get; set; }
        /// <summary>
        /// Name of the bolt assembly.
        /// </summary>
        public string BoltAssemblyName { get; set; }
    }
}
