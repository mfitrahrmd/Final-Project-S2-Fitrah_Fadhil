using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class ProfilingRepository<TContext> : CoreRepository<string, Profiling, TContext>, IProfilingRepository
    where TContext : DbContext
{
    public ProfilingRepository(TContext context) : base(context)
    {
    }
}