using API.Data;
using API.Models;
using API.Repositories.Contracts;

namespace API.Repositories.Implementations;

public class UniversityRepository : CoreRepository<int, TbMUniversity, Tugas6Context>, IUniversityRepository
{
    public UniversityRepository(Tugas6Context context) : base(context)
    {
    }
}