namespace OpenHAB.NetRestApi.Helpers
{
    public static class Json
    {
        /// <summary>
        /// removes malformatted episodes of characters from the Json string
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string Fix(string json)
        {
            return json.Replace(@"\""", @"""").Replace(@"""""", @"""")
                       .Replace(@"""[", @"[").Replace(@"]""", @"]")
                       .Replace(@"""{", @"{").Replace(@"}""", @"}");
        }
    }
}