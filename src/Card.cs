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

		public Card()
		{

		}

		public Card(Rank CardRank, Suit CardSuit)
		{
			this.CardRank = CardRank;
			this.CardSuit = CardSuit;

		}

		public int HighValue {
		
			get {
				switch (CardRank) {
				case Rank.JACK:
				case Rank.QUEEN:
				case Rank.KING:
				case Rank.TEN:
					return 10;
				case Rank.ACE:
					return 11;
				default:
					return (int)CardRank;
				}
			}
		}
		 

		public int LowValue {

			get {
				switch (CardRank) {
				case Rank.JACK:
				case Rank.QUEEN:
				case Rank.KING:
				case Rank.TEN:
					return 10;
				default:
					return (int)CardRank;
				}
			}

		} 
	}}




