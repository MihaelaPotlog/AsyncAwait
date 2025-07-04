namespace WebAppSample.Demos;

public class GetUsersResponseDto
{
    public bool HasMorePages { get; set; }
    public int PageNumber { get; set; }
    public IList<User> Users { get; set; }
}

public class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
