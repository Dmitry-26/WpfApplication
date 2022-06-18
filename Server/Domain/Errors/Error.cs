namespace Domain.Errors
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents Error object.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="code">The string representation of error code.</param>
        /// <param name="message">The message.</param>
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Error code of server.
        /// </summary>
        public enum CommonErrorCodes
        {
            /// <summary>
            /// The bad argument error code. Argument has correct format, but doesn't have correct data.
            /// </summary>
            BadArgument,

            /// <summary>
            /// The data is not found error code.
            /// </summary>
            DataIsNotFound,
        }

        /// <summary>
        /// Codes of inner errors.
        /// </summary>
        public enum DetailErrorCodes
        {
            /// <summary>
            /// Properties are null, empty, or consists only of white-space characters.
            /// </summary>
            EmptyValue,

            /// <summary>
            /// Value has incorrect format.
            /// </summary>
            IncorrectFormat,
            /// <summary>
            /// Entity Id and Id of depended entity are equal
            /// </summary>
            DataCollision
        }

        /// <summary>
        /// Gets one of a server-defined set of error codes.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; }

        /// <summary>
        /// Gets a human-readable representation of the error.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; }

        /// <summary>
        /// Gets or sets the target of the error.
        /// </summary>
        /// <value>
        /// The target.
        /// </value>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets an array of details about specific errors that led to this reported error.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public List<Error> Details { get; set; }
    }
}
