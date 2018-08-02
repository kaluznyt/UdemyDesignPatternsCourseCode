using System.Collections.Generic;
using System.Text;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    public class BetterFormattedText
    {
        private string _plainText;
        private List<TextRange> formatting = new List<TextRange>();

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }

        public TextRange GetRange(int start, int end)
        {
            var range = new TextRange { Start = start, End = end };
            formatting.Add(range);
            return range;
        }


        public BetterFormattedText(string plainText)
        {
            this._plainText = plainText;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _plainText.Length; i++)
            {
                var c = _plainText[i];

                foreach (var textRange in formatting)
                {
                    if (textRange.Covers(i) && textRange.Capitalize)
                    {
                        c = char.ToUpper(c);
                    }
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}