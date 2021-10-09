using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Library: CafeLib
// Author: Zachary Erickson
// Purpose: Problem Set 16
namespace CafeLib
{

    // Interface: IMood
    // [+IMood | +Mood:string:r]
    public interface IMood
    {       
        string Mood {get;}
    }

    // Interface: ITakeOrder
    // [+ITakeOrder| +TakeOrder():void]
    public interface ITakeOrder
    {
        void TakeOrder();
    }

    // Class: HotDrink
    // [+A:HotDrink | +instant:bool; +milk:bool; -sugar:byte; +size:string; +customer:Customer
    // | +AddSugar(amount:byte):v; +Steam():a | (); (brand:string)]
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {
            Console.WriteLine("Adding sugar");
        }

        public abstract void Steam();
        

        public HotDrink() { }
        public HotDrink(string brand)
        {

        }
    }

    // Class: Waiter
    // [+Waiter | +name:string | +Mood:string:r; +ServeCustomer(cup:HotDrink):void]
    public class Waiter:IMood
    {
        public string name;

        public string Mood { get; }

        public void ServeCustomer(HotDrink cup) 
        {
            Console.WriteLine("Here's your order!");
        }
       
    }

    // Class: Customer
    // [+Customer | +name:string; +creditCardNumber:string | +Mood:string:r]
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood { get; }
    }

    // Class: CupOfCoffee
    // [+CupOfCoffee | +beanType:string | +Steam():o; +TakeOrder() | +(brand:string):base(brand)]
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam()
        {
            Console.WriteLine("Steaming..");
        }

        public void TakeOrder()
        {
            Console.WriteLine("Taking order..");
        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }

    // Class: CupOfTea
    // [+CupOfTea | +leafType:string | +Steam():o; +TakeOrder() | +(customerIsWealthy:bool)]
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public override void Steam()
        {
            Console.WriteLine("Steaming..");
        }

        public void TakeOrder()
        {
            Console.WriteLine("Taking order..");
        }

        public CupOfTea(bool customerIsWealthy) { }
    }

    // Class: CupOfCocoa
    // [+CupOfCocoa | +numCups:int:s; +marshmallows:bool; -source:string | +Source:string:w; +Steam():o;
    // +AddSugar(amount:byte):o; +TakeOrder() | ():this(false); (marshmallows:bool):bas("Expensive Organic Brand")]
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source { set { } }

        public override void Steam()
        {
            Console.WriteLine("Steaming..");
        }

        public override void AddSugar(byte amount)
        {
            Console.WriteLine("Adding " + amount + "sugar(s)");
        }

        public void TakeOrder()
        {
            Console.WriteLine("Taking order..");
        }

        public CupOfCocoa()
        {
            this.marshmallows = false;
        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }

    }
}
