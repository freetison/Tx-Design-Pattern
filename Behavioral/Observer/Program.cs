using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.CompilerServices;
using Observer.Model;
using Observer.Publisher;
using Tx.Core.Extentions;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {

            var stockPublisher = new StockPublisher();

            Assembly.GetExecutingAssembly().GetTypesAssignableFrom<IObserver<Stock>>().ForEach(t =>
            {
                dynamic instance = (IObserver<Stock>) Activator.CreateInstance(t);
                instance?.Subscribe(stockPublisher);
            });


            stockPublisher.Publish(new Stock("usd", 0.0M));
            stockPublisher.Publish(new Stock("usd", 30.2M));
            stockPublisher.Publish(new Stock("usb", 300.0M));
            stockPublisher.Publish(new Stock("usb", -25.0M));

            stockPublisher.UnSubscribe();;

            Console.ReadLine();
        }
    }
}
