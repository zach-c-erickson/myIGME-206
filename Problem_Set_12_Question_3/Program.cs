using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_12_Question_3
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 12 Question 3
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Create an instance of MyDerivedClass and call the GetString Method.
        static void Main(string[] args)
        {
            // create instance of MyDerivedClass
            MyDerivedClass myDerivedClass = new MyDerivedClass();

            // write the output of GetString()
            Console.WriteLine(myDerivedClass.GetString());

        }
    }


    // Class : MyClass
    // Purpose: class with private string field, a write-only string property,
    // and a GetString Method
    public class MyClass
    {
        // private string field
        private string myString = "banana";

        // public string property
        public string MyString
        {
            // allows to set myString
            set
            {
                myString = value;
            }
        }

        // returns string field
        public virtual string GetString()
        {
            return myString;
        }
    }

    // Class: MyDerivedClass
    // Purpose: Inherited from MyClass, GetString() grabs the myString variable
    // from MyClass and adds extra text.
    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }
    }
}
