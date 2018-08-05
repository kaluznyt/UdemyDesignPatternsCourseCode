namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier()
        {
            
        }
        public NoBonusesModifier(Creature creature)
            : base(creature) { }

        public override void Handle() { }

    }
}