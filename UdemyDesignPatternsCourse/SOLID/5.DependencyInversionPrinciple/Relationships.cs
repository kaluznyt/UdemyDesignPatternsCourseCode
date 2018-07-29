using System.Collections.Generic;
using System.Linq;

namespace UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple
{
    // Low Level Module, abstracted the store away to IRelationshipBrowser interface
    public class Relationships : IRelationshipBrowser
    {
        private readonly List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();
        //public List<(Person, Relationship, Person)> Relations => _relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return _relations.Where(
                x => x.Item1.Name == name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }
}