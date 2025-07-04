namespace AsyncAwait.Slides.InProgress;

class WaitAllExercise0Solved
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
                tasks.Add(ProcessAsync(index));
            }

            aggregatedTask = Task.WhenAll(tasks);

            await aggregatedTask;
        }
        catch (Exception ex)
        {
            var innerExceptionsMessages = aggregatedTask
                                            ?.Exception
                                            ?.InnerExceptions
                                            .Select(ex => ex.Message) ?? new List<string>();

            Console.WriteLine("Exceptions: " + string.Join(';', innerExceptionsMessages));
            throw;
        }
    }


    /// <summary>
    /// Simulates asynchronous work
    /// </summary>
    static async Task<int> ProcessAsync(int index)
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
