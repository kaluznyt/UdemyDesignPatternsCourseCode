namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Iterator
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Creature : IEnumerable<int>
    {
        private readonly int[] stats = new int[3];

        private const int strength = 0;
        public int Strength
        {
            get => this.stats[strength];
            set => this.stats[strength] = value;
        }

        public int Agility { get; set; }
        public int Intelligence { get; set; }

        public double AvgStat => this.stats.Average();

        public IEnumerator<int> GetEnumerator()
        {
            return this.stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}