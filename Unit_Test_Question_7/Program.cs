using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Question_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Tardis myTardis = new Tardis();
            PhoneBooth myPhoneBooth = new PhoneBooth();

            UsePhone(myTardis);
            UsePhone(myPhoneBooth);
        }
        static void UsePhone(object obj)
        {
            PhoneInterface myPhoneInterface = null;

            myPhoneInterface = (PhoneInterface)obj;

            myPhoneInterface.MakeCall();
            myPhoneInterface.HangUp();

            if(obj.GetType() == typeof(Tardis))
            {
                Tardis obj1 = new Tardis();
                obj1.TimeTravel();
            }
            if(obj.GetType() == typeof(PhoneBooth))
            {
                PhoneBooth obj2 = new PhoneBooth();
                obj2.OpenDoor();
            }
        }
    }

   


    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();

    }

    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber;

        public abstract void Connect();

        public abstract void Disconnect();


    }

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

        public static bool operator == (Tardis tardis1, Tardis tardis2)
        {
            return (tardis1.WhichDrWho == tardis2.WhichDrWho);
        }
        public static bool operator != (Tardis tardis1, Tardis tardis2)
        {
            return (tardis1.WhichDrWho != tardis2.WhichDrWho);
        }
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
