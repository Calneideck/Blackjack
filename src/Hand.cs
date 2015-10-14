using System;
using System.Collections.Generic;

namespace Blackjack.src
{
	public class Hand
	{
		public List<Card> PlayerCards = new List<Card>();

		public Hand ()
		{
		}
			
		public void AddCard (Card card)
		{
			PlayerCards.Add (card);
		}

	}
}
