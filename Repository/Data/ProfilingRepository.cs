using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace DTS_Web_Api.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
    {
        private readonly DbSet<Profiling> _dbSet;
        public ProfilingRepository(MyContext context) : base(context)
        {
            _dbSet = _context.Set<Profiling>();
        }

        public async Task<IEnumerable<TotalMajorVM>> GetTotalByMajorAsync()
        {
            var result = _context.TbMProfilings.Join(_context.TbMEducations,
                                                     p => p.EducationId,
                                                     e => e.Id,
                                                     (p, e) => new { p, e }).Join
                                                     (_context.TbMUniversities,
                                                     a => a.e.UniversityId,
                                                     u => u.Id,
                                                     (a, u) => new { a, u }).
                                                     GroupBy(T => new { T.a.e.Major, T.u.Name }).
                                                     Select(G => new TotalMajorVM
                                                     {
                                                         Total = G.Count(),
                                                         Major = G.Key.Major,
                                                         UniversityName = G.Key.Name
                                                     });
            /*var result = _dbSet.Include(e => e.EducationId).Include(e => e.Education)
            .GroupBy(e => new { e.Education.Major, e.Education.University.Name })
            .Select(g => new TotalMajorVM
            {
                Total = g.Count(),
                Major = g.Key.Major,
                UniversityName = g.Key.Name
            });*/

            return result;
        }
    }
}
