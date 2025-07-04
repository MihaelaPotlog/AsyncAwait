namespace AsyncAwait.AsyncFlowDemos;

public class BasicAsyncFlowWithALotIndependentWork
{
    public static async Task DoWorkX1Async()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Do sync X1 work");
        Console.WriteLine($"          {threadId}");

        var task = DoWorkX2Async();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Do independent X1 work    {threadId}");

        DoSynchronousIndependentWork();

        await task;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Do dependent X1 work     {threadId}");

        Console.ResetColor();
    }

    private static void DoSynchronousIndependentWork()
    {
        for (int i = 0; i < 100000; i++)
        {
            Console.Write(".");
        }
        Console.WriteLine();
        Console.WriteLine("~0.0~ FINISH doing SynchronousIndependentWork ~");
    }

    public static async Task DoWorkX2Async()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Do sync X2 work");
        Console.WriteLine($"          {threadId}");

        var task = DoWorkX3Async();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Do independent X2 work    {threadId}");
        await task;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Do dependent X2 work     {threadId}");
    }

    public static async Task DoWorkX3Async()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Do sync X3 work");
        Console.WriteLine($"          {threadId}");

        var task = Task.Delay(100);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Do independent X3 work    {threadId}");

        await task;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Do dependent X3 work     {threadId}");
        for (int i = 0; i < 200000; i++)
        {
            Console.Write("#");
        }
    }

    private static string threadId => $" [Thread: {Environment.CurrentManagedThreadId}]";
}
