using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Classes;
using Tennis.Exceptions;
using Tennis.Interfaces;

namespace Tennis
{
    /// <summary>
    /// Represents a tennis game and manages the scores of the players.
    /// </summary>
    public class TennisGame5Correction : ITennisGame
    {

        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;
        private readonly IConsole _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="TennisGame5Correction"/> class.
        /// </summary>
        /// <param name="playerOneName">The name of player one.</param>
        /// <param name="playerTwoName">The name of player two.</param>
        public TennisGame5Correction(string playerOneName, string playerTwoName, IConsole console)
        {
            _playerOne = new Player(playerOneName);
            _playerTwo = new Player(playerTwoName);
            _console = console;
        }

        /// <summary>
        /// Gets the current score of the tennis game.
        /// </summary>
        /// <returns>A string representing the current score.</returns>
        public string GetScore()
        {
            if (IsDeuce())
            {
                _console.WriteLine("Deuce");
                return "Deuce";
            }
            else if (IsAdvancedScore())
            {
                return GetAdvancedScore();
            }
            else
            {
                return GetRegularScore();
            }
        }

        /// <summary>
        /// Records a point won by the specified player.
        /// </summary>
        /// <param name="playerName">The name of the player who won the point.</param>
        /// <exception cref="PlayerNotFoundException">Thrown when the player name is invalid.</exception>
        public void WonPoint(string playerName)
        {
            if (playerName == _playerOne.Name)
            {
                _playerOne.WonPoint();
            }
            else if (playerName == _playerTwo.Name)
            {
                _playerTwo.WonPoint();
            }
            else
            {
                throw new PlayerNotFoundException($"Invalid player name: {playerName}");
            }
        }

        /// <summary>
        /// Determines whether the scores are at Deuce.
        /// </summary>
        /// <returns>True if the scores are at Deuce; otherwise, false.</returns>
        private bool IsDeuce()
        {
            return _playerOne.Score >= 3 && _playerTwo.Score == _playerOne.Score;
        }

        /// <summary>
        /// Determines whether at least one player has reached the advanced stages of the game.
        /// </summary>
        /// <returns>True if at least one player has reached the advanced stages; otherwise, false.</returns>
        private bool IsAdvancedScore()
        {
            return _playerOne.Score >= 4 || _playerTwo.Score >= 4;
        }

        /// <summary>
        /// Gets the score when at least one player has reached the advanced stages of the game.
        /// </summary>
        /// <returns>A string representing the current score.</returns>
        private string GetAdvancedScore()
        {
            if (Math.Abs(_playerOne.Score - _playerTwo.Score) >= 2)
            {
                _console.WriteLine($"Win for {LeadingPlayer().Name}");
                return $"Win for {LeadingPlayer().Name}";
            }
            else
            {
                _console.WriteLine($"Advantage {LeadingPlayer().Name}");
                return $"Advantage {LeadingPlayer().Name}";
            }
        }

        /// <summary>
        /// Gets the regular score of the game.
        /// </summary>
        /// <returns>A string representing the regular score.</returns>
        private string GetRegularScore()
        {
            if (_playerOne.Score == _playerTwo.Score)
            {
                _console.WriteLine($"{ScoreToString(_playerOne.Score)}-All");
                return ScoreToString(_playerOne.Score) + "-All";
            }
            else
            {
                _console.WriteLine($"{ScoreToString(_playerOne.Score)}-{ScoreToString(_playerTwo.Score)}");
                return ScoreToString(_playerOne.Score) + "-" + ScoreToString(_playerTwo.Score);
            }
        }

        /// <summary>
        /// Determines the player with the leading score.
        /// </summary>
        /// <returns>The player with the leading score.</returns>
        private IPlayer LeadingPlayer()
        {
            return _playerOne.Score > _playerTwo.Score ? _playerOne : _playerTwo;
        }

        /// <summary>
        /// Converts a score value to its corresponding string representation.
        /// </summary>
        /// <param name="score">The score to convert.</param>
        /// <returns>A string representing the score.</returns>
        /// <exception cref="InvalidScoreException">Thrown when the score is invalid.</exception>
        private static string ScoreToString(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => throw new InvalidScoreException("Invalid score.")
            };
        }
    }
}