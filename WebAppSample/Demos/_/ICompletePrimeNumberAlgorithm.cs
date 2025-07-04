namespace WebAppSample.Demos._
{
    public interface ICompletePrimeNumberAlgorithm
    {
        bool IsPrime(ulong number, CancellationToken token);
    }
}
