using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public class GameMain
	{
		private static int money = 100;
		private  const int BET = 10;
		private bool Win;


		public static void LoadResources()
		{

		}

		private static void HandleUserInput(Deck mydeck)
		{
			Hand Player = new Hand(2, "Player");


			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{
				mydeck.Draw ();	
			}

			if (SwinGame.KeyTyped (KeyCode.vk_h))
			{

			}

			if (SwinGame.KeyTyped (KeyCode.vk_l))
			{

			}
				

			if (SwinGame.KeyTyped (KeyCode.vk_b)) 
			{ 
				if (money <= 0)
				{
					Console.WriteLine("You dont have any money Left");
				}

				else
				{
					money = money - BET;
				}
			}
		}

		private static void DrawGame(Deck mydeck, Hand hand)
		{


			SwinGame.ClearScreen(Color.White);
			SwinGame.DrawText("Cards Remaining :" + mydeck.CardLeft()  ,Color.Red,0,20);
			SwinGame.DrawText ("Money Left :" + money, Color.Gold, 600, 20);
			SwinGame.DrawText ("Player Points :" + hand.PlayerPoints, Color.Blue, 400, 50);


			SwinGame.DrawFramerate(0, 0);
			SwinGame.RefreshScreen(60);
		}

		public static void Main()
		{
			Deck test = new Deck ();
			Hand hand = new Hand (2, "Player");
			SwinGame.OpenGraphicsWindow("BlackJack", 800, 600);
			LoadResources ();

			while (false == SwinGame.WindowCloseRequested())
			{
				HandleUserInput (test);
				DrawGame (test, hand);



				SwinGame.RefreshScreen(60);
			}
		}
	}
}