using System.Text.Json;
using AsyncAwait.AsyncComposition.Demos;

namespace AsyncAwait.Slides.ValueTaskExercises
{
    /// <summary>
    /// Change the return type from Task to ValueTask and make the required changes in order for the code to build successfully.
    /// </summary>
    internal static class ValueTaskExercise3
    {
        private static readonly HttpClient _httpClient;

        static ValueTaskExercise3()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://www.boredapi.com/api/");
        }

        public static async Task DoSomethingAsync()
        {
            var getActivityTasks = new List<Task<Fact>>();

            for (var countParticipants = 1; countParticipants <= 5; countParticipants++)
            {
                getActivityTasks.Add(GetActivityAsync(countParticipants));
            }

            var activities = await Task.WhenAll(getActivityTasks);

            activities.ToList().ForEach(activity=> Console.WriteLine(activity.Text));
        }

        static async Task<Fact> GetActivityAsync(int countParticipants)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"activity?participants={countParticipants}");
            response.EnsureSuccessStatusCode();

            var activity = JsonSerializer.Deserialize<Fact>(await response.Content.ReadAsStringAsync());
            return activity;
        }
    }
}
