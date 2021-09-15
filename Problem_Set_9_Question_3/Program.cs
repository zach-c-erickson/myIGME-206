using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_9_Question_3
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 9 Question 3
    // Restrictions: None

    static class Program
    {
        // define the delegate function data type
        delegate string ReadLine();


        // Method: Main
        // Purpose: Read user input using a delegate function
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize user input string
            string userInput = null;

            // declare delegate variable that will point to the function
            // to be called
            ReadLine readThisLine;


            // set the delegate function variable to the 
            // ReadUserInput() function
            readThisLine = new ReadLine(ReadUserInput);

            do
            {
                // prompt the user to type something
                Console.WriteLine("Type Something!");


                // call the delegate function to read the input
                userInput = readThisLine();


            } while (userInput.Length == 0);
            


            // return the user input
            Console.WriteLine("You typed: {0}", userInput);


        }

        // Method: ReadUserInput()
        // Purpose: Reads the user input and returns a string
        // Restricitons: None

        static string ReadUserInput()
        {
            return Console.ReadLine();
        }
    }
}
