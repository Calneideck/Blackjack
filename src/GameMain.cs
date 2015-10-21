using System;
using SwinGameSDK;


namespace Blackjack.src
{
	public class GameMain
	{
		private  static Bitmap BackgroundImage;
		public static SoundEffect CardShuffle;
		public static SoundEffect CardSlide;

		private static void LoadImages() // load the images 
		{
			for (int i = 1; i <= 13; i++)
			{
				SwinGame.LoadBitmapNamed (i + " of spades", i + "s.png");
				SwinGame.LoadBitmapNamed (i + " of hearts", i + "h.png");
				SwinGame.LoadBitmapNamed (i + " of clubs", i + "c.png");
				SwinGame.LoadBitmapNamed (i + " of diamonds", i + "d.png");
			}
			//Background

			BackgroundImage = Images.LoadBitmap("Background.jpg");

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

		private static void PlayerleUserInput(BlackJackGame game)
		{
			//Fetch the next batch of UI interaction
			SwinGame.ProcessEvents();

			if (SwinGame.KeyTyped (KeyCode.vk_SPACE ) && !game.Decision)
			{	Audio.PlaySoundEffect (CardSlide);
				game.Player.AddCard((game.Deck.Draw()));
			}

			if (SwinGame.KeyTyped (KeyCode.vk_s))
			{
				game.Decision = true;
			}
			if (SwinGame.KeyTyped (KeyCode.vk_s))
			{
				game.Decision = true;
			}

			if (SwinGame.KeyTyped (KeyCode.vk_r)) 
			{
				game.RestartGame ();
			}

			if (SwinGame.KeyTyped (KeyCode.vk_c))
			{
				game.Player.BetDown ();

			}


			if (SwinGame.KeyTyped (KeyCode.vk_b)) 
			{ 
				if (game.Player.Money <= 0)
				{
					Console.WriteLine("You dont have any money Left");
				}

				else
				{
					game.Player.BetUp();
				}
			}
				
		}

		private static void DrawGame(BlackJackGame game)
		{
            Graphics.ClearScreen();
            Images.DrawBitmap (BackgroundImage, 0, 0); 
			game.DrawGame ();
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
			Player player = new Player ();
			BlackJackGame game = new BlackJackGame (deck, player, dealer);
			game.DealFirstTwoCards ();

			SwinGame.OpenGraphicsWindow("BlackJack", 800, 600);
			LoadResources ();

			while (false == SwinGame.WindowCloseRequested())
			{
				PlayerleUserInput (game);
				UpdateGame(game);
				DrawGame (game);
				SwinGame.RefreshScreen(60);
			}
		}
	}
}