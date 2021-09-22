using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_8_Question_8
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 8 Question 8
    // Restrictions: None

    class Program
    {
        // Method: Main
        // Purpose: Ask for a string from the user, then return a string
        // with 'yes' replaced with 'no' and vice versa
        // Restrictions: None

        static void Main(string[] args)
        {
            // initialize strings for user input and the result
            string userInput = null;
            string resultString = "";
            string testWord = null;

            // use a check punctuation bool
            bool hasPunctuation = false;

            // make sure the user inputted something
            do
            {
                Console.WriteLine("Enter a string:");
                userInput = Console.ReadLine();

            } while (userInput.Length == 0);
            

            // split the string into an array of word strings
            string[] words = userInput.Split(' ');

            // go through each word and check if it says yes or no
            foreach(string word in words)
            {
                // check to see if the string ends with punctuation
                hasPunctuation = Char.IsPunctuation(word, word.Length-1);

                // if so, grab the part of the string without punctuation
                if (hasPunctuation)
                {
                    testWord = word.Substring(0, word.Length - 1);
                }
                else
                {
                    testWord = word;
                }
                switch (testWord)
                {
                    // switch no with yes
                    case "no":
                        resultString = resultString + "yes";
                        break;

                    // switch yes with no
                    case "yes":
                        resultString = resultString + "no";
                        break;

                    // switch no with yes
                    case "No":
                        resultString = resultString + "Yes";
                        break;

                    // switch yes with no
                    case "Yes":
                        resultString = resultString + "No";
                        break;

                    // anything else, just add it to the result string
                    default:
                        resultString = resultString + testWord;
                        break;
                }

                // add punctuation back to the word if it existed
                if (hasPunctuation)
                {
                    resultString = resultString + word[word.Length-1] + " ";
                }
                else
                {
                    resultString = resultString + " ";
                }

                

            }

            // return result string
            Console.WriteLine("Your result string is: " + resultString);


        }
    }
}
