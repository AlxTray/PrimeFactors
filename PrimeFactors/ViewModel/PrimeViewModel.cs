using GalaSoft.MvvmLight.Command;
using PrimeFactors.Model;
using PrimeFactors.Utilities;
using System.ComponentModel;
using System.Windows.Input;

namespace PrimeFactors.ViewModel
{

    public class PrimeViewModel : IPrimeViewModel, INotifyPropertyChanged
    {
        private IPrimeFactorisationAlgorithm _primeFactorAlgorithm;
        private readonly IAlgorithmFactory _algorithmSelector;
        private int _inputNumber;
        private List<int> _primeFactors;
        private string _algorithmName;

        public PrimeViewModel(IAlgorithmFactory selector)
        {
            _algorithmSelector = selector;
            CalculateCommand = new RelayCommand(CalculatePrimeFactors);
        }

        public int InputNumber
        {
            get => _inputNumber;
            set
            {
                _inputNumber = value;
                RaisePropertyChanged(nameof(InputNumber));
            }
        }

        public List<int> PrimeFactors
        {
            get => _primeFactors;
            set
            {
                _primeFactors = value;
                RaisePropertyChanged(nameof(PrimeFactors));
            }
        }

        public string AlgorithmName
        {
            get => _algorithmName;
            set
            {
                _algorithmName = value;
                RaisePropertyChanged(nameof(AlgorithmName));
            }
        }

        public ICommand CalculateCommand { get; }

        private void CalculatePrimeFactors()
        {
            _primeFactorAlgorithm = _algorithmSelector.SelectAlgorithm(InputNumber);

            PrimeFactors = _primeFactorAlgorithm.GetPrimeFactors(InputNumber);
            AlgorithmName = _primeFactorAlgorithm.GetAlgorithmName();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}