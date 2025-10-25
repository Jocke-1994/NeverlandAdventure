using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Missions
{
    public class Mission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Added { get; set; } = false;

        public string ResourceType { get; set; } = ""; // t.ex. "Trä"
        public int RequiredAmount { get; set; } = 0;
        public int CurrentProgress { get; set; } = 0;

        public Mission(string name, string description, string resourceType, int requiredAmount)
        {
            Name = name;
            Description = description;
            ResourceType = resourceType;
            RequiredAmount = requiredAmount;
        }
    }
}
