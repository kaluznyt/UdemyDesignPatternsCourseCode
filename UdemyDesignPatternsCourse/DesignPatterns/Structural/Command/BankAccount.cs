namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Command
{
    using System;

    public class BankAccount
    {
        private int balance;

        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            this.balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {this.balance}");
        }

        public bool Withdraw(int amount)
        {
            if (this.balance - amount >= this.overdraftLimit)
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