using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test_Question_10
{
    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Unit Test Question 10
    class Program
    {
        // Method: Main
        // Purpose: Create a Bloodhound and Valkyrie object and call MyMethod on both
        static void Main(string[] args)
        {
            Bloodhound legend1 = new Bloodhound();
            Valkyrie legend2 = new Valkyrie();

            MyMethod(legend1);
            MyMethod(legend2);
        }

        // Method: MyMethod
        // Purpose: Takes an object as a parameter and calls methods associated with the object
        static void MyMethod(object obj)
        {
            // Cast object as a Legend
            ReconLegend reconLegend = (ReconLegend)obj;

            // Cast object as an ILegend
            ILegend iLegend = (ILegend)obj;

            // Cast object as an IEmote
            IEmote iEmote = (IEmote)obj;

            // Call methods associated with the abstract class ReconLegend
            reconLegend.Shoot();
            reconLegend.Jump();

            // Call methods associated with ILegend
            iLegend.Passive();
            iLegend.Tactical();
            iLegend.Ultimate();

            // Call method associated with IEmote
            iEmote.Emote();
            
        }
    }

    // [+I:ILegend| Tactical(); Ultimate(); Passive()]
    public interface ILegend
    {
        void Tactical();
        void Ultimate();
        void Passive();
    }

    // [+I:IEmote| Emote()]
    public interface IEmote
    {
        void Emote();     
    }

    // [+A:ReconLegend| -legendType:string| +LegendType:r; +Shoot():a; +Jump():v| +(myString:string) ]
    public abstract class ReconLegend
    {
        private string legendType = "Recon";

        public string LegendType
        {
            get { return legendType; }
            
        }
        public abstract void Shoot();
        public virtual void Jump()
        {
            Console.WriteLine("Jump in air");
        }

        
    }

    // [+Bloodhound| -name:string | +name:string:r; +Tactical(); +Ultimate(); +Passive();
    // +Emote(); +Shoot():o]
    // [+A:ReconLegend] <-.- [+Bloodhound]
    // [+I:ILegend] ^ [+Bloodhound]
    // [+I:IEmote] ^ [+Bloodhound]
    public class Bloodhound : ReconLegend, ILegend, IEmote
    {
        private string name = "Bloodhound";
       

        public string Name
        {
            get { return name; }
        }
        

        public void Tactical()
        {
            Console.WriteLine("Scanning for enemies...");
        }

        public void Ultimate()
        {
            Console.WriteLine("Entering Beast of the Hunt...");
        }

        public void Passive()
        {
            Console.WriteLine("Tracking Enemies...");
        }

        public  void Emote()
        {
            Console.WriteLine("Smell the dirt...");
        }
        public override void Shoot()
        {
            Console.WriteLine("Fire!");
        }
      
       

    }
    // [+Valkyrie| -name:string | +name:string:r; +Tactical(); +Ultimate(); +Passive();
    // +Emote(); +Shoot():o; +Jump():o]
    // [+A:ReconLegend] <-.- [+Valkyrie]
    // [+I:ILegend] ^ [+Valkyrie]
    // [+I:IEmote] ^ [+Valkyrie]
    public class Valkyrie : ReconLegend, ILegend, IEmote
    {
        private string name = "Valkyrie";
        
        public string Name
        {
            get { return name; }
        }

        public void Tactical()
        {
            Console.WriteLine("Launching Barrage...");
        }

        public void Ultimate()
        {
            Console.WriteLine("Taking Off...");
        }

        public void Passive()
        {
            Console.WriteLine("Scan Beacon...");
        }
        public void Emote()
        {
            Console.WriteLine("Do a barrel roll!...");
        }
        public override void Shoot()
        {
            Console.WriteLine("Fire!");
        }
       
        public override void Jump()
        {
            Console.WriteLine("Hold spacebar to fly...");
        }
        
    }
}
