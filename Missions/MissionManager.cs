using System;
using System.Collections.Generic;
using System.Linq;

namespace NeverlandAdventure.Missions
{
    public static class MissionManager
    {
        private static List<Mission> allMissions = new()
        {
            new Mission("Vakt", "Samla 5 trä och 3 sten.", "Trä", 5),
            new Mission("AnimalCare", "Samla 4 mat till djuren.", "Mat", 4)
        };

        public static List<Mission> GetMissions() => allMissions;

        // Returnerar progress för ett visst resursnamn
        public static (int Progress, int Required) GetMissionProgress(string resource)
        {
            var mission = allMissions.FirstOrDefault(m => m.ResourceType == resource && m.Added);
            if (mission != null)
                return (mission.CurrentProgress, mission.RequiredAmount);
            else
                return (0, 0);
        }

        // Uppdaterar progress när spelaren samlar
        public static void UpdateMissionProgress(string resource)
        {
            var mission = allMissions.FirstOrDefault(m => m.ResourceType == resource && m.Added);
            if (mission != null && mission.CurrentProgress < mission.RequiredAmount)
            {
                mission.CurrentProgress++;
            }
        }

        // Hämtar extra insamlingsgräns per resurs baserat på uppdrag
        public static int GetExtraDailyLimit(string resource)
        {
            var mission = allMissions.FirstOrDefault(m => m.ResourceType == resource && m.Added);
            return mission != null ? mission.RequiredAmount : 0;
        }
    }
}