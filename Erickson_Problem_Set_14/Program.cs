using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erickson_Problem_Set_14
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 14
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create an instance of Baby and Adult and call MyMethod on both
        static void Main(string[] args)
        {
            Baby myBaby = new Baby();
            Adult myAdult = new Adult();

            MyMethod(myBaby);
            MyMethod(myAdult);
        }

        // Method: MyMethod
        // Purpose: Using an object as a parameter, create an ITalk, cast the object to ITalk and call ITalk.Talk().
        public static void MyMethod(object myObject)
        {
            ITalk iTalk = null;

            iTalk = (ITalk)myObject;

            iTalk.Talk();
            
        }
    }


    
    // Interface: ITalk
    // Purpose: Contains Talk() method
    public interface ITalk
    {
        void Talk();
    }

    // Class: Baby
    // Purpose: Inherits from ITalk and creates the Baby.Talk() method
    public class Baby : ITalk
    {
        public void Talk()
        {
            Console.WriteLine("Goo goo ga ga!");
        }
    }

    // Class: Adult
    // Purpose: Inherits from ITalk and creates the Adult.Talk() method
    public class Adult : ITalk
    {
        public void Talk()
        {
            Console.WriteLine("Hello there, friend!");
        }
    }
}
