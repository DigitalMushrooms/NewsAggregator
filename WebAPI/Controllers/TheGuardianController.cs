using Application.Common.Models;
using Application.TheGuardian.Queries.GetContent;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class TheGuardianController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetContent()
    {
        PaginatedList<Article> articles = await Mediator.Send(new GetContentQuery());
        return Ok(articles);
    }
}