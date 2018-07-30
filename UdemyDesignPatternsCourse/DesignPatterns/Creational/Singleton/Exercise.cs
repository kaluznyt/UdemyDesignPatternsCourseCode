using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton
{
    class Exercise
    {
    }

    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            return func() == func();
        }
    }
}
