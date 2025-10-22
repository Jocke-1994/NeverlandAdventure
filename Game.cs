using NeverlandAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace NeverlandAdventure
{
    public class Game
    {
        private Dictionary<string, int> resources;
        private bool running = true;

        private class Task
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool Added { get; set; } = false;
        }
        private List<Task> allTasks;    // Lista över alla uppdrag

        public void Start()
        {

            Console.Clear();
            LongBackGround();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Solen klättrar över trädtopparna. Dagg glänser på gräset och röken från nattens glöd stiger sakta upp.");
            Console.WriteLine("Det är din första morgon i gläntan - din nya plats.");
            Console.WriteLine("Byn är tyst, men snart hörs röster. Någon tänder en eld, någon ropar på barnen.");
            Console.WriteLine("Du vet att du måste börja bygga ett nytt liv här.\n");
            Console.WriteLine("Dagens uppdrag: Samla mat och ved.\n");
            Console.WriteLine("Tryck [Enter] för att börja din dag...");
            Console.ReadLine();
            Console.Clear();

            Initialize();

            while (running)
            {
                ShowMainMenu();
            }
        }

        private void Initialize()
        {
            // Initiera resurser
            resources = new Dictionary<string, int>
        {
            { "Trä", 0 },
            { "Sten", 0 },
            { "Mat", 0 },
            { "Försvar", 0 }
        };

            // Initiera uppdragslistan
            allTasks = new List<Task>
        {
            new Task { Name = "Vakt", Description = "Samla 5 trä och 3 sten." },
            new Task { Name = "AnimalCare", Description = "Samla 4 mat till djuren." }
        };
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\n--- HUVUDMENY ---");
            Console.WriteLine("1. Visa uppdrag");
            Console.WriteLine("2. Samla");
            Console.WriteLine("3. Omvandla");
            Console.WriteLine("4. Visa statistik");
            Console.WriteLine("5. Lägesrapport");
            Console.WriteLine("6. Spara & Avsluta");
            Console.Write("Val: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ShowTasks(); break;
                case "2": GatherMenu(); break;
                case "3": ConvertMenu(); break;
                case "4": ShowStats(); break;
                case "5": ShowReport(); break;
                case "6": SaveAndExit(); break;
                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }

        private void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("--- UPPDRAG ---");

            int optionNumber = 1;
            Dictionary<int, Task> visibleTasks = new Dictionary<int, Task>();

            foreach (var task in allTasks)
            {
                if (!task.Added) // Visa bara uppdrag som inte lagts till
                {
                    Console.WriteLine($"{optionNumber}. Prata med {task.Name}");
                    visibleTasks.Add(optionNumber, task);
                    optionNumber++;
                }
            }

            Console.WriteLine($"{optionNumber}. Tillbaka");
            Console.Write("Val: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selected))
            {
                if (selected == optionNumber)
                    return; // Tillbaka

                if (visibleTasks.ContainsKey(selected))
                {
                    var task = visibleTasks[selected];
                    if (task.Name == "Vakt") TalkToGuard(task);
                    else if (task.Name == "AnimalCare") TalkToAnimalCare(task);
                }
            }
        }

        private void TalkToGuard(Task task)
        {
            bool stayInDialog = true;
            while (stayInDialog)
            {
                Console.Clear();
                Console.WriteLine("Brynulf (Vaktkapten):");
                Console.WriteLine($"\"Bra att du är här. {task.Description} Kan du fixa det?\"");
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nej");
                Console.WriteLine("3. Tillbaka");
                Console.Write("Val: ");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        task.Added = true; // Markera uppdraget som lagt till
                        Console.WriteLine($"\n\"Utmärkt! {task.Description} har blivit tillagt till dina uppdrag.\"");
                        Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn...");
                        Console.ReadKey();       // Väntar på enter
                        stayInDialog = false;    // Avslutar loop → tillbaka till huvudmenyn
                        Console.Clear();         // Rensar skärmen så dialogen försvinner
                        break;

                    case "2":
                        Console.WriteLine("\n\"Vi måste stärka vårt försvar... men gör som du vill.\"");
                        Console.WriteLine("Tryck på [Enter] för att fortsätta...");
                        Console.ReadLine();
                        break;

                    case "3":
                        stayInDialog = false;
                        Console.Clear();  // Rensar skärmen direkt när man går tillbaka
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private void TalkToAnimalCare(Task task)
        {
            bool stayInDialog = true;
            while (stayInDialog)
            {
                Console.Clear(); // Rensar skärmen varje gång
                Console.WriteLine("Sigrid (AnimalCare):");
                Console.WriteLine($"\"Där är du! {task.Description} Tar du hand om det?\"");
                Console.WriteLine("1. Ja");
                Console.WriteLine("2. Nej");
                Console.WriteLine("3. Tillbaka");
                Console.Write("Val: ");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        task.Added = true; // markerar uppdrag
                        Console.WriteLine($"\n\"Tack! {task.Description} har blivit tillagt till dina uppdrag.\"");
                        Console.WriteLine("\nTryck på valfri tangent för att återgå till huvudmenyn...");
                        Console.ReadKey();
                        stayInDialog = false; // tillbaka till huvudmeny
                        break;

                    case "2":
                        Console.WriteLine("\n\"Djuren måste äta... någon måste göra det.\"");
                        Console.WriteLine("Tryck på [Enter] för att fortsätta...");
                        Console.ReadLine();
                        // stannar i dialog, loopar om
                        break;

                    case "3":
                        stayInDialog = false;
                        Console.Clear(); // rensar dialog
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private void GatherMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- SAMLA ---");
                Console.WriteLine("Vad vill du samla?");
                Console.WriteLine("1. Trä");
                Console.WriteLine("2. Sten");
                Console.WriteLine("3. Mat");
                Console.WriteLine("4. Tillbaka");
                Console.Write("Val: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Gather("Trä"); break;
                    case "2": Gather("Sten"); break;
                    case "3": Gather("Mat"); break;
                    case "4":
                        Console.Clear();
                        return; // Avslutar GatherMenu → tillbaka till huvudmeny
                    default:
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent och försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void Gather(string resource)
        {
            Console.Clear();
            Console.WriteLine($"Du försöker samla {resource}.\n");

            var rnd = new Random();
            int correctAnswers = 0;

            for (int i = 0; i < 3; i++)
            {
                int a = rnd.Next(1, 10);
                int b = rnd.Next(1, 10);
                int answer = a + b;

                Console.Write($"Vad är {a} + {b}? ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int userAnswer) && userAnswer == answer)
                {
                    correctAnswers++;
                }
            }

            if (correctAnswers == 3)
            {
                resources[resource] += 1;
                Console.WriteLine($"\nBra jobbat! Du fick 1 {resource}.");
            }
            else
            {
                Console.WriteLine($"\nDu klarade inte alla uppgifter. Ingen {resource} samlad denna gång.");
            }

            Console.WriteLine("\nTryck på valfri tangent för att återgå till Samla-menyn...");
            Console.ReadKey();

            // OBS: Ingen GatherMenu() här! Loopen i GatherMenu hanterar återgången.
        }

        private void ConvertMenu()
        {
            Console.Clear();
            Console.WriteLine("--- OMVANDLA ---");
            Console.WriteLine("1. 2 Trä + 2 Sten -> +1 Försvar");
            Console.WriteLine("2. Tillbaka");
            Console.Write("Val: ");
            string val = Console.ReadLine();

            if (val == "1")
            {
                if (resources["Trä"] >= 2 && resources["Sten"] >= 2)
                {
                    resources["Trä"] -= 2;
                    resources["Sten"] -= 2;
                    resources["Försvar"] += 1;
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

        private void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("--- STATISTIK ---");
            foreach (var r in resources)
            {
                Console.WriteLine($"{r.Key}: {r.Value}");
            }
            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }

        private void ShowReport()
        {
            Console.Clear();
            Console.WriteLine("--- LÄGESRAPPORT ---");
            Console.WriteLine("Allt verkar lugnt för tillfället. Röken stiger stilla över gläntan.");
            Console.WriteLine("\nTryck på valfri tangent för att återgå...");
            Console.ReadKey();
        }


        private void SaveAndExit()
        {
            Console.Clear();
            Console.WriteLine("Dina framsteg är sparade (simulerat).");
            running = false;
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

