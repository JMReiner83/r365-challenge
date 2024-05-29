using R365.Challenge.Library;
using System.Text.RegularExpressions;

namespace R365.Challenge.Cli
{
    internal class Program
    {
        const string HelpCommand = "help";
        static readonly string HelpCommandInput = $"{HelpCommand}{Environment.NewLine}";

        private static readonly string LineTerminationSequence = $"{Environment.NewLine}{Environment.NewLine}";

        static void Main(string[] args)
        {
            PrintWelcome();
            ProcessInput();
            PrintExit();
        }

        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the R365 Challenge CLI.");
            Console.WriteLine($"Type `{HelpCommand}` for more info and examples.");
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            Console.Clear();

            Console.WriteLine("You can enter addends to sum using any of the following formats...");
            Console.WriteLine();

            Console.WriteLine("* Separated by a comma or new line [Enter key].");
            Console.WriteLine();
            Console.WriteLine("  - Example #1:");
            Console.WriteLine("    1,2,3");
            Console.WriteLine("    => 6");
            Console.WriteLine();
            Console.WriteLine("  - Example #2:");
            Console.WriteLine("    1,2");
            Console.WriteLine("    3");
            Console.WriteLine("    => 6");
            Console.WriteLine();

            Console.WriteLine("* Prefixed with custom delimiter using the format: //{delimiter}\\n{numbers}.");
            Console.WriteLine();
            Console.WriteLine("  - Example #1:");
            Console.WriteLine("    //#");
            Console.WriteLine("    2#5");
            Console.WriteLine("    => 7");
            Console.WriteLine();

            Console.WriteLine("Two consecutive new lines will terminate the input.");
            Console.WriteLine();

            Console.WriteLine($"Type `{HelpCommand}` to see this message again.");
            Console.WriteLine();
        }

        private static string ReadInput()
        {

            string input = String.Empty;
            PrintPrompt();

            // Weird, but since we have to accept new lines in the input string, let's make two new lines the escape sequence.
            while (!input.EndsWith(LineTerminationSequence))
            {
                input += Convert.ToChar(Console.Read());

                // Check for help command before trying to parse.
                if (input.Equals(HelpCommandInput, StringComparison.OrdinalIgnoreCase))
                {
                    input = String.Empty;
                    PrintHelp();
                    PrintPrompt();
                }
            }

            return input;
        }

        private static void PrintPrompt()
        {
            Console.Write("Enter input: ");
        }

        private static void ProcessInput()
        {
            var calculator = new Calculator();
            var input = ReadInput();

            try
            {
                var result = calculator.Add(input);

                Console.WriteLine($"Result: {result}");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine($"Error with your input: {aex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error: {ex.Message}");
            }
        }

        private static void PrintExit()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
        }
    }
}
