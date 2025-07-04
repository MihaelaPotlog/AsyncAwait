namespace AsyncAwait.Slides.FireAndForget
{
    internal static class FireAndForget
    {
        public static async Task Test1Async()
        {
            Test2();
        }
        public static void Test2()
        {
            Test3Async();
        }

        public static async Task Test3Async()
        {
            //await Task.Delay(1000);
            Console.WriteLine("Hello");
            throw new InvalidOperationException();
        }
    }
}
