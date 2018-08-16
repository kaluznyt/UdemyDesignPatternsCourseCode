namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;
        public void Visit(DoubleExpression de)
        {
            this.Result = de.value;
        }

        public void Visit(AdditionExpression ae)
        {
            ae.left.Accept(this);
            var a = this.Result;
            ae.right.Accept(this);
            var b = this.Result;
            this.Result = a + b;
        }
    }
}