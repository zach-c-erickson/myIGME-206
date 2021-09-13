using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_8_Question_9
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 8 Question 9
    // Restrictions: None

    class Program
    {
        // Method: Main
        // Purpose: Add double quotes around every word in a string
        // Restrictions: None

        static void Main(string[] args)
        {
            // initialize strings for user input and the result
            string userInput = null;
            string resultString = "";


            // make sure the user inputted something
            do
            {
                Console.WriteLine("Enter a string:");
                userInput = Console.ReadLine();

            } while (userInput.Length == 0);


            // split the string into an array of word strings
            string[] words = userInput.Split(' ');

            // go through each word in the array
            foreach (string word in words)
            {
                // adds double quotes to each word and adds them to result string
                resultString = resultString + "\"" + word +  "\"" + " ";

            }

            // return result string
            Console.WriteLine("Your result string is: " + resultString);


        }
    }
}
