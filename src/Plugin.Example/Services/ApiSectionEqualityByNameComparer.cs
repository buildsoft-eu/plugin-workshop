using System.Collections.Generic;
using Example.API;

namespace Plugin.Example.Services
{
    public class ApiSectionEqualityByNameComparer : IEqualityComparer<Section>
    {
        public bool Equals(Section x, Section y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null)
            {
                return false;
            }

            if (y is null)
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.Name == y.Name;
        }

        public int GetHashCode(Section obj)
        {
            return obj.Name != null ? obj.Name.GetHashCode() : 0;
        }
    }
}
