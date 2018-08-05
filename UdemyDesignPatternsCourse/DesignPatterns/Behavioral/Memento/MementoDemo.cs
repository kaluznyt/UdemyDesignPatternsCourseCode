using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Memento
{
    public class MementoDemo : IDemo
    {
        public void Run()
        {
            // MementoClassic();

            // MementoForUndoAndRedo();
        }

        private static void MementoForUndoAndRedo()
        {
            var ba = new UndoRedo.BankAccount(100);
            ba.Deposit(50); // 150
            ba.Deposit(25); // 175
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");

            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");

            ba.Redo();
            Console.WriteLine($"Redo 1: {ba}");
        }

        private static void MementoClassic()
        {
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50); // 150
            var m2 = ba.Deposit(25); // 175
            Console.WriteLine(ba);

            ba.Restore(m1);
            Console.WriteLine(ba);

            ba.Restore(m2);
            Console.WriteLine(ba);
        }
    }

    namespace UndoRedo
    {
        public class BankAccount
        {
            private int balance;
            private List<Memento> changes = new List<Memento>();

            private int current;

            public BankAccount(int balance)
            {
                this.balance = balance;
                this.changes.Add(new Memento(balance));
            }

            public Memento Deposit(int amount)
            {
                this.balance += amount;

                var m = new Memento(this.balance);
                this.changes.Add(m);
                ++this.current;

                return m;
            }

            public Memento Restore(Memento m)
            {
                if (m != null)
                {
                    this.balance = m.Balance;
                    this.changes.Add(m);
                    return m;
                }

                return null;
            }

            public Memento Undo()
            {
                if (this.current > 0)
                    return Restore(this.changes[--this.current]);

                return null;
            }

            public Memento Redo()
            {
                if (this.current + 1 < changes.Count)
                    return Restore(this.changes[++this.current]);

                return null;
            }

            public override string ToString()
            {
                return $"{nameof(this.balance)}: {this.balance}";
            }
        }

        public class Memento
        {
            public int Balance { get; }

            public Memento(int balance)
            {
                this.Balance = balance;
            }
        }
    }
}
