namespace WebAppSample.Demos.AsyncEnumerator;

public interface IUsersService
{
    IAsyncEnumerable<IList<User>> GetPaginatedUsersAsync();
}
