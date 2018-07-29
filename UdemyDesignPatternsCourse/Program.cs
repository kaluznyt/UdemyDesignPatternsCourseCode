using UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple;
using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

namespace UdemyDesignPatternsCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SingleResponsibilityPrinciple().Run();
            //new OpenClosedPrinciple().Run();
            new LiskovSubstitutionPrinciple().Run();
        }
    }
}
