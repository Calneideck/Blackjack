using System;

namespace Blackjack.src
{

	public enum Rank
	{
		ACE = 1,
		TWO,
		THREE ,
		FOUR,
		FIVE,
		SIX,
		SEVEN,
		EIGHT,
		NINE,
		TEN,
		JACK,
		QUEEN,
		KING
	}

	public enum Suit
	{
		SPADE,
		HEART,
		CLUB,
		DIAMOND
	}
	public class Card
	{
		public Suit CardSuit;
		public Rank CardRank;

		public Card(Rank CardRank, Suit CardSuit)
		{
			this.CardRank = CardRank;
			this.CardSuit = CardSuit;

		}

		 
	}
}




