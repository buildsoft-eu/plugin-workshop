using System;
using Example.API;

namespace Plugin.Example.Models
{
    public class MaterialConflict
    {
        public Material ApiMaterial { get; set; }
        public Guid? UbsmMaterial { get; set; }
        public ConflictType ConflictType { get; set; }
    }
}
