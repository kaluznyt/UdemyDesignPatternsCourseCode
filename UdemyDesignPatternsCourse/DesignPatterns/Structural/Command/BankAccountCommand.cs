namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Command
{
    using System;

    public class BankAccountCommand : ICommand
    {
        private BankAccount bankAccount;

        public enum Action
        {
            Deposit, Withdraw
        }

        private Action action;

        private int amount;

        private bool succeeded;

        public BankAccountCommand(BankAccount bankAccount, Action action, int amount)
        {
            this.bankAccount = bankAccount;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (this.action)
            {
                case Action.Deposit:
                    this.bankAccount.Deposit(this.amount);
                    this.succeeded = true;
                    break;
                case Action.Withdraw:
                    this.succeeded = this.bankAccount.Withdraw(this.amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!this.succeeded) return;

            switch (action)
            {
                case Action.Deposit:
                    this.bankAccount.Withdraw(this.amount);
                    break;
                case Action.Withdraw:
                    this.bankAccount.Deposit(this.amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}