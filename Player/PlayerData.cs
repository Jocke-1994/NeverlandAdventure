using System;
using System.Collections.Generic;
using NeverlandAdventure.Missions;

namespace NeverlandAdventure.Player
{
    public static class PlayerData
    {
        private static Dictionary<string, int> resources = new()
        {
            { "Trä", 0 },
            { "Sten", 0 },
            { "Mat", 0 },
            { "Försvar", 0 }
        };

        public static void AddResource(string name, int amount)
        {
            if (resources.ContainsKey(name))
                resources[name] += amount;
            else
                resources[name] = amount;
        }

        public static bool HasEnough(string name, int amount)
        {
            return resources.ContainsKey(name) && resources[name] >= amount;
        }

        public static void RemoveResource(string name, int amount)
        {
            if (resources.ContainsKey(name))
            {
                resources[name] = Math.Max(0, resources[name] - amount);
            }
        }

        public static void ShowResources()
        {
            Console.WriteLine("--- Dina resurser ---");
            foreach (var r in resources)
            {
                Console.WriteLine($"{r.Key}: {r.Value}");
            }
        }
        private static Dictionary<string, int> todayCount = new();
        private static Dictionary<string, int> dailyLimit = new()
            {
                { "Trä", 3 },
                { "Sten", 3 },
                { "Mat", 3 }
            };

        public static int GetTodayCount(string name) => todayCount.ContainsKey(name) ? todayCount[name] : 0;
        public static int GetDailyLimit(string name)
        {
            int baseLimit = dailyLimit.ContainsKey(name) ? dailyLimit[name] : 0;
            int missionBonus = MissionManager.GetExtraDailyLimit(name);
            return baseLimit + missionBonus;
        }


        public static void IncrementTodayCount(string name)
        {
            if (!todayCount.ContainsKey(name))
                todayCount[name] = 0;
            todayCount[name]++;
        }
    }
}