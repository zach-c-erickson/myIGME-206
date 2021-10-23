using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Question_7
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Unit Test Question 7
    class Program
    {
        // Method: Main
        // Purpose: Creates a Tardis object and a Phonebooth object and calls UsePhone() on both
        static void Main(string[] args)
        {
            Tardis myTardis = new Tardis();
            PhoneBooth myPhoneBooth = new PhoneBooth();

            UsePhone(myTardis);
            UsePhone(myPhoneBooth);
        }
        // Method: UsePhone
        // Purpose: Uses an object as a parameter and calls PhoneInterface methods on the
        // object and calls TimeTravel() or OpenDoor() based on type
        static void UsePhone(object obj)
        {
            // Create PhoneInterface and cast on object
            PhoneInterface myPhoneInterface = null;
            myPhoneInterface = (PhoneInterface)obj;

            // Call both PhoneInterface methods on object
            myPhoneInterface.MakeCall();
            myPhoneInterface.HangUp();

            // if obj is a Tardis, call TimeTravel()
            if(obj.GetType() == typeof(Tardis))
            {
                Tardis obj1 = (Tardis)obj;
                obj1.TimeTravel();
            }
            // if obj is a PhoneBooth, call OpenDoor()
            if (obj.GetType() == typeof(PhoneBooth))
            {
                PhoneBooth obj2 = (PhoneBooth)obj;
                obj2.OpenDoor();
            }
        }
    }

    // [+I:PhoneInterface| Answer(); MakeCall(); HangUp()]
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();

    }

    //[+A:Phone| -phoneNumber:string; +address:string| +PhoneNumber:string; +Connect():a; +Disconnect():a]
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public abstract void Connect();

        public abstract void Disconnect();


    }

    // [+RotaryPhone|| +Answer(); +MakeCall(); +HangUp(); +Connect():o; +Disconnect():o]
    // [+A:Phone] <-.- [+RotaryPhone]
    // [+I:PhoneInterface] ^ [+RotaryPhone]
    public class RotaryPhone: Phone, PhoneInterface
    {
        public void Answer() { }
       

        public void MakeCall() 
        {
            Console.WriteLine("Dialing...");
        }
     

        public void HangUp() 
        {
            Console.WriteLine("Call ended...");
        }
    

        public override void Connect() { }
     

        public override void Disconnect() { }
        

    }

    // [+Tardis| -sonicScrewdriver:bool; -whichDrWho:byte; -femaleSideKick:string; +exteriorSurfaceArea:double;
    // +interiorVolume:double | +WhichDrWho:byte:r; +FemaleSideKick:string:r; +TimeTravel()]
    // [+RotaryPhone] <-.- [+Tardis]
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;

        private byte whichDrWho;

        private string femaleSideKick;
         
        public double exteriorSurfaceArea;

        public double interiorVolume;

        public byte WhichDrWho
        {
            get { return whichDrWho; }
        }

        public string FemaleSideKick
        {
            get { return femaleSideKick; }
        }

        public void TimeTravel() 
        {
            Console.WriteLine("Time Traveling...");
        }

        // == and != can be overridden using Tardis.WhichDrWho as normal
        public static bool operator == (Tardis tardis1, Tardis tardis2)
        {
            return (tardis1.WhichDrWho == tardis2.WhichDrWho);
        }
        public static bool operator != (Tardis tardis1, Tardis tardis2)
        {
            return (tardis1.WhichDrWho != tardis2.WhichDrWho);
        }

        // < and > must take into account the cases where either of the WhichDrWho values are 10
        public static bool operator < (Tardis tardis1, Tardis tardis2)
        {
           if (tardis1.WhichDrWho == 10)
            {
                return false;
            }
           else if (tardis2.WhichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (tardis1.WhichDrWho < tardis2.WhichDrWho);
            }
     
        }
        public static bool operator > (Tardis tardis1, Tardis tardis2)
        {
            if (tardis2.WhichDrWho == 10)
            {
                return false;
            }
            else if (tardis1.WhichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (tardis1.WhichDrWho > tardis2.WhichDrWho);
            }

        }
        // <= and >= must take into account the cases where either of the WhichDrWho values are 10
        public static bool operator <= (Tardis tardis1, Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10 && tardis2.WhichDrWho != 10)
            {
                return false;
            }
            else if (tardis2.WhichDrWho == 10 && tardis1.WhichDrWho != 10)
            {
                return true;
            }
            else
            {
                return (tardis1.WhichDrWho <= tardis2.WhichDrWho);
            }

        }
        public static bool operator >= (Tardis tardis1, Tardis tardis2)
        {
            if (tardis1.WhichDrWho == 10 && tardis2.WhichDrWho != 10)
            {
                return true;
            }
            else if (tardis2.WhichDrWho == 10 && tardis1.WhichDrWho != 10)
            {
                return false;
            }
            else
            {
                return (tardis1.WhichDrWho <= tardis2.WhichDrWho);
            }

        }

    }

    // [+PushButtonPhone || +Answer(); +MakeCall(); +HangUp(); +Connect():o; +Disconnect():o]
    // [+A:Phone] <-.- [+PushButtonPhone]
    // [+I:PhoneInterface] ^ [+PushButtonPhone]
    public class PushButtonPhone:Phone, PhoneInterface
    {
        public void Answer() { }
        public void MakeCall() 
        {
            Console.WriteLine("Making Call..");
        }
        public void  HangUp() 
        {
            Console.WriteLine("Ending Call..");
        }

        public override void Connect() { }
        public override void Disconnect() { }

    }

    // [+PhoneBooth| -superMan:bool; +costPerCall:double; +phoneBook:bool | +OpenDoor(); +CloseDoor()]
    // [+PushButtonPhone] <-.- [+PhoneBooth]
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor() 
        {
            Console.WriteLine("Opening Door.");
        }
        public void CloseDoor() { }
    }
}
