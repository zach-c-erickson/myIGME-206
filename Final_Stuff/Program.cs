using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using System.Timers;
using System.Diagnostics;


namespace FinalExam
{
    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

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
        enum NodeState
        {
            ice,
            liquid_gas,
            gas,
            liquid_ice
        }


        // Adjacency List (neighbor index, cost)
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

        static void Q1()
        {
            string sSentence = null;
            //SortedList<char, int> charCount = new SortedList<char, int>();
            int[] charCount = new int[26];

            Random rand = new Random();

            //Console.Write("Enter a sentence: ");
            //sSentence = Console.ReadLine();

            for (int i = 0; i < 200000; ++i)
            {
                sSentence += (char)(rand.Next(26) + 'a');
            }

            foreach (char c in sSentence.ToLower())
            {
                if (Char.IsLetter(c))
                {
                    ++charCount[c - 'a'];

                    //if (charCount.ContainsKey(c))
                    //{
                    //    ++charCount[c];
                    //}
                    //else
                    //{
                    //    charCount[c] = 1;
                    //}
                }
            }

            Console.WriteLine("Character counts:");

            for (int i = 0; i < charCount.Length; ++i)
            {
                Console.WriteLine($"{(char)(i + 'a')}: {charCount[i]}");
            }

            //foreach (KeyValuePair<char, int> kvp in charCount)
            //{
            //    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            //}

        }

        static void Main(string[] args)
        {
            Q1();

            Q3();
        }

        static Timer sTimer;
        static Timer qTimer;
        static bool bTimedOut;
        static Object lockObject = new object();

