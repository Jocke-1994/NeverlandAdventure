using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Events
{
    public class BearEvent : BaseEvent
    {
        public BearEvent()
        {
            Name = "BearEvent";
            Probability = 0.06; // 6 % chans
        }

        public override void Trigger()
        {
            DisplayRandomLineFromFile();
        }
    }
}
