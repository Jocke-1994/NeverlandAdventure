using System;
using NeverlandAdventure.Player;

namespace NeverlandAdventure.Menus
{
    public class ConvertMenu
    {
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("--- OMVANDLA ---");
            Console.WriteLine("1. 2 Trä + 2 Sten → +1 Försvar");
            Console.WriteLine("2. Tillbaka");
            Console.Write("Val: ");
            string val = Console.ReadLine();

            if (val == "1")
            {
                if (PlayerData.HasEnough("Trä", 2) && PlayerData.HasEnough("Sten", 2))
                {
                    PlayerData.RemoveResource("Trä", 2);
                    PlayerData.RemoveResource("Sten", 2);
                    PlayerData.AddResource("Försvar", 1);
                    Console.WriteLine("Försvaret har förbättrats!");
                }
                else
                {
                    Console.WriteLine("Du har inte tillräckligt med resurser.");
                }
            }
            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }
    }
}