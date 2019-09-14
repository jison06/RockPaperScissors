using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Text;

namespace RockPaperScissors
{
    class Game
    {
        public int GamesNeededToWin { get; set; }

        public string Winner { get; set; }

        public int FindGamesNeededToWin(int gamesToPlay)
        {
            var requiredGamesToWin = 0;
            var startingDifference = 0;
            for (int i = 0; i < gamesToPlay; i++)
            {
                if (i > 3 && i % 2 == 0)
                {
                    var difference = startingDifference += 1;
                    requiredGamesToWin = i - difference;
                }
                else
                {
                    requiredGamesToWin = i;
                }
            }

            GamesNeededToWin = requiredGamesToWin;
            return requiredGamesToWin;
        }

        public void GamesToBePlayed()
        {
            while (true)
            {
                Console.WriteLine("Choose the number of games to be played.");
                var playerInput = Console.ReadLine();
                int number = 0;
                var isNumber = Int32.TryParse(playerInput, out number);

                if (playerInput == string.Empty)
                {
                    Console.WriteLine("Choose an odd number!");
                }
                else if (isNumber == false && playerInput != string.Empty)
                {
                    Console.WriteLine("Put in a number!");
                }
                else
                {
                    var numberOfGames = Int32.Parse(playerInput);
                    if (numberOfGames % 2 != 0)
                    {
                        Console.WriteLine($"Games to be played: {numberOfGames}");
                        Console.WriteLine($"Number of games needed to win: {FindGamesNeededToWin(numberOfGames)}");
                        return;
                    }
                    Console.WriteLine("Choose an odd number!");
                }
            }
        }

        private void PlayerWinCounter(int player1WinCount, int player2WinCount, int tieCount)
        {
            Console.WriteLine($"Player1: {player1WinCount}, Player2 {player2WinCount}, Ties:{tieCount}");
        }

        private void GameSequence(Player winningPlayer, Player losingPlayer, int winningPlayerWinCounter, int losingPlayerWinCounter, int tieCounter)
        {
            if (winningPlayer.UsedShape.Contains("Rock") && losingPlayer.UsedShape.Contains("Scissors"))
            {
                winningPlayerWinCounter++;
                PlayerWinCounter(winningPlayerWinCounter, losingPlayerWinCounter, tieCounter);
            }
            else if (winningPlayer.UsedShape.Contains("Paper") && losingPlayer.UsedShape.Contains("Rock"))
            {
                winningPlayerWinCounter++;
                PlayerWinCounter(winningPlayerWinCounter, losingPlayerWinCounter, tieCounter);
            }
            else if (winningPlayer.UsedShape.Contains("Scissors") && losingPlayer.UsedShape.Contains("Paper"))
            {
                winningPlayerWinCounter++;
                PlayerWinCounter(winningPlayerWinCounter, losingPlayerWinCounter, tieCounter);
            }
            else
            {
                tieCounter++;
                PlayerWinCounter(winningPlayerWinCounter, losingPlayerWinCounter, tieCounter);
            }
        }

        public void RunGame()
        {
            var player1WinCounter = 0;
            var player2WinCounter = 0;
            var tieCounter = 0;
            Player player1 = new Player(player1WinCounter);
            Player player2 = new Player(player2WinCounter);

            while (player1WinCounter < GamesNeededToWin || player2WinCounter < GamesNeededToWin)
            {
                player1.ChooseShape();
                player2.ChooseShape();
                GameSequence(player1, player2, player1WinCounter, player2WinCounter, tieCounter);
                GameSequence(player2, player1, player2WinCounter, player1WinCounter, tieCounter);
            }
        }
    }
}
