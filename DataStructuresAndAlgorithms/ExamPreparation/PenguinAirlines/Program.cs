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

            bool[] visited = new bool[islandsCount];
            int[] islandsIds = new int[islandsCount];

            for (int i = 0; i < islandsCount; i++)
            {
                if (!visited[i])
                {
                    Dfs(i, adjacencyList, visited, i, islandsIds);
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
                    if (islandsIds[firstIslandIndex] == islandsIds[secondIslandIndex])
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

        private static void Dfs(int firstComponentIndex, List<int>[] adjacencyList, bool[] visited, int componentId, int[] componentsIds)
        {
            visited[firstComponentIndex] = true;
            componentsIds[firstComponentIndex] = componentId;

            foreach (var successor in adjacencyList[firstComponentIndex])
            {
                if (!visited[successor])
                {
                    Dfs(successor, adjacencyList, visited, componentId, componentsIds);
                }
            }
        }
    }
}