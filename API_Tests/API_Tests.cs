using API.Data;
using API.Repositories.Contracts;
using API.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace API_Tests;

public abstract class API_Tests
{
    protected readonly IServiceProvider _service;

    protected API_Tests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<InMemoryTugas6Context>();
        serviceCollection.AddTransient<CoreRepository<int, Entity, InMemoryTugas6Context>, CoreRepositoryImpl<int, Entity, InMemoryTugas6Context>>();
        serviceCollection.AddTransient<IUniversityRepository, UniversityRepository<InMemoryTugas6Context>>();
        serviceCollection.AddTransient<IEmployeeRepository, EmployeeRepository<InMemoryTugas6Context>>();

        _service = serviceCollection.BuildServiceProvider();
    }
}