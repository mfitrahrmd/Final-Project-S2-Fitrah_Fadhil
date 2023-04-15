using API.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using DateTime = System.DateTime;

namespace API_Tests;

[TestClass]
public class CoreRepositoryShould : API_Tests
{
    private CoreRepository<int, Entity, InMemoryTugas6Context> _coreRepository;

    public CoreRepositoryShould()
    {
        _coreRepository = _service.GetService<CoreRepository<int, Entity, InMemoryTugas6Context>>();
    }

    [TestMethod]
    public void InsertOne_Should_Insert_New_Entity()
    {
        var entity = Entity.Random();

        var insertedEntity = _coreRepository.InsertOne(entity).Result;

        Assert.IsNotNull(insertedEntity);
        Assert.AreEqual(entity.Id, insertedEntity.Id);
        Assert.AreEqual(entity.Name, insertedEntity.Name);
        Assert.AreEqual(entity.Birthdate, insertedEntity.Birthdate);
        Assert.AreEqual(entity.IsMarried, insertedEntity.IsMarried);
    }

    [TestMethod]
    public void FindOneByPk_Should_Find_Entity_With_Given_Pk()
    {
        var createdEntity = CreateRandomEntity();

        var foundEntity = _coreRepository.FindOneByPk(createdEntity.Id).Result;

        Assert.IsNotNull(foundEntity);
        Assert.AreEqual(createdEntity.Id, foundEntity.Id);
        Assert.AreEqual(createdEntity.Name, foundEntity.Name);
        Assert.AreEqual(createdEntity.Birthdate, foundEntity.Birthdate);
        Assert.AreEqual(createdEntity.IsMarried, foundEntity.IsMarried);
    }

    [TestMethod]
    public void UpdateOneByPk_Should_Update_Entity_With_Given_Pk()
    {
        var createdEntity = CreateRandomEntity();

        var toBeUpdateEntity = new Entity
        {
            Id = createdEntity.Id,
            Name = "Fitrah",
            Birthdate = new DateTime(1999, 12, 26),
            IsMarried = false
        };

        var testCases = new List<TestCase>(new[]
        {
            new TestCase
            {
                Name = "Update existing entity",
                Id = toBeUpdateEntity.Id,
                Entity = toBeUpdateEntity,
                Result = e =>
                {
                    Assert.IsNotNull(e);
                    Assert.AreEqual(toBeUpdateEntity.Id, e.Id);
                    Assert.AreEqual(toBeUpdateEntity.Name, e.Name);
                    Assert.AreEqual(toBeUpdateEntity.Birthdate, e.Birthdate);
                    Assert.AreEqual(toBeUpdateEntity.IsMarried, e.IsMarried);
                }
            },
            new TestCase
            {
                Name = "Update non existing entity",
                Id = 1000,
                Entity = toBeUpdateEntity,
                Result = e =>
                {
                    Assert.IsNull(e);
                }
            }
        });
        
        testCases.ForEach(async tc =>
        {
            var updatedEntity = await _coreRepository.UpdateOneByPk(tc.Id, tc.Entity);

            tc.Result(updatedEntity);
        });
    }

    [TestMethod]
    public void DeleteOneByPk_Should_Update_Entity_With_Given_Pk()
    {
        var createdEntity = CreateRandomEntity();

        var testCases = new List<TestCase>(new[]
        {
            new TestCase
            {
                Name = "Delete existing entity",
                Id = createdEntity.Id,
                Result = e =>
                {
                    Assert.IsNotNull(e);
                    Assert.AreEqual(createdEntity.Id, e.Id);
                    Assert.AreEqual(createdEntity.Name, e.Name);
                    Assert.AreEqual(createdEntity.Birthdate, e.Birthdate);
                    Assert.AreEqual(createdEntity.IsMarried, e.IsMarried);
                }
            },
            new TestCase
            {
                Name = "Delete non existing entity",
                Id = 1000,
                Result = e =>
                {
                    Assert.IsNull(e);
                }
            }
        });
        
        testCases.ForEach(async tc =>
        {
            var updatedEntity = await _coreRepository.DeleteOneByPk(tc.Id);

            tc.Result(updatedEntity);
        });

    }

    [TestMethod]
    public void FindAll_Should_Find_All_Entities()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateRandomEntity();
        }

        var foundEntities = _coreRepository.FindAll().Result;

        foundEntities.ToList().ForEach(Assert.IsNotNull);

        var foundLimitedEntities = _coreRepository.FindAll(5, 5).Result;

        Assert.AreEqual(5, foundLimitedEntities.Count());

        foundLimitedEntities.ToList().ForEach(Assert.IsNotNull);
    }
    
    private Entity CreateRandomEntity()
    {
        var service = _service.GetService<CoreRepository<int, Entity, InMemoryTugas6Context>>();
        
        var entity = Entity.Random();

        var insertedEntity = service.InsertOne(entity).Result;

        Assert.IsNotNull(insertedEntity);
        Assert.AreEqual(entity.Id, insertedEntity.Id);
        Assert.AreEqual(entity.Name, insertedEntity.Name);
        Assert.AreEqual(entity.Birthdate, insertedEntity.Birthdate);
        Assert.AreEqual(entity.IsMarried, insertedEntity.IsMarried);

        return insertedEntity;
    }
    
    private struct TestCase
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Entity Entity { get; set; }
        public Action<Entity> Result;
    }
}