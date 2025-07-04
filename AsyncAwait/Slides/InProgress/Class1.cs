namespace AsyncAwait.Slides.InProgress
{
    internal class Class1
    {
        public static async Task TestAsync()
        {
            Task task = DoAsync();

            try
            {
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async Task DoAsync()
        {
            var task = DoSomethingAsync();
            if (true)
            {
                throw new Exception("do async");
            }
            await task;
        }

        public static async Task DoSomethingAsync()
        {
            Console.WriteLine("Still doing work");

            await Task.Delay(1000);

            Console.WriteLine("Still doing work");

            throw new Exception();
        }
    }
}
