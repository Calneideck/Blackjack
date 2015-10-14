using System;
using System.Collections.Generic;

namespace Blackjack.src
{
	public class Hand
	{
		public List<Card> Cards = new List<Card>();

		public Hand ()
		{
		}

		public void AddCard (Card card)
		{
			Cards.Add (card);
		}

	}
}
