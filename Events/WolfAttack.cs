using System;

namespace NeverlandAdventure.Events
{
    public class WolfAttackEvent : BaseEvent
    {
        public WolfAttackEvent()
        {
            Name = "WolfAttack";     // matchar filnamnet WolfAttack.txt
            Probability = 0.10;
        }

        public override void Trigger()
        {
            DisplayRandomLineFromFile();
        }
    }
}