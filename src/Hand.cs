 ﻿using System;
using System.Collections.Generic;
 
 {
 	public class Hand
 	{
		public Hand ()
		public List<Card> PlayerCards = new List<Card>();
		public string Name;


		public int PlayerPoints
		{
			get 
			{
				int Points = 0;
				foreach (Card c in PlayerCards)
				{
					Points += (int)c.CardRank;
				}
				return Points;
			}
		}

		public Hand (int HandSize, string Name)
 		{
			PlayerCards.Capacity = HandSize;
			this.Name = Name;
 		}
			
 	}
 }
 
