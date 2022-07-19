namespace Domain.ValidationErrors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Errors;

    /// <summary>
    /// Represents errors of validation.
    /// </summary>
    public class ValidationError : ValidationResult
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public Error.DetailErrorCodes ErrorCode { get; set; }
        public ValidationError(Error.DetailErrorCodes errorCode, string errorMessage, IEnumerable<string> memberNames)
            : base(errorMessage, memberNames)
        {
            this.ErrorCode = errorCode;
        }
    }
}