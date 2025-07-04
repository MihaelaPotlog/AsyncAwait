using System.Diagnostics;

namespace AsyncAwait.AsyncComposition;

internal class WhenAllAndWhenAnyExercise
{

    static HttpClient _httpClient = new();

    static IEnumerable<string> _urlList = new string[]
    {
            "https://learn.microsoft.com",
            "https://learn.microsoft.com/aspnet/core",
            "https://learn.microsoft.com/azure",
            "https://learn.microsoft.com/azure/devops",
    };

    public static async Task SumPageSizesAsync()
    {
        var stopwatch = Stopwatch.StartNew();

        var downloadTasks = _urlList.Select(url => ProcessUrlAsync(url, _httpClient));

        var result = await Task.WhenAll(downloadTasks);
        var total = result.Sum();

        stopwatch.Stop();

        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Elapsed time:              {stopwatch.Elapsed}\n");
    }

    static async Task<int> ProcessUrlAsync(string url, HttpClient client)
    {
        byte[] content = await client.GetByteArrayAsync(url);
        Console.WriteLine($"{url,-60} {content.Length,10:#,#}");

        return content.Length;
    }
}

