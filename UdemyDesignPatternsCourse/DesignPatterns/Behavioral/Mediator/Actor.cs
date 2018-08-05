using System.Collections.Generic;

namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    using System;
    using System.Reactive.Linq;

    public class Actor
    {
        protected EventBroker broker;

        protected List<IDisposable> subscriptions = new List<IDisposable>();

        public Actor(EventBroker broker)
        {
            this.broker = broker;
        }

        public void Unsubscribe()
        {
            this.subscriptions.ForEach(s => s.Dispose());
        }

        protected void Subscribe<T>(string name, Action<T> action) where T : PlayerEvent
        {
            this.subscriptions.Add(
                    broker.OfType<T>()
                    .Subscribe(action));
        }
    }
}