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

        public Mission(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
