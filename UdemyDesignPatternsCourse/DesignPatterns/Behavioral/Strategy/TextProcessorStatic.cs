namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Strategy
{
    using System.Collections.Generic;
    using System.Text;

    public class TextProcessorStatic<LS> where LS : IListStrategy, new()
    {
        private StringBuilder sb = new StringBuilder();

        private readonly IListStrategy listStrategy = new LS();

        public void AppendList(IEnumerable<string> items)
        {
            this.listStrategy.Start(this.sb);
            foreach (var item in items)
            {
                this.listStrategy.AddListItem(this.sb, item);
            }
            this.listStrategy.End(this.sb);
        }

        public StringBuilder Clear()
        {
            return this.sb.Clear();
        }

        public override string ToString()
        {
            return this.sb.ToString();
        }
    }
}