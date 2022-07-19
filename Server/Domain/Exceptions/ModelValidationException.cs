namespace Domain.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Domain.ValidationErrors;

    /// <summary>
    /// Represents errors that occur during passing model validation.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationException" />
    public class ModelValidationException : ValidationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">A specified message that states the error.</param>
        public ModelValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="errors">The errors - results of validation.</param>
        public ModelValidationException(string message, List<ValidationError> errors)
            : base(message)
        {
            this.Errors = errors;
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<ValidationError> Errors { get; } = new List<ValidationError>();
    }
}
