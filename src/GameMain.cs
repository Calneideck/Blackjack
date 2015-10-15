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
			Hand Player = new Hand();


			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{
				mydeck.Draw ();	
			}

			if (SwinGame.KeyTyped (KeyCode.vk_h))
			{

			}

			if (SwinGame.KeyTyped (KeyCode.vk_s))
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

		private static void DrawGame(Deck mydeck)
		{
			SwinGame.ClearScreen(Color.White);
			SwinGame.DrawText("Cards Remaining :" + mydeck.CardsLeft()  ,Color.Red,0,20);
			SwinGame.DrawText ("Money Left :" + money, Color.Gold, 600, 20);

			SwinGame.DrawFramerate(0, 0);
			SwinGame.RefreshScreen(60);
		}

		public static void Main()
		{
			Dealer dealer = new Dealer ();
			Deck test = new Deck ();
			Hand hand = new Hand ();
			SwinGame.OpenGraphicsWindow("BlackJack", 800, 600);
			LoadResources ();

			while (false == SwinGame.WindowCloseRequested())
			{
				HandleUserInput (test);
				DrawGame (test);

				if (hand.CardTotal >= 22) 
				{

				} else if (dealer.CardTotal >= 22)
				{

				}

				SwinGame.RefreshScreen(60);
			}
		}
	}
}