using AsyncAwait.AsyncComposition;
using AsyncAwait.AsyncComposition.Demos;
using AsyncAwait.AsyncFlowDemos;
using AsyncAwait.AsyncVoid;

while (true)
{
    Console.WriteLine($"{Environment.NewLine} 1 - Basic async flow - Demo" +
                       "\n 2 - What happens if it's a lot of 'independent work'? Demo" +
                       "\n 3 - WhenAll Demo" +
                       "\n 4 - WhenAny Demo" +
                       "\n 5 - WhenAll and exception handling exercise Demo" +
                       "\n 7 - WhenAll/WhenAny - exercise" +
                       "\n 8 - WhenAll/WhenAny - exercise solved" +
                       "\n 9 - async void Demo");

    var command = Console.ReadKey();
    Console.WriteLine();

    Func<Task> action = command.KeyChar switch
    {
        '1' => BasicAsyncFlow.DoWorkX1Async,
        '2' => BasicAsyncFlowWithALotIndependentWork.DoWorkX1Async,

        '3' => WhenAllDemo.GetRandomFactsAsync,
        '4' => WhenAnyDemo.ProcessAsync,
        '5' => ExceptionHandlingForWaitAllDemo.GetActivitiesAsync,

        '7' => WhenAllAndWhenAnyExercise.SumPageSizesAsync,
        '8' => WhenAllAndWhenAnyExerciseSolved.SumPageSizesAsync,

        '9' => AsyncVoidService.TestAsync,
        _ => () =>
      {
          Console.WriteLine();
          Console.WriteLine(Environment.NewLine + "Command not found");
          return Task.CompletedTask;
      }
    };

    await action.Invoke();

    Console.WriteLine(Environment.NewLine + "Press any key..");
    Console.ReadKey();
}

