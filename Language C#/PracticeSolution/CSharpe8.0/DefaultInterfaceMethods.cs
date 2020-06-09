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
            
            // <SnippetHighlightCast>
            // Check the discount:
            ICustomer theCustomer = c;
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
            // </SnippetHighlightCast>
            // </SnippetTestDefaultImplementation>

            // Add more orders to get the discount:
            DateTime recurring = new DateTime(2013, 3, 15);
            for (int i = 0; i < 15; i++)
            {
                o = new SampleOrder(recurring, 19.23m * i);
                c.AddOrder(o);

                recurring.AddMonths(2);
            }
            
            Console.WriteLine($"Data about {c.Name}");
            Console.WriteLine($"Joined on {c.DateJoined}. Made {c.PreviousOrders.Count()} orders, the last on {c.LastOrder}");
            Console.WriteLine("Reminders:");
            
            foreach (var item in c.Reminders)
                Console.WriteLine($"\t{item.Value} on {item.Key}");
            
            foreach (IOrder order in c.PreviousOrders)
                Console.WriteLine($"Order on {order.Purchased} for {order.Cost}");

            //
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");

            // <SnippetSetLoyaltyThresholds>
            ICustomer.SetLoyaltyThresholds(new TimeSpan(30, 0, 0, 0), 1, 0.25m);
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
            // </SnippetSetLoyaltyThresholds>
        }
    }


    // <SnippetICustomerVersion1>
    public interface ICustomer
    {
        IEnumerable<IOrder> PreviousOrders { get; }
        DateTime DateJoined { get; }
        DateTime? LastOrder { get; }
        IDictionary<DateTime, string> Reminders { get; }

       
        string Name { get; }
       

        /*
        // <SnippetLoyaltyDiscountVersionOne>
        // Version 1:
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
            if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
            {
                return 0.10m;
            }
            return 0;
        }
        // </SnippetLoyaltyDiscountVersionOne>
        */

        /*
        // <SnippetLoyaltyDiscountVersionTwo>
        // Version 2:
        public static void SetLoyaltyThresholds(
            TimeSpan ago,
            int minimumOrders = 10,
            decimal percentageDiscount = 0.10m)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentageDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0,0,0); // two years
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime start = DateTime.Now - length;
            if ((DateJoined < start) && (PreviousOrders.Count() > orderCount))
            {
                return discountPercent;
            }
            return 0;
        }
        // </SnippetLoyaltyDiscountVersionTwo>
        */

        // Version 3:
        public static void SetLoyaltyThresholds(TimeSpan ago, int minimumOrders, decimal percentageDiscount)
        {
            length = ago;
            orderCount = minimumOrders;
            discountPercent = percentageDiscount;
        }
        private static TimeSpan length = new TimeSpan(365 * 2, 0, 0, 0); // two years
        private static int orderCount = 10;
        private static decimal discountPercent = 0.10m;

        // <SnippetFinalVersion>
        public decimal ComputeLoyaltyDiscount() => DefaultLoyaltyDiscount(this);
        protected static decimal DefaultLoyaltyDiscount(ICustomer c)
        {
            DateTime start = DateTime.Now - length;

            if ((c.DateJoined < start) && (c.PreviousOrders.Count() > orderCount))
            {
                return discountPercent;
            }
            return 0;
        }
        // </SnippetFinalVersion>

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

        // <SnippetOverrideAndExtend>
        public decimal ComputeLoyaltyDiscount()
        {
            if (PreviousOrders.Any() == false)
                return 0.50m;
            else
                return ICustomer.DefaultLoyaltyDiscount(this);
        }
        // </SnippetOverrideAndExtend>

        
       
    }
    class SampleOrder : IOrder
    {
        public SampleOrder(DateTime purchase, decimal cost) =>
            (Purchased, Cost) = (purchase, cost);

        public DateTime Purchased { get; }

        public decimal Cost { get; }
    }
}