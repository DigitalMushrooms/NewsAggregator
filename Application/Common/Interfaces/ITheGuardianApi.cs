using Application.Common.Models;
using Domain.Entities;
using Domain.Options.TheGuardian;

namespace Application.Common.Interfaces;

public interface ITheGuardianApi
{
    Task<PaginatedList<Article>> GetContent(ContentFilterOptions contentFilters);
}