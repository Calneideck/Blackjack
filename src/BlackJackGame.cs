using System;

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

		public BlackJackGame (Deck deck, Hand hand, Dealer dealer)
		{
			_deck = deck;
			_hand = hand;
			_dealer = dealer;
		}

		public void CheckScores()
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
				if (_hand.CardTotal > _dealer.CardTotal) 
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

        public GameState Status
        {
            get { return _gamestate; }
        }
	}
}

