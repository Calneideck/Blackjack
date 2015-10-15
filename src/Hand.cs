﻿using System;
using System.Collections.Generic;

namespace Blackjack.src
{
 	public class Hand
 	{
		public List<Card> Cards = new List<Card>();
		private int Total;


		public int CardTotal 
		{
			get 
			{
				int Total = 0;
				foreach (Card card in Cards)
				{
					Total += (int)card.Rank;
				}
				foreach (Card card in Cards) //it goes through the loop
				{
					if (card.Rank == Rank.ACE && Total <= 10)
						Total += 10;// loops the card to check if the card values
				}	
				return Total;
			}

			set 
			{ 
				Total = value;
			}


		}

		public void AddCard (Card card)
		{
			Cards.Add (card);
		}
			
		public Hand ()
 		{
 		}
			
 	}
 }
 
