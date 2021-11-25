using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// Author: Zachary Erickson
// Purpose: Unit Test 3 Question 7

namespace Unit_Test_3_Question_7
{
    // Class: Wizard
    // Purpose: Has a name and age
    public class Wizard
    {
        private string name;
        private int age;

        public Wizard(string name, int age)
        {          
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return name; }
        }
        public int Age
        {
            get { return age; }
        }
    }

    // Class: Program
    // Purpose: Creates comparison delegate method and uses it to compare Wizards
    class Program
    {

        // Method: CompareWizard
        // Purpose: Uses Wizard's ages to create the comparison for List.Sort()
        public static int CompareWizard(Wizard wiz1, Wizard wiz2)
        {
            if(wiz1.Age > wiz2.Age)
            {
                return 1;
            }
            else if(wiz1.Age < wiz2.Age)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        // Method: Main
        // Purpose: Creates several wizards, adds them to a wizard list, and sorts the list
        static void Main(string[] args)
        {

            // Creates wizardList
            List<Wizard> wizList = new List<Wizard>();

            // Create several wizards with ages and names
            Wizard w0 = new Wizard("Merlin", 16);
            Wizard w1 = new Wizard("Gandalf", 24000);
            Wizard w2 = new Wizard("Glinda", 24);
            Wizard w3 = new Wizard("Yoda", 900);
            Wizard w4 = new Wizard("Albus Dumbledore", 150);
            Wizard w5 = new Wizard("Morgana Le Fay", 84);
            Wizard w6 = new Wizard("Rand al'Thor", 20);
            Wizard w7 = new Wizard("Harry Dresden", 37);
            Wizard w8 = new Wizard("Elric", 42);
            Wizard w9 = new Wizard("Prospero", 28);


            // Adds each wizard to the wizList
            wizList.Add(w0);
            wizList.Add(w1);
            wizList.Add(w2);
            wizList.Add(w3);
            wizList.Add(w4);
            wizList.Add(w5); 
            wizList.Add(w6);
            wizList.Add(w7);
            wizList.Add(w8);
            wizList.Add(w9);


            // Prints the wizList before sorting
            Console.WriteLine("Unsorted Wizard List:");

            foreach(Wizard wiz in wizList)
            {
                Console.WriteLine("Name: " + wiz.Name + " Age: " + wiz.Age);
            }


            // Uses the Comparison to sort the list
            wizList.Sort(CompareWizard);

            Console.WriteLine();

            // Prints the Sorted wizList
            Console.WriteLine("Sorted Wizard List:");

            foreach (Wizard wiz in wizList)
            {
                Console.WriteLine("Name: " + wiz.Name + " Age: " + wiz.Age);
            }
        }
    }
}
