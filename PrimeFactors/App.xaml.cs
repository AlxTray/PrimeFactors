using PrimeFactors.Model;
using PrimeFactors.Utilities;
using PrimeFactors.ViewModel;
using System.Windows;
using Unity;

namespace PrimeFactors
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();
            // Extra algorithms to be registered here
            container.RegisterType<IPrimeFactorisationAlgorithm, TrialDivisionAlgorithm>();

            container.RegisterType<IAlgorithmFactory, AlgorithmFactory>();
            container.RegisterType<PrimeViewModel>();
            container.RegisterType<MainWindow>();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }

}
