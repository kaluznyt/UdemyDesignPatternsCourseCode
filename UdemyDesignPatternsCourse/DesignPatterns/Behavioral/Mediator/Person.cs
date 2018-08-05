namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public string Name;

        public ChatRoom Room;

        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            this.Name = name;
        }

        public void Say(string message)
        {
            this.Room.Broadcast(this.Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            this.Room.Message(this.Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            var s = $"{sender}: '{message}'";
            this.chatLog.Add(s);
            Console.WriteLine($"[{this.Name}'s chat session] {s}");
        }
    }
}