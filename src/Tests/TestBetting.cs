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
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            Assert.IsTrue(game.Player.Money == 90);
            Assert.IsTrue(game.Player.Bet == 10);
        }

		[Test()]
		public void TestBetLose()
		{
			Player player = new Player();
			Deck deck = new Deck();
			Dealer dealer = new Dealer();

			BlackJackGame game = new BlackJackGame(deck, player, dealer);

			player.AddCard(new Card(Rank.TEN, Suit.DIAMOND));
			player.AddCard(new Card(Rank.FOUR, Suit.SPADE));

			dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
			dealer.AddCard(new Card(Rank.EIGHT, Suit.SPADE));

			game.Decision = true;
			game.CheckScores();
			game.RestartGame ();

			Assert.IsTrue(game.Player.Money == 80);
		}



        [Test()]
        public void BetUp()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);
            game.Player.BetUp();
            Assert.IsTrue(game.Player.Bet == 20);
        }

        [Test()]
        public void BetDown()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            game.Player.BetUp();
            game.Player.BetUp();
            game.Player.BetUp();
            game.Player.BetDown();
            Assert.IsTrue(game.Player.Bet == 30);
        }

        [Test()]
        public void BetDownLowerLimit()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            game.Player.BetDown();
            Assert.IsTrue(game.Player.Bet == 10);
        }

        [Test()]
        public void TestBetWin()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.ACE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.NINE, Suit.SPADE));

            dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
            dealer.AddCard(new Card(Rank.EIGHT, Suit.SPADE));

            game.Decision = true;
            game.CheckScores();
			game.RestartGame ();
            Assert.IsTrue(game.Player.Money == 100);

        }

        [Test()]
        public void TestWin21()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

			dealer.AddCard(new Card(Rank.TEN, Suit.HEART));
			dealer.AddCard(new Card(Rank.EIGHT, Suit.SPADE));

            player.AddCard(new Card(Rank.ACE, Suit.DIAMOND));
            player.AddCard(new Card(Rank.JACK, Suit.SPADE));

			game.Decision = true;
            game.CheckScores();
			game.RestartGame ();
            Assert.IsTrue(game.Player.Money == 120);
        }

        [Test()]
        public void TestDoubleDown()
        {
            Player player = new Player();
            Deck deck = new Deck();
            Dealer dealer = new Dealer();

            BlackJackGame game = new BlackJackGame(deck, player, dealer);

            player.AddCard(new Card(Rank.SIX, Suit.DIAMOND));
            player.AddCard(new Card(Rank.FIVE, Suit.SPADE));
            game.DoubleDown();

            Console.WriteLine(player.Bet);
            Console.WriteLine(player.Cards.Count);
            Console.WriteLine(game.Decision);

            Assert.IsTrue(player.Bet == 20);
            Assert.IsTrue(player.Cards.Count == 3);
            Assert.IsTrue(game.Decision);
        }
    }
}
