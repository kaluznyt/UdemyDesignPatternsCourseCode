using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype.CopyThroughSerialization;
using Address = UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype.ICloneableIsNotTheWayToGoMainlyBecauseItDoesntSpecifyIfItsShallowOrDeepCloneAndItIsNotGeneric.Address;
using Person = UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype.ICloneableIsNotTheWayToGoMainlyBecauseItDoesntSpecifyIfItsShallowOrDeepCloneAndItIsNotGeneric.Person;

namespace UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype
{
    public class Prototype : IDemo
    {
        public void Run()
        {
            //ICloneable();

            //CopyConstructors();

            //DeepCopy();

            CopyThroughSerialization();
        }

        private void CopyThroughSerialization()
        {
            var john = new CopyThroughSerialization.Person(new[] { "John", "Smith" },
                new CopyThroughSerialization.Address("London Road", 123));

            //var jane = john.DeepCopy();
            //var jane = john.DeepCopyThroughJsonSerializer();
            var jane = john.DeepCopyThroughXmlSerializer();

            jane.Names = new[] { "Jane", "Doe" };

            jane.Address.HouseNumber = 543;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        private static void DeepCopy()
        {
            var john = new DeepCopySpecificInterface.Person(new[] { "John", "Smith" },
                new DeepCopySpecificInterface.Address("London Road", 123));

            var jane = john.DeepCopy();

            jane.Address.HouseNumber = 543;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }

        private static void CopyConstructors()
        {
            var john = new CopyConstructors.Person(new[] { "John", "Smith" },
                new CopyConstructors.Address("London Road", 123));

            var jane2 = new CopyConstructors.Person(john) { Address = { HouseNumber = 1234 } };

            Console.WriteLine(john);
            Console.WriteLine(jane2);
        }

        private static void ICloneable()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = john.Clone() as Person;
            jane.Address.HouseNumber = 321;

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }

    namespace CopyThroughSerialization
    {
        public static class ExtensionMethods
        {
            public static T DeepCopy<T>(this T self)
            {
                var stream = new MemoryStream();
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);

                stream.Seek(0, SeekOrigin.Begin);

                object copy = formatter.Deserialize(stream);
                stream.Close();

                return (T)copy;
            }

            public static T DeepCopyThroughJsonSerializer<T>(this T self)
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(self));
            }

            public static T DeepCopyThroughXmlSerializer<T>(this T self)
            {
                using (var ms = new MemoryStream())
                {
                    var xml = new XmlSerializer(typeof(T));
                    xml.Serialize(ms, self);
                    ms.Position = 0;
                    return (T)xml.Deserialize(ms);
                }
            }
        }

        public class Person
        {
            public Person()
            {

            }
            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public string[] Names;
            public Address Address;
            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }
        }

        public class Address
        {
            public Address()
            {

            }
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public string StreetName;
            public int HouseNumber;

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
    }

    namespace DeepCopySpecificInterface
    {
        public interface IPrototype<T>
        {
            T DeepCopy();
        }

        public class Person : IPrototype<Person>
        {
            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public string[] Names;
            public Address Address;
            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }

            public Person DeepCopy()
            {
                return new Person(Names, Address.DeepCopy());
            }
        }

        public class Address : IPrototype<Address>
        {
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public string StreetName;
            public int HouseNumber;

            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
    }

    namespace CopyConstructors
    {
        public class Person
        {
            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public Person(Person other)
            {
                Names = other.Names;
                Address = new Address(other.Address);
            }

            public string[] Names;
            public Address Address;

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }
        }

        public class Address
        {
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public string StreetName;
            public int HouseNumber;

            public Address(Address otherAddress)
            {
                StreetName = otherAddress.StreetName;
                HouseNumber = otherAddress.HouseNumber;

            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }
    }

    namespace ICloneableIsNotTheWayToGoMainlyBecauseItDoesntSpecifyIfItsShallowOrDeepCloneAndItIsNotGeneric
    {
        public class Person : ICloneable
        {
            public Person(string[] names, Address address)
            {
                Names = names;
                Address = address;
            }

            public string[] Names;
            public Address Address;

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }

            public object Clone()
            {
                return new Person(Names, (Address)Address.Clone());
            }
        }

        public class Address : ICloneable
        {
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public string StreetName;
            public int HouseNumber;

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }

            public object Clone()
            {
                return new Address(StreetName, HouseNumber);
            }
        }
    }
}
