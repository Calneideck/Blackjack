using System;

namespace Blackjack
{
	public enum Rank
	{
		ACE = 1,
		TWO, 
		THREE,
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
		private Suit _suit;
		private Rank _rank;

		public Card (Rank r, Suit s)
		{
            _rank = r;
            _suit = s;
		}

		public Rank Rank
		{
			get { return _rank; }
		}

		public Suit Suit
		{
			get { return _suit; }
		}
			

        public int Value
        {
            get
            {
                if ((int)_rank > 10)
                    return 10;
                return (int)_rank;
            }
        }

		public String ConvertToString()
		{
			String result = "";
			switch (_rank) 
			{
			case Rank.JACK:
				result += "Jack";
				break;
			case Rank.QUEEN:
				result += "Queen";
				break;
			case Rank.KING:
				result += "King";
				break;
			case Rank.ACE:
				result += "Ace";
				break;
			case Rank.TEN:
				result += "10";
				break;
			default:
				result += (int)_rank;
				break;
			}

			switch (_suit) {

			case Suit.SPADE:
				result += " of Spades";
				break;
			case Suit.HEART:
				result += " of Hearts";
				break;
			case Suit.DIAMOND:
				result += " of Diamonds";
				break;
			case Suit.CLUB:
				result += " of Clubs";
				break;
			default:
				result+= "TBD";
				break;
			}

			return result;
		}

	}
}



