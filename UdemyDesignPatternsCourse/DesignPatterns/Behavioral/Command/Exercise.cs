namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Command
{
    using System;

    namespace Coding.Exercise
    {
        public class Command
        {
            public enum Action
            {
                Deposit,

                Withdraw
            }

            public Action TheAction;

            public int Amount;

            public bool Success;
        }

        public class Account
        {
            public int Balance { get; set; }

            public void Process(Command c)
            {
                switch (c.TheAction)
                {
                    case Command.Action.Deposit:
                        c.Success = this.Deposit(c.Amount);
                        break;
                    case Command.Action.Withdraw:
                        c.Success = this.Withdraw(c.Amount);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            private bool Deposit(int amount)
            {
                this.Balance += amount;
                return true;
            }

            private bool Withdraw(int amount)
            {

                if (this.Balance >= amount)
                {
                    this.Balance -= amount;
                    return true;
                }

                return false;
            }
        }
    }
}