namespace Example.API
{
    public class Geometry
    {
        /// <summary>
        /// Horizontal beam definition.
        /// </summary>
        public Beam Beam { get; set; }

        /// <summary>
        /// Vertical columns definition.
        /// </summary>
        public Beam Column { get; set; }

        /// <summary>
        /// Connection between beam and columns definition.
        /// </summary>
        public Connection Connection { get; set; }

        /// <summary>
        /// Height under the beam in meters.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Width between the columns in meters.
        /// </summary>
        public double Width { get; set; }
    }
}
