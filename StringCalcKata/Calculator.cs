namespace StringCalcKata
{
    public class Calculator
    {
        private readonly IHandler handler;

        public Calculator(IHandler handler)
        {
            this.handler = handler;
        }

        public int Add(string input)
        {
            return handler.Handle(input);
        }
    }
}