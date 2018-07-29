using System;

namespace UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple
{
    public class OldFashinedPrinter : IMachine
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }

        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }
    }
}