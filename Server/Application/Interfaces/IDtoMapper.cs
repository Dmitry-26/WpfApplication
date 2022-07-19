namespace Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines methods for Casting Dto model to Entity model.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public interface IDtoMapper<T>
    {
        /// <summary>
        /// Casts Dto Model to entity model.
        /// </summary>
        /// <returns>Model of entity.</returns>
        public T ToModel();
    }
}