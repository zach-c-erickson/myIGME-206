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
using System.Diagnostics;

namespace Final_Exam_Question_2
{
    // Author: Zachary Erickson
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

    class Program
    {
        // Create static variables for Main
        static Timer qTimer;
        static Timer sTimer;
        static bool bElapsed;
        static Object lockObject = new object();

        // Matrix representation of graph, numbers indicate weight 
        static int[,] mGraph = new int[,]
        {
                    // A    B    C    D    E    F    G    H
            /* A */  {-1,   1,   5,  -1,  -1,  -1,  -1,  -1 },
            /* B */  {-1,  -1,  -1,   1,  -1,   7,  -1,  -1 },
            /* C */  {-1,  -1,  -1,   0,   2,  -1,  -1,  -1 },
            /* D */  {-1,   1,   0,  -1,  -1,  -1,  -1,  -1 },
            /* E */  {-1,  -1,   2,  -1,  -1,  -1,   2,  -1 },
            /* F */  {-1,  -1,  -1,  -1,  -1,  -1,  -1,   4 },
            /* G */  {-1,  -1,  -1,  -1,   2,   1,  -1,  -1 },
            /* H */  {-1,  -1,  -1,  -1,  -1,  -1,  -1,  -1 }
        };

        // List representation of graph. Tuples represent the index the path goes to and its cost
        static (int, int)[][] listGraph = new (int, int)[][]
        {
            /* A */ new (int, int)[] {(1, 1), (2, 5)},
            /* B */ new (int, int)[] {(3, 1), (5, 7)},
            /* C */ new (int, int)[] {(3, 0), (4, 2)},
            /* D */ new (int, int)[] {(1, 1), (2, 0)},
            /* E */ new (int, int)[] {(2, 2), (6, 2)},
            /* F */ new (int, int)[] {(7, 4)},
            /* G */ new (int, int)[] {(4, 2), (5,1)},
            /* H */ null
        };

        // enum to keep track of state
        enum NodeState
        {
            ice,
            liquid_gas,
            gas,
            liquid_ice
        }

        // int array holding the integer value of of states and the order they transition
        static int[] stateList = new int[]
        {
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas,
            (int)NodeState.gas,
            (int)NodeState.ice,
            (int)NodeState.liquid_gas
        };

