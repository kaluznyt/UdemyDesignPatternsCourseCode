namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Text;

    using ImpromptuInterface;

    public class Log<T> : DynamicObject where T : class, new()
    {
        private readonly T subject;
        private Dictionary<string, int> methodCallCount = new Dictionary<string, int>();

        protected Log(T subject)
        {
            this.subject = subject;
        }

        public static I As<I>() where I : class

        {
            if (!typeof(I).IsInterface)
                throw new ArgumentException("I must be an interface");

            return new Log<T>(new T()).ActLike<I>();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                Console.WriteLine($"Invoking {this.subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");

                if (this.methodCallCount.ContainsKey(binder.Name))
                    this.methodCallCount[binder.Name]++;
                else
                {
                    this.methodCallCount.Add(binder.Name, 1);
                }

                result = this.subject.GetType().GetMethod(binder.Name).Invoke(this.subject, args);
            }
            catch
            {
                result = null;
                return false;
                throw;
            }

            return true;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var keyValuePair in this.methodCallCount)
                {
                    sb.AppendLine($"{keyValuePair.Key} called {keyValuePair.Value} time(s)");
                }

                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return $"{this.Info}\n{this.subject}";
        }
    }
}