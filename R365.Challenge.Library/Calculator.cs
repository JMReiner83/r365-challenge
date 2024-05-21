using System.ComponentModel;

namespace R365.Challenge.Library
{
    public class Calculator
    {
        public Calculator() { }

        char Delimiter { get; init; } = ',';

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
            var splitArgs = args.Split(Delimiter);

            if (splitArgs.Count() > 2)
            {
                throw new ArgumentException("More than 2 numbers were provided.");
            }

            return splitArgs.Select(a =>
            {
                _ = Int32.TryParse(a, out int x);
                return x;
            });
        }
    }
}
