namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }
}