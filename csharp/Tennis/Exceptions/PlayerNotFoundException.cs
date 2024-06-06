using System;

namespace Tennis.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an invalid player name is used.
    /// </summary>
    internal class PlayerNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param
        public PlayerNotFoundException(string message) : base(message)
        {
        }
    }
}
