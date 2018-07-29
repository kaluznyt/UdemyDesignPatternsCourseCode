namespace UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple
{
    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public bool IsSatisfied(Product product)
        {
            return this.color == product.Color;
        }
    }
}