using System;

namespace RockPaperScissors
{
  class Program
  {
    static void Main()
    {
      var rockPaperScissorsGame = new Game();
      var player1 = new Player();
      var player2 = new Player();
      rockPaperScissorsGame.EnterPlayersNames();
      rockPaperScissorsGame.GamesToBePlayed();
      rockPaperScissorsGame.RunGame(player1, player2);
    }
  }
}