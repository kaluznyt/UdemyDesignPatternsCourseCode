namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> _first;
        private readonly ISpecification<T> _second;

        public AndSpecification(ISpecification<T> second, ISpecification<T> first)
        {
            this._second = second;
            this._first = first;
        }

        public bool IsSatisfied(T t)
        {
            return _first.IsSatisfied(t) && _second.IsSatisfied(t);
        }
    }
}