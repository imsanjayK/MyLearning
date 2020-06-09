using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpe8
{
    class DefaultInterfaceMethods
    {
        public DefaultInterfaceMethods()
        {
            Console.WriteLine("======================[ START ]=========================");
            RunSample();
            Console.WriteLine("=======================[ END ]==========================");
        }

        private void RunSample()
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31))
            {
                Reminders =
                {
                    { new DateTime(2010, 08, 12), "childs's birthday" },
                    { new DateTime(1012, 11, 15), "anniversary" }
                }
             };

            SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            c.AddOrder(o);

            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            
            foreach (var item in c.Reminders)
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            
            foreach (IOrder order in c.PreviousOrders)
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");
        }
    }


    // <SnippetICustomerVersion1>
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }
        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        IDictionary<DateTime, string> Reminders { get; }
    }
    // <SnippetICustomerVersion1>

    public interface IOrder
    {
       DateTime Purchased { get; }
       decimal Cost { get; }
    }

    class SampleCustomer : ICustomer
    {
        public SampleCustomer(string name, DateTime dateJoined) =>
             (Name, DateJoined) = (name, dateJoined);

        private List<IOrder> allOrders = new List<IOrder>();

        public IEnumerable<IOrder> PreviousOrders => allOrders;

        public DateTime DateJoined { get; }

        public DateTime? LastOrder { get; private set; }

        public string Name { get; }

        private Dictionary<DateTime, string> reminders = new Dictionary<DateTime, string>();
        public IDictionary<DateTime, string> Reminders => reminders;

        public void AddOrder(IOrder order)
        {
            if (order.Purchased > (LastOrder ?? DateTime.MinValue))
                LastOrder = order.Purchased;
            allOrders.Add(order);
        }
    }
    class SampleOrder : IOrder
    {
        public SampleOrder(DateTime purchase, decimal cost) =>
            (Purchased, Cost) = (purchase, cost);

        public DateTime Purchased { get; }

        public decimal Cost { get; }
    }
}