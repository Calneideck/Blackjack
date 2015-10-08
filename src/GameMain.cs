using System;
using SwinGameSDK;

namespace Blackjack.src
{
    public class GameMain
    {
        public static void Main()
        {
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();

            while (false == SwinGame.WindowCloseRequested())
            {
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.White);

                SwinGame.DrawFramerate(0, 0);

                SwinGame.RefreshScreen(60);
            }
        }
    }
}