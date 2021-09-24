using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Question_13
{
    
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Unit test question 13
    // Restrictions: None
    class Program
    {
        // Struct: employee
        // Purpose: Hold information for name and salary of an employee
        struct employee
        {
            public string name;
            public double dSalary;
        }

        // Method: Main
        // Purpose: Prompt user for name and give a raise if their name is Zach
        // Restrictions: None
        static void Main(string[] args)
        {
            

            // create new employee and set salary
            employee testEmployee;
            testEmployee.dSalary = 30000;


            // prompt for user name and save as employee's name
            Console.Write("What is your name? : ");
            testEmployee.name = Console.ReadLine();
                       

            // call GiveRaise method and if true, congratulate and display new salary
            if (GiveRaise(ref testEmployee))
            {
                Console.WriteLine("Congratulations! Your new salary is {0}", testEmployee.dSalary);
            }
            else { Console.WriteLine("No raise for you! Your salary is {0}", testEmployee.dSalary); }
        }

        // Method: GiveRaise
        // Purpose: call employee struct to find if name == zach, if true, raise salary.
        // Restrictions: None
        static bool GiveRaise(ref employee employee)
        {
            if (employee.name.ToLower() == "zach")
            {
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
