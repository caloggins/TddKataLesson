namespace StringCalcKata
{
    public class Calculator
    {
        private readonly Handler handler = new EmptyStringHandler();

        public int Add(string input)
        {
            return handler.Handle(input);
        }
    }
}