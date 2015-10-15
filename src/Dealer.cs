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


	}
}