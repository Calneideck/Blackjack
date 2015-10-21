using System;

namespace Blackjack.src
{
	public class Dealer : Hand
	{
		public Dealer ()
		{
		}
			
		public void Deal (Deck deck)
		{
			while (CardTotal < 16)
			{
				AddCard (deck.Draw());
			}
		}

		public override string FirstTwoCards
		{
			get {
				string result1 = Cards [0].ConvertToString ();
				string result2 = Cards [1].ConvertToString ();
				return "Dealer has: " + result1 + " & " + result2; 
			}
		}
	}
}