        static void Q3()
        {
            Random rand = new Random();


            int nRoom = 0;

            int playerHp = 5;
            int playerState = (int)NodeState.ice;

            string[] desc = new string[]
            {
                "room A desc",
                "room B desc",
                "room C desc",
                "room D desc",
                "room E desc",
                "room F desc",
                "room G desc",
                "room H desc"
            };

            sTimer = new Timer(1000);
            sTimer.Elapsed += ChangeNodeStates;

            qTimer = new Timer(15000);


            // describe that there are rooms A-H, and the initial state of each room and how they change state every second

            // ask player to start the game

            sTimer.Start();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();



            // nRoom keeps track of which room the player is in A=0, H=7
            // while not in room H (the exit)
            while (nRoom != 7)
            {

                // display a desc of the room
                Console.WriteLine(desc[nRoom]);

                // display the current state of the player

                // display any exits from the room
                // the neighbors of the current room are stored as an array of tuples
                // storing the neighbor index (0-7), the available direction (eg. "N"), and the cost of the exit
                // fetch the array of neighbors for the current room
                (int, int)[] thisRoomsNeighbors = listGraph[nRoom];

                int nExits = 0;

                // check each neighbor of the current room to see if it's available
                foreach ((int, int) neighbor in thisRoomsNeighbors)
                {
                    // if the player's HP is greater than the cost of the exit
                    if (playerHp > neighbor.Item2)
                    {
                        // display the exit
                        Console.WriteLine("There is an exit to room " + (char)('A' + neighbor.Item1) + " which costs " + neighbor.Item2 + " HP");

                        // count how many exits are available
                        ++nExits;
                    }
                }

                // display the hp
                Console.WriteLine($"You have {playerHp} HP");

                // ask the player if they want wager (w) for more hp or leave (l) or change state (c) the room only if there are nExits > 0
                string sResponse = null;

                // if there are exits available
                if (nExits > 0)
                {
                    while (sResponse != "l" && sResponse != "w" && sResponse != "c")
                    {
                        // prompt for w or l
                        Console.Write("Would you like to wager for more health, change state or leave the room? ");

                        // grab the first character and lowercase it
                        sResponse = Console.ReadLine().ToLower()[0].ToString();
                    }
                }
                else
                {
                    // they need to wager, there are no exits
                    sResponse = "w";
                }

                // only if more than 1 HP
                if (sResponse.ToLower() == "c")
                {

                    {
                        if (playerState == (int)NodeState.ice)
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

                    playerHp--;

                }

                // if leaving room
                if (sResponse.ToLower() == "l" /* leaving room */ )
                {
                    // initialize that the direction is invalid
                    bool bValid = false;
                    string sDirection;

                    while (!bValid)
                    {
                        Console.Write("Which room letter: ");

                        // read the first char of the direction
                        sDirection = Console.ReadLine().ToUpper()[0].ToString();

                        int nCost = 0;

                        foreach ((int, int) neighbor in thisRoomsNeighbors)
                        {
                            // if the player's HP is greater than the cost of the exit
                            if ((sDirection[0] - 'A') == neighbor.Item1 && playerHp > neighbor.Item2)
                            {
                                nCost = neighbor.Item2;
                                bValid = true;
                                break;
                            }
                        }

                        if (bValid)
                        {
                            lock (lockObject)
                            {
                                if (stateList[(sDirection[0] - 'A')] == playerState)
                                {
                                    // deduct the HP
                                    playerHp -= nCost;

                                    // move to the room
                                    nRoom = sDirection[0] - 'A';

                                    break;
                                }
                            }
                        }

                        // indicate invalid direction chosen
                        if (!bValid)
                        {
                            Console.WriteLine("That isn't a valid direction");
                        }
                    }
                }
                else
                {
                    // otherwise grinding for HP

                    // trivia question
                    // fetch api
                    // 15 second limit to answer
                    // multiple choice 1-4

                    // ask player how much HP to wager (limited to playerHp)

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

                    // prompt for wager amount
                    string sWager = null;
                    int nWager = 0;

                    do
                    {
                        Console.Write("Enter how much of your HP to wager: ");
                        sWager = Console.ReadLine();
                    } while (!int.TryParse(sWager, out nWager) || (nWager < 0) || (nWager > playerHp));

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
                    qTimer.Elapsed += (o, e) => { bTimedOut = true; qTimer.Stop(); Console.WriteLine("Time's up. Press enter."); };

                    qTimer.Start();

                    Console.Write("==> ");
                    string sAnswer = Console.ReadLine();

                    qTimer.Stop();

                    sAnswer = nAnswer.ToString();

                    // if an incorrect answer
                    if (sAnswer != nAnswer.ToString() || bTimedOut)
                    {
                        Console.WriteLine($"Wrong!  The answer was {nAnswer}.");
                        playerHp -= nWager;
                    }
                    else
                    {
                        Console.WriteLine("Correct! You are stronger!");
                        playerHp += nWager;
                    }
                }
            }

            Console.WriteLine($"You escaped the maze with {playerHp} HP!");

            stopwatch.Stop();
            Console.WriteLine("Time for 10,000 generations: {0}ms\n {1} generations per second",
                        stopwatch.ElapsedMilliseconds, 10000000 / stopwatch.ElapsedMilliseconds);

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

        public interface IPlayerSettings
        {
            public void SavePlayerSettings(string fileName, PlayerSettings settings);
            public PlayerSettings LoadPlayerSettings(string fileName);
        }

        public class PlayerSettings
        {
            public string player_name;
            public int level;
            public int hp;
            public string[] inventory;
            public string license_key;
        }

        // {"player_name":"dschuh","level":4,"hp":99,"inventory":["spear","water bottle","hammer","sonic screwdriver","cannonball","wood","Scooby snack","Hydra","poisonous potato","dead bush","repair powder"],"license_key":"DFGU99-1454"}

        // eager loading singleton
        public class SettingsClass : IPlayerSettings
        {
            private static SettingsClass instance = new SettingsClass();

            private SettingsClass()
            {

            }

            public static SettingsClass GetInstance()
            {
                return instance;
            }

            public void SavePlayerSettings(string fileName, PlayerSettings settings)
            {
                string sSettings;

                // refer to 20 Questions if any problem
                sSettings = JsonConvert.SerializeObject(settings);

                // write sSettings to fileName
            }

            public PlayerSettings LoadPlayerSettings(string fileName)
            {
                string sSettings = null;

                // read fileName to sSettings
                PlayerSettings settings;

                settings = JsonConvert.DeserializeObject<PlayerSettings>(sSettings);
                return settings;
            }
        }

        static void Q4()
        {
            PlayerSettings settings = new PlayerSettings();

            SettingsClass settingsFunctions = SettingsClass.GetInstance();

            settings = settingsFunctions.LoadPlayerSettings("c:/settings.json");
            settingsFunctions.SavePlayerSettings("c:/settings.json", settings);

        }
    }
}