namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    using System;

    public class BankAccount : IBankAccount
    {
        private const int OverdraftLimit = -500;

        private int balance;

        public void Deposit(int amount)
        {
            this.balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {this.balance}");

        }

        public bool Withdraw(int amount)
        {
            if (this.balance - amount >= OverdraftLimit)
            {
                this.balance -= amount;
                Console.WriteLine($"Withdrew ${amount}, balance is now {this.balance}");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{nameof(this.balance)}: {this.balance}";
        }
    }
}