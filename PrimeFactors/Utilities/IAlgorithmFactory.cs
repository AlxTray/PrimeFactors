using PrimeFactors.Model;

namespace PrimeFactors.Utilities
{
    public interface IAlgorithmFactory
    {
        IPrimeFactorisationAlgorithm SelectAlgorithm(int number);
    }
}
