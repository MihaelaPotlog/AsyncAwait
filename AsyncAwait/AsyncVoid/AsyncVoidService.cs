namespace AsyncAwait.AsyncVoid;

internal class AsyncVoidService
{
    public static async Task TestAsync()
    {
        try
        {
            FireAndForgetAsync();

            var index = 0;
            while (true)
            {
                Console.WriteLine($"{index++}");
            }
        }
        catch (Exception e) { }
    }

    private static async void FireAndForgetAsync()
    {
        await Task.Delay(0);
        Console.WriteLine("Entered async void method!");
        throw new Exception("Hello world!");
    }
}
