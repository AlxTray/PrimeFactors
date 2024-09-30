namespace PrimeFactors.Model
{
    public interface IPrimeFactorisationAlgorithm
    {
        List<int> GetPrimeFactors(int number);
        string GetAlgorithmName();
    }
}
