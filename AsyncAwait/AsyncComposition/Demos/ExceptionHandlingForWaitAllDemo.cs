using System.Text.Json;

namespace AsyncAwait.AsyncComposition.Demos;

class ExceptionHandlingForWaitAllDemo
{
    private static readonly HttpClient _httpClient;

    static ExceptionHandlingForWaitAllDemo()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://uselessfacts.jsph.pl/api/v2/facts/random");
    }

    public async static Task GetActivitiesAsync()
    {
        var getActivityTasks = new List<Task<Fact>>();
        Task<Fact[]>? aggregatedTask = default;

        try
        {
            string[] languages = ["en", "en", "yy", "zz"];

            foreach (var language in languages)
            {
                getActivityTasks.Add(GetRandomFactAsync(language));
            }

            aggregatedTask = Task.WhenAll(getActivityTasks);

            var facts = aggregatedTask.Result;

            facts.ToList().ForEach(fact => Console.WriteLine(fact));
        }
        catch (AggregateException ex)
        {
            var allExceptionsMessages = aggregatedTask?.Exception?.InnerExceptions?.Select(ex => ex.Message) ?? [];

            Console.WriteLine("\nExceptions:\n" + string.Join('\n', allExceptionsMessages));

            foreach (var task in getActivityTasks)
            {
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine(task.Result.ToString());
                }
            }
        }


    }

    private static async Task<Fact> GetRandomFactAsync(string language)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"?language={language}");
        response.EnsureSuccessStatusCode();

        // Simulate an error for demonstration purposes
        if (language != "de" && language != "en")
        {
            throw new InvalidOperationException($"Something went wrong for language {language}");
        }

        var stringResponse = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<Fact>(stringResponse);
    }
}



