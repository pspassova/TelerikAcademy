using Wintellect.PowerCollections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerRanking
{
    public class Startup
    {
        private static IDictionary<string, SortedSet<Player>> playersSortedByType = new Dictionary<string, SortedSet<Player>>();
        private static BigList<Player> players = new BigList<Player>();

        private const string RanklistCommand = "ranklist";
        private const string FindCommand = "find";
        private const string AddCommand = "add";
        private const string EndCommand = "end";

        public static void Main()
        {
            int[] commands = new int[5];

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                string action = command[0];

                switch (action)
                {
                    case RanklistCommand:
                        HandleRanklistCommand(command);
                        break;
                    case FindCommand:
                        HandleFindCommand(command);
                        break;
                    case AddCommand:
                        HandleAddCommand(command);
                        break;
                    case EndCommand:
                        return;
                    default:
                        break;
                }
            }
        }

        private static void HandleAddCommand(string[] command)
        {
            string name = command[1];
            string type = command[2];
            int age = int.Parse(command[3]);
            int position = int.Parse(command[4]) - 1;

            Player player = new Player(name, type, age, position);

            bool typeIsFound = playersSortedByType.ContainsKey(type);
            if (!typeIsFound)
            {
                playersSortedByType.Add(type, new SortedSet<Player>());
            }

            if (playersSortedByType[type].Contains(player))
            {
                return;
            }

            playersSortedByType[type].Add(player);

            if (position > players.Count)
            {
                players.Add(player);
            }
            else
            {
                players.Insert(position, player);
            }

            Console.WriteLine("Added player {0} to position {1}", player.Name, player.Position + 1);
        }

        private static void HandleFindCommand(string[] command)
        {
            string searchedType = command[1];
            StringBuilder handledCommand = new StringBuilder();

            handledCommand.AppendFormat("Type {0}: ", searchedType);

            bool typeIsFound = playersSortedByType.ContainsKey(searchedType);
            if (!typeIsFound)
            {
                Console.WriteLine(handledCommand.ToString());
                return;
            }

            int count = 0;
            foreach (var player in playersSortedByType[searchedType])
            {
                handledCommand.AppendFormat("{0}; ", player.ToString());
                count++;

                if (count == 5)
                {
                    break;
                }
            }

            handledCommand.Length = handledCommand.Length - 2;
            Console.WriteLine(handledCommand.ToString());
        }

        private static void HandleRanklistCommand(string[] command)
        {
            int startPosition = int.Parse(command[1]);
            int endPosition = int.Parse(command[2]);

            StringBuilder handledCommand = new StringBuilder();
            for (int position = startPosition - 1; position < endPosition; position++)
            {
                handledCommand.AppendFormat("{0}. ", position + 1);
                handledCommand.AppendFormat("{0}; ", players[position]);
            }

            handledCommand.Length = handledCommand.Length - 2;
            Console.WriteLine(handledCommand.ToString());
        }
    }

    public class Player : IComparable<Player>
    {
        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public string Name
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public int Age
        {
            get; set;
        }

        public int Position
        {
            get; set;
        }

        public int CompareTo(Player other)
        {
            int comparedByName = this.Name.CompareTo(other.Name.ToLower());
            int comparedByAge = other.Age.CompareTo(this.Age);

            return comparedByName != 0 ? comparedByName : comparedByAge;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }
}
