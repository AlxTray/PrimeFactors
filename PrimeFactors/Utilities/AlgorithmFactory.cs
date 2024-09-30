using PrimeFactors.Model;
using Unity;

namespace PrimeFactors.Utilities
{
    public class AlgorithmFactory : IAlgorithmFactory
    {
        private readonly IUnityContainer _container;

        public AlgorithmFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IPrimeFactorisationAlgorithm SelectAlgorithm(int number)
        {
            // This would choose the correct algorithm but only one exists in this example
            return _container.Resolve<TrialDivisionAlgorithm>();

        }
    }
}
