using System.Net;

namespace AsyncAwait.LegacyToTAP;

internal class EventBasedToTAP
{
    public static async Task RunAsync()
    {
        await DownloadStringAsync(new Uri("https://learn.microsoft.com/azure/devops"));

        throw new Exception("Hello world!");
    }

    public static Task<string> DownloadStringAsync(Uri url)
    {
        var tcs = new TaskCompletionSource<string>();

        var client = new WebClient();

        client.DownloadStringCompleted += (s, e) =>
        {
            if (e.Error != null)
                tcs.TrySetException(e.Error);
            else if (e.Cancelled)
                tcs.TrySetCanceled();
            else
                tcs.TrySetResult(e.Result);

            throw new Exception("Still in event handler!");
        };

        client.DownloadStringAsync(url);

        return tcs.Task;
    }
}
