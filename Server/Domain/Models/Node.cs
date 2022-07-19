using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Errors;
using Domain.ValidationErrors;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;
public class Node : IValidatableObject
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? ParentId { get; set; }
    public Node? Parent { get; set; }
    public List<Node> Children { get; set; } = new List<Node>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();

        List<string> nullOrEmptyProperties = new List<string>();
        List<string> uncorrectDataProperties = new List<string>();

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
            uncorrectDataProperties.Add($"{nameof(this.ParentId)}");
        }

        if (uncorrectDataProperties.Count > 0)
        {
            errors.Add(new ValidationError(Error.DetailErrorCodes.DataCollision, $"Properties can made cycle dependence", uncorrectDataProperties));
        }

        if (nullOrEmptyProperties.Count > 0)
        {
            errors.Add(new ValidationError(Error.DetailErrorCodes.EmptyValue, "Properties are null, empty, or consists only of white-space characters", nullOrEmptyProperties));
        }

        return errors;

    }
}
