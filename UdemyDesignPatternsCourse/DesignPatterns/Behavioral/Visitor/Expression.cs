namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor ev);
    }
}