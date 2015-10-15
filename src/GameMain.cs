using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public class GameMain
	{
		private static int money = 100;
		private  const int BET = 10;

		public static void LoadResources()
		{

		}

		private static void HandleUserInput(BlackJackGame game)
		{
			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{
				game.Player.AddCard((game.Deck.Draw()));
				game.Decision = true;
			}

			if (SwinGame.KeyTyped (KeyCode.vk_s))
			{
				game.Decision = true;
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

		private static void DrawGame(BlackJackGame game)
		{
			game.DrawGame ();
			SwinGame.DrawText ("Money Left :" + money, Color.Gold, 600, 20);
			SwinGame.RefreshScreen(60);
		
	
		}

		private static void UpdateGame(BlackJackGame game)
		{
			game.UpdateGame ();
		}

		public static void Main()
		{
			Dealer dealer = new Dealer ();
			Deck deck = new Deck ();
			Hand player = new Hand ();
			BlackJackGame game = new BlackJackGame (deck, player, dealer);
			game.DealFirstTwoCards ();

			SwinGame.OpenGraphicsWindow("BlackJack", 800, 600);
			LoadResources ();

			while (false == SwinGame.WindowCloseRequested())
			{
				HandleUserInput (game);
				UpdateGame(game);
				DrawGame (game);
				SwinGame.RefreshScreen(60);
			}
		}
	}
}