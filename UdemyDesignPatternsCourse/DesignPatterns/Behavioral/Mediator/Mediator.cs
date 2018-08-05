namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    using Autofac;

    using UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Mediator;

    public class Mediator : IDemo
    {
        public void Run()
        {
            FootballTraining();

            //ChatDemo();
        }

        private static void FootballTraining()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<FootballCoach>();
            cb.Register((c, p) => new FootballPlayer(c.Resolve<EventBroker>(), p.Named<string>("name")));

            using (var c = cb.Build())
            {
                var coach = c.Resolve<FootballCoach>();
                var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));
                var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Chris"));

                player1.Score();
                player1.Score();
                player1.Score();
                player1.AssaultReferee();
                player2.Score();
            }
        }

        private static void ChatDemo()
        {
            var room = new ChatRoom();
            var john = new Person("John");
            var jane = new Person("Jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hello");
            jane.Say("oh hey john");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("Simon", "hi simon you....");
        }
    }
}

