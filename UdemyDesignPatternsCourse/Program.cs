using UdemyDesignPatternsCourse.DesignPatterns.Builder;

using UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple;
using UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple;
using UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple;
using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

namespace UdemyDesignPatternsCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solid();
            DesignPatterns();
        }

        private static void DesignPatterns()
        {
            new Builder().Run();
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
