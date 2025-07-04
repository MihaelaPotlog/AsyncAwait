namespace AsyncAwait.Slides.ValueTaskExercises;

internal class ValueTaskExercise2
{
    /// <summary>
    /// Assuming is required to call an async method (GetValueAsync) in the static constructor,
    /// change the static constructor such that it does not have an undefined behavior.
    /// </summary>
    static ValueTaskExercise2()
    {
        var valueTask = GetValueAsync();

        if (!valueTask.IsCompleted)
        {
            Console.WriteLine("Processing data asynchronously...");
        }

        valueTask.GetAwaiter().GetResult(); // Blocking operation

        Console.WriteLine("Data processing completed.");
    }

    /// <summary>
    /// Simulates an async operation that can complete synchronously
    /// </summary>
    /// <returns></returns>
    static async ValueTask<int> GetValueAsync()
    {
        var random = new Random();

        if (random.Next(2) == 0)
        {
            await Task.Delay(0); // Simulating an asynchronous operation
            return 42;
        }

        await Task.Delay(3000);
        return 52;
    }
}

