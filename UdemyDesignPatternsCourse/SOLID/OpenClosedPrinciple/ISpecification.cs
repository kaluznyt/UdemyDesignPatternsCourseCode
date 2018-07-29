namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}