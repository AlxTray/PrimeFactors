using System.Windows.Input;

namespace PrimeFactors.ViewModel
{
    public interface IPrimeViewModel
    {
        int InputNumber { get; set; }
        List<int> PrimeFactors { get; set; }
        string AlgorithmName { get; set; }
        ICommand CalculateCommand { get; }
    }
}
