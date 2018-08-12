namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();

        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Markdown:
                    this.listStrategy = new MarkdownListStrategy();
                    break;
                case OutputFormat.Html:
                    this.listStrategy = new HtmlListStrategy();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

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