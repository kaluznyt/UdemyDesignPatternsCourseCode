using System;

namespace Coding.Exercise2
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value value);
        public abstract void Visit(AdditionExpression value);
        public abstract void Visit(MultiplicationExpression value);
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }

        public override string ToString()
        {
            return this.TheValue.ToString();
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        // todo
        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }

        public override string ToString()
        {
            return $"({this.LHS}+{this.RHS})";
        }
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        // todo
        public override void Accept(ExpressionVisitor ev)
        {
            ev.Visit(this);
        }

        public override string ToString()
        {
            return $"{this.LHS}*{this.RHS}";
        }
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private string Expression { get; set; }
        public override void Visit(Value value)
        {
            Expression = value.ToString();
        }

        public override void Visit(AdditionExpression ae)
        {
            Expression = ae.ToString();
        }

        public override void Visit(MultiplicationExpression me)
        {
            Expression = me.ToString();
        }

        public override string ToString()
        {
            return Expression;
        }
    }
}