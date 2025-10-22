using NeverlandAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Twilio.Types;

namespace NeverlandAdventure
{
    public class RegisterFeature
    {
        public static async Task ShowRegisterFeature()
        {
            Console.WriteLine("För att skapa ett konto ange:");

            // 1️⃣ Användarnamn
            Console.Write("Ange användarnamn: ");
            string username = Console.ReadLine();

            // 2️⃣ Lösenord
            Console.Write("Ange lösenord: ");
            string password = HidePassword();

            // 3️⃣ Kontrollera username och password
            bool passwordOk = CheckPasswordStrength(password);
            bool usernameOk = CheckUsernameAvailability(username);

            if (!passwordOk || !usernameOk)
            {
                Console.WriteLine("Användarnamn eller lösenord stämmer inte.");
                return;
            }

            // 4️⃣ Kör 2FA
            bool verified = await TwoFactorAuthAsync();
            if (!verified)
            {
                Console.WriteLine("Registreringen avbröts.");
                return;
            }

            // 5️⃣ Allt klart
            Console.WriteLine($"✅ Kontot har skapats!");
        }
        public static bool CheckUsernameAvailability(string username)
        {
            // Kontrollera om användarnamnet är tillgängligt
            List<string> existingUsernames = new List<string> { "user1", "admin", "testuser" }; // Exempel på befintliga användarnamn
            if (existingUsernames.Contains(username))
            {
                Console.WriteLine("Användarnamnet är redan taget. Vänligen välj ett annat.");
                return false; // Användarnamnet är inte tillgängligt
            }

            else
            {
                Console.WriteLine("Användarnamnet är tillgängligt.");
                return true; // Användarnamnet är tillgängligt
            }

        }

        public static bool CheckPasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;
            // Kontrollera lösenordets styrka
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool isStrong = hasUpper && hasLower && hasDigit && hasSpecial && password.Length >= 8;

            if (isStrong)
            {
                Console.WriteLine("Lösenordet är starkt.");
            }
            else
            {
                Console.WriteLine("Lösenordet är svagt. Använd minst 8 tecken med stora och små bokstäver, siffror och specialtecken.");
            }
            return isStrong;
        
        }
        // Hjälpmetod för att läsa lösenord med '*' i konsolen
        public static string HidePassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b"); // tar bort * från konsolen
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }
        public static async Task<bool> TwoFactorAuthAsync()
        {
            Console.Write("Ange ditt telefonnummer för 2FA: ");
            string phoneNumber = Console.ReadLine();

            if (phoneNumber.StartsWith("0"))
            {
                phoneNumber = "+46" + phoneNumber.Substring(1);
            }

            Random rand = new Random();
            string verificationCode = rand.Next(100000, 999999).ToString();

            TwoStepVerification twilio = new TwoStepVerification();
            await twilio.SendSmsAsync(phoneNumber, $"Koden för att registrera ett konto till Neverland är: {verificationCode}");

            Console.Write("Ange koden du fick via SMS: ");
            string userInput = Console.ReadLine();

            if (userInput == verificationCode)
            {
                Console.WriteLine("✅ Verifiering lyckades! Kontot är nu bekräftat.");
                return true;
            }
            else
            {
                Console.WriteLine("❌ Fel kod. Registrering avbruten.");
                return false;
            }
        }

        //
        // Klassen ska hantera användarregistrering inklusive validering av indata,
        // lagring av användarinformation
        // 2FA -verifiering och eventuella felhanteringar.
        // Ett demokonto ska skapas för teständamål då 2FA kommer användas vid registrering.
        // Sms är 2FA -metoden som ska användas.

        //Vad ska efterfrågas vid registrering?
        // Användarnamn
        // Lösenord
        // E-postadress (för glömt lösenord)
        // Telefonnummer (för 2FA)
    }
}
