using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erickson_HelloWorld
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 1
    // Restrictions: None



    // Keyboard Shortcut for "Build Solution": F6
    // Keyboard Shortcut for "Start Debugging": F5
    // The program closed after the initial run since the code inside Main was executed
    // Keyboard Shortcut for "Start without Debugging": Crtl + F5

    class Program
    {
        static void Main(string[] args)
        {
            //test integer variables
            int myFavInt = 64;
            int myOtherInt = 31;

            //test string variable
            string myMom = "Anna";

            //Showing parenthetical operation
            int mySum = myFavInt + myOtherInt;

            Console.WriteLine("Zachary Erickson");
            Console.WriteLine("My mother's name is " + myMom);
            Console.WriteLine("My favorite number is " + myFavInt);
            Console.WriteLine("64 plus 31 = " + (myFavInt + myOtherInt));
            Console.WriteLine("64 plus 31 = " + mySum);


            //testing for-loop
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            //testing while loop
            int v = myFavInt;
            while (v > 59)
            {
                Console.WriteLine(v);
                v--;
            }

        }
    }
}

