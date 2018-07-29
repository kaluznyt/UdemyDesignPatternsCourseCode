using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

namespace UdemyDesignPatternsCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //new SingleResponsibilityPrinciple().Run();
            new OpenClosedPrinciple().Run();
        }
    }
}
