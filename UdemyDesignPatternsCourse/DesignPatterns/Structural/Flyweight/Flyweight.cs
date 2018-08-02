using JetBrains.dotMemoryUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static System.Console;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    public class Flyweight : IDemo
    {
        private readonly ITestOutputHelper output;

        public Flyweight(ITestOutputHelper output)
        {
            this.output = output;
            DotMemoryUnitTestOutput.SetOutputMethod(output.WriteLine);
        }

        public void Run()
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft);

            var bft = new BetterFormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            WriteLine(bft);
        }

        [Fact]
        public void TestUser() // 2132311
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User>();

            foreach (var lastName in lastNames)
            {
                foreach (var firstName in firstNames)
                {
                    var user = new User($"{firstName} {lastName}");
                    users.Add(user);
                }
            }

            ForceGC();

            dotMemory.Check(m => output.WriteLine(m.SizeInBytes.ToString()));
        }

        [Fact]
        public void TestUser2() // 2132311 - 1819665
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = new List<User2>();

            foreach (var lastName in lastNames)
            {
                foreach (var firstName in firstNames)
                {
                    var user = new User2($"{firstName} {lastName}");
                    users.Add(user);
                }
            }

            ForceGC();

            dotMemory.Check(m => output.WriteLine(m.SizeInBytes.ToString()));
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            var random = new Random();

            return new string(Enumerable.Range(0, 10)
                        .Select(i => (char)('a' + random.Next(26)))
                        .ToArray());


        }
    }
}
