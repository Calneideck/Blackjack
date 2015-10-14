using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Blackjack.src.tests
{
    [TestFixture()]
    class TestCard
    {
        [Test()]
        public void TestDealCard()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            Assert.IsTrue(deck.CardLeft() == 52);
            deck.Draw();
            Assert.IsTrue(deck.CardLeft() == 51);
        }

        [Test()]
        public void TestHandTotal()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            Assert.IsTrue(hand.PlayerCards.Count == 0);
            hand.AddCard(deck.Draw());
            Assert.IsTrue(hand.PlayerCards.Count == 1);
        }

        [Test()]
        public void TestAce()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
			//Assert.IsTrue(hand.PlayerPoints[0] == 1);
			//Assert.IsTrue(hand.PlayerPoints[1] == 11);
        }
    }
}
