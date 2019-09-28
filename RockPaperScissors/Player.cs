using System;

namespace RockPaperScissors
{
	class Player
	{
		public int Wins { get; set; }
		public string UsedShape { get; set; }
		public bool Winner { get; set; }

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
			Winner = true;
			return Wins;
		}
	}
}

