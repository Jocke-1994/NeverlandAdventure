using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Utils
{
    public class TextHelper
    {
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
                        Console.ReadKey(true); // slukar tangenttrycket
                    }

                    if (skip)
                    {
                        // skriv ut resten direkt, inklusive alla återstående rader
                        foreach (string remainingLine in lines.Skip(Array.IndexOf(lines, line)))
                            Console.WriteLine(remainingLine);
                        break;
                    }

                    Console.WriteLine(line);
                    Thread.Sleep(1500); // justera för hastighet, 800ms = 0.8 sek per rad
                }

                Console.WriteLine(); // extra rad på slutet
            }
            else
            {
                Console.WriteLine("Kunde inte hitta berättelsen. Kontrollera filvägen.");
                Console.WriteLine($"Försökte läsa från: {path}");
            }
        }
    }
}
