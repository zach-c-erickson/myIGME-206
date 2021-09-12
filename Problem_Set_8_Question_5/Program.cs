using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Set_8_Question_5
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Problem Set 8 question 5
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Use a three-dimensional array to store values for x,
        // y, and z in a multivariable equation
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize values to store the values of x, y, and z
            double x = 0;
            double y = 0;
            double z = 0;

            // initialize counters for array dimensions
            int nX = 0;
            int nY = 0;

            // create double array
            double[,,] zFunc = new double[21, 31, 3];

            // loop through each value of x, increment nX and x after each iteration
            for(x = -1; x <= 1; x += 0.1, ++nX)
            {

                // round x to one decimal point to deal with rounding issues
                x = Math.Round(x, 1);

                // reset nY to 0 for this value of x
                nY = 0;

                // loop through each value of y, increment nY and y after each iteration
                for (y = 1; y <= 4; y += 0.1, ++nY)
                {
                    // round y to one decimal point to deal with rounding issues
                    y = Math.Round(y, 1);


                    // calculate z = 3y^2 + 2x - 1
                    z = 3 * Math.Pow(y, 2) + 2 * x - 1;

                    // round z to three decimal points
                    z = Math.Round(z, 3);

                    // store values of x, y, and z for this data point
                    zFunc[nX, nY, 0] = x;
                    zFunc[nX, nY, 1] = y;
                    zFunc[nX, nY, 2] = z;
                }
            }

        }
    }
}
