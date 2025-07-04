namespace AsyncAwait.Slides.InProgress;

class WaitAllExercise2
{
    private static int _count = 5;

    public static async Task WaitOnAggregatedTaskAsync()
    {
        Task<int[]>? aggregatedTask = null;
        try
        {
            var tasks = new List<Task<int>>();

            for (var index = 1; index <= _count; index++)
            {
                tasks.Add(GetPriceAsync(index));
            }

            var total = 0;
            while (tasks.Any())
            {
                var completedTask = await Task.WhenAny(tasks);
                total += await completedTask;
                tasks.Remove(completedTask);
            }
        }
        catch (Exception ex)
        {
            var innerExceptionsMessages = aggregatedTask
                                            ?.Exception
                                            ?.InnerExceptions
                                            .Select(ex => ex.Message) ?? new List<string>();

            Console.WriteLine(string.Join('\n', innerExceptionsMessages));
            throw;
        }
    }


    /// <summary>
    /// Simulates asynchronous work
    /// </summary>
     static async Task<int> GetPriceAsync(int index)
    {
        if (index <= 3)
        {
            throw new Exception($"Count is {index}");
        }

        Random rnd = new Random();
        await Task.Delay(rnd.Next(1, 4000));

        Console.WriteLine($"DoWork {index} finished");

        return index;
    }
}
