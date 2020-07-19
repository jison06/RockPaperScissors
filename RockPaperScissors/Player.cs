using System;

namespace RockPaperScissors
{
	class Player
	{
		public int Wins { get; set; }
		public string UsedShape { get; set; }
		public bool Winner { get; set; }

		public void ChooseShape()
		{
			string[] shapes = { "Rock", "Paper", "Scissors" };
			var randomShape = new Random().Next(0, 3);
			UsedShape = shapes[randomShape];
		}

		public void AddWin(int winCounter)
		{
			++winCounter;
			Wins = winCounter;
			Winner = true;
		}
	}
}

