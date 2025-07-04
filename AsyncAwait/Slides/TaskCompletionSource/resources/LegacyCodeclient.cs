using AsyncAwait.LegacyToTAP;

namespace AsyncAwait.Slides.TaskCompletionSource.resources
{
    internal class LegacyCodeClient
    {
        public static async Task GetDataAsync()
        {
            var uri = new Uri("https://en.wikipedia.org/wiki/Orion_(constellation)");

            var result = await EventBasedToTAP.DownloadStringAsync(uri);

            // Process data
        }
    }
}
