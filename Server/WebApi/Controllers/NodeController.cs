namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using Application.DTO;
    using Application.Interfaces;
    using Domain.Errors;
    using Domain.Exceptions;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class NodeController : ApplicationController
    {
        private readonly ILogger<NodeController> logger;
        private INodeService service;

        public NodeController(ILogger<NodeController> logger, INodeService service)
            : base(logger)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<NodeDtoResponse>> Get()
        {
            return StatusCode((int)HttpStatusCode.OK, this.service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<NodeDtoResponse> Get(int id)
        {
            NodeDtoResponse response;
            try
            {
                response = this.service.Get(id);
            }
            catch (NodeNotFoundException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.NotFound,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.DataIsNotFound.ToString(), e.Message) { Target = nameof(id) }));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPut]
        public ActionResult Edit(NodeDtoPutRequest node)
        {
            try
            {
                this.service.Edit(node);
            }
            catch (ModelValidationException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.UnprocessableEntity,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.BadArgument.ToString(), e.Message) { Target = nameof(node), Details = GetErrorDetails(e) }));
            }
            catch (NodeNotFoundException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.NotFound,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.DataIsNotFound.ToString(), e.Message) { Target = nameof(node) }));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        public ActionResult<List<int>> Add(NodeDtoPostRequest node)
        {
            List<int> ids = new List<int>();
            try
            {
                ids = this.service.Add(node);
            }
            catch (ModelValidationException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.UnprocessableEntity,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.BadArgument.ToString(), e.Message) { Target = nameof(node), Details = GetErrorDetails(e) }));
            }
            catch (NodeNotFoundException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.NotFound,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.DataIsNotFound.ToString(), e.Message) { Target = nameof(node) }));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return StatusCode((int)HttpStatusCode.Created, ids);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.service.Delete(id);
            }
            catch (NodeNotFoundException e)
            {
                return StatusCode(
                    (int)HttpStatusCode.NotFound,
                    new ErrorResponse(new Error(Error.CommonErrorCodes.DataIsNotFound.ToString(), e.Message) { Target = nameof(id) }));
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}