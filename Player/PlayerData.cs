using System;
using System.Collections.Generic;

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
    }
}