        // Method: Main
        // Purpose: Don't Die II
        static void Main(string[] args)
        {
            // Create Random
            Random rand = new Random();

            // bValid bool
            bool bValid = false;

           
            // sReponse string
            string sResponse = null;

            // int to store health
            int health = 5;

            // int to store current room index
            int currentPlayerPos = 0;

            // int to store player's state
            int playerState = (int)NodeState.ice;

            // room descriptions
            string[] descriptions = new string[]
            {
                "You find yourself in what looks like a operating room. \nThere are several blades scattered around the room and blood spattered around an operating table.",

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
                " to safety."
            };

            // Create state timer
            sTimer = new Timer(1000);
            sTimer.Elapsed += ChangeNodeStates;

            // Create question timer
            qTimer = new Timer(15000);

            // Game Introduction

            Console.WriteLine("Welcome to Escape!");

            Console.WriteLine();

            Console.WriteLine("Your goal is to escape the laboratory. There are eight rooms you can find yourself in. They are labeled A-H.");

            Console.WriteLine();

            Console.WriteLine("Each room has a state (ice, liquid or gas) that changes each second from ice -> liquid -> gas -> liquid -> ice -> liquid -> etc.");

            Console.WriteLine();

            Console.WriteLine("Your player also has a state. You may spend one HP to change your state. You must be the same state as the room you would like to enter.");

            Console.WriteLine();

            Console.WriteLine("Here are the initial states of reach room:");

            Console.WriteLine();

            Console.WriteLine("Room A: ice");
            Console.WriteLine("Room B: liquid");
            Console.WriteLine("Room C: gas");
            Console.WriteLine("Room D: ice");
            Console.WriteLine("Room E: liquid");
            Console.WriteLine("Room F: gas");
            Console.WriteLine("Room G: ice");
            Console.WriteLine("Room H: liquid");

            Console.WriteLine();

            // 
            do
            {
                Console.Write("Press 's' to start");
                sResponse = Console.ReadLine();

                switch (sResponse.ToLower())
                {
                    case "s":
                        bValid = true;
                        break;
                    default:
                        bValid = false;
                        break;

                }
            } while (!bValid);

            // start state timer
            sTimer.Start();          

            // while the player is not at the exit
            while (currentPlayerPos != 7)
            {
                // Display the current room's decription
                Console.WriteLine(descriptions[currentPlayerPos]);

                Console.WriteLine();

                // Display the currents current state
                Console.WriteLine("Your current state is: " + (NodeState)playerState);


                // Get the information on the current room's neighbors
                (int, int)[] neighbors = listGraph[currentPlayerPos];

                // set a variable to count the available exits
                int nExits = 0;

                // Go through each neighbor of the current room
                foreach((int,int) neighbor in neighbors)
                {
                    // if the player's health is greater than the cost of the neighboring room
                    if(health > neighbor.Item2)
                    {
                        // Display the room and cost
                        Console.WriteLine("There is an exit to room " + (char)('A' + neighbor.Item1) + " which costs " + neighbor.Item2 + " HP");

                        // count how many exits are available
                        ++nExits;
                    }
                }

                // Display current health
                Console.WriteLine("You have: " + health + " HP");
                Console.WriteLine();

                sResponse = null;
                // ask player if they want to wager for health (w), leave (l), or change state (c) if nExits > 0

                if (nExits > 0)
                {
                    while(sResponse != "l" && sResponse != "w" && sResponse != "c")
                    {
                        // prompt for w or l
                        Console.Write("Would you like to wager for more health, change state or leave the room");

                        // grab the first letter of user's response
                        sResponse = Console.ReadLine().ToLower()[0].ToString();
                    }
                }
                else
                {
                    // since there are no exits, the player must wager
                    sResponse = "w";
                }

                // if player wants to change state, change the state and decrease health
                if(sResponse == "c")
                {
                    {
                        if(playerState == (int)NodeState.ice)
                        {
                            playerState = (int)NodeState.liquid_gas;
                        }
                        else if (playerState == (int)NodeState.liquid_gas)
                        {
                            playerState = (int)NodeState.gas;
                        }
                        else if (playerState == (int)NodeState.gas)
                        {
                            playerState = (int)NodeState.liquid_ice;
                        }
                        else if (playerState == (int)NodeState.liquid_ice)
                        {
                            playerState = (int)NodeState.ice;
                        }
                    }

                    health--;
                }

                // if the player wants to leave
                if(sResponse == "l")
                {
                    bValid = false;
                    string sDirection;

                    while (!bValid)
                    {
                        // Ask which room
                        Console.Write("Which room letter: ");

                        // read the user's input
                        sDirection = Console.ReadLine().ToUpper()[0].ToString();

                        int nCost = 0;

                        // go through the room's neighbors
                        foreach((int, int) neighbor in neighbors)
                        {
                            // if the player can access this room, set bValid to true
                            if((sDirection[0] - 'A') == neighbor.Item1 && health > neighbor.Item2)
                            {
                                nCost = neighbor.Item2;
                                bValid = true;
                                break;
                            }
                        }

                        // reduce the player's health by the cost and change the currentPlayerPos to the neighbor
                        if (bValid)
                        {
                            lock (lockObject)
                            {
                                if (stateList[(sDirection[0] - 'A')] == playerState)
                                {
                                    health -= nCost;

                                    currentPlayerPos = sDirection[0] - 'A';

                                    break;
                                }
                            }
                        }

                        if (!bValid)
                        {
                            Console.WriteLine("That isn't a valid direction");
                            Console.WriteLine();
                        }
                    }
                }

                else
                {
                    // otherwise the player wants to wager

                    // set variables for Trivia API
                    string url = null;
                    string s = null;

                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader reader;

                    url = "https://opentdb.com/api.php?amount=1&type=multiple";

                    request = (HttpWebRequest)WebRequest.Create(url);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    s = reader.ReadToEnd();
                    reader.Close();

                    Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);


                    trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                    trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
                    {
                        trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                    }

                    // prompt for wager amount and make sure they have enough health
                    string sWager = null;
                    int nWager = 0;

                    do
                    {
                        Console.Write("Enter how much of your HP to wager: ");
                        sWager = Console.ReadLine();
                    } while (!int.TryParse(sWager, out nWager) || (nWager < 0) || (nWager > health));

                    // ask question
                    Console.WriteLine(trivia.results[0].question);

                    // choose random answer spot
                    int nAnswer = rand.Next(trivia.results[0].incorrect_answers.Count + 1);
                    int nWrongCntr = 0;

                    // output the correct answer in random position
                    // prefix each with 1-N to allow player to answer with N
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count + 1; ++i)
                    {
                        if (i == nAnswer)
                        {
                            // if this is the correct answer to show
                            Console.WriteLine($"{i + 1}: {trivia.results[0].correct_answer}");
                        }
                        else
                        {
                            // show the incorrect answers
                            Console.WriteLine($"{i + 1}: {trivia.results[0].incorrect_answers[nWrongCntr]}");
                            ++nWrongCntr;
                        }
                    }

                    // increment the answer to be 1-based instead of 0-based
                    ++nAnswer;

                    // 15 second timer
                    qTimer = new Timer(15000);

                    // use an anonymous method via a lambda expression to catch the lapsed timer event
                    qTimer.Elapsed += (o, e) => { bElapsed = true; qTimer.Stop(); Console.WriteLine("Time's up. Press enter."); };

                    qTimer.Start();

                    Console.Write("==> ");
                    string sAnswer = Console.ReadLine();

                    qTimer.Stop();

                    sAnswer = nAnswer.ToString();

                    // if an incorrect answer
                    if (sAnswer != nAnswer.ToString() || bElapsed)
                    {
                        Console.WriteLine($"Wrong!  The answer was {nAnswer}.");
                        health -= nWager;
                    }
                    else
                    {
                        Console.WriteLine("Correct! You are stronger!");
                        health += nWager;
                    }

                }

            }

            Console.WriteLine("You escaped the maze with " + health + " HP!");
        
        }
               

        static void ChangeNodeStates(object sender, ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                for (int i = 0; i < stateList.Length; ++i)
                {
                    if (stateList[i] == (int)NodeState.ice)
                    {
                        stateList[i] = (int)NodeState.liquid_gas;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_gas)
                    {
                        stateList[i] = (int)NodeState.gas;
                    }
                    else if (stateList[i] == (int)NodeState.gas)
                    {
                        stateList[i] = (int)NodeState.liquid_ice;
                    }
                    else if (stateList[i] == (int)NodeState.liquid_ice)
                    {
                        stateList[i] = (int)NodeState.ice;
                    }
                }
            }
            
        }
    }
}
