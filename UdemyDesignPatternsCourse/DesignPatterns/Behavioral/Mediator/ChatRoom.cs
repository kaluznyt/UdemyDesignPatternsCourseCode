namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    using System.Collections.Generic;
    using System.Linq;

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            var joinMsg = $"{p.Name} joins the chat";
            this.Broadcast("room", joinMsg);

            p.Room = this;
            this.people.Add(p);
        }

        public void Broadcast(string source, string msg)
        {
            foreach (var person in this.people)
            {
                if (person.Name != source)
                {
                    person.Receive(source, msg);
                }
            }
        }

        public void Message(string source, string destination, string message)
        {
            this.people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }
}