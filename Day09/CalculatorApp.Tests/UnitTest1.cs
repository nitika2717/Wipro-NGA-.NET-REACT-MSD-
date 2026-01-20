
namespace CalculatorApp.Tests;
public class Tests
{
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        // ADD TESTS

        [Test]
        public void Add_ValidNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Add(10.5, 20.5);
            Assert.AreEqual(31.0, result);
        }

        [Test]
        public void Add_ZeroAndNumber_ReturnsNumber()
        {
            double result = _calculator.Add(0, 15);
            Assert.AreEqual(15, result);
        }

        // SUBTRACT TESTS

        [Test]
        public void Subtract_ValidNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Subtract(20, 10);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Subtract_NumberAndZero_ReturnsNumber()
        {
            double result = _calculator.Subtract(15, 0);
            Assert.AreEqual(15, result);
        }

        // MULTIPLY TESTS 

        [Test]
        public void Multiply_ValidNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Multiply(5, 4);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Multiply_NumberWithZero_ReturnsZero()
        {
            double result = _calculator.Multiply(10, 0);
            Assert.AreEqual(0, result);
        }

        // DIVIDE TESTS

        [Test]
        public void Divide_ValidNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Divide(20, 5);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                _calculator.Divide(10, 0);
            });
        }


        
}