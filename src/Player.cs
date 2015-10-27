using System;

namespace Blackjack.src
{
	public class Player :Hand
	{
		private int _money;
		private int _bet = 0;

		public Player ()
		{
			_money = 100;
		}

		public void BetUp ()
		{
			_money -= 10;
			_bet += 10;
		}

		public int Money
		{
			get{ return _money; }
			set{ _money = value; }
		}

		public int Bet
		{
			get { return _bet; }
			set{ _bet = value; }
		}


		public void BetDown ()
		{
			if (_bet > 10) 
			{
				_money += 10;
				_bet -= 10;
			}

		}
	}
}

