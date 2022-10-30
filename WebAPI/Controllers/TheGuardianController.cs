using Application.TheGuardian.Queries.GetContent;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class TheGuardianController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetContent()
    {
        await Mediator.Send(new GetContentQuery());
        return Ok();
    }
}