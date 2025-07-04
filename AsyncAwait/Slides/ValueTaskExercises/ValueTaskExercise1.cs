namespace AsyncAwait.Slides.ValueTaskExercises;

internal static class ValueTaskExercise1
{

    public static void DoSomethingAsync()
    {
        Task<int> task = GetValueAsync();
        ValueTask<int> valueTask = new ValueTask<int>(task); // Incorrect usage

        Console.WriteLine($"Result: {valueTask.Result}");
    }

    public static async Task<int> GetValueAsync()
    {
        await Task.Delay(8000); // Simulating an asynchronous operation
        return 42;
    }
}

