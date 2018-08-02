using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator
{

    namespace Exercise
    {

        public class Bird
        {
            public int Age { get; set; }

            public string Fly()
            {
                return (Age < 10) ? "flying" : "too old";
            }
        }

        public class Lizard
        {
            public int Age { get; set; }

            public string Crawl()
            {
                return (Age > 1) ? "crawling" : "too young";
            }
        }

        public class Dragon // no need for interfaces
        {
            private Bird bird = new Bird();
            private Lizard lizard = new Lizard();
            private int age;


            public int Age
            {
                get { return age; }
                set { this.bird.Age = this.lizard.Age = this.age = value; }
            }

            public string Fly()
            {
                return this.bird.Fly();
            }

            public string Crawl()
            {
                return this.lizard.Crawl();
            }
        }
    }
}