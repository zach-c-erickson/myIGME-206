using System;

namespace UT1_BugSquash
{
    // Class: Program
    // Editor: Zachary Erickson
    // Purpose: Bug squashing exercise
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;

            //int nY
            //Compile-time Error: need semi-colon
            int nY;

            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);
            //Compile-time Error: Need quotes around eveything in the parentheses
            Console.WriteLine("This program calculates x ^ y.");
            do
            {
                Console.Write("Enter a whole number for x: ");

                //Console.ReadLine();
                //Logical Error: need to set sNumber equal to user input
                sNumber = Console.ReadLine();

            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                //} while (int.TryParse(sNumber, out nX));
                //Logical Error: must use nY instead of nX and must be !int.TryParse
            } while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);


            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            //Logical Error: need to include the values that go between brackets

            Console.WriteLine("{0}^{1} = {2}", nX,nY,nAnswer);
        }


        // int Power(int nBase, int nExponent)
        // Compile-time error: needs to be static so it can be used in main method
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0;
                //Logical Error: must save returnVal as 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1);
                //Run-time Error: Need to call nExponent - 1 as the second parameter
                nextVal = Power(nBase, nExponent + 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal;
            //Compile-time Error: must return this value
            return returnVal;
        }
    }
}

