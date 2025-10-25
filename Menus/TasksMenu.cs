using System;
using NeverlandAdventure.Missions;

namespace NeverlandAdventure.Menus
{
    public class TasksMenu
    {
        public void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("=== UPPDRAG ===");
            MissionManager.ShowMissions();

            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}