using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;


namespace Traffic
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 11 question 6
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Create instances of vehicle classes and call AddPassenger
        // Restrictions: None
        static void Main(string[] args)
        {
            // create new compact, freight train and SUV
            Compact myCompact = new Compact();
            FreightTrain myFreightTrain = new FreightTrain();
            SUV mySUV = new SUV();

            // call AddPassenger to each
            AddPassenger(myCompact);
            AddPassenger(mySUV);
            AddPassenger(myFreightTrain);
        }

        // Method: AddPassenger
        // Purpose: Call LoadPassenger to object and call WriteLine on the object
        // Restrictions: None
        public static void AddPassenger(object obj)
        {
            IPassengerCarrier passengerCarrier;

            passengerCarrier = (IPassengerCarrier)obj;

            passengerCarrier.LoadPassenger();

            
            Console.WriteLine(obj.ToString());
            
            
        }
    }
}
