namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MoreLinq;

    public class Command : IDemo
    {
        public void Run()
        {
            BankCommandDemo();
        }

        private static void BankCommandDemo()
        {
            var ba = new BankAccount();

            var commands = new List<BankAccountCommand>
                               {
                                   new BankAccountCommand(
                                       ba,
                                       BankAccountCommand.Action.Deposit,
                                       100),
                                   new BankAccountCommand(
                                       ba,
                                       BankAccountCommand.Action.Withdraw,
                                       1000),
                                   new BankAccountCommand(
                                       ba,
                                       BankAccountCommand.Action.Deposit,
                                       1000),
                                   new BankAccountCommand(
                                       ba,
                                       BankAccountCommand.Action.Withdraw,
                                       999),
                                   new BankAccountCommand(
                                       ba,
                                       BankAccountCommand.Action.Withdraw,
                                       999)
                               };

            Console.WriteLine(ba);

            commands.ForEach(c => c.Call());

            Console.WriteLine(ba);

            Enumerable.Reverse(commands).ForEach(a => a.Undo());

            Console.WriteLine(ba);
        }
    }
}
