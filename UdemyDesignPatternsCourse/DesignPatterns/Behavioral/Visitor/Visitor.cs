namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Visitor
{
    using System;
    using System.Text;

    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);
    }

    public interface IVisitor
    {

    }

    public abstract class Expresssion
    {
        public virtual void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<Expresssion> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class DoubleExpresssion : Expresssion
    {
        public double Value;

        public DoubleExpresssion(double value)
        {
            this.Value = value;
        }

        public override void Accept(IVisitor ev)
        {
            if (ev is IVisitor<DoubleExpresssion> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class AdditionExpresssion : Expresssion
    {
        public Expresssion Left, Right;

        public AdditionExpresssion(Expresssion right, Expresssion left)
        {
            this.Right = right;
            this.Left = left;
        }

        public override void Accept(IVisitor ev)
        {
            if (ev is IVisitor<AdditionExpresssion> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class ExpresssionPrinter : IVisitor,
                                      IVisitor<Expresssion>,
                                      IVisitor<DoubleExpresssion>,
                                      IVisitor<AdditionExpresssion>
    {
        private StringBuilder sb = new StringBuilder();
        public void Visit(Expresssion obj)
        {
            
        }

        public void Visit(DoubleExpresssion obj)
        {
            this.sb.Append(obj.Value);
        }

        public void Visit(AdditionExpresssion obj)
        {
            this.sb.Append("(");
            obj.Left.Accept(this);
            this.sb.Append("+");
            obj.Right.Accept(this);
            this.sb.Append(")");
        }

        public override string ToString()
        {
            return this.sb.ToString();
        }
    }

    public class Visitor : IDemo
    {
        public void Run()
        {
            var e = new AdditionExpresssion(
                new DoubleExpresssion(1),
                new AdditionExpresssion(
                    new DoubleExpresssion(2),
                    new DoubleExpresssion(3)
                    ));

            //ClassicVisitor(e);

            var acyclic = new ExpresssionPrinter();
            acyclic.Visit(e);

            Console.WriteLine(acyclic);
        }

        private static void ClassicVisitor(AdditionExpression e)
        {
            var ev = new ExpressionPrinter();
            ev.Visit(e);

            Console.WriteLine(ev);

            var ec = new ExpressionCalculator();
            ec.Visit(e);

            Console.WriteLine(ec.Result);
        }
    }
}
