using System;

namespace Coding.Exercise
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                IEnumerable<T> Traverse(Node<T> node)
                {
                    yield return node.Value;

                    if (node.Left != null)
                        foreach (var left in Traverse(node.Left))
                            yield return left;

                    if (node.Right != null)
                        foreach (var right in Traverse(node.Right))
                            yield return right;
                }

                foreach (var s in Traverse(this))
                {
                    yield return s;
                }

            }
        }
    }
}
