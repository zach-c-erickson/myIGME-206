using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Exam_Question_1
{
    // Author: Zachary Erickson
    // Class: Program
    // Purpose: Console app testing number of characters
    class Program
    {

        // Method: Main
        // Purpose: Prompts user for string, prints how many letters are in the string. The first section is the improved version,
        // the second section is the base version.
        static void Main(string[] args)
        {

           /******************************* Improved Version (2.374s execution time) ******************************/

            

            // intialize string variables
            string sReponse = null;

            // SortedList to keep track of quantity of characters
            SortedList<char, int> quantityList = new SortedList<char, int>();

            // prompt user for string and save as sResponse
            Console.WriteLine("Please enter a string");
            sReponse = Console.ReadLine();


            // for each char in the array
            foreach (char character in sReponse.ToLower())
            {

                // if the character is a letter..
                if (Char.IsLetter(character))
                {

                    // if quantityList does not contain the char
                    if (!quantityList.ContainsKey(character))
                    {
                        // add the character to quantity list and set quantity to 1
                        quantityList[character] = 1;
                    }
                    else
                    {
                        // otherwise, add one to the quantity of the letter
                        ++quantityList[character];
                    }
                }
            }

            // for each quantity pair, print the letter and quantity
            foreach (KeyValuePair<char, int> kvp in quantityList)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }

            
            
            /************************* Base Version (3.75s execution time) ************************/

            /*

            // intialize string variable
            string sReponse2 = null;

            // int array to keep track of quantity of characters
            int[] charCount = new int[26];

            // prompt user for string and save as sResponse2
            Console.WriteLine("Please enter a string");
            sReponse2 = Console.ReadLine();


            // for each char in the array
            foreach (char character in sReponse2.ToLower())
            {

                // if the character is a letter..
                if (Char.IsLetter(character))
                {
                    // add 1 to the current char count for that character
                    ++charCount[character - 'a'];
                }
            }

            // go through each vallue in the array and write the number of that char
            for (int i = 0; i < charCount.Length; ++i)
            {
                Console.WriteLine((char)(i + 'a') + ": " + charCount[i]);
            }

            */

        }
    }
}






        

        

