namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Mediator
{
    using System.Collections.Generic;

    public class Participant
    {
        private readonly Mediator mediator;

        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            this.mediator.AddMe(this);
        }

        public void Say(int n)
        {
            this.mediator.Saying = this;
            this.mediator.Say(n);
        }
    }

    public class Mediator
    {
        private List<Participant> participants = new List<Participant>();

        public Participant Saying;

        public void AddMe(Participant participant)
        {
            this.participants.Add(participant);
        }

        public void Say(int n)
        {
            this.participants.ForEach(p => p.Value += p != this.Saying ? n : 0);
        }
    }
}
