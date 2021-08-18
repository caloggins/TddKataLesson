namespace StringCalcKata
{
    public class EmptyStringHandler : IHandler
    {
        private readonly IHandler successor;

        public EmptyStringHandler(IHandler successor)
        {
            this.successor = successor;
        }

        public int Handle(string input)
        {
            if (InputIsEmpty(input))
                return 0;

            return successor.Handle(input);
        }

        private bool InputIsEmpty(string input)
        {
            return input == "";
        }
    }
}