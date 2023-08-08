using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;
using TahilBorsa.Repository;
using TahilBorsasi.Repository;
using NLog;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//log kay�tlar� i�in tutulan servis alan�
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});
//--

//baglant� ve swagger build alan�
builder.Services.AddDbContext<RepositoryContext>(
    optn => optn.UseSqlServer("Data Source=OMER-DIRICANLI\\SQLEXPRESS; " +
    "Initial Catalog=DbGrainExchange; Integrated Security=true; TrustServerCertificate=True")
    );

builder.Services.AddScoped<RepositoryWrapper, RepositoryWrapper>();
//--

/*
* JWT Authentication i�in eklenmesi gereken kodlar
*/
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    var Key = Encoding.UTF8.GetBytes("TahilBorsasi�lkProjeTokenOlusturmaStringi");
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache(); //Cache servisini aktive et.

//json serialize aktive
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//--

var app = builder.Build();

// Configure the HTTP request pipeline.
// hata control mekan�zmas� dahil edildi.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}
//--
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.MapControllers();

app.Run();
