namespace Domain.Errors
{
    /// <summary>
    /// Represents Error object.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public ErrorResponse(Error error)
        {
            Error = error;
        }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Error Error { get; set; }
    }
}
