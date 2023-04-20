using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using API.Data;
using API.Extensions.Filters;
using API.Repositories.Contracts;
using API.Repositories.Implementations;
using API.Services;
using API.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Tugas6Context>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository<Tugas6Context>>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository<Tugas6Context>>();
builder.Services.AddScoped<IRoleRepository, RoleRepository<Tugas6Context>>();
builder.Services.AddScoped<IEducationRepository, EducationRepository<Tugas6Context>>();
builder.Services.AddScoped<IProfilingRepository, ProfilingRepository<Tugas6Context>>();
builder.Services.AddScoped<IAccountRepository, AccountRepository<Tugas6Context>>();
builder.Services.AddScoped<IAccountRoleRepository, AccountRoleRepository<Tugas6Context>>();
builder.Services.AddSingleton<JwtUtil>();
builder.Services.AddSingleton<BcryptUtil>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilterAttribute>();
    options.Filters.Add<CustomActionFilterAttribute>();
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}).AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingNull; // omit properties with null
        options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles; // ignore cardinality include cycle
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["jwt:Issuer"],
            ValidAudience = builder.Configuration["jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(applicationBuilder =>
    {
        applicationBuilder.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            await context.Response.WriteAsync("{\"message\":\"unexpected server error\"}");
        });
    });
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();