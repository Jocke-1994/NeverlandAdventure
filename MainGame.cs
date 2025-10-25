using NeverlandAdventure.Game;
using NeverlandAdventure.Menus;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace NeverlandAdventure
{
    public class MainGame
    {
        private bool running = true;

        public void Start()
        {
            Console.Clear();

            if (!GameState.IsIntroPlayed)
            {
                LongBackGround();
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Solen klättrar över trädtopparna...");
                Console.WriteLine("Det är din första morgon i gläntan - din nya plats.");
                Console.WriteLine("Dagens uppdrag: Samla mat och ved.\n");
                Console.WriteLine("Tryck [Enter] för att börja din dag...");
                Console.ReadLine();

                GameState.IsIntroPlayed = true;
            }

            Console.Clear();
            GameState.Day = 1;

            var mainMenu = new IngameMainMenu();
            mainMenu.ShowMainMenu();
        }

        public static void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Tack för att du spelade Neverland Adventure!");
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }

        public static void LongBackGround()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BackgroundStory", "LongBackground.txt");

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                bool skip = false;

                Console.WriteLine("(Tryck på valfri tangent för att visa hela berättelsen direkt...)\n");

                foreach (string line in lines)
                {
                    if (Console.KeyAvailable)
                    {
                        skip = true;
                        Console.ReadKey(true);
                    }

                    if (skip)
                    {
                        foreach (string remainingLine in lines.Skip(Array.IndexOf(lines, line)))
                            Console.WriteLine(remainingLine);
                        break;
                    }

                    Console.WriteLine(line);
                    Thread.Sleep(1200);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Kunde inte hitta berättelsen. Kontrollera filvägen.");
                Console.WriteLine($"Försökte läsa från: {path}");
            }
        }
    }
}