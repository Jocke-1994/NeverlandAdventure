using NeverlandAdventure.Game;
using NeverlandAdventure.Menus;
using NeverlandAdventure.Missions;
using System;

namespace NeverlandAdventure.Menus
{
    public class IngameMainMenu
    {
        private bool keepRunning = true;

        public void ShowMainMenu()
        {
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("=== HUVUDMENY ===");
                Console.WriteLine("1. Uppdrag");
                Console.WriteLine("2. Samla");
                Console.WriteLine("3. Gå till kvällen");
                Console.WriteLine("4. Avsluta spelet");
                Console.Write("\nVälj ett alternativ: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        new TasksMenu().ShowTasks();
                        break;
                    case "2":
                        new CollectMenu().Show();
                        break;
                    case "3":
                        GoToEvening();
                        break;
                    case "4":
                        ExitGame();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GoToEvening()
        {
            Console.Clear();
            Console.WriteLine("Solen går ner bakom träden...");
            Console.WriteLine("Du avslutar dagens arbete och gör dig redo för natten.\n");
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();

            GameState.ProcessEvening();
        }

        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Vill du verkligen avsluta spelet? (j/n)");
            string confirm = Console.ReadLine()?.ToLower();

            if (confirm == "j")
            {
                keepRunning = false;
                MainGame.EndGame();
            }
        }
    }
}