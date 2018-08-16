namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);

        void Visit(AdditionExpression ae);
    }
}