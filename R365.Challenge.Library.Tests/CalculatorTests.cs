using R365.Challenge.Library;

namespace R365.Challenge.Library.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator = new Calculator();

        [Theory]
        [MemberData(nameof(CalculatorTestData.ValidInputsWithStandardDelimiters), MemberType = typeof(CalculatorTestData))]
        public void Add_SumsAllowedNumberOfAddends(string args, int expectedResult)
        {
            var sum = _calculator.Add(args);
            Assert.Equal(expectedResult, sum);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.ValidInputsWithCustomDelimiter), MemberType = typeof(CalculatorTestData))]
        public void ParseArgs_HandlesCustomDelimiter(string args, int expectedResult)
        {
            var sum = _calculator.Add(args);
            Assert.Equal(expectedResult, sum);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.InputsWithNegativeNumbers), MemberType = typeof(CalculatorTestData))]
        public void ParseArgs_ThrowsExWhenNegativeNumbers(string args)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Add(args));
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.InputsWithNonIntegralValues), MemberType = typeof(CalculatorTestData))]
        public void ParseArgs_ConvertsNonIntToZero(string args, int expectedResult)
        {
            var parsedArgs = _calculator.ParseArgs(args);
            Assert.Equal(0, parsedArgs.ElementAt(1));

            var sum = _calculator.Add(args);
            Assert.Equal(expectedResult, sum);
        }
    }
}