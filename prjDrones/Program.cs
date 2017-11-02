using System;
using System.Collections.Generic;
using System.IO;
namespace prjDrones
{
    class Program
    {
        private class Drone
        {
            public int Id { get; set; }
            public int FlightRange { get; set; }
        }

        // Input/Output code

        // The first line of the input contains three decimal ints separated by space:
        //   - total number of drones ('D')
        //   - number of drones to be selected ('G')
        //   - number of drones in maintenance ('M')
        // The following 'D' lines each contains two decimal ints separated by space with information about each drone:
        //   - ID
        //   - flight range in kilometers
        // The following 'M' lines each contains the numeric ID of a drone currently in maintenance.

        // Print the IDs of the 'G' selected drones to the standard output, one per line, sorted by flight range (greater first).
        static void Main(String[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int numberOfDrones = int.Parse(tokens[0]);
            int requiredDrones = int.Parse(tokens[1]);
            int numberOfDronesInMaintenance = int.Parse(tokens[2]);

            var drones = new List<Drone>();
            var inMaintenanceDrones = new List<int>();

            for (int i = 0; i < numberOfDrones; i++)
            {
                tokens = Console.ReadLine().Split();
                drones.Add(new Drone { Id = int.Parse(tokens[0]), FlightRange = int.Parse(tokens[1]) });
            }

            for (int i = 0; i < numberOfDronesInMaintenance; i++)
            {
                inMaintenanceDrones.Add(int.Parse(Console.ReadLine()));
            }

            var result = GreatestFlightRangeDrones(requiredDrones, drones, inMaintenanceDrones);

            foreach (var droneId in result)
            {
                Console.WriteLine(droneId);
            }
            Console.ReadLine();
        }
        /*
     * Complete the function below.
     */
        static List<int> GreatestFlightRangeDrones(int requiredDrones, List<Drone> drones, List<int> inMaintenanceDrones)
        {
            List<int> listRequiredDrones = new List<int>();
            SortedList<int, Drone> dronesSorted = new SortedList<int, Drone>();
            
            foreach (Drone item in drones)
            {
                bool isAvailable = true;
                foreach (int inMant in inMaintenanceDrones)
                {
                    if (inMant == item.Id)
                    {
                        isAvailable = false;
                        break;
                    }
                }
                if (isAvailable)
                {
                    dronesSorted.Add(item.FlightRange, item);
                }
            }
            int count = 0;
            int[] reverseDrones = new int[dronesSorted.Count];
            foreach (var stListItem in dronesSorted)
            {
                reverseDrones[count] = stListItem.Value.Id;
                count = count + 1;

            }
            count = 0;
            for (int i = reverseDrones.Length-1; i >= 0; i--)
            {
                if (count < requiredDrones)
                {
                    listRequiredDrones.Add(reverseDrones[i]);
                }
                count = count + 1;
            }

            return listRequiredDrones;

        }
    }
}
