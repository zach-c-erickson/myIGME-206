using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_21
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 21
    class Program
    {

        // implementation of the adjacency matrix

        static int[,] mGraph = new int[,]
        {

                        /* A */  /* B */  /* C */  /* D */  /* E */  /* F */  /* G */  /* H */
            /* A */     {  0,       2,       -1,      -1,      -1,      -1,      -1,      -1 },
            /* B */     { -1,      -1,        2,       3,      -1,      -1,      -1,      -1 },
            /* C */     { -1,       2,       -1,      -1,      -1,      -1,      -1,      20 },
            /* D */     { -1,       3,        5,      -1,       2,       4,      -1,      -1 },
            /* E */     { -1,      -1,       -1,      -1,      -1,       3,      -1,      -1 },
            /* F */     { -1,      -1,       -1,      -1,      -1,      -1,       1,      -1 },
            /* G */     { -1,      -1,       -1,      -1,       0,      -1,      -1,       2 },
            /* H */     { -1,      -1,       -1,      -1,      -1,      -1,      -1,      -1 }

        };

        // implementation of parallel adjacency lists
        static int[][] lGraph = new int[][]
        {
            /* A */ new int[] {0, 1},           // {A, B}
            /* B */ new int[] {2, 3},           // {C, D}
            /* C */ new int[] {1, 7},           // {B, H}
            /* D */ new int[] {1, 2, 4, 5},     // {B, C, E, F}
            /* E */ new int[] {5},              // {F}
            /* F */ new int[] {6},              // {G}
            /* G */ new int[] {4, 7},           // {E, H}
            /* H */ new int[] { },               // { }
        };

        // store the edge weights
        static int[][] wGraph = new int[][]
        {
            /* A */ new int[] {0, 2},
            /* B */ new int[] {2, 3},
            /* C */ new int[] {2, 20},
            /* D */ new int[] {3, 5, 2, 4},
            /* E */ new int[] {3},
            /* F */ new int[] {1},
            /* G */ new int[] {0, 2},
            /* H */ new int[] {},
        };

        // make the readable sorted list
        static SortedList<(string, string), int> slMatrix = new SortedList<(string, string), int>();

        static void Main(string[] args)
        {
            slMatrix[("A", "A")] = 0;
            slMatrix[("A", "B")] = 2;
            slMatrix[("A", "C")] = -1;
            slMatrix[("A", "D")] = -1;
            slMatrix[("A", "E")] = -1;
            slMatrix[("A", "F")] = -1;
            slMatrix[("A", "G")] = -1;
            slMatrix[("A", "H")] = -1;

            slMatrix[("B", "A")] = -1;
            slMatrix[("B", "B")] = -1;
            slMatrix[("B", "C")] = 2;
            slMatrix[("B", "D")] = 3;
            slMatrix[("B", "E")] = -1;
            slMatrix[("B", "F")] = -1;
            slMatrix[("B", "G")] = -1;
            slMatrix[("B", "H")] = -1;

            slMatrix[("C", "A")] = -1;
            slMatrix[("C", "B")] = 2;
            slMatrix[("C", "C")] = -1;
            slMatrix[("C", "D")] = -1;
            slMatrix[("C", "E")] = -1;
            slMatrix[("C", "F")] = -1;
            slMatrix[("C", "G")] = -1;
            slMatrix[("C", "H")] = 20;

            slMatrix[("D", "A")] = -1;
            slMatrix[("D", "B")] = 3;
            slMatrix[("D", "C")] = 5;
            slMatrix[("D", "D")] = -1;
            slMatrix[("D", "E")] = 2;
            slMatrix[("D", "F")] = 4;
            slMatrix[("D", "G")] = -1;
            slMatrix[("D", "H")] = -1;

            slMatrix[("E", "A")] = -1;
            slMatrix[("E", "B")] = -1;
            slMatrix[("E", "C")] = -1;
            slMatrix[("E", "D")] = -1;
            slMatrix[("E", "E")] = -1;
            slMatrix[("E", "F")] = 3;
            slMatrix[("E", "G")] = -1;
            slMatrix[("E", "H")] = -1;

            slMatrix[("F", "A")] = -1;
            slMatrix[("F", "B")] = -1;
            slMatrix[("F", "C")] = -1;
            slMatrix[("F", "D")] = -1;
            slMatrix[("F", "E")] = -1;
            slMatrix[("F", "F")] = -1;
            slMatrix[("F", "G")] = 1;
            slMatrix[("F", "H")] = -1;

            slMatrix[("G", "A")] = -1;
            slMatrix[("G", "B")] = -1;
            slMatrix[("G", "C")] = -1;
            slMatrix[("G", "D")] = -1;
            slMatrix[("G", "E")] = 0;
            slMatrix[("G", "F")] = -1;
            slMatrix[("G", "G")] = -1;
            slMatrix[("G", "H")] = 2;

            slMatrix[("H", "A")] = -1;
            slMatrix[("H", "B")] = -1;
            slMatrix[("H", "C")] = -1;
            slMatrix[("H", "D")] = -1;
            slMatrix[("H", "E")] = -1;
            slMatrix[("H", "F")] = -1;
            slMatrix[("H", "G")] = -1;
            slMatrix[("H", "H")] = -1;

            
            // Just for fun, wanted to draw the matrix in the console

            string myString = "       A    B    C    D    E    F    G    H\n\n";

            // Goes through each combination of letters and uses ASCII to convert to letter
            for (int i = 0; i < 8; ++i)
            {
                char char1 = Convert.ToChar(i + 65);

                string string1 = char1.ToString();

                myString += " " + string1;

                for (int j = 0; j < 8; ++j)
                {
                    char char2 = Convert.ToChar(j + 65);

                    string string2 = char2.ToString();

                    int myInt = slMatrix[(string1, string2)];

                    if(j == 0)
                    {
                        if (myInt >= 0 && myInt < 10)
                        {
                            myString += "   { " + myInt;
                        }

                        else
                        {
                            myString += "   {" + myInt;
                        }
                    }
                    else
                    {
                        if (myInt >= 0 && myInt < 10)
                        {
                            myString += "    " + myInt;
                        }

                        else
                        {
                            myString += "   " + myInt;
                        }

                    }



                    if (j == 7)
                    {
                        myString += "}\n\n";
                    }
                }
            }

            Console.WriteLine(myString);


        }
    }
}
