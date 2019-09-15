using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RockPaperScissors
{
	[TestFixture]
	class GameFixture : Game
	{
		[Test]
		public void Should_calculate_correct_games_needed_to_win()
		{
			var gamesToBePlayed = 3;
			var gamesNeededToWin = 2;

			Assert.AreEqual(gamesNeededToWin, FindGamesNeededToWin(gamesToBePlayed));
		}

		[Test]
		public void Should_detect_wrong_amount_of_games_needed_to_win()
		{
			var gamesToBePlayed = 3;
			var gamesNeededToWin = 1;

			Assert.AreNotEqual(gamesNeededToWin, FindGamesNeededToWin(gamesToBePlayed));
		}

		[Test]
		public void Should_increment_tie_count()
		{
			var player1 = new Player { UsedShape = "Rock" };
			var player2 = new Player { UsedShape = "Rock" };
			var game = new Game ();
			var expectedTieCount = 1;

			GameSequence(player1, player2);
			Assert.AreEqual(expectedTieCount, game.Ties);
		}

		[Test]
		public void Should_increment_win_counter_when_shapes_are_rock_and_scissors()
		{
			var player1 = new Player { UsedShape = "Rock" };
			var player2 = new Player { UsedShape = "Scissors" };
			var gamesToBePlayed = 3;
			var expectedPlayer1WinCount = 1;
			var expectedPlayer2WinCount = 0;

			FindGamesNeededToWin(gamesToBePlayed);
			RunGame(player1, player2);
			Assert.AreEqual(expectedPlayer1WinCount, player1.Wins);
			Assert.AreEqual(expectedPlayer2WinCount, player2.Wins);
		}

		[Test]
		public void Should_increment_win_counter_when_shapes_are_paper_and_rock()
		{
			var player1 = new Player { UsedShape = "Paper" };
			var player2 = new Player { UsedShape = "Rock" };
			var game = new Game { Ties = 0 };
			var expectedTieCount = 1;

			RunGame(player1, player2);
			Assert.AreEqual(game.Ties, expectedTieCount);
		}

		[Test]
		public void Should_increment_win_counter_when_shapes_are_scissors_and_paper()
		{
			var player1 = new Player { UsedShape = "Scissors" };
			var player2 = new Player { UsedShape = "Paper" };
			var game = new Game { Ties = 0 };
			var expectedTieCount = 1;

			RunGame(player1, player2);
			Assert.AreEqual(game.Ties, expectedTieCount);
		}
	}
}
