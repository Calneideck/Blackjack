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

		public BlackJackGame (Deck deck, Player player, Dealer dealer)
		{
			_deck = deck;
			_player = player;
			_dealer = dealer;
			_decision = false;
			_player.BetUp ();
		}

		public void CheckScores()
		{
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
			SwinGame.DrawText (_player.FirstTwoCards(), Color.Black, 400, 500);
			SwinGame.DrawText(_dealer.FirstTwoCards(), Color.Black, 400, 200);
			SwinGame.DrawText("Total: " + _dealer.CardTotal, Color.Black, 400, 270);
			SwinGame.DrawText ("Total: " + _player.CardTotal, Color.Black, 400, 585);
			SwinGame.DrawText (" available Money $" + _player.Money, Color.Gold, 600, 20);
			SwinGame.DrawText (" Bet $" + _player.Bet, Color.Gold, 600, 40);

			if (Player.CardsinHand >= 3) 
			{
				Card myCard = Player.Cards [2];
				SwinGame.DrawText ("Your Third Card is: " + myCard.ConvertToString(), Color.Black, 400, 525);
				SwinGame.DrawBitmap(myCard.CardImage(), 500f, 355f);
			}

			if (Player.CardsinHand >= 4) 
			{
				Card myCard = Player.Cards [3];
				SwinGame.DrawText ("Your Fourth Card is: " + myCard.ConvertToString(), Color.Black, 400, 545);
				SwinGame.DrawBitmap(myCard.CardImage() ,550f, 355f);
			}

			if (Player.CardsinHand >= 5) 
			{
				Card myCard = Player.Cards [4];
				SwinGame.DrawText ("Your Fifth Card is: " + myCard.ConvertToString(), Color.Black, 400, 565);
				SwinGame.DrawBitmap(myCard.CardImage() ,600f, 355f);
			}

			if (Dealer.CardsinHand >= 2) 
			{
				Card DealerCard = Dealer.Cards [1];
				SwinGame.DrawText ("Dealer's Second Card is: " + DealerCard.ConvertToString(), Color.Black, 400, 225);
				SwinGame.DrawBitmap(DealerCard.CardImage(),  450f, 75f);
			}

			if (Dealer.CardsinHand >= 3) 
			{
				Card DealerCard = Dealer.Cards [2];
				SwinGame.DrawText ("Dealer's Third Card is: " + DealerCard.ConvertToString(), Color.Black, 400, 235);
				SwinGame.DrawBitmap(DealerCard.CardImage(),  500f, 75f);
			}

			if (Dealer.CardsinHand >= 4) 
			{
				Card DealerCard = Dealer.Cards [3];
				SwinGame.DrawText ("Dealer's Fourth Card is: " + DealerCard.ConvertToString(), Color.Black, 400, 245);
				SwinGame.DrawBitmap(DealerCard.CardImage() , 550f, 75f);
			}

			if (Dealer.CardsinHand >= 5) 
			{
				Card DealerCard = Dealer.Cards [4];
				SwinGame.DrawText ("Dealer's Fifth Card is: " + DealerCard.ConvertToString(), Color.Black, 400, 255);
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
				} else {
					Player.Bet = 0;
				}
				Player.Bet = 0;
				Player.BetUp ();

				_decision = false;
				_player.ClearHands ();
				_dealer.ClearHands ();
				//_deck.Shuffle ();
				DealFirstTwoCards ();
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
            //CheckScores ();
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

