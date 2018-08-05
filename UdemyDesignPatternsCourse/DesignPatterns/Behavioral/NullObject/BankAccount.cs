namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.NullObject
{
    public class BankAccount
    {
        private ILog log;

        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            this.balance += amount;
            this.log.Info($"Deposited {amount}, balance is now {this.balance}");
        }

    }
}