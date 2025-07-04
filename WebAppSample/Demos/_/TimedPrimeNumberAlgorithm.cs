namespace WebAppSample.Demos._
{
    public class TimedPrimeNumberAlgorithm : ICompletePrimeNumberAlgorithm
    {
        private readonly ICompletePrimeNumberAlgorithm _algorithm;

        public TimedPrimeNumberAlgorithm(ICompletePrimeNumberAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public bool IsPrime(ulong number, CancellationToken token)
        {
            using var timedCts = new CancellationTokenSource();

            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(token, timedCts.Token);

            timedCts.CancelAfter(1000);

            return _algorithm.IsPrime(number, linkedCts.Token);
        }
    }
}
