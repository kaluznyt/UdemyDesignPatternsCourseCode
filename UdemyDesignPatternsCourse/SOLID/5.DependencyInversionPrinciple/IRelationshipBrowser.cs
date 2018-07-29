using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
}