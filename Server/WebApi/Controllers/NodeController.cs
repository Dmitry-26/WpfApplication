using System.Collections.Generic;
using System.Net;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NodeController : ControllerBase
{
    private readonly ILogger<NodeController> _logger;
    private INodeService service;

    public NodeController(ILogger<NodeController> logger, INodeService service)
    {
        this.service = service;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<NodeDtoResponse>> Get()
    {
        return StatusCode((int)HttpStatusCode.OK, service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<NodeDtoResponse> Get(int id)
    {
        return StatusCode((int)HttpStatusCode.OK, service.Get(id));
    }

    [HttpPut]
    public ActionResult Edit(NodeDtoPutRequest node)
    {
        service.Edit(node);
        return StatusCode((int)HttpStatusCode.OK);
    }

    [HttpPost]
    public ActionResult Post(NodeDtoPostRequest node)
    {
        service.Add(node);
        return StatusCode((int)HttpStatusCode.OK);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        service.Delete(id);
        return StatusCode((int)HttpStatusCode.OK);
    }
}
