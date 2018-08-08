namespace UdemyDesignPatternsCourse
{
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Command;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Interpreter;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.NullObject;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer;
    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.State;
    using UdemyDesignPatternsCourse.DesignPatterns.Creational.Builder;
    using UdemyDesignPatternsCourse.DesignPatterns.Creational.Factories;
    using UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype;
    using UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Adapter;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Bridge;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Composite;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Iterator;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Memento;
    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy;
    using UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple;
    using UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple;
    using UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple;
    using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
    using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

    using Xunit.Sdk;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Solid();
            DesignPatterns();
        }

        private static void DesignPatterns()
        {
            // Creational();
            // Structural();
            Behavioral();
        }

        private static void Creational()
        {
            new Builder().Run();
            new Factories().Run();
            new Prototype().Run();
            new Singleton().Run();
        }

        private static void Structural()
        {
            new Adapter().Run();
            new Bridge().Run();
            new Composite().Run();
            new Decorator().Run();
            new Flyweight(new TestOutputHelper()).Run();
            new Proxy().Run();
        }

        private static void Behavioral()
        {
            // new ChainOfResponsibility().Run();
            // new Command().Run();
            // new Interpreter().Run();
            // new Iterator().Run();
            // new Mediator().Run();
            // new MementoDemo().Run();
            // new NullObject().Run();
            // new Observer().Run();
            new State().Run();
        }

        private static void Solid()
        {
            new SingleResponsibilityPrinciple().Run();
            new OpenClosedPrinciple().Run();
            new LiskovSubstitutionPrinciple().Run();
            new InterfaceSegregationPrinciple().Run();
            new DependencyInversionPrinciple().Run();
        }
    }
}
