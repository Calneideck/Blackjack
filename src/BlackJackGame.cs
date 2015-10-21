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
		}

		public void CheckScores()
		{
			if (_decision)
			{
				if (_player.CardTotal > 21) 
				{
					_gamestate = GameState.LOSE;
				} 
				else 
				{
					if (_player.CardsinHand == 5)
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

			}

		}

		public void DrawGame()
		{
			SwinGame.ClearScreen(Color.White);
			SwinGame.DrawText("Cards Remaining: " + _deck.CardsLeft()  ,Color.Red,0,20);
			SwinGame.DrawText (_player.FirstTwoCards, Color.Black, 400, 500);
			SwinGame.DrawText ("Total: " + _player.CardTotal, Color.Black, 400, 585);
			SwinGame.DrawText (" Your Money " + _player.Money, Color.Gold, 600, 20);
			SwinGame.DrawText (" Bet " + _player.Bet, Color.Gold, 600, 40);

			if (Player.CardsinHand >= 3) 
			{
				string result;
				result = Player.Cards [2].ConvertToString();
				SwinGame.DrawText ("Your Third Card is: " + result, Color.Black, 400, 525);
			}

			if (Player.CardsinHand >= 4) 
			{
				string result;
				result = Player.Cards [3].ConvertToString();
				SwinGame.DrawText ("Your Fourth Card is: " + result, Color.Black, 400, 545);
			}

			if (Player.CardsinHand >= 5) 
			{
				string result;
				result = Player.Cards [4].ConvertToString();
				SwinGame.DrawText ("Your Fifth Card is: " + result, Color.Black, 400, 565);
			}

			if (_decision)
			{	switch (_gamestate) 
				{
				case GameState.LOSE:
					SwinGame.DrawText ("You Lose", Color.Black, 300, 300);
					_player.Bet = 10;
					break;

				case GameState.WIN:
					SwinGame.DrawText ("You Win", Color.Black, 300, 300);
					break;

				case GameState.DRAW: SwinGame.DrawText ("Match Draw", Color.Black, 300, 300);
					break;
				default: 
					break;
				}

				SwinGame.DrawText (_dealer.FirstTwoCards, Color.Black, 400, 200);
				SwinGame.DrawText ("Total: " + _dealer.CardTotal, Color.Black, 400, 250);
			}


		}

		public void CheckDecision()
		{
			if (_player.CardTotal > 21) 
			{
				_decision = true;			
			} 
		}

		public void RestartGame()
		{
			if (_gamestate == GameState.WIN) {
				_player.Money += (_player.Bet * 2);
				_player.Bet = 10;
			}


			_decision = false;
			new BlackJackGame(_deck, _player, _dealer);
			_player.ClearHands ();
			_dealer.ClearHands ();
			_deck.Shuffle ();
			DealFirstTwoCards ();
		}

		public void DealFirstTwoCards()
		{
			Audio.PlaySoundEffect (GameMain.CardShuffle);
			_player.AddCard (_deck.Draw ());
			_player.AddCard (_deck.Draw ());
			_dealer.AddCard (_deck.Draw ());
			_dealer.AddCard (_deck.Draw ());
		}

		public void UpdateGame()
		{
			CheckScores ();
			CheckDecision ();
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

