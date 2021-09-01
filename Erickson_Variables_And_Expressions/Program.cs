using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erickson_Variables_And_Expressions
{

    // Class Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 3 (question 5)
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Recieve four user-inputed integers
        //          and calculate their product            
        // Restrictions: None

        static void Main(string[] args)
        {

            // declare four integer variables that will store user
            // input integers
            int firstInt = 0;
            int secondInt = 0;
            int thirdInt = 0;
            int fourthInt = 0;

            // declare string that will hold the user input when
            // asked for an integer
            string sInt = null;

            // declare string that will store user input when
            // asked to start again
            string startOver = null;

            // declare bool for use in do-while
            bool bValid = false;

            // introduction
            Console.WriteLine("Welcome to the product machine!");
            
            // have start so the user can return and start again
            start:

                do
                {
                    Console.WriteLine();

                    // prompt for first integer
                    Console.Write("Enter your first integer:");

                    // store input as a string
                    sInt = Console.ReadLine();

                    try
                    {
                        // makes sure that the user entered an integer and
                        // converts their input to an int type
                        firstInt = int.Parse(sInt);
                        bValid = true;
                    }

                    catch
                    {
                        Console.WriteLine();
                        
                        // if the user did not input an integer, they will
                        // be prompted to
                        Console.WriteLine("Please enter an integer.");
                        bValid = false;
                    }
                } while (!bValid);

                Console.WriteLine();

                do
                {
                    // repeat all for second integer
                    Console.Write("Enter your second integer:");
                    sInt = Console.ReadLine();

                    try
                    {
                        secondInt = int.Parse(sInt);
                        bValid = true;
                    }

                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter an integer.");
                        bValid = false;
                    }
                } while (!bValid);

                Console.WriteLine();


                do
                {
                    // repeat all for third integer
                    Console.Write("Enter your third integer:");
                    sInt = Console.ReadLine();

                    try
                    {
                        thirdInt = int.Parse(sInt);
                        bValid = true;
                    }

                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter an integer.");
                        bValid = false;
                    }
                } while (!bValid);

                Console.WriteLine();


                do
                {
                    // repeat all for fourth integer
                    Console.Write("Enter your final integer:");
                    sInt = Console.ReadLine();

                    try
                    {
                        fourthInt = int.Parse(sInt);
                        bValid = true;
                    }

                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter an integer.");
                        bValid = false;
                    }
                } while (!bValid);

                Console.WriteLine();
                
                // Display the product to the user
                Console.WriteLine(firstInt + " * " + secondInt + " * " + thirdInt + " * " + fourthInt + " = "
                    + (firstInt * secondInt * thirdInt * fourthInt));

                Console.WriteLine();
            do
            {
                // ask user if they want to start again
                Console.WriteLine("Do you want to calculate another product? (Y/N): ");

                // store answer in startOver string
                startOver = Console.ReadLine();

                // determine if user inputed 'y' or 'n', if they say yes, goto start
                // if they say no, end program.
                if (startOver.ToLower() == "y")
                {
                    goto start;
                }
                else
                {
                    break;
                }

            } while (true);


        }
    }
}
