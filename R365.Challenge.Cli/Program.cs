using R365.Challenge.Library;

namespace R365.Challenge.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            Console.WriteLine("Welcome to the R365 Challenge CLI.");
            Console.Write("Enter a comma-separated string of addends to sum: ");
            var input = Console.ReadLine();
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
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
        }
    }
}
