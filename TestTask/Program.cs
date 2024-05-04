using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestTask.Context;
using TestTask.Repositories;

var builder = WebApplication.CreateBuilder(args);
string DBName = "RectangleDB";


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString(DBName)));

builder.Services.AddScoped<IRectangleRepository, RectangleRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
