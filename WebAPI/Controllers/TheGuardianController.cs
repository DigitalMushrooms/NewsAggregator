using Application.Common.Models;
using Application.TheGuardian.Queries.GetContent;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class TheGuardianController : ApiControllerBase
{
    private readonly IValidator<GetContentQuery> _validator;

    public TheGuardianController(IValidator<GetContentQuery> validator)
    {
        _validator = validator;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetContent(int? starRating)
    {
        var query = new GetContentQuery {StarRating = starRating};
        
        ValidationResult validationResult = await _validator.ValidateAsync(query);

        if (!validationResult.IsValid) 
        {
            return BadRequest(validationResult.ToDictionary());
        }
        
        PaginatedList<Article> articles = await Mediator.Send(query);
        return Ok(articles);
    }
}