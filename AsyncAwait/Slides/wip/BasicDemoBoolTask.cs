using System.Threading;

namespace AsyncAwait.Slides.wip
{
    internal class BasicDemoBoolTask
    {
        public async Task DoWorkX1Async()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do sync X1 work");

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = DoWorkX2Async();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Do  independent X1 work");

            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await task;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do  dependent X1 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.ResetColor();
        }

        public async Task DoWorkX2Async()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do sync X2 work");

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = DoWorkX3Async();
            var task4 = DoWorkX4Async();

            var isEqual = task == task4;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Do  independent X2 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await task;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do  dependent X2 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public async Task<bool> DoWorkX3Async()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do sync X3 work");

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = Task.Delay(5000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Do  independent X3 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await task;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do  dependent X3 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            return true;
        }

        public async Task<bool> DoWorkX4Async()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do sync X3 work");

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var task = Task.Delay(5000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Do  independent X3 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await task;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do  dependent X3 work");
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            return true;
        }
    }
}
