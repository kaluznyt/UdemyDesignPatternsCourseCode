namespace UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple
{
    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private readonly IPrinter _printer;
        private readonly IScanner _scanner;
        private readonly IFax _fax;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner, IFax fax)
        {
            _printer = printer;
            _scanner = scanner;
            _fax = fax;
        }

        public void Scan(Document d)
        {
            _scanner.Scan(d);
        }

        public void Print(Document d)
        {
            _printer.Print(d);
        }

        public void Fax(Document d)
        {
            _fax.Fax(d);
        }
    }
}