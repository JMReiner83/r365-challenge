using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R365.Challenge.Library.Tests
{
    internal record CalculatorTestRecord
    {
        public CalculatorTestRecord(string? args, int? expectedResult)
        {
            Args = args;
            ExpectedResult = expectedResult;
        }

        public string? Args { get; }
        public int? ExpectedResult { get; }
    }

    internal class CalculatorTestData
    {
        public static IEnumerable<object[]> ValidInputsWithStandardDelimiters()
        {
            yield return new object[] { "20", 20 };
            yield return new object[] { "1,5000", 1 };
            yield return new object[] { null, 0 };
            yield return new object[] { "1,2,3,4,5,6,7,8,9,10,11,12", 78 };
            yield return new object[] { $"1{Environment.NewLine}2,3", 6 };

        }

        public static IEnumerable<object[]> ValidInputsWithCustomDelimiter()
        {
            yield return new object[] { $"//#{Environment.NewLine}2#5", 7 };

        }

        public static IEnumerable<object[]> InputsWithNegativeNumbers()
        {
            yield return new object[] { "-1" };
            yield return new object[] { "0,-1,-2" };

        }

        public static IEnumerable<object[]> InputsWithNonIntegralValues()
        {
            yield return new object[] { "1,", 1 };
            yield return new object[] { "5,tytyt", 5 };

        }
    }
}
