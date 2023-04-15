using API.Models;
using API.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace API_Tests;

[TestClass]
public class UniversityRepositoryShould : API_Tests
{
    private readonly IUniversityRepository _universityRepository;

    public UniversityRepositoryShould()
    {
        _universityRepository = _service.GetService<IUniversityRepository>();
    }

    [TestMethod]
    public void FindManyContainsName_Should_Find_Entities_Contains_Name()
    {
        _universityRepository.InsertOne(new TbMUniversity
        {
            Name = "University of Sriwijaya"
        });
        _universityRepository.InsertOne(new TbMUniversity
        {
            Name = "University of Indonesia"
        });
        _universityRepository.InsertOne(new TbMUniversity
        {
            Name = "State Polytechnic of Sriwijaya"
        });

        var testCases = new List<TestCase>(new []
        {
            new  TestCase
            {
                Name = "Find universities contain existing name",
                University = new TbMUniversity
                {
                    Name = "Sriwijaya"
                },
                Result = u =>
                {
                    Assert.AreEqual(2, u.Count());
                }
            }
        });
    }
    
    private struct TestCase
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public TbMUniversity University { get; set; }
        public Action<IEnumerable<TbMUniversity>> Result;
    }
}