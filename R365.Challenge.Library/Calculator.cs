using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace R365.Challenge.Library
{
    public class Calculator
    {
        // Req 6, 7, 8: Support custom delimiters
        static readonly Regex CustomDelimiterFormat = new Regex($"//(?<delimiter1>.|(\\[(?<delimiter2>[^\\]]+)\\])+){Environment.NewLine}(?<numbers>(.|\n)+)", RegexOptions.Multiline);

        // Req 3: Support newline delimiter in addition to comma
        static readonly string[] DefaultDelimiters = new string[] { ",", Environment.NewLine };

        public Calculator() { }

        public int Add(string? args)
        {
            if (args == null)
            {
                return 0;
            }

            return ParseArgs(args).Sum();
        }

        public IEnumerable<int> ParseArgs(string args)
        {
            string[] splitArgs;

            var customDelimiterMatch = CustomDelimiterFormat.Match(args);
            if (customDelimiterMatch.Success)
            {
                // Split custom delimiter from numbers string.
                string[] delimiters;
                var customDelimiters = customDelimiterMatch.Groups["delimiter2"];
                if (customDelimiters.Length > 0)
                {
                    // Req 7, 8: Custom delimiter(s) of any length
                    delimiters = DefaultDelimiters.Concat(customDelimiters.Captures.Select(c => c.Value)).ToArray();
                }
                else
                {
                    // Req 6: Customer delimiter (single char)
                    string customDelimiter = customDelimiterMatch.Groups["delimiter1"].Value;
                    delimiters = DefaultDelimiters.Append(customDelimiter).ToArray();
                }

                string numbers = customDelimiterMatch.Groups["numbers"].Value;

                splitArgs = numbers.Split(delimiters, StringSplitOptions.None);
            }
            else
            {
                // Parse entire string as numbers
                splitArgs = args.Split(DefaultDelimiters, StringSplitOptions.None);
            }

            var integers = splitArgs.Select(a =>
            {
                _ = Int32.TryParse(a, out int x);

                // Req 5: Convert numbers > 1000 to 0
                if (x > 1000)
                {
                    return 0;
                }

                return x;
            });

            // Req 4: Deny negative numbers
            var negativeIntegers = integers.Where(x => x < 0).ToList();
            if (negativeIntegers.Any())
            {
                throw new ArgumentException(
                    $"Negative integers are not allowed ({String.Join(", ", negativeIntegers)})");
            }

            return integers;
        }
    }
}
