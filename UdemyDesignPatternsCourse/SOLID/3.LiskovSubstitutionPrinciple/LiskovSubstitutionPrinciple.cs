using static System.Console;

namespace UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple
{
    /// <summary>
    /// Liskov Substitution Principle
    /// - you should be able to substitute a base type for a subtype
    /// - make certain things in class virtual, so when inherited proper members are called when accessed by a base type
    /// </summary>
    public class LiskovSubstitutionPrinciple : IDemo
    {
        public static int Area(Rectangle r) => r.Width * r.Height;

        public void Run()
        {
            var rectangle = new Rectangle(2, 3);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            Rectangle square = new Square();
            square.Width = 5;
            WriteLine($"{square} has area {Area(square)}");
        }
    }
}
