namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    public class User
    {
        public override string ToString()
        {
            return $"{nameof(fullName)}: {fullName}";
        }

        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }
}