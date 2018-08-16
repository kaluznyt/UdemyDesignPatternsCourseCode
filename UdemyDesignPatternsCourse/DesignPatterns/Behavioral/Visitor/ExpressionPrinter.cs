namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    using System.Text;

    public class ExpressionPrinter : IExpressionVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            this.sb.Append(de.value);
        }

        public void Visit(AdditionExpression ae)
        {
            this.sb.Append("(");
            ae.left.Accept(this);
            this.sb.Append("+");
            ae.right.Accept(this);
            this.sb.Append(")");
        }

        public override string ToString()
        {
            return this.sb.ToString();
        }
    }
}