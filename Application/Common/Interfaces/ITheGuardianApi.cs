using Application.Common.Models;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ITheGuardianApi
{
    Task<PaginatedList<Article>> GetContent();
}