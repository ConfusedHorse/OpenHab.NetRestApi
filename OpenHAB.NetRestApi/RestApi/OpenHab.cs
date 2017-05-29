namespace OpenHAB.NetRestApi.RestApi
{
    public static class OpenHab
    {
        #region Rest Client

        public static OpenHabRestClient CreateRestClient(string url)
        {
            return RestClient = new OpenHabRestClient(url);
        }

        internal static OpenHabRestClient RestClient { get; private set; }

        #endregion
    }
}