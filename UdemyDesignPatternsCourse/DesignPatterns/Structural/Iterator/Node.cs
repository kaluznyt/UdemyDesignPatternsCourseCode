namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Iterator
{
    public class Node<T>
    {
        public T Value;

        public Node<T> Left, Right;

        public Node<T> Parent;

        public Node(T value)
        {
            this.Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;

            if (left != null)
                left.Parent = this;

            if (right != null)
                right.Parent = this;

        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}