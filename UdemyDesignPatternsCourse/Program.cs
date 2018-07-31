﻿using UdemyDesignPatternsCourse.DesignPatterns.Creational.Builder;
using UdemyDesignPatternsCourse.DesignPatterns.Creational.Factories;
using UdemyDesignPatternsCourse.DesignPatterns.Creational.Prototype;
using UdemyDesignPatternsCourse.DesignPatterns.Creational.Singleton;
using UdemyDesignPatternsCourse.DesignPatterns.Structural.Adapter;
using UdemyDesignPatternsCourse.DesignPatterns.Structural.Bridge;
using UdemyDesignPatternsCourse.DesignPatterns.Structural.Composite;
using UdemyDesignPatternsCourse.SOLID.DependencyInversionPrinciple;
using UdemyDesignPatternsCourse.SOLID.InterfaceSegregationPrinciple;
using UdemyDesignPatternsCourse.SOLID.LiskovSubstitutionPrinciple;
using UdemyDesignPatternsCourse.SOLID.OpenClosedPrinciple;
using UdemyDesignPatternsCourse.SOLID.SingleResponsibilityPrinciple;

namespace UdemyDesignPatternsCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solid();
            DesignPatterns();
        }

        private static void DesignPatterns()
        {
            //Creational();
            Structural();
        }

        private static void Creational()
        {
            //new Builder().Run();
            //new Factories().Run();
            //new Prototype().Run();
            new Singleton().Run();
        }

        private static void Structural()
        {
            //new Adapter().Run();
            //new Bridge().Run();
            new Composite().Run();
        }

        static void Solid()
        {
            new SingleResponsibilityPrinciple().Run();
            new OpenClosedPrinciple().Run();
            new LiskovSubstitutionPrinciple().Run();
            new InterfaceSegregationPrinciple().Run();
            new DependencyInversionPrinciple().Run();
        }
    }
}
