using Microsoft.EntityFrameworkCore;
using YurtYonetimSistemi.Persistence;
using YurtYonetimSistemi.Persistence.Context;
using YurtYonetimSistemi.Persistence.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{

    var connectionStrings =
        builder.Configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

    options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
    {
        sqlServerOptionsAction.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
    });

});


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
