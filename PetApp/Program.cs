using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// PetApp
// Author: Zachary Erickson
// Purpose: Problem Set 13
// Restrictions: None

namespace PetApp
{
    // Interface: ICat
    // [+ICat || Eat(), Play(), Scratch(), Purr()]
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    // Interface: IDog
    // [+IDog || Eat(), Play(), Bark(), NeedWalk(), GotoVet()]
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    // Class: Pet
    // [+A:Pet | -name:string, +age:int | +Name:string, +Eat():a, +Play():a, +GotoVet():a | (), (name:string, age:int)]
    public abstract class Pet
    {
        private string name;
        public int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public abstract void Eat();

        public abstract void Play();

        public abstract void GotoVet();

        public Pet()
        {
        
        }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    // Class: Cat
    // [+Cat || +Eat():o, +Play():o, +Purr(), +Scratch(), +GotoVet():o | ()] 
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine("Meow, yummy!");

        }
        public override void Play()
        {
            Console.WriteLine("Mew, bring out the yarn!");
        }

        public override void GotoVet()
        {
            Console.WriteLine("Hisss, you can;t make me go!");
        }

        public void Purr()
        {
            Console.WriteLine("purrrrrrrrrrr");
        }
        public void Scratch()
        {
            Console.WriteLine("purr, thank you!");
        }

    }

    // Class: Dog
    // [+Dog | +license:string | +Eat():o, +Play():o, +Bark(), +NeedWalk(), +GotoVet():o | (szLicense:string, szName:string, nAge:int):base(szName, nAge)]
    public class Dog : Pet, IDog
    {
        public string license;

        public override void Eat()
        {
            Console.WriteLine("Woof, yum yum!");
        }
        public override void Play()
        {
            Console.WriteLine("Woof, Woof! I love to play!");
        }

        public override void GotoVet()
        {
            Console.WriteLine("Bark!! I hate the vet!");
        }

        public void Bark()
        {
            Console.WriteLine("BARK! BARK BARK!");
        }

        public void NeedWalk()
        {
            Console.WriteLine("Arf, let's walk to the park!"); 
        }

        public Dog(string szLicense, string szName, int nAge):base(szName, nAge) { }
    }

    // Class: Pets
    // [+Pets | +petList:List<Pet> | +this:int petEI, +Count:int:r, +Add(pet:Pet), +Remove(pet:Pet), +RemoveAt(petEI:int)]

    public class Pets
    {
        public List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count
        {
            get
            {
                return petList.Count();
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }

        public void RemoveAt(int petEI)
        {
            petList.RemoveAt(petEI);
        }


    }

    // Class: Program
    class Program
    {
        // Method: Main
        // Purpose: Proceed through a loop 50 times. There is a 10% chance that the user will be prompted for a new pet's name, age (and license for dogs).
        // These pets will be added to petList. There is a 90% chance that a method will be called based on a random pet in petList.
        static void Main(string[] args)
        {
            // Initialize pet, interface variables
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            // Initialize Pets class instance
            Pets pets = new Pets();

            // Create new random
            Random rand = new Random();

            // Go through a loop 50 times
            for(int i = 0; i < 50; i++)
            {
                // pick a random number between 1 and 11, exclusive. If it is 1, create a new animal
                if (rand.Next(1,11) == 1)
                {
                    // pick another random number between 0 and 2, exclusive. If 0, create a new dog.
                    if (rand.Next(0,2) == 0)
                    {

                        // Prompt for dog's name, age and license and save them as variables.
                        Console.WriteLine("You bought a dog!");
                        Console.Write("Dog's Name => ");

                        string sName = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("Age => ");

                        string sAge = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("License => ");

                        string sLicense = Console.ReadLine();

                        int.TryParse(sAge, out int thisAge);

                        // create a new dog using the user prompts
                        dog = new Dog(sLicense, sName, thisAge);

                        // add new dog to pets.petList
                        pets.petList.Add(dog);

                    }

                    // If the random was 1, create a new cat
                    else
                    {
                        // prompt user for name and age and save them as variables
                        Console.WriteLine("You bought a cat!");
                        Console.Write("Cat's Name => ");

                        string sName = Console.ReadLine();

                        Console.WriteLine();
                        Console.Write("Age => ");

                        string sAge = Console.ReadLine();

                        Console.WriteLine();

                        int.TryParse(sAge, out int thisAge);

                        // create new cat and set the cat's name and age as the user prompts
                        cat = new Cat();

                        cat.age = thisAge;
                        cat.Name = sName;

                        // add new cat to pets.petList
                        pets.petList.Add(cat);
                    }
                }
                // if the original random was not 1, we will call a method
                else
                {
                    // if there are no pets in pets.petList, restart the loop
                    if (pets.Count == 0)
                    {
                        thisPet = null;
                    }
                    // if there is a pet in pets.petList, select a random pet from the list
                    else
                    {
                        int randomPetInt = rand.Next(0, pets.Count);
                        thisPet = pets.petList[randomPetInt];
                        if (thisPet == null)
                        {
                            continue;
                        }
                        else
                        {
                            // if the pet is a Dog, cast thisPet to an IDog and call a random Dog method.
                            if (thisPet.GetType() == typeof(Dog))
                            {
                                iDog = (IDog)thisPet;

                                int methodType = rand.Next(0, 4);

                                Console.Write(thisPet.Name + ": ");

                                switch (methodType)
                                {
                                    case 0:
                                        iDog.Eat();
                                        break;
                                    case 1:
                                        iDog.Play();
                                        break;
                                    case 2:
                                        iDog.Bark();
                                        break;
                                    case 3:
                                        iDog.NeedWalk();
                                        break;
                                    case 4:
                                        iDog.GotoVet();
                                        break;

                                }
                            }

                            // if the pet is a Cat, cast thisPet to an ICat and call a random Cat method.
                            else if (thisPet.GetType() == typeof(Cat))
                            {
                                iCat = (ICat)thisPet;

                                int methodType = rand.Next(0, 4);

                                Console.Write(thisPet.Name + ": ");

                                switch (methodType)
                                {
                                    case 0:
                                        iCat.Eat();
                                        break;
                                    case 1:
                                        iCat.Play();
                                        break;
                                    case 2:
                                        iCat.Purr();
                                        break;
                                    case 3:
                                        iCat.Scratch();
                                        break;
                                    case 4:
                                        thisPet.GotoVet();
                                        break;
                                }
                            }
                        }
                    }
                    
                }
            }
        }
    }


}
