﻿using System.ComponentModel;

namespace R365.Challenge.Library
{
    public class Calculator
    {
        public Calculator() { }

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

            return splitArgs.Select(a =>
            {
                _ = Int32.TryParse(a, out int x);
                return x;
            });
        }
    }
}
