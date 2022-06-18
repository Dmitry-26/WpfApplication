using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Validation.Interfaces
{
    public interface IModelValidator<T> where T : IValidatableObject
    {
        public void Validate(T model);
    }
}