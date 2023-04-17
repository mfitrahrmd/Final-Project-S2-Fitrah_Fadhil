using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;

namespace DTS_Web_Api.Repository.Data
{
    public class UniversityRepository : GeneralRepository<TbMUniversity, int, MyContext>, IUniversityRepository
    {
        public UniversityRepository(MyContext context) : base(context)
        {
        }
    }
}
