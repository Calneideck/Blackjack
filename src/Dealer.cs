using System;
using SwinGameSDK;

namespace Blackjack.src
{
	public class Dealer : Hand
	{
		public Dealer ()
		{
		}
			
		public void Deal (Deck deck)
		{
			while (CardTotal < 17)
			{
				AddCard (deck.Draw());
			}
		}

		public override string FirstTwoCards ()
		{

			Card FirstCard = Cards [0];
			SwinGame.DrawBitmap(FirstCard.CardImage(), 400f, 75f);
			return "Dealer has: " + FirstCard.ConvertToString ();

		}
	}
}