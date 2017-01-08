using System;
using System.Collections.Generic;
using System.Linq;

namespace PenguinAirlines
{
    public class Program
    {
        private const string NoFlightsAvailableMessage = "No flights available.";
        private const string ThereIsADirectFlightMessage = "There is a direct flight.";
        private const string ThereIsntADirectFlightMessage = "There are flights, unfortunately they are not direct, grandma :(";

        public static void Main()
        {
            int islandsCount = int.Parse(Console.ReadLine());

            List<int>[] adjacencyList = new List<int>[islandsCount];
            for (int i = 0; i < islandsCount; i++)
            {
                string flights = Console.ReadLine();
                if (flights == "None")
                {
                    adjacencyList[i] = new List<int>();
                }
                else
                {
                    adjacencyList[i] = flights.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToList();
                }
            }

            int[] componentsId = new int[islandsCount];
            bool[] visited = new bool[islandsCount];

            for (int i = 0; i < islandsCount; i++)
            {
                if (!visited[i])
                {
                    Dfs(i, adjacencyList, visited, i, componentsId);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Have a break")
                {
                    break;
                }

                int[] info = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
                int firstIslandIndex = info[0];
                int secondIslandIndex = info[1];

                if (adjacencyList[firstIslandIndex].Contains(secondIslandIndex))
                {
                    Console.WriteLine(ThereIsADirectFlightMessage);
                }

                else
                {
                    if (visited[secondIslandIndex])
                    {
                        Console.WriteLine(ThereIsntADirectFlightMessage);
                    }

                    else
                    {
                        Console.WriteLine(NoFlightsAvailableMessage);
                    }
                }
            }
        }

        private static void Dfs(int firstIslandIndex, List<int>[] adjacencyList, bool[] visited, int id, int[] componentsId)
        {
            visited[firstIslandIndex] = true;
            componentsId[firstIslandIndex] = id;

            foreach (var successor in adjacencyList[firstIslandIndex])
            {
                if (!visited[successor])
                {
                    Dfs(successor, adjacencyList, visited, id, componentsId);
                }
            }
        }
    }
}
