namespace AsyncAwait.Slides.ExceptionHandling
{
    internal class ProcessingService
    {
        public static async Task TestAsync()
        {
            var task = ProcessAsync();
            await task;
        }

        private static async Task ProcessAsync()
        {
            await Task.Delay(1000);
            throw new Exception("Hello World");
        }
    }
}
