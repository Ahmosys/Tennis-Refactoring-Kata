using Tennis.Interfaces;

namespace Tennis.Classes
{
    /// <summary>
    /// Represents a tennis player.
    /// </summary>
    internal class Player : IPlayer
    {
        private int _score;
        private string _name;

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string Name { get => _name;}

        /// <summary>
        /// Gets the score of the player.
        /// </summary>
        public int Score
        {
            get => _score;
            private set => _score = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        public Player(string name)
        {
            _name = name;
            _score = 0;
        }

        /// <summary>
        /// Increases the player's score by one point.
        /// </summary>
        public void WonPoint()
        {
            _score++;
        }
    }
}
