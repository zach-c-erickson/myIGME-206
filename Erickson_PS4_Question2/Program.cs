using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erickson_PS4_Question2
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Logic test
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Obtain two numbers from user, display them
        //          if both numbers are <= 10. 
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize two integers
            int firstInt = 0;
            int secondInt = 0;

            // intialize user input string
            string sInt = null;

            // initialize do-while bool
            bool bValid = false;

        start:

            do
            {
                // prompt for first integer
                Console.WriteLine("Please enter your first integer: ");
                sInt = Console.ReadLine();

                try
                {
                    // make sure user entered an int
                    firstInt = int.Parse(sInt);
                    bValid = true;
                }

                catch
                {
                    // prompts user for int if they entered anything else
                    Console.WriteLine("Please enter an integer.");
                    Console.WriteLine();
                }

            } while (!bValid);

            Console.WriteLine();

            do
            {
                // prompt for first integer
                Console.WriteLine("Please enter your first integer: ");
                sInt = Console.ReadLine();

                try
                {
                    // make sure user entered an int
                    secondInt = int.Parse(sInt);
                    bValid = true;
                }

                catch
                {
                    // prompts user for int if they entered anything else
                    Console.WriteLine("Please enter an integer.");
                    Console.WriteLine();
                }

            } while (!bValid);

            Console.WriteLine();

            // apply logic from question 1 to determine if both ints are > 10 or if both are < 10

            if (firstInt > 10 ^ secondInt > 10)
            {
                Console.WriteLine("Success! Your numbers were: " + firstInt + " and " + secondInt + ".");
            }

            else
            {
                // If both are > 10 or < 10, restart
                Console.WriteLine("Failure, you must start over.");
                goto start;
            }


        }
    }
}
