using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_3_Question_7
{

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

    class Program
    {

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

        static void Main(string[] args)
        {
            List<Wizard> wizList = new List<Wizard>();

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


            Console.WriteLine("Unsorted Wizard List:");

            foreach(Wizard wiz in wizList)
            {
                Console.WriteLine("Name: " + wiz.Name + " Age: " + wiz.Age);
            }


            wizList.Sort(CompareWizard);

            Console.WriteLine();
            Console.WriteLine("Sorted Wizard List:");

            foreach (Wizard wiz in wizList)
            {
                Console.WriteLine("Name: " + wiz.Name + " Age: " + wiz.Age);
            }
        }
    }
}
