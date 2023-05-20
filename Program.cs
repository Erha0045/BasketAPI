using AutoMapper;
using Basket.API;
using Basket.API.Data;
using Basket.API.Repo;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure the database connection for MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?
    .Replace("MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"))
    .Replace("MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"));

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

/* builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
*/
        IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddScoped<IBasketRepo, BasketRepo>();
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
