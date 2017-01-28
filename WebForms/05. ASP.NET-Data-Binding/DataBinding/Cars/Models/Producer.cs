using System.Collections.Generic;

namespace Cars.Models
{
    public class Producer
    {
        public string Name
        {
            get; set;
        }

        public HashSet<string> Models
        {
            get; set;
        }
    }
}