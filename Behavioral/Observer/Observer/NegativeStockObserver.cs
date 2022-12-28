using System;
using System.Runtime.InteropServices;
using System.Xml;
using Observer.Model;

namespace Observer.Observer
{
    public class NegativeStockObserver : IObserver<Stock>
    {
        private IDisposable _unSubscriber;
        public virtual void Subscribe(IObservable<Stock> provider)
        {
            if (provider != null) _unSubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted() => _unSubscriber.Dispose();

        public virtual void OnError(Exception e) => Console.WriteLine(e.Message);

        public virtual void OnNext(Stock stock)
        {
            if (stock is { Price: < 0 }) Console.WriteLine($"{GetType().Name} is Processing {stock.Price} ");
        }
    }
}