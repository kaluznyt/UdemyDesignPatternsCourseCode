namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Interpreter
{
    public class Token
    {
        public enum TokenType
        {
            Integer, Plus, Minus, Lparen, Rparen
        }

        public TokenType Type;

        public string Text;

        public Token(TokenType type, string text)
        {
            this.Type = type;
            this.Text = text;
        }

        public override string ToString()
        {
            return $"`{this.Text}`";
        }
    }
}