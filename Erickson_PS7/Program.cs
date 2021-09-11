using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Erickson_PS7
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 7
    // Restrictions: None

    class Program
    {

        // Method: Main
        // Purpose: Prompt user for words to create a Mad Lib from a list of stories
        // Restrictions: None

        static void Main(string[] args)
        {
            // number of mad libs
            int numLibs = 0;
            int cntr = 0;

            // user mad lib choice
            int nChoice = 0;

            // will be used to count how many times the user submits something invalid when prompted yes or no
            int playAgainCounter = 1;

            // initializes user input string
            string userInput = null;

            // string that will hold the completed mad lib
            // starts with a space so the formatting looks nice when written in the console
            string resultString = " ";

            // initialize bool to see if the word has a comma
            bool hasComma = false;

            // initialize bool for do-while
            bool bValid = false;

            // create random to get a random index for play again strings
            Random rand = new Random();

            // string array containing little quips to be used if the user does not enter yes or no when prompted
            string[] playAgainStrings = {"Are you messing with me?", "Not funny, just write yes or no, it's so simple", "WRITE YES OR NO!!!", "So you're some kind of comedian?",
                "I'm begging you to break this loop, I'm stuck here, I need your help. Just type yes or no", "If I could type 'no' for you, I would"};

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\Users\\Zachary\\Downloads\\Templates\\MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\Users\\Zachary\\Downloads\\Templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            // ask the user if they want to play. If they say yes, proceed. If they say no, quit.
            // If they don't write yes or no, prompt them to enter a valid answer.
            
            do
            {
                Console.WriteLine("Would you like to make a Mad Lib? (yes or no)");
                userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "yes":

                        Console.WriteLine();
                        bValid = true;
                        goto start;

                    case "no":
                        Console.WriteLine();
                        Console.WriteLine("Fine by me. Seeya!");
                        bValid = true;
                        break;

                    default:
                        // Every third time the user inputs something invalid, generate a random quip from the array.
                        if (playAgainCounter % 3 == 0)
                        {
                            playAgainCounter++;
                            Console.WriteLine();
                            Console.WriteLine(playAgainStrings[rand.Next(0, playAgainStrings.Length)]);
                            Console.WriteLine();
                            bValid = false;
                            break;
                        }

                        else
                        {
                            playAgainCounter++;
                            Console.WriteLine();
                            Console.WriteLine("Please type 'yes' or 'no'");
                            Console.WriteLine();
                            bValid = false;
                            break;
                        }


                }

            } while (!bValid);

        // game will restart from here.
        start:


            // prompt the user for which Mad Lib they want to play (nChoice)
            do
            {
                Console.WriteLine("Pick a story (1-" + numLibs + "):");
                userInput = Console.ReadLine();

                // make sure user input was an int
                bValid = int.TryParse(userInput, out nChoice);

                // make sure the choice was between 1 and 6
                bValid = nChoice > 0 && nChoice <= numLibs;

            } while (!bValid);

            // subtract one from nChoice in order to use it for array index.
            nChoice--;

            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' ');

            foreach (string word in words)
            {              

                // check to see if word is a placeholder
                if (word.StartsWith("{"))
                {

                    // mark words that have a comma so the comma can be reapplied after the user input
                    hasComma = word.EndsWith(",");
                    string wordType = null;
                    
                    // if the word has a comma, the substring must get rid of the comma as well as the {}
                    if (hasComma)
                    {
                        wordType = word.Substring(1, word.Length -3);
                    }

                    // otherwise, the substring must just get rid of {}
                    else
                    {
                        wordType = word.Substring(1, word.Length - 2);
                    }
                    
                    // if the word contains '_', replace with a space
                    if (wordType.Contains("_"))
                    {
                        wordType = wordType.Replace("_", " ");
                    }

                   // check to see if the placeholder word start with a vowel
                   if (wordType.StartsWith("A") || wordType.StartsWith("E") || wordType.StartsWith("I") ||
                        wordType.StartsWith("O") || wordType.StartsWith("U"))
                   {

                        // if so prompts the user for the placeholder word
                        do
                        {
                            Console.WriteLine("Enter an " + wordType.ToLower() + ":");
                            userInput = Console.ReadLine();

                            // makes sure the user inputted something
                            if(userInput.Length == 0) 
                            {
                                
                                Console.WriteLine("You must enter something.");
                                Console.WriteLine();
                                bValid = false;
                            }

                            else { bValid = true; }

                        } while (!bValid);                          
                    }

                   // does the same thing except uses 'a' instead of 'an'
                    else 
                    {
                        Console.WriteLine("Enter a " + wordType.ToLower() + ":");
                        userInput = Console.ReadLine();
                    }

                   // replaces the comma if the original word had a comma at the end
                    if (hasComma)
                    {
                        resultString += userInput + ", ";
                    }

                    else 
                    { 
                       resultString += userInput + " "; 
                    }
                    

                }

                // adds the escape sequence
                else if (word.StartsWith("/n"))
                {
                    resultString += "/n";
                }

                // adds a non-placeholder word
                else
                {
                    resultString += (word + " ");
                }
            }

            // displays the completed mad lib
            Console.WriteLine();
            Console.WriteLine("Here is your Mad Lib!");
            Console.WriteLine();
            Console.WriteLine(resultString);
            Console.WriteLine();

            // resets the invalid input counter
            playAgainCounter = 1;


            // does the same thing as the first block of code prompting the user if they want to play
            do
            {
                Console.WriteLine("Would you like to play again (yes or no)?");
                userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    // brings the user back to the start
                    case "yes":

                        Console.WriteLine();
                        bValid = true;
                        goto start;

                    case "no":
                        Console.WriteLine();
                        Console.WriteLine("Thanks for playing!");
                        bValid = true;
                        break;

                    default:

                        if (playAgainCounter % 3 == 0)
                        {
                            playAgainCounter++;
                            Console.WriteLine();
                            Console.WriteLine(playAgainStrings[rand.Next(0, playAgainStrings.Length)]);
                            Console.WriteLine();
                            bValid = false;
                            break;
                        }

                        else
                        {
                            playAgainCounter++;
                            Console.WriteLine();
                            Console.WriteLine("Please type 'yes' or 'no'");
                            Console.WriteLine();
                            bValid = false;
                            break;
                        }
                        

                }

            } while (!bValid);
            

        }

        





    }
    
}
