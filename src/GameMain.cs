using System;
using SwinGameSDK;


namespace Blackjack.src
{
	public class GameMain
	{
		private static int money = 100;
		private  const int BET = 10;
		private  static Bitmap BackgroundImage;
		public static SoundEffect CardShuffle;
		public static SoundEffect CardSlide;

		private static void LoadImages() // load the images 
		{
<<<<<<< HEAD
			for (int i = 1; i <= 13; i++)
			{
				SwinGame.LoadBitmapNamed (i + " of spades", i + "s.png");
				SwinGame.LoadBitmapNamed (i + " of hearts", i + "h.png");
				SwinGame.LoadBitmapNamed (i + " of clubs", i + "c.png");
				SwinGame.LoadBitmapNamed (i + " of diamonds", i + "d.png");
			}
=======
			//Background

			BackgroundImage = Images.LoadBitmap("Background.jpg");

>>>>>>> dd70ffa450d957e6c7e3d2fd1d84ded7d4a2fdf0
		}

		public static void LoadSoundEffects()// load the sound effects
		{
			CardShuffle = Audio.LoadSoundEffect ("cardShuffle.ogg");
			CardSlide = Audio.LoadSoundEffect("cardSlide8.ogg");
		}	

		public static void LoadResources() // Cards
		{
			LoadImages ();
			LoadSoundEffects ();
		}

		private static void HandleUserInput(BlackJackGame game)
		{
			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
			{	Audio.PlaySoundEffect (CardSlide);
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
            Graphics.ClearScreen();
            Images.DrawBitmap (BackgroundImage, 0, 0); 
			game.DrawGame ();
			SwinGame.DrawText ("Money Left: " + money, Color.Gold, 600, 20);
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