using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erickson_PS6
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 6
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Generate a random number bewteen 1 and 100 (inclusive)
        //          and have the player try and guess the number.
        // Restrictions: None
        static void Main(string[] args)
        {

            // initialize counter
            int i = 0;

            // create new random
            Random rand = new Random();

            // initialize play again answer
            string playAgain = null;

            // initialize user input string
            string sGuess = null;

            // initialize user input int
            int iGuess = 0;

            // initialize do-while bool
            bool bValid = false;

        // create start reference so the player can play again
        start:

            // create random number
            int randomNumber = rand.Next(0, 101);

            // introduce game and rules
            Console.WriteLine("Welcome to NUMBER GUESSER!!");
            Console.WriteLine();
            Console.WriteLine("I am thinking of a number between 0 and 100, " +
                "you have 8 tries to guess what I am thinking!");
            Console.WriteLine();


            //  create for loop that allows the player to guess 8 times and keeps track of how many attempts have been made
            for(i = 0; i <= 7; i++)
            {
                // create a do-while to ensure the guess is an integer between 1 and 100
                do {
                    Console.WriteLine("Guess a number: ");
                    sGuess = Console.ReadLine();

                    // save parsed int ad iGuess
                    try {
                        iGuess = int.Parse(sGuess);

                        // check to make sure int is between 1 and 100
                        if (iGuess < 0 || iGuess > 100)
                        {
                            Console.WriteLine("Please enter an integer between 0 and 100");
                            Console.WriteLine();
                            bValid = false;
                        }
                        else { bValid = true; }
                        
                    }

                    // catch non-integers and prompt for a valid guess
                    catch
                    {
                        Console.WriteLine("bshbs Please enter an integer between 0 and 100");
                        Console.WriteLine();
                        bValid = false;
                    }

                    
                   
                } while (!bValid);

               // test guess against random number

               // test cases for guess being less than the random number
               if (iGuess < randomNumber)
                {
                    // if i = 7 (8th guess), show loss text and display the number.
                    if (i == 7)
                    {
                        Console.WriteLine("Too Low. You lose, the number was " + randomNumber + ".");
                        Console.WriteLine();
                    }

                    // otherwise, state that the guess was too low and show the number
                    // of remaining guesses
                    else 
                    { 
                        Console.WriteLine("Too low, " + (7 - i) + " guesses remaining");
                        Console.WriteLine();
                    }
                    
                }

               // test cases gor guess being higher than the random number
               else if (iGuess > randomNumber)
                {
                    // if i = 7 (8th guess), show loss text and display the number.
                    if (i == 7) 
                    {
                        Console.WriteLine("Too high. You lose, the number was " + randomNumber + ".");
                        Console.WriteLine();
                    }

                    // otherwise, state that the guess was too high and show the number
                    // of remaining guesses
                    else
                    { 
                        Console.WriteLine("Too high, " + (7 - i) + " guesses remaining");
                        Console.WriteLine();
                    }
                    
                }

                // test cases of guessing the correct number 
                else
                {
                    // if the user guesses correctly on the first try, let them know
                    if (i == 0)
                    {
                        Console.WriteLine("CORRECT!!! The number was: " + randomNumber + ". You guessed it on the first try!");
                    }

                    // otherwise, let the user know how many guesses it took
                    else
                    {
                        Console.WriteLine("CORRECT!!! The number was: " + randomNumber + ". You guessed it in " + (i+1) + " tries!");              
                    }

                    // break the for-loop
                    Console.WriteLine();
                    break;

                }

            }

            // use do-while to prompt the user to play again
            do
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine().ToLower();

                switch (playAgain)
                {
                    case "y":
                        bValid = true;
                        Console.WriteLine();
                        goto start;

                    case "n":
                        bValid = true;
                        break;

                    default:
                        Console.WriteLine("Please enter 'y' or 'n'");
                        Console.WriteLine();
                        bValid = false;
                        break;
                }
            } while (!bValid);


        }
    }
}
