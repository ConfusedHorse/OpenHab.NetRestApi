namespace OpenHAB.NetRestApi.RestApi
{
    public static class OpenHab
    {
        #region Rest Client

        public static OpenHabRestClient CreateRestClient(string url, bool startEventService = false)
        {
            var restUrl = $"http://{url}:8080/rest";

            var restClient = new OpenHabRestClient(restUrl);
            if (startEventService) restClient.EventService.InitializeAsync();
            return RestClient = restClient;
        }

        internal static OpenHabRestClient RestClient { get; private set; }

        #endregion
    }
}