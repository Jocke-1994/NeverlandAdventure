using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverlandAdventure.Events
{
    public class DamagedSupplyEvent : BaseEvent
    {
        public DamagedSupplyEvent()
        {
            Name = "DamagedSupplyEvent";
            Probability = 0.08; // 8 % chans
        }

        public override void Trigger()
        {
            DisplayRandomLineFromFile();
        }
    }
}
