using System.ComponentModel;

namespace R365.Challenge.Library
{
    public class Calculator
    {
        public Calculator() { }

        // Req 3: Support newline delimiter in addition to comma
        char[] Delimiters { get; init; } = new[] { ',', '\n' };

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
            var splitArgs = args.Split(Delimiters);

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
