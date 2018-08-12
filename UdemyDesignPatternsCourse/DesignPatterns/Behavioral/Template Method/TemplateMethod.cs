namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Template_Method
{
    using System;

    public class TemplateMethod : IDemo
    {
        public void Run()
        {
            var chess = new Chess();
            chess.Run();
        }
    }
}
