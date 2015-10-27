using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public enum GameState
	{
		WIN,
		LOSE,
		DRAW
	}
	public class BlackJackGame
	{
		private Deck _deck;
		private Player _player;
		private Dealer _dealer;
		private GameState _gamestate;
		private bool _decision;
		private bool _playing = false;
		private  bool _doubledowned = false;

		public BlackJackGame (Deck deck, Player player, Dealer dealer)
		{
			_deck = deck;
			_player = player;
			_dealer = dealer;
			_decision = false;
			_player.BetUp ();
			CheckScores ();
		}

		public bool Double
		{
			get {return _doubledowned;}
			set {_doubledowned = value;}
		}

		public bool Playing 
		{
			get {return _playing;}
			set {_playing = value;}
		}

		public void CheckScores()
		{
			if (Player.CardTotal == 21) {
				_decision = true;
			}
			if (_decision)
			{
				if (Dealer.CardTotal > 21)
                {
                    _gamestate = GameState.WIN;
                }
                else if (_player.CardTotal > _dealer.CardTotal)
				{
					_gamestate = GameState.WIN;
				}
				else if (_player.CardTotal < _dealer.CardTotal)
				{
					_gamestate = GameState.LOSE;
				}
				else
				{
					_gamestate = GameState.DRAW;
				}
			}
            else
            {
                if (_player.CardTotal > 21) 
				{
					_gamestate = GameState.LOSE;
                    _decision = true;
				} 
                else if (_player.CardsinHand == 5)
				{
					_gamestate = GameState.WIN;
                    _decision = true;
				}
            }
		}

		public void DrawGame()
		{
			SwinGame.DrawText("Cards Remaining: " + _deck.CardsLeft()  ,Color.Blue, 20, 20);
			SwinGame.DrawText("Play again: R key", Color.Blue, 20, 60);
			SwinGame.DrawText("Hit: Spacebar", Color.Blue, 20, 80);
			SwinGame.DrawText("Sit: S key", Color.Blue, 20, 100);
			SwinGame.DrawText("DoubleDown: D key", Color.Blue, 20, 120);
			SwinGame.DrawText("Bet Up: B key", Color.Blue, 20, 140);
			SwinGame.DrawText("Bet Down: C key", Color.Blue, 20, 160);
			SwinGame.DrawText("Dealer's Total: " + _dealer.CardTotal,  Color.White, "Arial", 30, 400, 200);
			SwinGame.DrawText("Your Total: " + _player.CardTotal, Color.White, "Arial", 30, 400, 480);
			SwinGame.DrawText(" available Money $" + _player.Money, Color.Gold, 600, 20);
			SwinGame.DrawText(" Bet $" + _player.Bet, Color.Gold, 600, 40);

            _player.DrawFirstTwoCards();
			_dealer.DrawFirstTwoCards();

			if (Player.CardsinHand >= 3) 
			{
				Card myCard = Player.Cards [2];
				SwinGame.DrawBitmap(myCard.CardImage(), 500f, 355f);
			}

			if (Player.CardsinHand >= 4) 
			{
				Card myCard = Player.Cards [3];
				SwinGame.DrawBitmap(myCard.CardImage() ,550f, 355f);
			}

			if (Player.CardsinHand >= 5) 
			{
				Card myCard = Player.Cards [4];
				SwinGame.DrawBitmap(myCard.CardImage() ,600f, 355f);
			}

			if (Dealer.CardsinHand >= 2) 
			{
				Card DealerCard = Dealer.Cards [1];
				SwinGame.DrawBitmap(DealerCard.CardImage(),  450f, 75f);
			}

			if (Dealer.CardsinHand >= 3) 
			{
				Card DealerCard = Dealer.Cards [2];
				SwinGame.DrawBitmap(DealerCard.CardImage(),  500f, 75f);
			}

			if (Dealer.CardsinHand >= 4) 
			{
				Card DealerCard = Dealer.Cards [3];
				SwinGame.DrawBitmap(DealerCard.CardImage() , 550f, 75f);
			}

			if (Dealer.CardsinHand >= 5) 
			{
				Card DealerCard = Dealer.Cards [4];
				SwinGame.DrawBitmap(DealerCard.CardImage() ,600f, 75f);
			}

			if (_decision)
			{	switch (_gamestate) 
				{
				case GameState.LOSE:
					SwinGame.DrawText ("You Lose", Color.Black, 300, 300);
					break;

				case GameState.WIN:
					SwinGame.DrawText ("You Win", Color.Black, 300, 300);
					break;

				case GameState.DRAW: SwinGame.DrawText ("Match Draw", Color.Black, 300, 300);
					break;
				default: 
					break;
				}

				if (Player.Money <= 0) 
				{
					Player.Bet = 0;
					SwinGame.DrawText (" No funds" , Color.Gold, 600, 60);
					SwinGame.DrawText (" Bet amount now set to 0" , Color.Gold, 600, 80);
				}
				
			}

		}

		public void DoubleDown()
		{
			Player.Bet = Player.Bet * 2;
		}

		public void RestartGame()
		{
			if (_decision == true) {
				if (_gamestate == GameState.WIN) {
					Player.Money = Player.Money + Player.Bet * 2;
					Player.Bet = 0;


				} 
				if (_gamestate == GameState.LOSE) {
					Player.Bet = 0;
				} 

				Player.BetUp ();

				Double = false;
				Playing = false;
				_decision = false;
				_player.ClearHands ();
				_dealer.ClearHands ();
				DealFirstTwoCards ();
				CheckScores ();

			} 
		}

		public void DealFirstTwoCards()
		{
			Audio.PlaySoundEffect (GameMain.CardShuffle);
			// Player gets 2 cards
            _player.AddCard (_deck.Draw ());
			_player.AddCard (_deck.Draw ());
            // Dealer gets 1
			_dealer.AddCard (_deck.Draw ());
		}

		public void UpdateGame()
		{
			
		}

		public GameState Status
		{
			get { return _gamestate; }
		}

		public Player Player
		{
			get { return _player; }
		}

		public Dealer Dealer
		{
			get { return _dealer; }
		}

		public Deck Deck 
		{ 
			get { return _deck; } 
		}

		public bool Decision
		{
			get { return _decision; }
			set { _decision = value; }
		}
	}
}

