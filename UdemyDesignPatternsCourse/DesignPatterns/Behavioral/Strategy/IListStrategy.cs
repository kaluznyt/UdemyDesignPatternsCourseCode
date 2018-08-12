namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Strategy
{
    using System.Text;

    public interface IListStrategy
    {
        void Start(StringBuilder sb);

        void End(StringBuilder sb);

        void AddListItem(StringBuilder sb, string item);
    }
}