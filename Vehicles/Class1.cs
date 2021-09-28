using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Class Library: Vehicles
// Author: Zachary Erickson
// Purpose: Create a library for vehicles
// Restrictions: None
namespace Vehicles
{

    //[+A:Vehicle||+LoadPassenger():v]
    public abstract class Vehicle
    {
        public virtual void LoadPassenger()
        {

        }
    }
    //[+I:IPassengerCarrier||LoadPassenger()]
    public interface IPassengerCarrier
    {
        void LoadPassenger();
    }

    //[+I:HeavyLoadCarrier||]
    public interface IHeavyLoadCarrier
    {

    }
    //[+A:Car||]
    public abstract class Car : Vehicle
    {

    }

    //[+A:Train||]
    public abstract class Train : Vehicle
    {

    }

    //[+Compact||]
    public class Compact : Car, IPassengerCarrier
    {

    }
    //[+SUV||]
    public class SUV : Car, IPassengerCarrier
    {


    }
    //[+Pickup||]
    public class Pickup: Car, IPassengerCarrier, IHeavyLoadCarrier
    {

    }
    //[+PassengerTrain||]
    public class PassengerTrain: Train, IPassengerCarrier
    {

    }
    //[+FreightTrain||]
    public class FreightTrain: Train, IHeavyLoadCarrier
    {

    }
    //[+_424DoubleBogey||]
    public class _424DoubleBogey : Train, IHeavyLoadCarrier
    {

    }


}
