using NeverlandAdventure;
using System;
using System.Collections.Generic;

namespace VillageGame
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            await Welcomepage.DisplayWelcomePage(); //För att testa Welcomepage.
            //LoginFeature.ShowLoginFeature(); //För att testa LoginFeature.
            //RegisterFeature.ShowRegisterFeature(); //För att testa RegisterFeature.
            //Game game = new Game();
            //game.Start();
        }

    }
}