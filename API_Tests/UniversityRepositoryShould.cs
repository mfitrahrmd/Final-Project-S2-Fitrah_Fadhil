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
                UniversityName = "Sriwijaya",
                Result = u =>
                {
                    Assert.AreEqual(2, u.Count());
                }
            },
            new  TestCase
            {
                Name = "Find universities contain non existing name",
                UniversityName = "Nothing",
                Result = u =>
                {
                    Assert.AreEqual(0, u.Count());
                }
            }
        });
        
        testCases.ForEach(async tc =>
        {
            var foundUniversities = await _universityRepository.FindManyContainsName(tc.UniversityName);

            tc.Result(foundUniversities);
        });
    }
    
    private struct TestCase
    {
        public string Name { get; set; }
        public string UniversityName { get; set; }
        public Action<IEnumerable<TbMUniversity>> Result;
    }
}