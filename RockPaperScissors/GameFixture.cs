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
			
			Assert.AreEqual(FindGamesNeededToWin(gamesToBePlayed), gamesNeededToWin);
		}

		[Test]
		public void Should_detect_wrong_amount_of_games_needed_to_win()
		{
			var gamesToBePlayed = 3;
			var gamesNeededToWin = 1;

			Assert.AreNotEqual(FindGamesNeededToWin(gamesToBePlayed), gamesNeededToWin);
		}

		//[Test]
		//public void Should_add_ties()
		//{
		//	var player1 = new Player();
		//	var player2 = new Player();
		//	var expectedTieCount = 1;

		//	player1.UsedShape = "Rock";
		//	player2.UsedShape = "Rock";

			
		//}
	}
}
