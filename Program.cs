using NeverlandAdventure;
using NeverlandAdventure.Menus;
using System;
using System.Collections.Generic;

namespace NeverlandAdventure
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Welcomepage.DisplayWelcomePage(); //För att testa Welcomepage. //await används för 2FA SMS. (await Welcomepage.DisplayWelcomePage();)
            //LoginFeature.ShowLoginFeature(); //För att testa LoginFeature.
            //RegisterFeature.ShowRegisterFeature(); //För att testa RegisterFeature.
            //För att testa CollectMenu.
            MainGame game = new MainGame();
            game.Start();

        }

    }
}