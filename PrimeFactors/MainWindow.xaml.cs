using PrimeFactors.ViewModel;
using System.Windows;

namespace PrimeFactors
{
    public partial class MainWindow : Window
    {
        public MainWindow(PrimeViewModel primeViewModel)
        {
            InitializeComponent();
            this.primeView.DataContext = primeViewModel;
        }
    }
}