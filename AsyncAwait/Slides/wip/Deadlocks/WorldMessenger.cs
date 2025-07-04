namespace AsyncAwait.Slides.wip.Deadlocks;

internal class WorldMessenger
{
    public static string MessageToTheWorld;

    static WorldMessenger()
    {
        SetMessageToTheWorldAsync().Wait();
    }

    public static async Task SetMessageToTheWorldAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        MessageToTheWorld = "Hello";
    }
}
