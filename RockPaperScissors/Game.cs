using System;

namespace RockPaperScissors
{
    class Game
    {
        public int GamesNeededToWin { get; set; }
        public int Ties { get; set; }
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
                    requiredGamesToWin = i + 1;
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

        private void PlayerWinCounter(int player1WinCount, int player2WinCount, int tieCounter)
        {
            Console.WriteLine($"Player1: {player1WinCount}, Player2 {player2WinCount}, Ties: {tieCounter}");
        }

        private void AddTies(int tieCounter)
        {
            tieCounter++;
            Ties = tieCounter;
        }

        private void GameSequence(Player player1, Player player2)
        {
            var player1WinCounter = player1.Wins;
            var player2WinCounter = player2.Wins;
            var tieCounter = Ties;

            if (player1.UsedShape.Contains("Rock") && player2.UsedShape.Contains("Scissors"))
            {
                player1.AddWin(player1WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else if (player1.UsedShape.Contains("Paper") && player2.UsedShape.Contains("Rock"))
            {
                player1.AddWin(player1WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else if (player1.UsedShape.Contains("Scissors") && player2.UsedShape.Contains("Paper"))
            {
                player1.AddWin(player1WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else if (player2.UsedShape.Contains("Rock") && player1.UsedShape.Contains("Scissors"))
            {
                player2.AddWin(player2WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else if (player2.UsedShape.Contains("Paper") && player1.UsedShape.Contains("Rock"))
            {
                player2.AddWin(player2WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else if (player2.UsedShape.Contains("Scissors") && player1.UsedShape.Contains("Paper"))
            {
                player2.AddWin(player2WinCounter);
                PlayerWinCounter(player1.Wins, player2.Wins, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
            else
            {
                AddTies(tieCounter);
                PlayerWinCounter(player1WinCounter, player2WinCounter, tieCounter);
                Console.WriteLine($"Player1: {player1.UsedShape}, Player2: {player2.UsedShape}");
            }
        }

        public void RunGame()
        {
            Player player1 = new Player();
            Player player2 = new Player();

            while (player1.Wins < GamesNeededToWin && player2.Wins < GamesNeededToWin)
            {
                player1.ChooseShape();
                player2.ChooseShape();
                GameSequence(player1, player2);
            }

            Console.WriteLine(player1.Wins > player2.Wins ? "Winner: Player 1" : "Winner: Player 2");
        }
    }
}
