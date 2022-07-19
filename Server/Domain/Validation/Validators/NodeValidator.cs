namespace Domain.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Exceptions;
    using Domain.Models;
    using Domain.Validation.Interfaces;
    using Domain.ValidationErrors;

    /// <summary>
    /// Validator for models.
    /// </summary>
    public class NodeValidator : IModelValidator<Node>
    {
        public void Validate(Node node)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(node);

            if (!Validator.TryValidateObject(node, validationContext, results))
            {
                throw new ModelValidationException($"{nameof(node)} didn't pass validation", results.Cast<ValidationError>().ToList());
            }
        }
    }
}