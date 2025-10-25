using System;
using NeverlandAdventure.Events;
using NeverlandAdventure.Game;

namespace NeverlandAdventure.Game
{
    public static class GameState
    {
        public static int Day { get; set; } = 0;
        public static bool IsIntroPlayed { get; set; } = false;

        public static void ProcessEvening()
        {
            Console.Clear();
            Console.WriteLine($"Kväll dag {Day}");
            Console.WriteLine("Alla samlas runt elden...\n");

            EventManager.TriggerNightEvent();

            Console.WriteLine("\nTryck på valfri tangent för att gå till nästa dag...");
            Console.ReadKey();

            Day++;
        }

        public static void ShowReport()
        {
            Console.Clear();
            Console.WriteLine("--- LÄGESRAPPORT ---");
            Console.WriteLine("Allt verkar lugnt för tillfället. Röken stiger stilla över gläntan.");
            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}