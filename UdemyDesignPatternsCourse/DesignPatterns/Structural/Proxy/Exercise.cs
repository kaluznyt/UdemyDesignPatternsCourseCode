using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private readonly Person person;

        public int Age
        {
            get => this.person.Age;
            set => this.person.Age = value;
        }

        public string Drink()
        {
            return this.person.Age < 18 ? "too young" : this.person.Drink();
        }

        public string Drive()
        {
            return this.person.Age < 16 ? "too young" : this.person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }

        public ResponsiblePerson(Person person)
        {
            this.person = person;
        }
    }
}
