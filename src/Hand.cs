using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Blackjack.src
{
	public class Hand
 	{
		public List<Card> Cards = new List<Card>();

		public int CardTotal 
		{
			get 
			{
				int Total = 0;
                bool ace = false;
				foreach (Card card in Cards)
				{
					Total += card.Value;
                    if (card.Rank == Rank.ACE)
                        ace = true;
				}
                if (Total <= 11 && ace)
                    Total += 10;
				return Total;
			}
		}

		public void ClearHands()
		{
			Cards.Clear ();
		}

		public void AddCard (Card card)
		{
			Cards.Add (card);
		}

		public int CardsinHand
		{
			get {return  Cards.Count; }
		}
			
		public virtual string FirstTwoCards()
		{
			Card FirstCard = Cards [0];
			Card SecondCard = Cards [1];
			SwinGame.DrawBitmap(FirstCard.CardImage(), 400f, 355f);
			SwinGame.DrawBitmap(SecondCard.CardImage(), 450f, 355f);
			return "You have: " + FirstCard.ConvertToString () + " & " + SecondCard.ConvertToString (); 

		}
			
 	}
 }
 
