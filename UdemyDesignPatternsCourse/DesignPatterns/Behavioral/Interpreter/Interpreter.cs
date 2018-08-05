namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Coding.Exercise;

    public class Interpreter : IDemo
    {
        public void Run()
        {
            //this.SimpleInterpreter();
            var processor = new ExpressionProcessor();
            processor.Variables.Add('x', 123);
            Console.WriteLine($"{"1+2+x"} {processor.Calculate("1+2+x")}");

            Console.WriteLine($"{"1+2+xx"} {processor.Calculate("1+2+xx")}");

            Console.WriteLine($"{"1+2+3+4"} {processor.Calculate("1+2+3+4")}");

            Console.WriteLine($"{"1"} {processor.Calculate("1")}");
        }

        private void SimpleInterpreter()
        {
            string input = "1+(133+4)-(12+1)+999-(1+2+(3+4)-2+34)";

            var tokens = this.Lex(input);

            Console.WriteLine(string.Join("\t", tokens));

            var parsed = this.Parse(tokens);
            Console.WriteLine($"{input} = {parsed.Value}");
        }

        IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();

            bool haveLHS = false;

            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.Type)
                {
                    case Token.TokenType.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (result.Left == null)
                            result.Left = integer;
                        else
                            result.Right = integer;
                        break;
                    case Token.TokenType.Plus:
                        result.OperationType = BinaryOperation.Type.Addition;
                        break;
                    case Token.TokenType.Minus:
                        result.OperationType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.TokenType.Lparen:
                        int j = i;
                        for (; i < tokens.Count; ++j)
                        {
                            if (tokens[j].Type == Token.TokenType.Rparen)
                                break;
                        }

                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();

                        var element = Parse(subexpression);

                        if (result.Left == null)
                            result.Left = element;
                        else
                            result.Right = element;
                        
                        i = j;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }

        List<Token> Lex(string input)
        {
            var result = new List<Token>();

            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];

                switch (character)
                {
                    case '+':
                        result.Add(new Token(Token.TokenType.Plus, "+"));
                    break;
                    case '-':
                        result.Add(new Token(Token.TokenType.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.TokenType.Lparen, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.TokenType.Rparen, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(character.ToString());

                        for (var j = i + 1; j < input.Length; ++j)
                        {
                            if (!char.IsDigit(input[j])) break;

                            sb.Append(input[j].ToString());
                            ++i;
                        }

                        result.Add(new Token(Token.TokenType.Integer, sb.ToString()));
                        break;
                }
            }

            return result;
        }
    }
}
