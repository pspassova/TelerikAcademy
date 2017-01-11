using Wintellect.PowerCollections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerRanking
{
    public class Startup
    {
        private static SortedDictionary<string, SortedSet<Player>> playersSortedByType = new SortedDictionary<string, SortedSet<Player>>();
        private static BigList<Player> players = new BigList<Player>();

        private const string RanklistCommand = "ranklist";
        private const string FindCommand = "find";
        private const string AddCommand = "add";
        private const string EndCommand = "end";

        public static void Main()
        {
            List<int[]> commands = new List<int[]>();

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
                        break;
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
                playersSortedByType.Add(type, new SortedSet<Player>(new PlayerComparer()));
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

            Console.WriteLine("Added player {0} to position {1}", player.Name, player.Position);
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

    public class Player
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

        // Resourse--http://stackoverflow.com/questions/371328/why-is-it-important-to-override-gethashcode-when-equals-method-is-overridden
        public override int GetHashCode()
        {
            const int multiplier = 397;

            unchecked
            {
                var hash = 0;

                hash = (hash * multiplier) ^ (dynamic)this.Name;
                hash = (hash * multiplier) ^ (dynamic)this.Type;
                hash = (hash * multiplier) ^ (dynamic)this.Age;
                hash = (hash * multiplier) ^ (dynamic)this.Position;

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Player;
            if (other == null)
            {
                return false;
            }

            bool equalsName = this.Name == other.Name;
            bool equalsType = this.Type == other.Type;
            bool equalsAge = this.Age == other.Age;
            bool equalsPosition = this.Position == other.Position;

            return equalsName && equalsType && equalsAge && equalsPosition;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    public class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player firstPlayer, Player secondPlayer)
        {
            int nameComparer = firstPlayer.Name.ToLower().CompareTo(secondPlayer.Name.ToLower());
            if (nameComparer == 0)
            {
                return firstPlayer.Age - secondPlayer.Age;
            }
            else
            {
                return nameComparer;
            }
        }
    }
}
