using Bogus;

namespace WebAppSample.Demos.AsyncEnumerator;

public class UsersService : IUsersService
{
    public async IAsyncEnumerable<IList<User>> GetPaginatedUsersAsync()
    {
        var pageIndex = 0;
        var hasMorePages = true;

        do
        {
            var page = await GetPageAsync(pageIndex);

            hasMorePages = page.HasMorePages;
            pageIndex++;

            yield return page.Users;

        } while (hasMorePages);
    }

    //Simulates a paginated request
    async Task<GetUsersResponseDto> GetPageAsync(int pageIndex)
    {
        Console.WriteLine("Getting users...");

        await Task.Delay(1000);
        var userFaker = new Faker<User>()
                            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                            .RuleFor(u => u.LastName, f => f.Name.LastName());

        var responseFaker = new Faker<GetUsersResponseDto>()
            .RuleFor(r => r.HasMorePages, f => pageIndex <= 5)
            .RuleFor(r => r.Users, f => userFaker.Generate(5))
            .RuleFor(r => r.PageNumber, pageIndex);

        var usersPage = responseFaker.Generate();

        return usersPage;
    }
}
