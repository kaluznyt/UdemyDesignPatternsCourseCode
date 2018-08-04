namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Iterator
{
    public class InOrderIterator<T>
    {
        private readonly Node<T> root;

        public Node<T> Current { get; set; }

        private bool yieldedStart;

        public InOrderIterator(Node<T> root)
        {
            this.root = root;

            this.Reset();

        }
        public bool MoveNext()
        {
            if (!this.yieldedStart)
            {
                this.yieldedStart = true;
                return true;
            }

            if (this.Current.Right != null)
            {
                this.Current = this.Current.Right;
                while (this.Current.Left != null)
                {
                    this.Current = this.Current.Left;
                }
                return true;
            }
            else
            {
                var p = this.Current.Parent;
                while (p != null && this.Current == p.Right)
                {
                    this.Current = p;
                    p = p.Parent;
                }

                this.Current = p;
                return this.Current != null;
            }
        }

        public void Reset()
        {
            this.yieldedStart = false;
            this.Current = this.root;

            while (this.Current.Left != null)
            {
                this.Current = this.Current.Left;
            }
        }
    }
}