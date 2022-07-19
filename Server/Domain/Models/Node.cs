namespace Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Domain.Errors;
    using Domain.ValidationErrors;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Model of Node.
    /// </summary>
    public class Node : IValidatableObject
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value></value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        /// <value></value>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets ParentId.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets Parent. It is Navigation Property.
        /// </summary>
        public Node? Parent { get; set; }

        /// <summary>
        /// Gets or sets node children. It is Navigation property.
        /// </summary>
        /// <typeparam name="Node">Children of node.</typeparam>
        public List<Node> Children { get; set; } = new List<Node>();

        /// <summary>
        /// Validates model.
        /// </summary>
        /// <param name="validationContext">Context</param>
        /// <returns>Results of validation.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            List<string> nullOrEmptyProperties = new List<string>();
            List<string> incorrectDataProperties = new List<string>();

            if (string.IsNullOrEmpty(this.Name))
            {
                nullOrEmptyProperties.Add($"{nameof(this.Name)}");
            }

            if (string.IsNullOrEmpty(this.Description))
            {
                nullOrEmptyProperties.Add($"{nameof(this.Description)}");
            }

            if (this.ParentId != null && this.Id == (int)this.ParentId)
            {
                incorrectDataProperties.Add($"{nameof(this.ParentId)}");
            }

            if (incorrectDataProperties.Count > 0)
            {
                errors.Add(new ValidationError(Error.DetailErrorCodes.DataCollision, $"Properties can made cycle dependence", incorrectDataProperties));
            }

            if (nullOrEmptyProperties.Count > 0)
            {
                errors.Add(new ValidationError(Error.DetailErrorCodes.EmptyValue, "Properties are null, empty, or consists only of white-space characters", nullOrEmptyProperties));
            }

            return errors;
        }
    }
}