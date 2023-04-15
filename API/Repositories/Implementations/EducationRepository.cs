using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class EducationRepository<TContext> : CoreRepository<int, TbMEducation, TContext>, IEducationRepository
    where TContext : DbContext
{
    public EducationRepository(TContext context) : base(context)
    {
    }
}