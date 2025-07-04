namespace AsyncAwait.Slides.InProgress;

class WaitAllExercise0
{
    private static int _count = 5;

    public static async Task TestAsync()
    {

        var tasks = new List<Task<int>>();

        for (var index = 1; index <= _count; index++)
        {
            tasks.Add(ProcessAsync(index));
        }

        try
        {
            var result = await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            //ToDo: print all exceptions
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
