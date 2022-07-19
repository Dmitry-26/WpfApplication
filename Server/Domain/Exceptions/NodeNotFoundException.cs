namespace Domain.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents errors that occur when Node is not found.
    /// </summary>
    public class NodeNotFoundException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeNotFoundException"/> class.
        /// </summary>
        /// <param name="message">A specified message that states the error.</param>
        public NodeNotFoundException(string message)
            : base(message)
        {
        }
    }
}