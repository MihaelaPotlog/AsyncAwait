namespace AsyncAwait.Slides.wip.Deadlocks;

internal class DeadlockInCtor
{
    private bool Hello { get; set; }
    public DeadlockInCtor()
    {
        var task = LoadDataAsync();
        var result = task.Result;
    }
    public async Task<bool> LoadDataAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        Hello = true;
        return true;
    }
}
