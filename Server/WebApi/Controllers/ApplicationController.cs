using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Errors;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class ApplicationController : Controller
    {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the error details.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>List of details about errors.</returns>
        protected List<Error> GetErrorDetails(ModelValidationException e)
        {
            List<Error> details = new List<Error>();
            foreach (var errors in e.Errors)
            {
                foreach (var targetName in errors.MemberNames)
                {
                    details.Add(new Error(errors.ErrorCode.ToString(), errors.ErrorMessage) { Target = targetName });
                }
            }

            return details;
        }
    }
}