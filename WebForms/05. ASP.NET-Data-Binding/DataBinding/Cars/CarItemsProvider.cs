using Cars.Models;
using System.Collections.Generic;

namespace Cars
{
    public class CarItemsProvider
    {
        private HashSet<Producer> producers;
        private HashSet<Extra> extras;
        private HashSet<string> engines;

        public HashSet<Producer> GetAllProducers()
        {
            this.producers = new HashSet<Producer>()
            {
                new Producer()
                {
                    Name = "Tesla",
                    Models = new HashSet<string>() { "S", "X", "3" }
                },
                new Producer()
                {
                    Name = "Rolls Royce",
                    Models = new HashSet<string>() { "Phantom", "Silver Shadow", "Corniche" }
                },
                new Producer()
                {
                    Name = "Ferrari",
                    Models = new HashSet<string>() { "275 GTB", "Daytona 365 GTB/4", "550 Barchetta" }
                }
            };

            return this.producers;
        }

        public HashSet<Extra> GetAllExtras()
        {
            this.extras = new HashSet<Extra>()
            {
                new Extra() { Type = "Satellite navigation" },
                new Extra() { Type = "Paint protection" },
                new Extra() { Type = "CD changer" },
                new Extra() { Type = "Nitrogen-filled tyres" },
                new Extra() { Type = "Ceramic brake pads" }
            };

            return this.extras;
        }

        public HashSet<string> GetAllEngines()
        {
            this.engines = new HashSet<string>()
            {
                "Gasoline",
                "Diesel",
                "Electrical",
                "Hybrid"
            };

            return this.engines;
        }
    }
}