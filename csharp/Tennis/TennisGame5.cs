using System;

namespace Tennis
{
    // TODO: Consider using another class for the player, such as 'Player.cs', and an abstraction like 'IPlayer'
    // This would enhance code clarity and maintainability, enabling easier extension and modification
    public class TennisGame5 : ITennisGame
    {
        // TODO: By convention, it's preferable to use camelCase for variable names, such as 'playerOneScore'
        // Encapsulation would be beneficial to restrict access and modification to these variables
        private int player1Score;
        private int player2Score;
        private string player1Name;
        private string player2Name;

        public TennisGame5(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Score++;
            else if (playerName == player2Name)
                player2Score++;
            else
                // TODO: Consider using a custom exception type for better error handling and debugging
                throw new ArgumentException("Invalid player name.");
        }

        public string GetScore()
        {
            // TODO: The usage of local variables 'p1' and 'p2' is redundant and unnecessary, directly use 'player1Score' and 'player2Score'
            int p1 = player1Score;
            int p2 = player2Score;

            // TODO: Refactor the loop logic for readability and clarity. Consider using descriptive variable names
            while (p1 > 4 || p2 > 4)
            {
                p1--;
                p2--;
            }

            // TODO: The switch statement has become too lengthy and less readable
            // Extract this logic into a separate method for better maintainability
            return (p1, p2) switch
            {
                // TODO: Consider using constants or enums instead of hardcoding strings for better maintainability and readability.
                (0, 0) => "Love-All",
                (0, 1) => "Love-Fifteen",
                (0, 2) => "Love-Thirty",
                (0, 3) => "Love-Forty",
                (0, 4) => $"Win for {player2Name}",
                (1, 0) => "Fifteen-Love",
                (1, 1) => "Fifteen-All",
                (1, 2) => "Fifteen-Thirty",
                (1, 3) => "Fifteen-Forty",
                (1, 4) => $"Win for {player2Name}",
                (2, 0) => "Thirty-Love",
                (2, 1) => "Thirty-Fifteen",
                (2, 2) => "Thirty-All",
                (2, 3) => "Thirty-Forty",
                (2, 4) => $"Win for {player2Name}",
                (3, 0) => "Forty-Love",
                (3, 1) => "Forty-Fifteen",
                (3, 2) => "Forty-Thirty",
                (3, 3) => "Deuce",
                (3, 4) => $"Advantage {player2Name}",
                (4, 0) => $"Win for {player1Name}",
                (4, 1) => $"Win for {player1Name}",
                (4, 2) => $"Win for {player1Name}",
                (4, 3) => $"Advantage {player1Name}",
                (4, 4) => "Deuce",
                // TODO: Throw a custom exception for better error handling and debugging.
                _ => throw new ArgumentException("Invalid score.")
            };
        }
    }
}
