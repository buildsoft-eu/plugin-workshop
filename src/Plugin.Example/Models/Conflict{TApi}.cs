using System;

namespace Plugin.Example.Models
{
    public class Conflict<TApi>
    {
        public TApi Api { get; set; }
        public Guid? Ubsm { get; set; }
        public ConflictType ConflictType { get; set; }
    }
}
