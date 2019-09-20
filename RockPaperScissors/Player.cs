using System;

namespace RockPaperScissors
{
	class Player
	{
		public int Wins { get; set; }
		public string UsedShape { get; set; }
		public string playerName { get; set; }

		public string ChooseShape()
		{
			string[] shapes = { "Rock", "Paper", "Scissors" };
			var randomShape = new Random().Next(0, 3);
			UsedShape = shapes[randomShape];
			return UsedShape;
		}

		public int AddWin(int winCounter)
		{
			++winCounter;
			Wins = winCounter;
			return Wins;
		}

		//find a way to make a check for the wins for when a player wins
		public bool IsWinningPlayer()
		{
			var currentWinCounter = Wins;
			var oldWinCount = --currentWinCounter;
			if (++oldWinCount == Wins)
				return true;
			
			return false;
		}
	}
}

