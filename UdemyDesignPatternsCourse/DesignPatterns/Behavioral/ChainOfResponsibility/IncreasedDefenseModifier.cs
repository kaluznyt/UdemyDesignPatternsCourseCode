namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility
{
    using System;

    public class IncreasedDefenseModifier : CreatureModifier
    {
        public IncreasedDefenseModifier()
        {
            
        }
        public IncreasedDefenseModifier(Creature creature)
            : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {this.creature.Name}'s defense");
            this.creature.Defense += 3;
            base.Handle();
        }
    }
}