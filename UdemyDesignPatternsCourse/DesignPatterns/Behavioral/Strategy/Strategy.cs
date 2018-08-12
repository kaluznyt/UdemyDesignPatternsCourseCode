namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Strategy
{
    using System;

    using Coding.Exercise;

    public class Strategy : IDemo
    {
        public void Run()
        {
            //DynamicStrategyDemo();

            //var tp = new TextProcessorStatic<HtmlListStrategy>();
            //tp.AppendList(new[] { "foo", "bar", "baz" });
            //Console.WriteLine(tp);

            var solver = new QuadraticEquationSolver(new RealDiscriminantStrategy());

            var solution = solver.Solve(1, 4, 5);

            var solution2 = solver.Solve(1, 10, 16);





        }

        private static void DynamicStrategyDemo()
        {
            var tp = new TextProcessor();
            tp.SetOutputFormat(OutputFormat.Markdown);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);

            tp.Clear();
            tp.SetOutputFormat(OutputFormat.Html);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);
        }
    }
}
