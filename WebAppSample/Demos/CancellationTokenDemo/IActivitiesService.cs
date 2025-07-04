namespace WebAppSample.Demos;

public interface IActivitiesService
{
    Task<IList<string>> GetActivitiesAsync(CancellationToken cancellationToken);
}
