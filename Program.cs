using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Phonebook;
using PhoneBook.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PhonebookContext>(options =>
{
    options.UseSqlServer
    (
        builder.Configuration.GetConnectionString("PhonebookContext") ?? throw new InvalidOperationException("Connection string 'PhonebookContext' not found.")
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My Phonebook",
        Description = "",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Phonebook V1");
});

app.MapContactEndpoints();

app.Run();