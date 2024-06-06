using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Tennis.Tests
{
    public class GoldenMasterTest2
    {
        private const string Dir = "D:\\PROJECTS\\SCHOOL_PROJECTS\\Tennis-Refactoring-Kata\\csharp\\Tennis.Tests\\GoldenMasterResult2\\";

        private string PlayGame(string player1Name, string player2Name, int player1Score, int player2Score)
        {
            var game = new TennisGame1(player1Name, player2Name);

            var highestScore = Math.Max(player1Score, player2Score);

            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                {
                    game.WonPoint(player1Name);
                }
                if (i < player2Score)
                {
                    game.WonPoint(player2Name);
                }
            }

            return game.GetScore();
        }

        private string MakeFileName(string player1Name, string player2Name, int player1Score, int player2Score)
        {
            return $"{player1Name}-{player2Name}-{player1Score}-{player2Score}.txt";
        }

        public static IEnumerable<object[]> CasGoldenMaster()
        {
            for (int scorePlayer1 = 0; scorePlayer1 < 16; scorePlayer1++)
                for (int scorePlayer2 = 0; scorePlayer2 < 16; scorePlayer2++)
                {
                    yield return new object[] { "player1", "player2", scorePlayer1, scorePlayer2 };
                    yield return new object[] { "John", "Jane", scorePlayer1, scorePlayer2 };
                    yield return new object[] { "Alice", "Bob", scorePlayer1, scorePlayer2 };
                }
        }

        [Theory]
        [MemberData(nameof(CasGoldenMaster))]
        public void Record(string player1Name, string player2Name, int player1Score, int player2Score)
        {
            var gameOutput = PlayGame(player1Name, player2Name, player1Score, player2Score);
            var fileName = MakeFileName(player1Name, player2Name, player1Score, player2Score);
            var path = Path.Combine(Dir, fileName);

            File.WriteAllText(path, gameOutput);
        }

        [Theory]
        [MemberData(nameof(CasGoldenMaster))]
        public void Replay(string player1Name, string player2Name, int player1Score, int player2Score)
        {
            var gameOutput = PlayGame(player1Name, player2Name, player1Score, player2Score);
            var fileName = MakeFileName(player1Name, player2Name, player1Score, player2Score);
            var path = Path.Combine(Dir, fileName);

            var expectedOutput = File.ReadAllText(path);

            Assert.Equal(expectedOutput, gameOutput);
        }
    }
}
