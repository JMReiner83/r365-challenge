using R365.Challenge.Library;

namespace R365.Challenge.Library.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator = new Calculator();

        [Theory]
        [InlineData("20", 20)]
        [InlineData("1,5000", 5001)]
        [InlineData("4,-3", 1)]
        [InlineData(null, 0)]
        [InlineData("1,2,3,4,5,6,7,8,9,10,11,12", 78)]
        public void Add_SumsAllowedNumberOfAddends(string args, int expectedResult)
        {
            var sum = _calculator.Add(args);
            Assert.Equal(expectedResult, sum);
        }

        [Theory]
        [InlineData("1,")]
        [InlineData("5,tytyt")]
        public void ParseArgs_ConvertsNonIntToZero(string args)
        {
            var parsedArgs = _calculator.ParseArgs(args);
            Assert.Equal(0, parsedArgs.ElementAt(1));
        }

        [Theory]
        [InlineData("1,", 1)]
        [InlineData("5,tytyt", 5)]
        public void ParseArgs_ConvertsInt(string args, int expectedResult)
        {
            var parsedArgs = _calculator.ParseArgs(args);
            Assert.Equal(expectedResult, parsedArgs.ElementAt(0));
        }
    }
}