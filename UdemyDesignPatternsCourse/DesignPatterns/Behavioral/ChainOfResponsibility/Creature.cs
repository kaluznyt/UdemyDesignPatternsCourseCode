namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class Creature
    {
        public string Name;

        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
        }

        public override string ToString()
        {
            return
                $"{nameof(this.Name)}: {this.Name}, {nameof(this.Attack)}: {this.Attack}, {nameof(this.Defense)}: {this.Defense}";
        }
    }
}