namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer
{
    using System;

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            this.Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}