using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tennis.Classes;
using Xunit;

namespace Tennis.Tests
{

    public class TestDataGeneratorGoldenMaster : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {0, 0},
            new object[] {1, 1},
            new object[] {2, 2},
            new object[] {3, 3},
            new object[] {4, 4},
            new object[] {1, 0},
            new object[] {0, 1},
            new object[] {2, 0},
            new object[] {0, 2},
            new object[] {3, 0},
            new object[] {0, 3},
            new object[] {4, 0},
            new object[] {0, 4},
            new object[] {2, 1},
            new object[] {1, 2},
            new object[] {3, 1},
            new object[] {1, 3},
            new object[] {4, 1},
            new object[] {1, 4},
            new object[] {3, 2},
            new object[] {2, 3},
            new object[] {4, 2},
            new object[] {2, 4},
            new object[] {4, 3},
            new object[] {3, 4},
            new object[] {5, 4},
            new object[] {4, 5},
            new object[] {15, 14},
            new object[] {14, 15},
            new object[] {6, 4},
            new object[] {4, 6},
            new object[] {16, 14},
            new object[] {14, 16},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class GoldenMasterTest
    {
        private string RunAGame(int player1Score, int player2Score)
        {
            var console = new StringBuilderConsole();
            var game = new TennisGame5Correction("player1", "player2", console);

            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    game.WonPoint("player1");
                if (i < player2Score)
                    game.WonPoint("player2");
            }

            game.GetScore();

            var output = console.Output;
            if (string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("No output was captured from the game.");
            }

            return output;
        }

        [Theory]
        [ClassData(typeof(TestDataGeneratorGoldenMaster))]
        public void Record(int p1, int p2)
        {
            var output = RunAGame(p1, p2);
            var directoryPath = "D:\\PROJECTS\\SCHOOL_PROJECTS\\Tennis-Refactoring-Kata\\csharp\\Tennis.Tests\\GoldenMasterResult\\";
            var fileName = $"GoldenMasterTest.Record.{p1}.{p2}.txt";
            var filePath = Path.Combine(directoryPath, fileName);

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(filePath, output, Encoding.UTF8);
        }

        [Theory]
        [ClassData(typeof(TestDataGeneratorGoldenMaster))]
        public void Replay(int p1, int p2)
        {
            var output = RunAGame(p1, p2);
            var directoryPath = "D:\\PROJECTS\\SCHOOL_PROJECTS\\Tennis-Refactoring-Kata\\csharp\\Tennis.Tests\\GoldenMasterResult\\";
            var fileName = $"GoldenMasterTest.Record.{p1}.{p2}.txt";
            var filePath = Path.Combine(directoryPath, fileName);

            var expected = File.ReadAllText(filePath, Encoding.UTF8);
            Assert.Equal(expected, output);
        }

    }
}
