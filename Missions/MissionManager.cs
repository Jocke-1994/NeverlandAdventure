using System;
using System.Collections.Generic;

namespace NeverlandAdventure.Missions
{
    public static class MissionManager
    {
        private static List<Mission> allMissions = new()
        {
            new Mission("Vakt", "Samla 5 trä och 3 sten."),
            new Mission("AnimalCare", "Samla 4 mat till djuren.")
        };

        public static void ShowMissions()
        {
            Console.WriteLine("=== Aktiva uppdrag ===\n");
            foreach (var m in allMissions)
            {
                Console.WriteLine($"- {m.Name}: {m.Description}");
            }
        }

        public static void TalkToGuard()
        {
            Console.WriteLine("Du pratar med vakten. Han berättar om faror i området.");
        }

        public static void TalkToAnimalCare()
        {
            Console.WriteLine("Du talar med Astrid, djurvårdaren. Hon tackar för hjälpen.");
        }
    }
}
