using System.Net.Http.Headers;

namespace AsyncAwait.Slides.wip
{
    internal class BasicDemoValueTask
    {
        private static string _token;
        private static readonly HttpClient _httpClient;
        private static DateTime _tokenTimeStamp;
        private static readonly int ExpirationMinutes = 30;

        static BasicDemoValueTask()
        {
            _httpClient = new HttpClient();
        }

        public async static Task<string> GetTokenAsync()
        {
            var now = DateTime.Now;

            if (_token is null || _tokenTimeStamp.AddMinutes(ExpirationMinutes) >= now)
            {
                _token = await GetAuthTokenAsync();
                _tokenTimeStamp = now;
            }

            return _token;
        }

        public async static Task<string> GetAuthTokenAsync()
        {
            return "hhr";
        }

        private async static ValueTask<string> GetAsync()
        {
            var list = new List<string> { "ce", "ffg", "fgk" };

            var tasks = list.Select(x => GetTokenAsync());

            var task = await Task.WhenAll(tasks);
            return "ghf";
        }
    }
}
