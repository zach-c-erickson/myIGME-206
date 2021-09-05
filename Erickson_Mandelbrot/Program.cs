using System;

namespace Erickson_Mandelbrot
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 4, Question 6
    // Restrictions: None

    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {

        // Method: Main
        // Purpose: Receive user input for parameters in Mandelbrot Generator
        // Restrictions: None

        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {

            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            // initialize bool for do-while
            bool bValid = false;

            // initialize string for user input
            string userString = null;

            // initialize doubles for coordinate min and max values
            double userImagCoordMin = 0.0;
            double userImagCoordMax = 0.0;
            double userRealCoordMin = 0.0;
            double userRealCoordMax = 0.0;

            // initialize doubles for for-loop increments
            double imagIncrement = 0.0;
            double realIncrmement = 0.0;
          

            start:

            // prompt for custom or default parameters and make lowercase
            Console.WriteLine("Would you like to use default or custom parameters? (Type 'custom' or 'default')");
            userString = Console.ReadLine().ToLower();

            // test for default, custom, or neither
            switch (userString)
            {
                
                // in the default case, set coordinates to default coordinates
                case ("default"):
                    userImagCoordMin = -1.2;
                    userImagCoordMax = 1.2;
                    userRealCoordMin = -0.6;
                    userRealCoordMax = 1.77;
                    break;
                

                // in custom case, prompt user for each coordinate
                case ("custom"):
                    do
                    {
                        Console.Write("Enter the minimum real coordinate:");
                        userString = Console.ReadLine();


                        // save each coordinate to its respective variable
                        try
                        {
                            userRealCoordMin = double.Parse(userString);
                            bValid = true;
                        }

                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a double.");
                            bValid = false;
                        }
                    } while (!bValid);

                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter the maximum real coordinate:");
                        userString = Console.ReadLine();

                        try
                        {
                            userRealCoordMax = double.Parse(userString);


                            // check to make sure max coordinate is greater than min coordinate
                            if (userRealCoordMax > userRealCoordMin)
                            {
                                bValid = true;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Maximum value must be greater than minimum value");
                                bValid = false;
                            }


                        }

                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a double.");
                            bValid = false;
                        }
                    } while (!bValid);

                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter the minimum imaginary coordinate:");
                        userString = Console.ReadLine();

                        try
                        {
                            userImagCoordMin = double.Parse(userString);
                            bValid = true;
                        }

                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a double.");
                            bValid = false;
                        }
                    } while (!bValid);

                    Console.WriteLine();

                    do
                    {
                        Console.Write("Enter the maximum imaginary coordinate:");
                        userString = Console.ReadLine();


                        try
                        {
                            userImagCoordMax = double.Parse(userString);

                            if (userImagCoordMax > userImagCoordMin)
                            {
                                bValid = true;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Maximum value must be greater than minimum value");
                                bValid = false;
                            }

                        }

                        catch
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please enter a double.");
                            bValid = false;
                        }
                    } while (!bValid);

                    Console.WriteLine();

                    break;

                // handle the case where user input was neither custom nor default
                default:

                    Console.WriteLine("Please enter 'custom' or 'default'");
                    goto start;
            }


            // find the increment needed to have the map be 80 x 48
            imagIncrement = (userImagCoordMax - userImagCoordMin) / 48.0;
            realIncrmement = (userRealCoordMax - userRealCoordMin) / 80.0;


            // replaced original values with new variables
            for (imagCoord = userImagCoordMax; imagCoord >= userImagCoordMin; imagCoord -= imagIncrement)
            {
                for (realCoord = userRealCoordMin; realCoord <= userRealCoordMax; realCoord += realIncrmement)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
