namespace WebAppSample.Demos.CancellationTokenDemo;

public class ActivitiesService : IActivitiesService
{
    public async Task<IList<string>> GetActivitiesAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);

        return ["Boardgames", "Videogames"];
    }
}
