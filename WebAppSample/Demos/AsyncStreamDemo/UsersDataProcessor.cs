namespace WebAppSample.Demos.AsyncEnumerator;

public class UsersDataProcessor : IUsersDataProcessor
{
    private readonly IUsersService _usersService;

    public UsersDataProcessor(IUsersService usersService)
    {
        _usersService = usersService;
    }

    public async Task ProcessUsersDataAsync()
    {
        Console.WriteLine($"Waiting for next users...");

        await foreach(var users in _usersService.GetPaginatedUsersAsync())
        {
            Console.WriteLine($"Processing data for {string.Join(", ", users)}");
            Thread.Sleep(1000);
            Console.WriteLine($"Finished processing users.");
        }

        Console.WriteLine("Received all users!");
    }
}
