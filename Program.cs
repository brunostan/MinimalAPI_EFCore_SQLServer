using Microsoft.OpenApi.Models;
using Phonebook.DB;

var builder = WebApplication.CreateBuilder(args);

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


app.MapGet("/contacts", () => PhonebookDB.GetAllContacts());
app.MapGet("/contact/{id}", (int id) => PhonebookDB.GetContact(id));
app.MapPost("/contact", (Contact contact) => PhonebookDB.CreateContact(contact));
app.MapPut("/contact", (Contact contact) => PhonebookDB.UpdateContact(contact));
app.MapDelete("/contact/{id}", (int id) => PhonebookDB.RemoveContact(id));


app.Run();