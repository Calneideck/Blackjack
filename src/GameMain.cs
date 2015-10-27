using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public class GameMain
	{
		private static Bitmap BackgroundImage;
		public static SoundEffect CardShuffle;
		public static SoundEffect CardSlide;
		public static  Music music;
		private static bool _playing = false;
		private static bool _doubledowned = false;

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
			music = Audio.LoadMusic("music.mp3");
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
				if (SwinGame.KeyTyped(KeyCode.vk_d))
				{
					game.DoubleDown ();
					Audio.PlaySoundEffect (CardSlide);
					game.Player.AddCard ((game.Deck.Draw ()));
					game.CheckScores ();
					_playing = true;
					_doubledowned = true;
				}

                if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
                {
					if (_doubledowned == false) {
						Audio.PlaySoundEffect (CardSlide);
						game.Player.AddCard ((game.Deck.Draw ()));
						game.CheckScores ();
						_playing = true;
					}
                }

                if (SwinGame.KeyTyped(KeyCode.vk_s))
                {
                    game.Dealer.Deal(game.Deck);
                    game.Decision = true;
                    game.CheckScores();
					_playing = true;
                }
            }

			if (SwinGame.KeyTyped (KeyCode.vk_r)) 
			{
				game.RestartGame ();
				_playing = false;
			}

			if (SwinGame.KeyTyped (KeyCode.vk_c))
			{
				if (_playing == false) {
					game.Player.BetDown ();
				}
			}
				
			if (SwinGame.KeyTyped (KeyCode.vk_b)) 
			{ 
				if (_playing == false) {
					if (game.Player.Money <= 0) {
						Console.WriteLine ("You dont have any money Left");
					} else {
						game.Player.BetUp ();
					}
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
			Audio.PlayMusic (music);
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