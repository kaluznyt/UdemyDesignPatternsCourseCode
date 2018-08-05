namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Mediator
{
    using System;

    using UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator;

    public class FootballPlayer : Actor
    {
        public string Name { get; set; }

        public int GoalsScored { get; set; } = 0;

        public FootballPlayer(EventBroker broker, string name)
            : base(broker)
        {
            this.Name = name;

            this.Subscribe<PlayerScoredEvent>(name, ps =>
                {
                    if (!ps.Name.Equals(name))
                        Console.WriteLine(
                            $"{name}: Nicely done, {ps.Name}! It's your {ps.GoalsScored} goal!");
                });

            this.Subscribe<PlayerScoredEvent>(name, ps =>
                {
                    if (ps.Name == name)
                    {
                        this.Unsubscribe();
                    }
                    else
                    {
                        Console.WriteLine($"{name}: See you in the lockers, {ps.Name}");
                    }
                });
        }

        public void Score()
        {
            this.GoalsScored++;
            this.broker.Publish(new PlayerScoredEvent { Name = this.Name, GoalsScored = this.GoalsScored });
        }

        public void AssaultReferee()
        {
            this.broker.Publish(new PlayerSentOffEvent { Name = this.Name, Reason = "violence" });
        }
    }
}