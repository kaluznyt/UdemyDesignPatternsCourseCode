namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Memento
{
    public class BankAccount
    {
        private int balance;

        public BankAccount(int balance)
        {
            this.balance = balance;
        }

        public Memento Deposit(int amount)
        {
            this.balance += amount;

            return new Memento(this.balance);
        }

        public void Restore(Memento m)
        {
            this.balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(this.balance)}: {this.balance}";
        }
    }
}