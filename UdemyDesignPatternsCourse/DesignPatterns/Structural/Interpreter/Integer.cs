namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Interpreter
{
    public class Integer : IElement
    {
        public int Value { get; }

        public Integer(int value)
        {
            this.Value = value;
        }
    }
}