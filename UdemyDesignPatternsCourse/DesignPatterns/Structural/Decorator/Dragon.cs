using System;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Decorator
{
    public class Dragon : IBird, ILizard
    {
        public static void Demo()
        {
            var d = new Dragon(new Bird(), new Lizard());
            d.Weight = 100;
            d.Fly();
            d.Crawl();
            Console.WriteLine(d.Weight);
        }

        private readonly IBird _bird;
        private readonly ILizard _lizard;
        private int _weight;

        public Dragon(IBird bird, ILizard lizard)
        {
            _bird = bird;
            _lizard = lizard;
        }

        public int Weight
        {
            get => _weight;
            set => this._weight = this._bird.Weight = this._lizard.Weight = value;
        }

        public void Fly()
        {
            _bird.Fly();
        }

        public void Crawl()
        {
            _lizard.Crawl();
        }
    }
}