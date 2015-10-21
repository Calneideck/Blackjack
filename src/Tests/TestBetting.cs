using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Blackjack.src.Tests
{
    [TestFixture()]
    class TestBetting
    {
        [Test()]
        public void TestStartingMoneyAndInitialBet()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            Assert.IsTrue(game.Money == 100);
            Assert.IsTrue(game.Bet == 10);
        }

        [Test()]
        public void BetUp()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            game.BetUp();
            Assert.IsTrue(game.Bet == 20);
        }

        [Test()]
        public void BetDown()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            game.BetUp();
            game.BetUp();
            game.BetUp();
            game.BetDown();
            Assert.IsTrue(game.Bet == 30);
        }

        [Test()]
        public void BetDownLowerLimit()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            game.BetDown();
            Assert.IsTrue(game.Bet == 10);
        }

        [Test()]
        public void TestBetWin()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.ACE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.NINE, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
            dealer.AddCard(new Card(Rank.EIGHT, Suit.SPADE));

            game.Decision = true;
            game.CheckScores();

            Assert.IsTrue(game.Money == 110);
        }

        public void TestBetLose()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
            player.AddCard(new Card(Rank.FOUR, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
            dealer.AddCard(new Card(Rank.EIGHT, Suit.SPADE));

            game.Decision = true;
            game.CheckScores();

            Assert.IsTrue(game.Money == 90);
        }

        [Test()]
        public void TestWin21()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.ACE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.JACK, Suit.SPADE));
            game.CheckScores();

            Assert.IsTrue(game.Money == 115);
        }

        [Test()]
        public void TestWinDouble()
        {
            Hand player = new Hand();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.FIVE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.SIX, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
            dealer.AddCard(new Card(Rank.SIX, Suit.SPADE));

            game.Player.DoubleDown();
            if (player.CardTotal > dealer.CardTotal)
            {
                game.CheckScores();
                Assert.IsTrue(game.Status == GameState.WIN);
            }
            else
            {
                Assert.Inconclusive();
            }

        }
    }
}
