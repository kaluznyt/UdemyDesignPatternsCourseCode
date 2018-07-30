namespace UdemyDesignPatternsCourse.DesignPatterns.Builder.FacetedBuilder
{
    public class PersonJobBuilder : PersonBuilder
    {

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earing(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }
}