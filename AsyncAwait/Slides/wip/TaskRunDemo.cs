namespace AsyncAwait.Slides.wip
{
    public class TaskRunDemo
    {
        public async Task DoSomethingAsync()
        {
            await Task.Run(() => DoSomething());
        }

        public void DoSomething()
        {
            Thread.Sleep(5000);
        }

        public async Task DoSomethingReallyAsync()
        {
            await DoSomethingAsync();
        }
    }
}
