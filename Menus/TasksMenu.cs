using System;
using NeverlandAdventure.Missions;

namespace NeverlandAdventure.Menus
{
    public class TasksMenu
    {
        public void ShowTasks()
        {
            bool inTasks = true;

            while (inTasks)
            {
                Console.Clear();
                Console.WriteLine("=== UPPDRAG ===");

                var missions = MissionManager.GetMissions();

                for (int i = 0; i < missions.Count; i++)
                {
                    var m = missions[i];
                    Console.WriteLine($"{i + 1}. {m.Name} - {(m.Added ? "[Accepterat]" : "[Nytt]")}");
                }

                Console.WriteLine($"{missions.Count + 1}. Tillbaka");
                Console.Write("\nVälj uppdrag: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= missions.Count)
                {
                    ShowMissionDialog(missions[choice - 1]);
                }
                else if (choice == missions.Count + 1)
                {
                    inTasks = false;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Tryck på valfri tangent...");
                    Console.ReadKey();
                }
            }
        }

        private void ShowMissionDialog(Mission mission)
        {
            Console.Clear();
            Console.WriteLine($"=== {mission.Name} ===");
            Console.WriteLine(mission.Description);
            Console.WriteLine("\nVill du acceptera uppdraget?");
            Console.WriteLine("1. Ja");
            Console.WriteLine("2. Nej / Tillbaka");

            string input = Console.ReadLine();

            if (input == "1")
            {
                if (!mission.Added)
                {
                    mission.Added = true;
                    Console.WriteLine("\nUppdraget accepterat!");
                }
                else
                {
                    Console.WriteLine("\nDu har redan accepterat detta uppdrag.");
                }
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}