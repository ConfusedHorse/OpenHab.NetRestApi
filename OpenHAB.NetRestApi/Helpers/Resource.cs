using System;
using System.Linq;

namespace OpenHAB.NetRestApi.Helpers
{
    public sealed class ResourceParameter
    {
        public ResourceParameter(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }

    public static class Resource
    {
        private const string Indicator = "?";
        private const string Delimiter = "&";

        /// <summary>
        ///     Returns a formatted Html parameter list
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string FormatParameters(params ResourceParameter[] parameters)
        {
            return parameters.IsNullOrEmpty()
                ? string.Empty
                : $"{Indicator}" +
                  $"{string.Join(Delimiter, parameters.Where(p => p != null).Select(p => $"{p.Name}={p.Value}"))}";
        }
    }
}