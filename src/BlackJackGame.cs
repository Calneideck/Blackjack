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
		private Hand _hand;
		private Dealer _dealer;
		private GameState _gamestate;
		private bool _decision;

		public BlackJackGame (Deck deck, Hand hand, Dealer dealer)
		{
			_deck = deck;
			_hand = hand;
			_dealer = dealer;
			_decision = false;
		}

		public void CheckScores()
		{
			if (_decision)
			{
				if (_hand.CardTotal > 21) 
				{
					_gamestate = GameState.LOSE;
				} 
				else 
				{
					if (_hand.CardsinHand == 5)
					{
						_gamestate = GameState.WIN;
					}
					else if (_hand.CardTotal > _dealer.CardTotal) 
					{
						_gamestate = GameState.WIN;
					}
					else if (_hand.CardTotal < _dealer.CardTotal)
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
			SwinGame.DrawText("Cards Remaining: " + _deck.CardsLeft()  ,Color.Red,0,20);
			SwinGame.DrawText (_hand.FirstTwoCards, Color.Black, 400, 500);
			SwinGame.DrawText ("Total: " + _hand.CardTotal, Color.Black, 400, 550);

			if (Player.CardsinHand > 2) 
			{
				string result;
				result = Player.Cards [2].ConvertToString();
				SwinGame.DrawText ("Your Third Card is: " + result, Color.Black, 400, 525);
			}

			if (_decision)
			{	switch (_gamestate) 
				{
				case GameState.LOSE: SwinGame.DrawText ("You Lose", Color.Black, 300, 300);
					break;
				case GameState.WIN: SwinGame.DrawText ("You Win", Color.Black, 300, 300);
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

		public void DealFirstTwoCards()
		{	
			Audio.PlaySoundEffect (GameMain.CardShuffle);
			_hand.AddCard (_deck.Draw ());
			_hand.AddCard (_deck.Draw ());
			_dealer.AddCard (_deck.Draw ());
			_dealer.AddCard (_deck.Draw ());
		}

		public void UpdateGame()
		{
			CheckScores ();
		}

        public GameState Status
        {
            get { return _gamestate; }
        }

		public Hand Player
		{
			get { return _hand; }
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

