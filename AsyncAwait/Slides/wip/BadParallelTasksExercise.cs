namespace AsyncAwait.Slides.wip
{
    internal class BadParallelTasksExercise
    {
        private HttpClient _client = new HttpClient();

        public async Task<List<string>> GetBothAsync()
        {
            var url1 = "https://en.wikipedia.org/wiki/Star";

            var result = new List<string>();
            var listTasks = new List<Task>();

            foreach (var i in Enumerable.Range(0, 100))
            {
                listTasks.Add(GetOneAsync(result, url1));
            }
            await Task.WhenAll(listTasks);
            return result;
        }

        async Task GetOneAsync(List<string> result, string url)
        {
            var data = await _client.GetStringAsync(url);
            result.Add(data);
        }
    }
}
