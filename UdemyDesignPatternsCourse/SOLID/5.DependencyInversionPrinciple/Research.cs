using System;

namespace UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple
{
    public class Research
    {

        public Research(IRelationshipBrowser relationshipBrowser)
        {
            foreach (var child in relationshipBrowser.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child called {child.Name}");
            }
        }


        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;

        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
        //    {
        //        Console.WriteLine($"Joh has a child called {r.Item3.Name}");
        //    }
        //}
    }
}