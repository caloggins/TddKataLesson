namespace StringCalcKata
{
    public class EmptyStringHandler : Handler
    {
        private readonly Handler successor = new NegativeNumberHandler();

        public override int Handle(string input)
        {
            if (input == "")
                return 0;

            return successor.Handle(input);
        }
    }
}