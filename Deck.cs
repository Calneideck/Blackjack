﻿using System;
using System.Collections.Generic;

namespace Blackjack
{
	public class Deck
	{
		private int cardsUsed;
		List<Card> _cards;

		public Deck ()
		{
			_cards = new List<Card> ();

			for (int i = 0; i < 4; i++) 
			{
				for (int j = 0; j < 13; j++) //52 times
				{
					_cards.Add (new Card (){Suit = (Suit)i,Rank = (Rank)j}); // I'm not sure if this is the correct way of setting Rank and Suit

				}
				cardsUsed = 0;
			}

		}

		public void Shuffle()
		{
			Random rnd = new Random();
			// for each card (no need to shuffle last card)
			for(int i = 0; i < 52 - 1; i++)
			{
				// pick a random index
				int rndIdx = rnd.Next(52 - i);
				Card temp = _cards[i];
				_cards[i] = _cards[i + rndIdx];
				_cards[i + rndIdx] = temp;
			}

			cardsUsed = 0;
		}

		public int CardLeft()
		{
			return 52 - cardsUsed;
		}

		public Card Draw()
		{
			if (cardsUsed == 52) 
			{
				Shuffle ();	
				return null;
			}

			else 
			{
				cardsUsed++;
				Card result = _cards [cardsUsed - 1];

				return result;
			}
		}
	}
}