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
			Assert.IsTrue(deck.CardsLeft() == 52);
            deck.Draw();
			Assert.IsTrue(deck.CardsLeft() == 51);
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
        public void TestCardTotal()
        {
            Deck deck = new Deck();
            Hand hand = new Hand(0, "Player's Hand");
            hand.AddCard(new Card(Rank.SEVEN, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 17);
        }

        [Test()]
        public void TestCardTotalWithHighAce()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 21);
        }

        [Test()]
        public void TestCardTotalWithLowAce()
        {
            Hand hand = new Hand();
            hand.AddCard(new Card(Rank.NINE, Suit.SPADE));
            hand.AddCard(new Card(Rank.JACK, Suit.SPADE));
            hand.AddCard(new Card(Rank.ACE, Suit.SPADE));
			Assert.IsTrue(hand.CardTotal == 20);
        }

        [Test()]
        public void TestDealer15()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.FIVE, Suit.CLUB));
            dealer.Deal();
            Assert.IsTrue(dealer.PlayerCards = 3);
        }

        [Test()]
        public void TestDealer16()
        {
            Deck deck = new Deck();
            Dealer dealer = new Dealer();
            dealer.AddCard(new Card(Rank.KING, Suit.HEART));
            dealer.AddCard(new Card(Rank.SIX, Suit.CLUB));
            dealer.Deal();
            Assert.IsTrue(dealer.PlayerCards = 2);
        }
    }
}
