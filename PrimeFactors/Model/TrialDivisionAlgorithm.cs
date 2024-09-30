namespace PrimeFactors.Model
{
    // Algorithm reference: https://www.geeksforgeeks.org/print-all-prime-factors-of-a-given-number/
    public class TrialDivisionAlgorithm : IPrimeFactorisationAlgorithm
    {
        public List<int> GetPrimeFactors(int number)
        {
            List<int> primeFactors = new List<int>();
            while (number % 2 == 0)
            {
                primeFactors.Add(2);
                number /= 2;
            }
 
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    primeFactors.Add(i);
                    number /= i;
                }
            }

            if (number > 2)
                primeFactors.Add(number);
            return primeFactors;
        }

        public string GetAlgorithmName() { return "TrialDivision"; }
    }
}
