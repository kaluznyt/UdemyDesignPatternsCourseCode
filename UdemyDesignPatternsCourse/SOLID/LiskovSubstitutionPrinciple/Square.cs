namespace UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple
{
    public class Square : Rectangle
    {

        public override int Width
        {
            set => base.Width = base.Height = value;
        }

        public override int Height
        {
            set => base.Width = base.Height = value;
        }

        public Square()
        {
            
        }

        public Square(int x) : base(x, x)
        {
        }
    }
}