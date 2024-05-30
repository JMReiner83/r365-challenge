namespace R365.Challenge.Library
{
    public record AddResult
    {
        public AddResult(IEnumerable<int> numbers)
        {
            Sum = numbers.Sum();
            Formula = $"{String.Join('+', numbers)} = {Sum}";
        }

        public int Sum { get; }

        public string Formula { get; }
    }
}
