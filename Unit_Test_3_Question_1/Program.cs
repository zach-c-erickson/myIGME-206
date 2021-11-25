using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// Author: Zachary Erickson
// Purpose: Unit Test Question 1
namespace Unit_Test_3_Question_1
{

    // Class: Program
    // Purpose: Console app testing for palindromes
    class Program
    {

        // Stack to hold characters and reverse them
        static Stack<string> forwardStack = new Stack<string>();

        // SortedList to keep track of quantity of characters
        static SortedList<string, int> quantityList = new SortedList<string, int>();
        

        // Method: Main
        // Purpose: Prompts user for string, prints how many letters are in the string, prints it
        // in reverse order, and tests if the string is a palindrome
        static void Main(string[] args)
        {
            // intialize string variables
            string sReponse = null;
            string reverse = null;
           

            // prompt user for string and save as sResponse
            Console.WriteLine("Please enter a string");
            sReponse = Console.ReadLine();
            
            // create a char array by parsing the user's response
            char[] parsedList = sReponse.ToCharArray();


            // for each char in the array, push the string version of the char into the Stack
            foreach (char character in parsedList)
            {
                forwardStack.Push(character.ToString());

                // if the character is a letter..
                if (Char.IsLetter(character)) 
                {
                   
                    // if quantityList does not contain the character (upper or lower-case)
                    if (!quantityList.ContainsKey(character.ToString().ToLower()))
                    {
                        // add the string version of the character to quantity list and set quantity to 1
                        quantityList.Add(character.ToString().ToLower(), 1);
                    }
                    else
                    {
                        // otherwise, add one to the quantity of the letter
                        quantityList[character.ToString().ToLower()]++;
                    }
                } 
            }

            // for each quantity pair, print the letter and quantity
            foreach(KeyValuePair<string, int> kvp in quantityList)
            {
                Console.WriteLine(kvp.Key.ToUpper() + ": " + kvp.Value);
            }

            // Add each character in reverse order to the reverse string by popping each string off of the Stack
            for (int i = 0; i <= parsedList.Length -1 ; ++i)
            {
                reverse += forwardStack.Pop();

                
            }

            // Print out the reversed string
            Console.WriteLine("Your reversed string is: " + reverse);

            Console.WriteLine();


            // Calls the RemovePunct method and checks if the strings are equal
            if (RemovePunct(reverse).ToUpper() == RemovePunct(sReponse).ToUpper())
            {
                Console.WriteLine("Your string is a palindrome!");
            }
            else
            {
                Console.WriteLine("Your string is not a palindrome.");
            }
            
            






        }

        // Method: RemovePunct
        // Purpose: Removes punctuation in a string
        public static string RemovePunct(string myString)
        {

            // create a char list by parsing the string paramater
            char[] thisParsedList = myString.ToCharArray();
            string returnString = null;


            // Goes through the list and checks if a char is a letter or not
            foreach (char character in thisParsedList)
            {
                // if char is a letter, add to the beginning of return string
                if (Char.IsLetter(character))
                {
                    returnString = character.ToString() + returnString;
                }

            }

            return returnString;
        }

    }
    
}
