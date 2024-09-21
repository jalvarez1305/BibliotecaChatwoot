using RestSharp;

namespace BibliotecasCrediMotos.Services.Chatwoot
{
    public  class Chatwoot_Media
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private Config _config;
        public Chatwoot_Media()
        {
            _config = new Config();
        }
        public async Task<MemoryStream> DownloadVideoAsync(string url)
        {   
            var client = new RestClient(url);
            var request = new RestRequest("",Method.Get);
            request.AddHeader("api_access_token", _config.CW_TOKEN);

            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Failed to download video: {response.ErrorMessage}");
            }

            var memoryStream = new MemoryStream(response.RawBytes);
            memoryStream.Position = 0; // Reset the position to the beginning of the stream
            return memoryStream;
        }

    }
}
