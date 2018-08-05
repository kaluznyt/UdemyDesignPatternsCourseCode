namespace UdemyDesignPatternsCourse.DesignPatterns.Structural.Mediator
{
    using System;
    using System.Reactive.Subjects;

    public class EventBroker : IObservable<PlayerEvent>
    {
        Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return this.subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            this.subscriptions.OnNext(pe);
        }
    }
}