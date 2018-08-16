namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    public class AdditionExpression : Expression
    {
        public Expression left;

        public Expression right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Accept(IExpressionVisitor ev)
        {
            ev.Visit(this);
        }
    }
}