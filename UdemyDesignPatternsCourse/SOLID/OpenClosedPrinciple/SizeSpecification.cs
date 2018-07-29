namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsSatisfied(Product product)
        {
            return this._size == product.Size;
        }
    }
}