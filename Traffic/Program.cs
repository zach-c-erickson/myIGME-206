using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;


namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            Compact myCompact = new Compact();
            FreightTrain myFreightTrain = new FreightTrain();
            SUV mySUV = new SUV();

            AddPassenger(myCompact);
            AddPassenger(mySUV);
            AddPassenger(myFreightTrain);
        }

        public static void AddPassenger(object obj)
        {
            IPassengerCarrier passengerCarrier;

            passengerCarrier = (IPassengerCarrier)obj;

            passengerCarrier.LoadPassenger();

            
                Console.WriteLine(obj.ToString());
            
            
        }
    }
}
