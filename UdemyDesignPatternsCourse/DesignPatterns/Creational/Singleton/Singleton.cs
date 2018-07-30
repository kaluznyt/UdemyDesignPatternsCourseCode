using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using MoreLinq.Extensions;
using UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton.ThisIsBadExampleAsThisTypeOfSingletonIsntTestableAsItHardcodeReferenceToImplementationAndForceToTestOnLiveData;
using Xunit;

namespace UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton
{
    public class Singleton : IDemo
    {
        public void Run()
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";

            Console.WriteLine($"{city} has a population {db.GetPopulation(city)}");
        }
    }

    // Monostate
    public class CEO
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }

    public class SingletonTests
    {
        [Fact]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;

            Assert.Equal(db, db2);
            Assert.Equal(1, SingletonDatabase.Count);
        }

        [Fact]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Tokyo", "Jakarta" };

            var tp = rf.GetTotalPopulation(names);

            Assert.Equal(216443213, tp);
        }

        [Fact]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gamma" };

            var tp = rf.GetTotalPopulation(names);

            Assert.Equal(4, tp);
        }

        [Fact]
        public void DependencyInjectionPopulationTest()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<DummyDatabase>()
                            .As<IDatabase>()
                            .SingleInstance();

            containerBuilder.RegisterType<ConfigurableRecordFinder>();

            using (var container = containerBuilder.Build())
            {
                var rf = container.Resolve<ConfigurableRecordFinder>();

                var names = new[] { "alpha", "beta" };

                var tp = rf.GetTotalPopulation(names);

                Assert.Equal(3, tp);
            }
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing database");

            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => Int32.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(database.GetPopulation);
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }

    namespace ThisIsBadExampleAsThisTypeOfSingletonIsntTestableAsItHardcodeReferenceToImplementationAndForceToTestOnLiveData
    {
        public class SingletonRecordFinder
        {
            public int GetTotalPopulation(IEnumerable<string> names)
            {
                return names.Sum(SingletonDatabase.Instance.GetPopulation);
            }
        }

        public interface IDatabase
        {
            int GetPopulation(string name);
        }

        public class SingletonDatabase : IDatabase
        {
            private readonly Dictionary<string, int> capitals;

            private static int instanceCount;
            public static int Count => instanceCount;

            private static Lazy<SingletonDatabase>
                instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

            public static SingletonDatabase Instance => instance.Value;

            private SingletonDatabase()
            {
                instanceCount++;
                Console.WriteLine("Initializing database");

                capitals = File.ReadAllLines("capitals.txt")
                    .Batch(2)
                    .ToDictionary(
                        list => list.ElementAt(0).Trim(),
                        list => Int32.Parse(list.ElementAt(1)));
            }

            public int GetPopulation(string name)
            {
                return capitals[name];
            }
        }
    }
}
