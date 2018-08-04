namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.ChainOfResponsibility
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