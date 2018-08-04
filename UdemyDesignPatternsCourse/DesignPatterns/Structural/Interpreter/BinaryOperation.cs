namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Interpreter
{
    using System;

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition, Subtraction
        }

        public Type OperationType;

        public IElement Left, Right;


        public int Value
        {
            get
            {
                switch (this.OperationType)
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
}