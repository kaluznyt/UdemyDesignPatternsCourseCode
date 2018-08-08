namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer
{
    using System;
    using System.Windows;

    public class Window
    {
        public Window(Button button)
        {
            //   button.Clicked += ButtonOnClicked;
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", this.ButtonOnClicked);
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (window handler)");
        }
    }
}