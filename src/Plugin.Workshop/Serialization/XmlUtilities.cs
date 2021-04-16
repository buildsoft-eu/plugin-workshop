using System;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Plugin.Workshop.Serialization
{
    public static class XmlUtilities
    {
        internal static T ConvertType<T>(object input)
        {
            var targetType = typeof(T);
            var isString = input is string;

            switch (isString)
            {
                case true when targetType == typeof(DateTime):
                    {
                        return DateTime.TryParse(
                            (string)input,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.RoundtripKind,
                            out var dateTime)
                            ? (T)(object)dateTime
                            : (T)(object)DateTime.UtcNow;
                    }
                case true when targetType == typeof(double):
                    return (T)(object)XmlConvert.ToDouble((string)input);
                case true when targetType == typeof(Guid):
                    return (T)(object)new Guid((string)input);
            }

            if (input.GetType().ImplementsInterface(typeof(IConvertible)))
            {
                return (T)Convert.ChangeType(
                    input,
                    targetType,
                    CultureInfo.InvariantCulture);
            }

            return (T)input;
        }

        private static bool ImplementsInterface(this Type givenType, Type interfaceType)
        {
            var ifs = givenType.GetInterfaces();
            return ifs.Any(t => t == interfaceType);
        }

        public static bool IsEqualTo(this object a, object b)
        {
            if (a == null)
            {
                return b == null;
            }

            if (b == null)
            {
                return false;
            }

            var type = a.GetType();

            if (type != b.GetType())
            {
                return false;
            }

            if (type == typeof(double))
            {
                return Math.Abs((double)a - (double)b) < 1e-15;
            }

            if (type == typeof(int))
            {
                return (int)a == (int)b;
            }
            if (type == typeof(bool))
            {
                return (bool)a == (bool)b;
            }

            return a.Equals(b);
        }

        public static string ToString<T>(this T val)
        {
            switch (val)
            {
                case DateTime _:
                    return ((DateTime)(object)val).ToString(
                        "o",
                        CultureInfo.InvariantCulture);
                case double _:
                    return XmlConvert.ToString((double)(object)val);
                case IFormattable x:
                    return x.ToString(
                        null,
                        CultureInfo.InvariantCulture);
                default:
                    return val != null
                        ? val.ToString()
                        : string.Empty;
            }
        }
    }
}
