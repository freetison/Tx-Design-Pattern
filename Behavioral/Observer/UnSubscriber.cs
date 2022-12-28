using System;
using System.Collections.Generic;
using Observer.Model;

namespace Observer
{
    public class UnSubscriber : IDisposable
    {
        private readonly IList<IObserver<Stock>> _observers;
        private readonly IObserver<Stock> _observer;
        private bool _disposed;

        public UnSubscriber(IList<IObserver<Stock>> observers, IObserver<Stock> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_observer != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
            _disposed = true;
        }
    }
}