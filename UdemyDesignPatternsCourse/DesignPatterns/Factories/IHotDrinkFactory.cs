namespace UdemyDesignPatternsCourse.DesignPatterns.Factories
{
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}