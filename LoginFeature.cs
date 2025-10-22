using NeverlandAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure
{
    public static class UserDatabase
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        // Lägg till användare
        public static void AddUser(string username, string password)
        {
            if (!users.ContainsKey(username))
            {
                users[username] = password;
            }
        }

        // Kontrollera användare
        public static bool VerifyUser(string username, string password)
        {
            return users.ContainsKey(username) && users[username] == password;
        }
    }
    public class LoginFeature
    {
        // Implementation for user login functionality


        public static void ShowLoginFeature()
        {
            // Skapa ett testkonto om det inte finns
            if (!UserDatabase.VerifyUser("Test", "Test123"))
                UserDatabase.AddUser("Test", "Test123");

            bool loggedIn = false;
            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("--- LOGIN ---");
                Console.Write("Ange användarnamn: ");
                string username = Console.ReadLine();

                Console.Write("Ange lösenord: ");
                string password = RegisterFeature.HidePassword();

                if (UserDatabase.VerifyUser(username, password))
                {
                    Console.WriteLine($"\nInloggning lyckades! Välkommen tillbaka {username}.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                    loggedIn = true;
                }
                else
                {
                    Console.WriteLine("\nFel användarnamn eller lösenord.");
                    Console.WriteLine("Tryck på valfri tangent för att försöka igen...");
                    Console.ReadKey();
                }
            }
        }
    }
}


