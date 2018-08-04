namespace UdemyDesignPatternsCourse
{
    using UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Command;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Interpreter;
    using UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple;
    using UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple;
    using UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple;
    using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
    using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

    class Program
    {
        static void Main(string[] args)
        {
            // Solid();
            DesignPatterns();
        }

        private static void DesignPatterns()
        {
            // Creational();
            Structural();
        }

        private static void Creational()
        {
            // new Builder().Run();
            // new Factories().Run();
            // new Prototype().Run();
            // new Singleton().Run();
        }

        private static void Structural()
        {
            // new Adapter().Run();
            // new Bridge().Run();
            // new Composite().Run();
            // new Decorator().Run();
            // new Flyweight(new TestOutputHelper()).Run();
            // new Proxy().Run();
            // new ChainOfResponsibility().Run();
            // new Command().Run();
            new Interpreter().Run();
        }

        static void Solid()
        {
            new SingleResponsibilityPrinciple().Run();
            new OpenClosedPrinciple().Run();
            new LiskovSubstitutionPrinciple().Run();
            new InterfaceSegregationPrinciple().Run();
            new DependencyInversionPrinciple().Run();
        }
    }
}
