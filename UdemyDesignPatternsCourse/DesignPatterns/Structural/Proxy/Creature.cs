namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => this.agility.Value;
            set => this.agility.Value = value;
        }
    }
}