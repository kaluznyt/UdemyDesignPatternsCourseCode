using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{

    public interface IExpression
    {
        int Value { get; }
    }

    public class Integer : IExpression
    {
        public int Value { get; set; }
    }
    public class Expression : IExpression
    {
        public IExpression Left;

        public IExpression Right;

        public enum Type
        {
            Addition, Subtraction
        }

        public Type Operation;

        public int Value
        {
            get
            {
                switch (Operation)
                {
                    case Type.Addition:
                        return this.Left.Value + this.Right.Value;
                        break;
                    case Type.Subtraction:
                        return this.Left.Value - this.Right.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            var tokens = Lex(expression);

            if (tokens == null)
            {
                return 0;
            }

            var result = Parse(tokens);

            return result.Value;

        }

        private IExpression Parse(List<Token> tokens)
        {
            var expression = new Expression();

            for (var index = 0; index < tokens.Count; index++)
            {
                var token = tokens[index];

                switch (token.Type)
                {
                    case Token.TokenType.Integer:
                        if (expression.Left == null)
                        {
                            expression.Left = new Integer { Value = int.Parse(token.Text) };
                        }
                        else if (expression.Right == null)
                        {
                            expression.Right = new Integer { Value = int.Parse(token.Text) };
                        }
                        else
                        {
                            var subExpression = new Expression();
                            subExpression.Left = expression;
                            subExpression.Right = new Integer { Value = int.Parse(token.Text) };
                            expression = subExpression;
                        }
                        break;
                    case Token.TokenType.Plus:
                        expression.Operation = Expression.Type.Addition;
                        break;
                    case Token.TokenType.Minus:
                        expression.Operation = Expression.Type.Subtraction;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return expression.Right != null ? expression : new Integer { Value = expression.Left.Value } as IExpression;
        }

        private List<Token> Lex(string expression)
        {
            var tokens = new List<Token>();

            for (var i = 0; i < expression.Length; i++)
            {
                var c = expression[i];

                switch (c)
                {
                    case '+':
                        tokens.Add(new Token
                        {
                            Text = "+",
                            Type = Token.TokenType.Plus
                        });
                        break;
                    case '-':
                        tokens.Add(new Token
                        {
                            Text = "-",
                            Type = Token.TokenType.Minus
                        });
                        break;
                    default:
                        if (char.IsLetter(c))
                        {
                            if (this.Variables.ContainsKey(c))
                                tokens.Add(new Token
                                {
                                    Text = this.Variables[c].ToString(),
                                    Type = Token.TokenType.Integer
                                });

                            if (!this.Variables.ContainsKey(c) || (expression.Length > i + 1 && char.IsLetter(expression[i + 1])))
                            {
                                return null;
                            }
                        }
                        else if (char.IsDigit(c))
                        {
                            var sb = new StringBuilder(c.ToString());

                            var j = i + 1;

                            for (; j < expression.Length; ++j)
                            {
                                var nextChar = expression[j];
                                if (char.IsDigit(nextChar))
                                    sb.Append(c.ToString());
                                else
                                    break;
                            }

                            tokens.Add(
                                new Token
                                {
                                    Text = sb.ToString(),
                                    Type = Token.TokenType.Integer
                                });

                        }
                        break;
                }
            }

            return tokens;
        }
    }

    internal class Token
    {
        public enum TokenType
        {
            Integer, Plus, Minus
        }
        public string Text { get; set; }

        public Token.TokenType Type { get; set; }
    }
}