namespace WebAppSample.Demos._
{
    public class CompletePrimeNumberAlgorithm : ICompletePrimeNumberAlgorithm
    {
        public bool IsPrime(ulong number, CancellationToken token)
        {
            ulong i = 2;

            while (i <= number / 2)
            {
                if (token.IsCancellationRequested)
                {
                    //Cleanup if there is something
                    token.ThrowIfCancellationRequested();
                }

                if (number % i == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
