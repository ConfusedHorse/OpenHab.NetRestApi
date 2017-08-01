namespace OpenHAB.NetRestApi.Helpers
{
    public static class Json
    {
        public static string Fix(string json)
        {
            return json.Replace(@"\""", @"""").Replace(@"""{", "{").Replace(@"}""", "}");
        }
    }
}