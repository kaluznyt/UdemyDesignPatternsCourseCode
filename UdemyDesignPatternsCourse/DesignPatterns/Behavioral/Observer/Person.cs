namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer
{
    using System;

    public class Person
    {
        public event EventHandler<EventArgs> FallsIll;

        public void CatchACold()
        {
            this.FallsIll?.Invoke(this, new EventArgs());
        }
    }
}