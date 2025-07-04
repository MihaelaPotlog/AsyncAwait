namespace AsyncAwait.Slides.ElidingAsyncAwait
{
    internal class ElidingAsyncAwaitService
    {
        public static async Task Test1Async()
        {
            var task = Test2Async();
            await task;
        }

        static Task Test2Async()
        {
            var task3 = Test3Async();

            return task3;
        }

        static async Task Test3Async()
        {
            await Task.Delay(0);
            throw new Exception("Hello world");
        }
    }
}
