namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }

        public string Name { get; set; }
    }
}