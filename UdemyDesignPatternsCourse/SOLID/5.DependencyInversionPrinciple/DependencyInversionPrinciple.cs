namespace UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple
{

    /// <summary>
    /// Dependency Inversion Principle
    /// - High level modules should not depend upon low level ones
    /// - use abstractions to hide the concrete implementations
    /// - do not expose implementation details directly but through interface
    /// </summary>
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
