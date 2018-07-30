namespace UdemyDesignPatternsCourse.DesignPatterns.Builder.FacetedBuilder
{
    public class PersonBuilder // facade
    {
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder { person = person };

        public PersonAddressBuilder Lives => new PersonAddressBuilder { person = person };

        public Person Build() => person;

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
}