namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Memento
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            this.Balance = balance;
        }
    }
}