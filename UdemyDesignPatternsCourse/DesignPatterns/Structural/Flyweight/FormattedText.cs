using System.Text;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Flyweight
{
    public class FormattedText
    {
        private string _plainText;
        private bool[] capitalize;

        public FormattedText(string plainText)
        {
            this._plainText = plainText;
            capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i <= end; i++)
                capitalize[i] = true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var index = 0; index < _plainText.Length; index++)
            {
                var c = _plainText[index];
                sb.Append(capitalize[index] ? char.ToUpper(c) : c);
            }

            return sb.ToString();
        }
    }
}