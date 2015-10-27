using System;
using SwinGameSDK;


namespace Blackjack.src
{
	public class GameMain
	{
		private static Bitmap BackgroundImage;
		public static SoundEffect CardShuffle;
		public static SoundEffect CardSlide;

		private static void LoadImages() // load the images 
		{
			for (int i = 1; i <= 13; i++)
			{
				SwinGame.LoadBitmapNamed (i + " of spades", i + "s.jpg");
				SwinGame.LoadBitmapNamed (i + " of hearts", i + "h.jpg");
				SwinGame.LoadBitmapNamed (i + " of clubs", i + "c.jpg");
				SwinGame.LoadBitmapNamed (i + " of diamonds", i + "d.jpg");
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

			if (!game.Decision)
            {
                if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
                {
                    Audio.PlaySoundEffect(CardSlide);
                    game.Player.AddCard((game.Deck.Draw()));
                    game.CheckScores();
                }
                if (SwinGame.KeyTyped(KeyCode.vk_s))
                {
                    game.Dealer.Deal(game.Deck);
                    game.Decision = true;
                    game.CheckScores();
                }
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
			SwinGame.OpenGraphicsWindow("BlackJack", 800, 600);
            LoadResources ();
            Dealer dealer = new Dealer();
            Deck deck = new Deck();
            Player player = new Player();
            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.DealFirstTwoCards();

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