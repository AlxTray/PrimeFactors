using Moq;
using PrimeFactors.Model;
using PrimeFactors.ViewModel;
using PrimeFactors.Utilities;

namespace PrimeFactors.Test.ViewModel
{
    [TestClass]
    public class PrimeViewModelTests
    {
        [TestMethod]
        public void CalculatePrimeFactors_ShouldReturnValidFactors()
        {
            var mockAlgorithm = new Mock<IPrimeFactorisationAlgorithm>();
            mockAlgorithm.Setup(a => a.GetPrimeFactors(It.IsAny<int>())).Returns(new List<int>() { 2, 3, 7 });

            var mockAlgorithmSelector = new Mock<IAlgorithmFactory>();
            mockAlgorithmSelector.Setup(s => s.SelectAlgorithm(It.IsAny<int>())).Returns(mockAlgorithm.Object);

            var viewModel = new PrimeViewModel(mockAlgorithmSelector.Object);
            viewModel.InputNumber = 42;

            viewModel.CalculateCommand.Execute(null);

            CollectionAssert.AreEqual(new List<int> { 2, 3, 7 }, viewModel.PrimeFactors);
        }

        [TestMethod]
        public void CalculatePrimeFactors_ShouldReturnNoFactors()
        {
            var mockAlgorithm = new Mock<IPrimeFactorisationAlgorithm>();
            mockAlgorithm.Setup(a => a.GetPrimeFactors(It.IsAny<int>())).Returns(new List<int>());

            var mockAlgorithmSelector = new Mock<IAlgorithmFactory>();
            mockAlgorithmSelector.Setup(s => s.SelectAlgorithm(It.IsAny<int>())).Returns(mockAlgorithm.Object);

            var viewModel = new PrimeViewModel(mockAlgorithmSelector.Object);
            viewModel.InputNumber = 42;

            viewModel.CalculateCommand.Execute(null);

            CollectionAssert.AreEqual(new List<int>(), viewModel.PrimeFactors);
        }

        [TestMethod]
        public void CalculatePrimeFactors_ShouldReturnAlgorithmName()
        {
            var mockAlgorithm = new Mock<IPrimeFactorisationAlgorithm>();
            mockAlgorithm.Setup(a => a.GetAlgorithmName()).Returns("Test Algorithm");

            var mockAlgorithmSelector = new Mock<IAlgorithmFactory>();
            mockAlgorithmSelector.Setup(s => s.SelectAlgorithm(It.IsAny<int>())).Returns(mockAlgorithm.Object);

            var viewModel = new PrimeViewModel(mockAlgorithmSelector.Object);
            viewModel.InputNumber = 42;

            viewModel.CalculateCommand.Execute(null);

            Assert.AreEqual("Test Algorithm", viewModel.AlgorithmName);
        }
    }
}