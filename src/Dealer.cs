<<<<<<< HEAD:Dealer.cs
﻿using System;

namespace Blackjack
{
	public class Dealer
	{
		public Dealer ()
		{
		}
	}
}

=======
﻿using System;

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

>>>>>>> bbaedf1b132de25e15bed4c28f497dd1850cb654:src/Dealer.cs
