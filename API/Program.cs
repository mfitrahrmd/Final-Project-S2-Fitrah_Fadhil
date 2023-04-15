using System.Text.Json.Serialization;
using API.Data;
using API.Repositories.Contracts;
using API.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Tugas6Context>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition =
        JsonIgnoreCondition.WhenWritingNull; // omit properties with null
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // ignore cardinality include cycle
});
builder.Services.AddScoped<IUniversityRepository, UniversityRepository<Tugas6Context>>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository<Tugas6Context>>();
builder.Services.AddScoped<IRoleRepository, RoleRepository<Tugas6Context>>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();