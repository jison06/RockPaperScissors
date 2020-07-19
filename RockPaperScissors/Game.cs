using System;

namespace RockPaperScissors
{
  class Game
  {
    public int GamesNeededToWin { get; set; }
    public int Ties { get; set; }
    public string FirstPlayerName { get; set; }
    public string SecondPlayerName { get; set; }

    public void EnterPlayersNames()
    {
      Console.WriteLine("Enter player one's name");
      var player1Name = Console.ReadLine();
      FirstPlayerName = player1Name;

      Console.WriteLine("Enter player two's name");
      var player2Name = Console.ReadLine();
      SecondPlayerName = player2Name;
    }

    private int FindGamesNeededToWin(int gamesToPlay)
    {
      return gamesToPlay / 2 + 1;
    }

    public void GamesToBePlayed()
    {
      var completed = false;
      while (!completed)
      {
        Console.WriteLine("Choose the number of games to be played.");
        var playerInput = Console.ReadLine();
        var number = 0;
        var isNumber = Int32.TryParse(playerInput, out number);

        if (!isNumber)
        {
          Console.WriteLine("Put in a number!");
        }
        else if (number % 2 == 0)
        {
          Console.WriteLine("Choose an odd number!");
        }
        else if (number < 0)
        {
          Console.WriteLine("Number has to be positive!");
        }
        else
        {
          Console.WriteLine($"Games to be played: {number}");
          Console.WriteLine($"Number of games needed to win: {FindGamesNeededToWin(number)}");

          completed = true;
        }
      }
    }

    //fix logic
    private void PlayerWinCounter(int player1WinCount, int player2WinCount, int tieCounter, Player player1, Player player2)
    {
      Console.WriteLine($"Winner: {(player1.Winner ? $"{FirstPlayerName}" : $"{SecondPlayerName}")}, Loser: {(player1.Winner ? $"{SecondPlayerName}" : $"{FirstPlayerName}")}");
      Console.WriteLine($"{FirstPlayerName}: {player1WinCount}, {SecondPlayerName} {player2WinCount}, Ties: {tieCounter}");
      player1.Winner = false;
      player2.Winner = false;
    }

    private void DisplayTieCounter(int player1WinCount, int player2WinCount, int tieCounter)
    {
      Console.WriteLine($"{FirstPlayerName}: {player1WinCount}, {SecondPlayerName} {player2WinCount}, Ties: {tieCounter}");
    }

    private void AddTies()
    {
      ++Ties;
    }

    //fix... adding win at the wrong place
    private void DisplayGameStatistics(Player player1, Player player2, int tieCounter, int winningPlayerWinCounter)
    {
      PlayerWinCounter(player1.Wins, player2.Wins, tieCounter, player1, player2);
      Console.WriteLine($"{FirstPlayerName}: {player1.UsedShape}, {SecondPlayerName}: {player2.UsedShape}");
    }

    //debug through this... player1 and player2 logic to get the losing player
    public void GameSequence(Player player1, Player player2)
    {
      var player1WinCounter = player1.Wins;
      var player2WinCounter = player2.Wins;
      var player1Shape = player1.UsedShape;
      var player2Shape = player2.UsedShape;

      if (player1Shape.Contains("Rock") && player2Shape.Contains("Scissors"))
      {
        player1.AddWin(player1WinCounter);
        DisplayGameStatistics(player1, player2, Ties, player1WinCounter);
      }
      else if (player1Shape.Contains("Paper") && player2Shape.Contains("Rock"))
      {
        player1.AddWin(player1WinCounter);
        DisplayGameStatistics(player1, player2, Ties, player1WinCounter);
      }
      else if (player1Shape.Contains("Scissors") && player2Shape.Contains("Paper"))
      {
        player1.AddWin(player1WinCounter);
        DisplayGameStatistics(player1, player2, Ties, player1WinCounter);
      }
      else if (player2Shape.Contains("Rock") && player1Shape.Contains("Scissors"))
      {
        player2.AddWin(player2WinCounter);
        DisplayGameStatistics(player2, player1, Ties, player2WinCounter);
      }
      else if (player2Shape.Contains("Paper") && player1Shape.Contains("Rock"))
      {
        player2.AddWin(player2WinCounter);
        DisplayGameStatistics(player2, player1, Ties, player2WinCounter);
      }
      else if (player2Shape.Contains("Scissors") && player1Shape.Contains("Paper"))
      {
        player2.AddWin(player2WinCounter);
        DisplayGameStatistics(player2, player1, Ties, player2WinCounter);
      }
      else if(String.Equals(player1Shape, player2Shape))
      {
        AddTies();
        DisplayTieCounter(player1WinCounter, player2WinCounter, Ties);
        Console.WriteLine($"{FirstPlayerName}: {player1Shape}, {SecondPlayerName}: {player2Shape}");
      }
    }

    public void RunGame(Player player1, Player player2)
    {
      while (player1.Wins < GamesNeededToWin && player2.Wins < GamesNeededToWin)
      {
        player1.ChooseShape();
        player2.ChooseShape();
        GameSequence(player1, player2);
      }

      Console.WriteLine(player1.Wins > player2.Wins ? $"Winner: {FirstPlayerName}" : $"Winner: {SecondPlayerName}");
    }
  }
}
