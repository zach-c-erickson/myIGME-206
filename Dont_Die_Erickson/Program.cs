using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace Dont_Die_Erickson
{


    // Class: Trivia
    // Purpose: Stores trivia information
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    // Class: TriviaResult
    // Purpose: USed by Trivia to collect trivia question data
    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }


    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 22
    class Program
    {
        static Timer timer;
        static bool bElapsed;
        

        // neighboring points can be determined by if (maxtrixGraph[x, y].Item1 == x)
        // relative direction is Item1 in the tuple
        // cost is Item2 in the tuple
        static (string, int)[,] matrinullGraph = new (string, int)[,]
        {
                 //    A           B           C           D           E           F           G           H
          /*A*/  {("NE", 0),  ("S", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)},
          /*B*/  {(null, -1), (null, -1), ("S", 2),   ("E", 3),   (null, -1), (null, -1), (null, -1), (null, -1)},
          /*C*/  {(null, -1), ("N", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 20)},
          /*D*/  {(null, -1), ("W", 3),   ("S", 5),   (null, -1), ("N", 2),   ("E", 4),   (null, -1), (null, -1)},
          /*E*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 3),   (null, -1), (null, -1)},
          /*F*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("E", 1),   (null, -1)},
          /*G*/  {(null, -1), (null, -1), (null, -1), (null, -1), ("N", 0),   (null, -1), (null, -1), ("S", 2)},
          /*H*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)}
        };

        //Item1 is the index of the neighbor, Item2 is the direction and Item3 is the cost
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
            new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null
        };

        // string array of room descriptions
        static string[] descriptions = new string[]
        {
            "You exit through the door and find yourself right back where you started..",

            "You enter a room filled with pools of water..and exposed wiring. \nYou feel electricity course through your body.",

            "Some sort of half-rodent/half-alien leaps at you as you enter the room. \nYou manage to dispose of it, but not after " +
            "receiving a couple bites and scratches.",

            "As you enter the room, you see a humanoid figure standing over a human strapped to an exam table.\n The alien notices you and begins to charge. " +
            "It takes a swing and connects with your stomach.\n You manage to fire your weapon before the thing strikes again. You approach the human on the exam table..\n" +
            "but it seems as though they won't be going anywhere...",

            "You enter a room scattered with x-rays of several human bodies. While examining these x-rays,\n a ceiling tile plummets to the ground and hits you in the head.",

            "You enter a pitch black room. As you tip-toe around you bump into a wall.\n The wall feels a bit slimy as you run your hand across it. All of the sudden,\n the" +
            " wall begins to move. Something grabs you and throws you across the room.\n You aim in the direction of the wall and fire your weapon. You are greeted by silence." +
            " \nAs you try to make your way around the room, you finally find a light switch.",

            "You enter the room and see a drinking fountain on the wall. You're parched. \nYou go over and take a sip. Immediately you realize that what you're drinking is not water.\n" +
            "You decide not to find out what the liquid was, however you begin to feel sick.",

            "You enter the room and see several humanoid creatures staring at you. It's go time.\nYou fire several rounds into the crowd, causing three of the creatures" +
            " to fall.\nOne of the creatures sprints at you and swings at your head. You manage to dodge the attack but another creature pierces you from behind.\nWith your" +
            " remaining strength, you manage to blast both of the combatants. After your battle, you can faintly see some daylight.\nAs you crawl toward the light, your vision" +
            " begins to fade.\n You take one last glance and, miraculously, you can see several people in hazmat suits coming to your aid.\nThey put you on a stretcher and bring you" +
            " to safety.",
         };

      
                   
        

        // Method: Main
        // Purpose: Player will navigate through a maze where exits require health points to access.

        static void Main(string[] args)
        {
           
            // int to store health
            int health = 1;

            // int to store wager amount
            int wager = 0;

            // int to store current room index
            int currentPlayerPos = 0;

            // int to store next room index
            int nextPlayerPos = 0;

            // damage int
            int damageTaken = 0;

            // win game bool
            bool winGame = false;

            // bool to see if there are unavailable doors
            bool doorsRemaining = false;

            // bool to see if there are available doors
            bool doorsAvailable = false;

            // while loop bool
            bool bValid = false;

            // exit while loop bool
            bool bValidExit = false;

            // wager while loop bool
            bool bValidWager = false;

            // bool keeping track of correct answer for wagers
            bool correctAnswer = false;

            // exit game bool
            bool exitGame = false;

            // user response string
            string sResponse = "";

            // Create random

            Random rand = new Random();

            start:
                
                // introduction text
                Console.WriteLine("Welcome To Don't Die!");
                Console.WriteLine();
                Console.WriteLine("You wake up in some sort of laboratory, strapped to an examination table. After a bit of struggle, " +
                    "you manage to free yourself from the bonds. On the table is some sort of firearm-like weapon that does not look like it is from your planet. You grab the " +
                    "weapon. You have no recollection of how you ended up here. All you know is that you need to find a way out.");
                Console.WriteLine();

                // while loop will continue until the player wants to exit or they win
                while (!exitGame)
                {
                    // set bools to false at each loop
                    int turn = 0;
                    bValid = false;
                    bValidExit = false;
                    bValidWager = false;
                    doorsRemaining = false;
                    doorsAvailable = true;
               
                    // display current health
                    Console.WriteLine("Your current health is: " + health);
                    
                    // foreach loop that keeps track of avilable doors
                    foreach ((int,string,int) details in listGraph[currentPlayerPos])
                    {
                        // if player's health exceeds the required health for the door
                        if(health > details.Item3)
                        {
                            // prompt the user that the door is available and push the door to the stack
                            Console.WriteLine("You see a door to the " + DirectionString(details.Item2));
                            doorsAvailable = true;
                        
                        }
                        else
                        {
                            // if a player cannot access a door, mark the doorsRemaining bool as true
                            doorsRemaining = true;
                        }
                    
                    }

                    // if there's an inaccessible door, let the player know
                    if (doorsRemaining)
                    {
                        Console.WriteLine("There appear to be doors you can't access with your current health");
                        Console.WriteLine();
                    
                    }
                    // if there are available doors
                    if (doorsAvailable)
                    {
                        while (!bValid)
                        {
                            // Ask user if they want to go through a door or wager some health
                            Console.WriteLine("Would you like to go through an door? Or wager some health with a trivia question? (door/wager)");
                            sResponse = Console.ReadLine();
                            
                            // if user wants to exit, ask what direction they would like to go
                            if (sResponse.ToLower() == "door")
                            {
                                


                            while (!bValidExit)
                                {
                                Console.WriteLine("Which direction would you like to go?");
                                sResponse = Console.ReadLine();
                                // go through the adjacency list to find the option with the direction the player wants to go
                                foreach ((int, string, int) details in listGraph[currentPlayerPos])
                                    {
                                        if(DirectionLetter(sResponse) == "error")
                                        {
                                            Console.WriteLine("Please enter a valid direction");
                                            
                                            break;
                                        }
                                        // calls DirectionLetter on the response so the user can write out the entire word (north/south/etc.)
                                        else if (DirectionLetter(sResponse) == details.Item2 || sResponse.ToUpper() == details.Item2)
                                        {

                                            // make sure the player selected a door they can access
                                            if(health > details.Item3)
                                            {
                                                // set nextPlayerPos to the index of the room the player wants to go.
                                                nextPlayerPos = details.Item1;

                                                // set damageTaken to a random number between 1 and the weight
                                                damageTaken = rand.Next(1, details.Item3 + 1);   

                                                

                                                // if damage taken is greater than 0, give the new room description and inform the player how much health they lost
                                                if (details.Item3 > 0)
                                                {
                                                    // take away the required health from the player
                                                    health -= damageTaken;
                                                    Console.WriteLine();
                                                    Console.WriteLine(descriptions[nextPlayerPos] + " You lost " + damageTaken + " health..");
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine(descriptions[nextPlayerPos]);
                                                    Console.WriteLine();
                                                }


                                                // set bools to true
                                                bValid = true;
                                                bValidExit = true;
                                            }

                                            // if they player selects a direction they cannot access, inform them and ask again.
                                            else
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("You cannot access that direction");
                                                Console.WriteLine();
                                            }
                                            
                                        }
                                    }
                                }

                                // increase turn
                                turn++;
                                
                                // set current position to the new position
                                currentPlayerPos = nextPlayerPos;
                                
                                // if the player reaches the final room, break the game loop and set winGame to true
                                if (currentPlayerPos == 7)
                                {
                                    exitGame = true;
                                    winGame = true;
                                }
                            

                            }

                            // if response is wager
                            else if (sResponse.ToLower() == "wager")
                            {
                                
                                while (!bValidWager)
                                {
                                    // ask player how much they want to wager and save it as the wager variable
                                    Console.WriteLine("How much would you like to wager: ");
                                    sResponse = Console.ReadLine();
                                    

                                    int.TryParse(sResponse, out wager);
                                    
                                    // inform the player if they wager more than their health
                                    if(wager > health)
                                    {
                                        Console.WriteLine("You cannot wager more health than you have. Your current health is: " + health);
                                        Console.WriteLine();
                                    }

                                    // inform the player that they cannot wager <= 0 health
                                    else if (wager <= 0)
                                    {
                                        Console.WriteLine("You must wager more than 0 health.");
                                        Console.WriteLine();
                                    }
                                        
                                    // save correctAnswer bool as CreateQuestion()
                                    else
                                    {
                                        correctAnswer = CreateQuestion();

                                        // if the player responds correctly, inform them and add their health
                                        if (correctAnswer)
                                        {
                                            health += wager;
                                            Console.WriteLine();
                                            Console.WriteLine("Correct! You gained " + wager + " health");
                                            Console.WriteLine();
                                        
                                            bValidWager = true;
                                            bValid = true;
                                        }

                                        // if the player responds incorrectly, inform them and subtract their health
                                        else
                                        {
                                            
                                            health -= wager;
                                            Console.WriteLine();
                                            Console.WriteLine("Incorrect! You lost " + wager + " health");
                                            Console.WriteLine();
                                        
                                            bValidWager = true;
                                            bValid = true;
                                        }

                                        // if the player reaches 0 health, ask them if they would like to start over
                                        if (health == 0)
                                        {
                                            Console.WriteLine("You have died...Start Over? (y/n)");
                                            sResponse = Console.ReadLine();

                                            switch (sResponse.ToLower())
                                            {
                                                case "y":
                                                        health = 1;
                                                        goto start;
                                                case "n":
                                                    bValidWager = true;
                                                    bValid = true;
                                                    exitGame = true;
                                                    break;
                                                default:
                                                    break;
                                            }

                                        }
                                    }
                                }
                            

                            }
                            // if the player does not respond with 'door' or 'wager', ask again.
                            else
                            {
                                Console.WriteLine("Please type 'door' or 'wager'");
                                Console.WriteLine();

                            while (!bValidWager)
                            {
                                // ask player how much they want to wager and save it as the wager variable
                                Console.WriteLine("How much would you like to wager: ");
                                sResponse = Console.ReadLine();


                                int.TryParse(sResponse, out wager);

                                // inform the player if they wager more than their health
                                if (wager > health)
                                {
                                    Console.WriteLine("You cannot wager more health than you have. Your current health is: " + health);
                                    Console.WriteLine();
                                }

                                // inform the player that they cannot wager <= 0 health
                                else if (wager <= 0)
                                {
                                    Console.WriteLine("You must wager more than 0 health.");
                                    Console.WriteLine();
                                }

                                // save correctAnswer bool as CreateQuestion()
                                else
                                {
                                    correctAnswer = CreateQuestion();

                                    // if the player responds correctly, inform them and add their health
                                    if (correctAnswer)
                                    {
                                        health += wager;
                                        Console.WriteLine();
                                        Console.WriteLine("Correct! You gained " + wager + " health");
                                        Console.WriteLine();

                                        bValidWager = true;
                                        bValid = true;
                                    }

                                    // if the player responds incorrectly, inform them and subtract their health
                                    else
                                    {

                                        health -= wager;
                                        Console.WriteLine();
                                        Console.WriteLine("Incorrect! You lost " + wager + " health");
                                        Console.WriteLine();

                                        bValidWager = true;
                                        bValid = true;
                                    }

                                    // if the player reaches 0 health, ask them if they would like to start over
                                    if (health == 0)
                                    {
                                        Console.WriteLine("You have died...Start Over? (y/n)");
                                        sResponse = Console.ReadLine();

                                        switch (sResponse.ToLower())
                                        {
                                            case "y":
                                                health = 1;
                                                goto start;
                                            case "n":
                                                bValidWager = true;
                                                bValid = true;
                                                exitGame = true;
                                                break;
                                            default:
                                                break;
                                        }

                                    }
                                }
                            }
                            }
                        }

                    

                    
                    }
                    // if there are no available doors, only offer the wager option
                    else
                    {
                        while (!bValid)
                    {
                        // Tell user they must wager.
                        Console.WriteLine("You must wager some health with a trivia question to access a door");
                        
                    }
                    }
                
                    // if the player makes it to room H, they win.
                if (winGame)
                {
                    Console.WriteLine("Congratualtions! You win!");
                }
                   
                
            }



        }
        // Method: DirectionString(string)
        // Purpose: Converts Letter to full word
        public static string DirectionString(string letter)
        {
            switch (letter)
            {
                case "N":
                    return "North";
                    

                case "E":
                    return "East";
                    

                case "S":
                    return "South";
                    

                case "W":
                    return "West";
                    

                default:
                    return "error";
                    
            };

        }

        // Method: DirectionLetter(string)
        // Purpose: Converts word to cardinal letter
        public static string DirectionLetter(string word)
        {
            switch (word.ToLower())
            {
                case "north":
                    return "N";


                case "east":
                    return "E";


                case "south":
                    return "S";


                case "west":
                    return "W";


                default:
                    return "error";

            };
        }

        
        // Method: CreateQuestion
        // Purpose: Returns a bool if the player answers the question correctly or not
        public static bool CreateQuestion()
        {
            // Create 15 second timer
            timer = new Timer(15000);
            timer.Elapsed += new ElapsedEventHandler(TimesUp);

            // Create 3 lists to store correct and incorrect answers
            List<string> answerList = new List<string>();
            List<string> randomAnswerList = new List<string>();
            SortedList<string, string> displayList = new SortedList<string, string>();

            // create bool for list randomization
            bool listFull = false;

            // create Random
            Random rand = new Random();

            // string variables
            string sResponse = null;

            string url = null;
            string s = null;
            
            // HTTP and Streamreader instances
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;
            
            
            // Open URL and save appropriate variables
            url = "https://opentdb.com/api.php?amount=1";
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            // Create a Trivia object based on the url
            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            // Decode the question and answers
            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);

            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
            }

            // add the correct answer and incorrect answers to one list
            answerList.Add(trivia.results[0].correct_answer);

            for(int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                answerList.Add(trivia.results[0].incorrect_answers[i]);
            }

            // If the question is easy
            if(trivia.results[0].difficulty == "easy")
            {
                // set elapsed bool to false
                bElapsed = false;

                // tell user they have 15 seconds
                Console.WriteLine("You have 15 seconds to answer the following question");



                Console.WriteLine();

                // Display question
                Console.WriteLine(trivia.results[0].question);

                Console.WriteLine();

                // fill the randomAnswerList with a random element from the AnswerList until the RandomeAnswerList is full
                // This makes it so they answers are randomized
                while (!listFull)
                {
                    int myInt = rand.Next(0, answerList.Count);

                    if (!randomAnswerList.Contains(answerList[myInt]))
                    {
                        randomAnswerList.Add(answerList[myInt]);
                        listFull = (randomAnswerList.Count == answerList.Count);
                    }
                }

                // In the sorted list, create key-value pairs with a letter of the alphabet and one of the answers
                for (int i = 0; i < answerList.Count; ++i)
                {
                    string letter = Convert.ToChar(i + 65).ToString();
                    displayList.Add(letter, randomAnswerList[i]);
                }

                // for each answer, siplay the letter and answer
                foreach (KeyValuePair<string, string> kvp in displayList)
                {
                    Console.WriteLine(kvp.Key + ". " + kvp.Value);
                }

                // start timer
                timer.Start();
                Console.WriteLine();

                // save player response as sResponse
                sResponse = Console.ReadLine();
                timer.Stop();

                // Check to see if the player selected the correct letter option
                foreach (KeyValuePair<string, string> kvp in displayList)
                {
                    if (kvp.Key.ToLower() == sResponse.ToLower())
                    {
                        sResponse = kvp.Value;
                    }
                }

                // if the player answers correctly before time is up, return true, otherwise return false
                if (!bElapsed)
                {
                    if (sResponse.ToLower() == trivia.results[0].correct_answer.ToLower())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            // if the question isn't easy, create another question
            else
            {
                return CreateQuestion();
            }
           

            

           
        }

        // Delegate TimesUp method
        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Inform the player that time is up and tell them to press enter
            Console.WriteLine("Time's up! Please press enter.");

            // set bElapsed to true
            bElapsed = true;
        }
    }

    
}
