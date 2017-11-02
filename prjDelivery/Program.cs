using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjDelivery
{
    class Program
    {
        // Input/Output code

        // The first line of the input contains two decimal integers separated by space:
        //   - the maximum weight ('W') that can be delivered in a single trip
        //   - the quantity of packages ('P') to be delivered.
        // The following 'P' lines contain a decimal integer representing the weight of each package.
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int tripMaxWeight = int.Parse(tokens[0]);
            int numberOfPackages = int.Parse(tokens[1]);

            int[] packagesWeight = new int[numberOfPackages];
            for (int i = 0; i < numberOfPackages; i++)
            {
                packagesWeight[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(minimumNumberOfTrips(tripMaxWeight, packagesWeight));
        }

        /*
   * Complete the function below.
   */

        static int minimumNumberOfTrips(int tripMaxWeight, int[] packagesWeight)
        {
            int totalTrips = 0;
            Dictionary<int, bool> delivery = new Dictionary<int, bool>();
            for (int i = 0; i < packagesWeight.Length; i++)
            {
                if (!delivery.ContainsKey(packagesWeight[i]))
                {
                    delivery.Add(packagesWeight[i], false);
                }
            }

            for (int i = 0; i < packagesWeight.Length; i++)
            {
                int totalWeightTrip = 0;
                if (!delivery[packagesWeight[i]])
                {
                    totalWeightTrip = packagesWeight[i];
                    bool insideExecuted = false;
                    for (int j = i + 1; j < packagesWeight.Length; j++)
                    {
                        insideExecuted = true;
                        if (!delivery[packagesWeight[j]])
                        {
                            if (totalWeightTrip + packagesWeight[j] <= tripMaxWeight)
                            {
                                delivery[packagesWeight[j]] = true;
                                delivery[packagesWeight[i]] = true;
                                totalTrips = totalTrips + 1;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    if (!insideExecuted)
                    {
                        delivery[packagesWeight[i]] = true;
                        totalTrips = totalTrips + 1;
                    }

                }
            }
            return totalTrips;
        }
    }
}
