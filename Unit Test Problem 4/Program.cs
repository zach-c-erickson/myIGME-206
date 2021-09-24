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

        // string and int for response
        static string sResponse = "";

        // question 1 and answer
        static string question1 = "What is your favorite color?";
        static string answer1 = "black";

        // question 2 and answer
        static string question2 = "What is the answer to life, the universe and everything?";
        static string answer2 = "42";

        // question 3 and answer
        static string question3 = "What is the airspeed velocity of an unladen swallow?";
        static string answer3 = "What do you mean? African or European Swallow?";

        // Method: Main
        // Purpose: Prompt the user for one of three questions. Give
        // them 5 seconds to answer the questions
        // Restrictions: None
        static void Main(string[] args)
        {
            // string and int of user question choice
            string sChoice = "";
            
            

            // boolean for checking valid input
            bool bValid = false;

            // play again?
            string sAgain = "";

           


        start:

            // ask for user's question choice
            Console.Write("Choose your question(1-3): ");
            

            // save choice
            sChoice = Console.ReadLine();

            bValid = false;

            Console.WriteLine();

            timeOutTimer = new Timer(5000);

            timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);

            bTimeOut = false;
           
            switch (sChoice)
            {

                case "1":
                 
                    timeOutTimer.Start();
                    Console.WriteLine("You have 5 seconds to answer the following question:");
                    Console.WriteLine(question1);
                        
                    sResponse = Console.ReadLine();
                        
                    timeOutTimer.Stop();
                     
                    bValid = true;

                    if(sResponse.ToLower() == answer1 && !bTimeOut)
                    {
                        Console.WriteLine("Well done!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer1);
                        break;
                    }
                    
                    
                case "2":
                    timeOutTimer.Start();
                    Console.WriteLine("You have 5 seconds to answer the following question:");
                    Console.WriteLine(question2);
                    sResponse = Console.ReadLine();
                    timeOutTimer.Stop();

                    if (sResponse.ToLower() == answer2 && !bTimeOut)
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

                    if (sResponse.ToLower() == answer3.ToLower() && !bTimeOut)
                    {
                        Console.WriteLine("Well done!");
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The answer is: " + answer3);
                    }
                    break;
                default:
                    goto start;
            }
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

        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Time's up!");
            Console.WriteLine("Please press enter");
            bTimeOut = true;

            timeOutTimer.Stop();
        }
    }
}
