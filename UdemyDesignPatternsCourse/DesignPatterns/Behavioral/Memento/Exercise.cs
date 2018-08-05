namespace Memento.Coding.Exercise
{
    using System.Collections.Generic;
    using System.Linq;

    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<int> Value { get; } = new List<int>();

        public Memento(List<int> value)
        {
            this.Value = value;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            return AddToken(new Token(value));
        }

        public Memento AddToken(Token token)
        {
            this.Tokens.Add(token);
            
            return new Memento(this.Tokens.Select(t => t.Value).ToList());
        }

        public void Revert(Memento m)
        {
            this.Tokens = m.Value.Select(v => new Token(v)).ToList();
        }
    }
}
