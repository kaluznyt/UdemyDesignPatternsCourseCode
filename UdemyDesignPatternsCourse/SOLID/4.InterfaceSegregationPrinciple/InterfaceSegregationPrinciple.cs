using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple
{
    /// <summary>
    /// Interface Seggregation Principle
    /// - Don't put too much into an interface, split into separate smaller more grained interfaces
    /// - it may force clients to implement things that are not needed
    /// - YAGNI rule - You Ain't Gonna Need It
    /// - similiar to the SRP / Separation of concerns
    /// </summary>
    public class InterfaceSegregationPrinciple : IDemo
    {
        public void Run()
        {

        }
    }
}
