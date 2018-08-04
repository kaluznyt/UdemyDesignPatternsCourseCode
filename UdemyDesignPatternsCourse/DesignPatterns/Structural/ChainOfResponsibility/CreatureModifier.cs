namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.ChainOfResponsibility
{
    public class CreatureModifier
    {
        protected Creature creature;

        protected CreatureModifier next; // linked list of modifiers

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public CreatureModifier() { }

        public void Add(CreatureModifier cm)
        {
            cm.creature = this.creature;
            if (this.next != null) this.next.Add(cm);
            else this.next = cm;
        }
        
        public virtual void Handle() => this.next?.Handle();
    }
}