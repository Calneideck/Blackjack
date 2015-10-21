using System;
using System.Collections.Generic;

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
				foreach (Card card in Cards)
				{
					Total += card.Value;
                    if (card.Rank == Rank.ACE && Total <= 10)
						Total += 10;// loops the card to check if the card values
				}
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
			
		public virtual string FirstTwoCards
		{
			get
			{	string result1 = Cards [0].ConvertToString ();
				string result2 = Cards [1].ConvertToString ();

				return "You have: " + result1 + " & " + result2; 
			}
		}
			
 	}
 }
 
