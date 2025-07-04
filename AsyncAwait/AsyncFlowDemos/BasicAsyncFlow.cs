namespace AsyncAwait.AsyncFlowDemos;

public class BasicAsyncFlow
{
  public static  async Task DoWorkX1Async()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"Do sync X1 work");
    Console.WriteLine($"          {ThreadId}");

    var task = DoWorkX2Async();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Do independent X1 work");
    Console.WriteLine($"   {ThreadId}");

    await task;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Do dependent X1 work");
    Console.WriteLine($"     {ThreadId}");

    Console.ResetColor();
  }

  static async Task DoWorkX2Async()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Do sync X2 work");
    Console.WriteLine($"          {ThreadId}");

    var task = DoWorkX3Async();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Do independent X2 work");
    Console.WriteLine($"   {ThreadId}");

    await task;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Do dependent X2 work");
    Console.WriteLine($"     {ThreadId}");
  }

  static async Task DoWorkX3Async()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Do sync X3 work");
    Console.WriteLine($"          {ThreadId}");

    var task = Task.Delay(99000);

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Do independent X3 work");
    Console.WriteLine($"   {ThreadId}");

    await task;

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Do dependent X3 work");
    Console.WriteLine($"     {ThreadId}");
  }

  private static string ThreadId => $" [Thread: {Environment.CurrentManagedThreadId}]";
}
