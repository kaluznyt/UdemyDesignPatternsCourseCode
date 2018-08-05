namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility
{
    using System;

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier() { }
        public DoubleAttackModifier(Creature creature)
            : base(creature)
        {
        }

        public override void Handle() // This modifies an object state therefore is not good 
        {
            Console.WriteLine($"Doubling {this.creature.Name}'s attack");
            this.creature.Attack *= 2;
            base.Handle();
        }
    }
}