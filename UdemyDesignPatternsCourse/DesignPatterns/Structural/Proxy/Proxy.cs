namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    using System.Diagnostics.CodeAnalysis;

    using static System.Console;

    public class Proxy : IDemo
    {
        public void Run()
        {
            //ProtectionProxyDemo();

            //PropertyProxyDemo();

            DynamicLoggingProxyDemo();
        }

        private static void DynamicLoggingProxyDemo()
        {
            var ba = Log<BankAccount>.As<IBankAccount>();

            ba.Deposit(100);
            ba.Withdraw(50);

            WriteLine(ba);
        }

        private static void PropertyProxyDemo()
        {
            var c = new Creature();
            c.Agility = 10;
            c.Agility = 11;
        }

        private static void ProtectionProxyDemo()
        {
            ICar car = new Car();
            var driver = new Driver { Age = 12 };

            ICar carProxy = new CarProxy(driver, car);
            carProxy.Drive();
        }
    }
}
