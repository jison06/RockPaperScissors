using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors
{
    class Player
    {
        public int Wins { get; set; }
        public string UsedShape { get; set; }

        public Player(int wins)
        {
            Wins = wins;
        }
        public string ChooseShape()
        {
            string[] shapes = { "Rock", "Paper" , "Scissors" };
            var randomShape = new Random().Next(0, 2);
            UsedShape = shapes[randomShape];
            return shapes[randomShape];
        }

        public int GetPlayerWins()
        {

        }
    }
}
