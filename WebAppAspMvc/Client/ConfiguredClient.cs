namespace WebAppAspMvc.Client
{
    public class ConfiguredClient
    {
        // Ensure '/' at the rightmost of the url
        private static readonly string baseApiUrl = "https://localhost:7080/api/";

        public static IHttpClientFactory? ClientFactory { get; set; }

        public static HttpClient CreateClient()
        {
            if (ClientFactory == null)
                throw new InvalidOperationException();

            var client = ClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseApiUrl);

            return client;
        }

        public static HttpClient CreateClient(IHttpClientFactory clientFactory)
        {
            if (clientFactory == null)
                throw new InvalidOperationException();

            var client = clientFactory.CreateClient();
            client.BaseAddress = new Uri(baseApiUrl);

            return client;
        }
    }
}
