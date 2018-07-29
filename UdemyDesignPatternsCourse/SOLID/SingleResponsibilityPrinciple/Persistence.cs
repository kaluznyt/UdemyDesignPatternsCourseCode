using System.IO;

namespace UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple
{
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename)
        {
            File.WriteAllText(filename, journal.ToString());
        }

        public static Journal Load(string filename)
        {
            return new Journal();
        }
    }
}