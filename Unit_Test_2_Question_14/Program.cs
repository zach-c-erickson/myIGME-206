using System;

namespace StructToClass
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Unit Test Question 14
    class Program
    {
        // Method: Main
        // Purpose: Create a new Friend object, set the fields, create a copy and show their differences
        static void Main(string[] args)
        {
            // Friend object created
            Friend friend = new Friend();
            

            // create my friend Charlie Sheen
            friend.Name = "Charlie Sheen";
            friend.Greeting = "Dear Charlie";
            friend.Birthdate = DateTime.Parse("1967-12-25");
            friend.Address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            Friend enemy = friend.ShallowCopy();

            // set the enemy greeting and address without changing the friend variable
            enemy.Greeting = "Sorry Charlie";
            enemy.Address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.Greeting} => {enemy.Greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.Address} => {enemy.Address}");
        }
    }
    // Class: Friend
    // [+Friend| -name:string; -greeting:string; -birthdate:DateTime; -address:string | +Name:string; +Greeting:string;
    // +Birthdate:DateTime; -Address:string | ShallowCopy()]
    public class Friend
    {
        // set all fields as private for sake of encapsulation
        private string name;
        private string greeting;
        private DateTime birthdate;
        private string address;

        // set properties to read/write for each field
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Greeting
        {
            get { return greeting; }
            set { greeting = value; }
        }
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // creates a ShallowCopy method
        public Friend ShallowCopy()
        {
            return (Friend)this.MemberwiseClone();
        }

    }
}


