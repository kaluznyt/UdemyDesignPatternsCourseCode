namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    public class DoubleExpression : Expression
    {
        public double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Accept(IExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }
}