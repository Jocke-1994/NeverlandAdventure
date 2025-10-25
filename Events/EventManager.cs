using System;
using System.Collections.Generic;

namespace NeverlandAdventure.Events
{
    public static class EventManager
    {
        private static readonly Random rng = new Random();

        private static readonly List<BaseEvent> nightEvents = new()
        {
            new WolfAttackEvent(),
            new BanditEvent(),
            new BearEvent(),
            new DamagedSupplyEvent()
            // osv – lägg till fler vid behov
        };

        public static void TriggerNightEvent()
        {
            double roll = rng.NextDouble();
            double cumulative = 0;

            foreach (var ev in nightEvents)
            {
                cumulative += ev.Probability;
                if (roll <= cumulative)
                {
                    ev.Trigger();
                    return;
                }
            }

            Console.WriteLine("Natten var lugn. Inga attacker eller olyckor skedde.");
        }
    }
}