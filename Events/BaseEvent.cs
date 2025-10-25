using System;
using System.IO;

namespace NeverlandAdventure.Events
{
    public abstract class BaseEvent
    {
        public string Name { get; protected set; }
        public double Probability { get; protected set; }
        protected Random rng = new Random();

        // Pekar till textfil för beskrivningar
        protected string EventFilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Events", $"{Name}.txt");

        public abstract void Trigger();

        protected void DisplayRandomLineFromFile()
        {
            if (!File.Exists(EventFilePath))
            {
                Console.WriteLine($"[Event-fil saknas: {EventFilePath}]");
                return;
            }

            string[] lines = File.ReadAllLines(EventFilePath);
            if (lines.Length == 0)
            {
                Console.WriteLine($"[Event-filen {Name}.txt är tom]");
                return;
            }

            string randomLine = lines[rng.Next(lines.Length)];
            Console.WriteLine(randomLine);
        }
    }
}