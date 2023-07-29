using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using TahilBorsa.Repository;
using TahilBorsasi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RepositoryContext>(
    optn => optn.UseSqlServer("Data Source=OMER-DIRICANLI\\SQLEXPRESS; " +
    "Initial Catalog=DbGrainExchange; Integrated Security=true; TrustServerCertificate=True")
    );

builder.Services.AddScoped<RepositoryWrapper, RepositoryWrapper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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
