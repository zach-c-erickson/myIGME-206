using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

namespace Unit_Test_Problem_4
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Recreate the 3 questions program
    // Restrictions: None
    class Program
    {

        // bTimeOut boolean
        static bool bTimeOut = false;

        // timeOutTimer Timer
        static Timer timeOutTimer;

        // string and int of user question choice
        static string sChoice = "";

        // first answer
        static string answer1 = "black";

        // second answer
        static string answer2 = "42";

        // third answer
        static string answer3 = "What do you mean? African or European Swallow?";


        // Method: Main
        // Purpose: Prompt the user for one of three questions. Give
        // them 5 seconds to answer the questions
        // Restrictions: None
        static void Main(string[] args)
        {

            // string and int for response
            string sResponse = "";

            // question 1
            string question1 = "What is your favorite color?";
            

            // question 2
            string question2 = "What is the answer to life, the universe and everything?";
            

            // question 3
            string question3 = "What is the airspeed velocity of an unladen swallow?";
            
                         
            // boolean for checking valid input
            bool bValid = false;

            // play again?
            string sAgain = "";

        // start of game   
        start:

            // ask for user's question choice
            Console.Write("Choose your question(1-3): ");
            

            // save choice
            sChoice = Console.ReadLine();

            // set bValid to false
            bValid = false;

            
            // create 5 second timer
            timeOutTimer = new Timer(5000);

            // assign delegate method
            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

            // set bTimeOut to false
            bTimeOut = false;
           
            // ask specific question based on user choice
            switch (sChoice)
            {

                case "1":
                    
                    // start timer
                    timeOutTimer.Start();

                    // ask question
                    Console.WriteLine("You have 5 seconds to answer the following question:");
                    Console.WriteLine(question1);
                        
                    // save response as sResponse
                    sResponse = Console.ReadLine();
                    

                    // stop timer
                    timeOutTimer.Stop();

                    // if timer expires, the answer if given in the delegate method so we don't need to give the answer again
                    if (bTimeOut)
                    {
                        break;
                    }
                    
                    // if response is correct, congratulate player
                    else if(sResponse.ToLower() == answer1)
                    {
                        Console.WriteLine("Well done!");
                        break;
                    }

                    // otherwise, give the correct answer
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer1);
                        break;
                    }
                    
                // repeat for second and third questions
                case "2":
                    timeOutTimer.Start();
                    Console.WriteLine("You have 5 seconds to answer the following question:");
                    Console.WriteLine(question2);
                    sResponse = Console.ReadLine();
                    timeOutTimer.Stop();


                    if (bTimeOut)
                    {
                        break;
                    }
                    else if (sResponse.ToLower() == answer2)
                    {
                        Console.WriteLine("Well done!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: "+ answer2);
                    }
                    break;
                case "3":
                    timeOutTimer.Start();
                    Console.WriteLine("You have 5 seconds to answer the following question:");
                    Console.WriteLine(question3);
                    sResponse = Console.ReadLine();
                    timeOutTimer.Stop();

                    if (bTimeOut)
                    {
                        break;
                    }
                    else if (sResponse.ToLower() == answer3.ToLower())
                    {
                        Console.WriteLine("Well done!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer3);
                    }
                    break;

                // if response was not 1, 2, or 3, go back to start
                default:
                    goto start;
            }

            // play again do-while
            do
            {
                Console.Write("Play again?");
                sAgain = Console.ReadLine();

                switch (sAgain.Substring(0, 1).ToLower())
                {
                    case "y":
                        bValid = true;
                        goto start;
                    case "n":
                        bValid = true;
                        break;
                    default:
                        break;
                }
            } while (!bValid);
            
        }

        // Method: TimesUp
        // Purpose: If the timer expires, give the correct answer and prompt the user to press enter. Also set bTimeOut to true.
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            
            Console.WriteLine("Time's up!");
            switch (sChoice)
            {
                case "1":
                    Console.WriteLine("The answer is: " + answer1);
                    break;
                case "2":
                    Console.WriteLine("The answer is: " + answer2);
                    break;
                case "3":
                    Console.WriteLine("The answer is: " + answer3);
                    break;

            }
            
            Console.WriteLine("Please press enter");
            bTimeOut = true;

            timeOutTimer.Stop();
        }
    }
}
