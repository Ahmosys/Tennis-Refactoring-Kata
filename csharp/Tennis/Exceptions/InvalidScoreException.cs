using System;

namespace Tennis.Exceptions
{
    /// <summary>
    /// The exception that is thrown when an invalid score is encountered.
    /// </summary>
    internal class InvalidScoreException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidScoreException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidScoreException(string message) : base(message)
        {
        }
    }
}
