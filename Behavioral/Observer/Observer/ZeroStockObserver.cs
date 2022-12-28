using System;
using Observer.Model;

namespace Observer.Observer
{
    public class ZeroStockObserver : IObserver<Stock>
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
            if (stock is { Price: 0M }) Console.WriteLine($"{GetType().Name} is Processing {stock.Price} ");
        }
    }
}