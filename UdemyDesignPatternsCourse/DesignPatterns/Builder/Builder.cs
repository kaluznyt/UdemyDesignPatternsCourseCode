using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UdemyDesignPatternsCourse.DesignPatterns.Builder
{
    public class Builder : IDemo
    {
        public void Run()
        {
            //HtmlBuilderDemo();

            //FluentDerivedBuilderDemo();

            //FacetedBuilderDemo();

            Exercise();
        }

        private static void Exercise()
        {
            var cb = new CodeBuilder("Person")
                    .AddField("Name", "string")
                    .AddField("Age", "int");

            WriteLine(cb);
        }

        private static void FacetedBuilderDemo()
        {
            var pb = new FacetedBuilder.PersonBuilder();

            FacetedBuilder.Person person = pb.Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earing(123000)
                .Lives
                .At("King Street")
                .In("New York")
                .WithPostcode("XXXXXX");

            WriteLine(person);
        }

        private static void FluentDerivedBuilderDemo()
        {
            var me = Person
                .NewBuilder
                .Called("tomasz")
                .WorksAsA("software dev")
                .Build();

            WriteLine(me);
        }

        private static void HtmlBuilderDemo()
        {
            var hello = "hello";

            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }

            sb.Append("</ul>");
            WriteLine(sb);


            var builder = new HtmlBuilder("ul")
                .AddChild("li", "hello")
                .AddChild("li", "world");
            WriteLine(builder);
        }
    }

    
}
