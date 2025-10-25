using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Resources
{
    public class Resource
    {
        public string Name { get; private set; }
        public int CollectedToday { get; private set; }
        public int DailyLimit { get; private set; }

        public int MissionNeed { get; set; } // hur många som behövs till uppdraget
        public int MissionCollected { get; private set; } // hur många som hittills samlats för uppdraget

        public Resource(string name, int dailyLimit)
        {
            Name = name;
            DailyLimit = dailyLimit;
            CollectedToday = 0;
            MissionNeed = 0; // 0 = inget aktivt uppdrag
            MissionCollected = 0;
        }

        public void Collect(int amount = 1)
        {
            if (CollectedToday + amount > DailyLimit)
            {
                Console.WriteLine($"Du kan inte samla mer av {Name} idag ({CollectedToday}/{DailyLimit}).");
                return;
            }

            CollectedToday += amount;

            // Om uppdraget kräver trä, uppdatera även där
            if (MissionNeed > 0 && MissionCollected < MissionNeed)
            {
                MissionCollected = Math.Min(MissionCollected + amount, MissionNeed);
            }
        }

        public string GetDisplayText()
        {
            string missionPart = MissionNeed > 0
                ? $"Uppdrag: {MissionCollected}/{MissionNeed} - "
                : "";

            return $"1. {Name} - {missionPart}Totalt för idag: {CollectedToday}/{DailyLimit}";
        }
    }
}
