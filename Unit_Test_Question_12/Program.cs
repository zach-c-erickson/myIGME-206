using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Question_12
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Unit test question 12
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Prompt user for name and give a raise if their name is Zach
        // Restrictions: None
        static void Main(string[] args)
        {
            // save string for user input
            string sName;

            // double for salary
            double dSalary = 30000;

            // prompt for user name and save as sName
            Console.Write("What is your name? : ");
            sName = Console.ReadLine();

            // call GiveRaise method and if true, congratulate and display new salary
            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations! Your new salary is {0}", dSalary);
            }
            else { Console.WriteLine("No raise for you! Your salary is {0}", dSalary); }


        }


        // Method: GiveRaise
        // Purpose: If name is zach, add 19999.99 to salary and return true,
        //          else, return false
        // Restrictions: None
        static bool GiveRaise(string name, ref double salary)
        {
            if (name.ToLower() == "zach")
            {
                salary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
