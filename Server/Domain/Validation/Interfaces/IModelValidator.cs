namespace Domain.Validation.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes methods for validation.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelValidator<T> where T : IValidatableObject
    {
        /// <summary>
        /// Validates model. If model is not valid throws validation exceptions.
        /// </summary>
        /// <param name="model">Model.</param>
        public void Validate(T model);
    }
}