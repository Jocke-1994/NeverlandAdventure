using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Events
{
    public class BanditEvent : BaseEvent
    {
        public BanditEvent()
        {
            Name = "BanditEvent";
            Probability = 0.07; // 7 % chans
        }

        public override void Trigger()
        {
            DisplayRandomLineFromFile(); // använder text från Events/BanditEvent.txt
        }
    }
}