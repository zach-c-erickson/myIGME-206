using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Editor: Zachary Erickson
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0
            // syntax error: requires a semicolon
            int i = 0;

            // declare string to hold all numbers
            // logical error: must be outside for loop so info can be stored and
            // not rewritten each iteration of the loop
            string allNumbers = null;


            // loop through the numbers 1 through 10
            // for (i = 1; i < 10; ++i)
            // increment should be after variable (syntax error), and operand should be '<=' so that
            // the loop stops after number 10 is processed (logical error)
            for (i = 1; i <= 10; i++)
            {
                // runtime error: must account for undefined case where i = 1
                // so that we do not divide by 0
                if (i == 1)
                {
                    // output explanation of calculation
                    Console.Write(i + "/" + (i - 1) + " = ");

                    // output the calculation based on the numbers
                    Console.WriteLine("Undefined");

                    // concatenate the number to allNumbers
                    allNumbers += i + " ";
                }
                else
                {
                    // output explanation of calculation
                    // Console.Write(i + "/" + i - 1 + " = ");
                    // logical error: need parentheses around 'i-1'
                    Console.Write(i + "/" + (i - 1) + " = ");

                    // output the calculation based on the numbers

                    // Console.WriteLine(i / (i - 1));
                    // logical error
                    // must convert integer to double so calculation can account for fractions
                    float myFloat = (float)i;
                    Console.WriteLine(myFloat / (myFloat - 1));

                    // concatenate each number to allNumbers
                    allNumbers += i + " ";

                    // increment the counter
                    // i = i + 1;
                    // logical error
                    // unnecessary since the loop already increments after each iteration.
                }

            }

            // output all numbers which have been processed
            // Console.WriteLine("These numbers have been processed: " allNumbers);
            // syntax error
            // needed to add a plus operator
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}

