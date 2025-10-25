using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.StartMenu
{
    public class Welcomepage
    {
        public static async Task DisplayWelcomePage()
        {
            bool isActive = true;
            while (isActive)
            {
                Console.Clear();
                // Användaren får välja att logga in eller registrera sig
                Console.WriteLine("Välkommen till Neverland Adventure!");
                Console.WriteLine("1. Logga in.");
                Console.WriteLine("2. Skapa konto.");
                Console.WriteLine("3. Spela utan konto.");

                Console.WriteLine("4. Avsluta.");
                //Console.WriteLine("Glömt lösenordet? Tryck 3."); Funktion som kan läggas till senare

                // Läs användarens val
                Console.Write("Val: ");
                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        LoginFeature.ShowLoginFeature();
                        break;
                    case "2":
                        await RegisterFeature.ShowRegisterFeature();
                        break;
                    case "3":
                        Console.WriteLine("Är du säker? Utan konto kan du inte spara");
                        Console.WriteLine("1. Fortsätt utan konto");
                        Console.WriteLine("2. Återgå till menyn");
                        string confirmChoice = Console.ReadLine();

                        if (confirmChoice == "1")
                        {
                            MainGame game = new MainGame();
                            game.Start();
                        }                      
                        break;
                    case "4":
                        Console.WriteLine("\nTack för att du spelade Neverland Adventure!");
                        Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                        Console.ReadKey();
                        isActive = false;
                        break;

                    //case "X":
                    //    PasswordRecoveryFeature.ShowPasswordRecoveryFeature();
                    //    break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                }
            }
            // Här kan du lägga till logik för att verifiera användarnamn och lösenord
            
        }
    }
}
