namespace UdemyDesignPatternsCourse.DesignPatterns.Behavioral.Observer
{
    using System;
    using System.ComponentModel;

    using Coding.Exercise;

    public class ProperMarket
    {
        public BindingList<float> Prices = new BindingList<float>();

        //public void AddPrice(float price)
        //{
        //    this.prices.Add(price);
        //    //PriceAdded?.Invoke(this, price);
        //}

        //public event EventHandler<float> PriceAdded;
    }

    public class Observer : IDemo
    {
        public void Run()
        {
            //this.EventBasedDemo();

            //this.WeakEventManagerDemo();

            //this.INotifyPropertyChangedDemo();

            // BindingListDemo();

            var game = new Game();

            var rat = new Rat(game);
            var rat2 = new Rat(game);
            var rat3 = new Rat(game);

            //rat.Dispose();
            //rat2.Dispose();
            //rat3.Dispose();

            Console.WriteLine($"Attack: {rat.Attack}");
            Console.WriteLine($"Attack: {rat2.Attack}");
            Console.WriteLine($"Attack: {rat3.Attack}");
        }

        private static void BindingListDemo()
        {
            var market = new ProperMarket();
            //market.PriceAdded += (sender, f) =>
            //    {
            //        Console.WriteLine($"We got a price of {f}");
            //    };

            //market.AddPrice(12);

            market.Prices.ListChanged += (sender, args) =>
                {
                    if (args.ListChangedType == ListChangedType.ItemAdded)
                    {
                        var price = ((BindingList<float>)sender)[args.NewIndex];
                        Console.WriteLine($"Price added {price}");
                    }
                };

            market.Prices.Add(123);
        }

        private void INotifyPropertyChangedDemo()
        {
            var market = new Market();
            market.PropertyChanged += this.Market_PropertyChanged;
        }

        private void Market_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Volatility")
            {
                Console.WriteLine("Volatility changed");
            }
        }

        private void WeakEventManagerDemo()
        {
            var button = new Button();
            var window = new Window(button);
            var windowRef = new WeakReference(window);
            button.Fire();

            window = null;

            this.FireGC();
            Console.WriteLine($"Is the window alive after GC? {windowRef.IsAlive}");
        }

        private void FireGC()
        {
            Console.WriteLine("GC Start");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC end");
        }

        private void EventBasedDemo()
        {
            var person = new Person();

            person.FallsIll += this.CallDoctor;

            person.CatchACold();

            person.FallsIll -= this.CallDoctor;
        }

        private void CallDoctor(object sender, EventArgs e)
        {
            Console.WriteLine("Call Doctor!");
        }
    }
}
