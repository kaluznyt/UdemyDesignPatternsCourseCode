namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.NullObject
{
    using System;
    using System.Dynamic;

    using Autofac;

    using ImpromptuInterface;

    public class NullObject :IDemo
    {
        public void Run()
        {
            // Demo();

            // DemoUsingDI();

            DemoUsingDynamicObject();
        }

        private static void DemoUsingDynamicObject()
        {
            var log = Null<ILog>.Instance;
            log.Info("This will not be logged");
            var ba = new BankAccount(log);
            ba.Deposit(100);
        }

        private static void DemoUsingDI()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<BankAccount>();
            cb.RegisterType<ConsoleLog>().As<ILog>();

            using (var c = cb.Build())
            {
                var ba = c.Resolve<BankAccount>();
                ba.Deposit(100);
            }
        }

        private static void Demo()
        {
            var log = new ConsoleLog();
            var nlog = new NullLog();
            var ba = new BankAccount(nlog);
            ba.Deposit(100);
        }
    }

    public class Null<TInterface> : DynamicObject
        where TInterface : class
    {
        public static TInterface Instance => new Null<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }
}
