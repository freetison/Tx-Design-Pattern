using System;
using System.Collections.Generic;
using System.Linq;
using Observer.Model;

namespace Observer.Publisher
{
    public class StockPublisher : IObservable<Stock>
    {
        private readonly IList<IObserver<Stock>> _observers;

        public StockPublisher()
        {
            _observers = new List<IObserver<Stock>>();
        }

        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
            return new UnSubscriber(_observers, observer);
        }


        public void Publish(Stock stock)
        {
            foreach (var observer in _observers)
            {
                if (stock == null)
                {
                    observer.OnError(new ArgumentNullException());
                }
                observer.OnNext(stock);
            }
        }
        public void UnSubscribe()
        {
            foreach (var observer in _observers.ToArray())
            {
                observer.OnCompleted();
            }
            _observers.Clear();
        }
    }
}