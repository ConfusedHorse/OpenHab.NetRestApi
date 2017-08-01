namespace OpenHAB.NetRestApi.RestApi
{
    public static class OpenHab
    {
        #region Rest Client

        public static OpenHabRestClient CreateRestClient(string url, bool startEventService = false)
        {
            var restClient = new OpenHabRestClient(url);
            restClient.EventService.InitializeAsync();
            return RestClient = restClient;
        }

        internal static OpenHabRestClient RestClient { get; private set; }

        #endregion
    }
}