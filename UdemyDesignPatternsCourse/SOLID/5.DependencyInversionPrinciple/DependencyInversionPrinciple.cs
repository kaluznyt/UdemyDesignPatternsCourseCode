namespace UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple
{
    public class DependencyInversionPrinciple : IDemo
    {
        public void Run()
        {
            var parent = new Person() { Name = "John" };
            var child1 = new Person() { Name = "Chris" };
            var child2 = new Person() { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
