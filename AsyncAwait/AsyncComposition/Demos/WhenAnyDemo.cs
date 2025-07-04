namespace AsyncAwait.AsyncComposition.Demos
{
    class WhenAnyDemo
    {
        private static List<string> _list = new List<string>
        {
            "https://en.wikipedia.org/wiki/Orion_(constellation)",
            "https://en.wikipedia.org/wiki/Cetus"
        };

        private static HttpClient _httpClient = new HttpClient();

        public static async Task ProcessAsync()
        {
            var tasks = _list.Select(url => ProcessDataFromUrlAsync(url));

            var completedTask = await Task.WhenAny(tasks);

            var result = await completedTask;
            Console.WriteLine("\nA task has completed!");
        }

        public static async Task<int> ProcessDataFromUrlAsync(string url)
        {
            Console.WriteLine($"Processing data from url: {url}");

            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
 
            await Task.Delay(5000);

            Console.WriteLine($"Finished for url: {url}");

            return result.Length;
        }
    }
}
