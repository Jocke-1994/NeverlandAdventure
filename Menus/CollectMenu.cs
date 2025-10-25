using System;
using NeverlandAdventure.Player;
using NeverlandAdventure.Resources;

namespace NeverlandAdventure.Menus
{
    public class CollectMenu
    {
        public void Show()
        {
            bool collecting = true;
            while (collecting)
            {
                Console.Clear();
                Console.WriteLine("=== SAMLA ===");
                Console.WriteLine("1. Trä");
                Console.WriteLine("2. Sten");
                Console.WriteLine("3. Mat");
                Console.WriteLine("4. Tillbaka");
                Console.Write("\nVälj resurs att samla: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Gather("Trä"); break;
                    case "2": Gather("Sten"); break;
                    case "3": Gather("Mat"); break;
                    case "4": collecting = false; break;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Gather(string resourceName)
        {
            Console.Clear();
            Console.WriteLine($"Du försöker samla {resourceName}...\n");

            var rnd = new Random();
            int correct = 0;

            for (int i = 0; i < 3; i++)
            {
                int a = rnd.Next(1, 10);
                int b = rnd.Next(1, 10);
                Console.Write($"Vad är {a} + {b}? ");
                if (int.TryParse(Console.ReadLine(), out int ans) && ans == a + b)
                    correct++;
            }

            if (correct == 3)
            {
                PlayerData.AddResource(resourceName, 1);
                Console.WriteLine($"\nDu fick 1 {resourceName}!");
            }
            else
            {
                Console.WriteLine("\nDu klarade inte uppgiften denna gång.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}