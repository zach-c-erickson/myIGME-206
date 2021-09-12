using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_8_Question_7
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 8 Question 7
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Take a user inputted string and output the characters in reverse order
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize user input string
            string userInput = null;

            // initialize result string
            string resultString = "";
                   
            // make sure the user enters something
            do
            {
                Console.Write("Enter a string: ");

                // save input as userInput
                userInput = Console.ReadLine();


            } while( userInput.Length == 0 );

            // go through each character in userInput
            foreach (char letter in userInput)
            {
                // add the character to the beginning of the result string
                resultString = letter + resultString;
            }
            // print the result string
            Console.WriteLine("Your string in reverse is: " + resultString);
        }
    }
}
