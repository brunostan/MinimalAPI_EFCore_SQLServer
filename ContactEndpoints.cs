using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhonebookDB;

namespace Phonebook;

public static class ContactEndpoints
{
    public static void MapContactEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Contact", async (PhonebookContext db) =>
        {
            return await db.Contact.ToListAsync();
        })
        .WithName("GetAllContacts")
        .Produces<List<Contact>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Contact/{id}", async (int id, PhonebookContext db) =>
        {
            return await db.Contact.FindAsync(id)
                is Contact model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetContactById")
        .Produces<Contact>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Contact/{id}", async (int id, Contact contact, PhonebookContext db) =>
        {
            var foundModel = await db.Contact.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(contact);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateContact")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Contact/", async (Contact contact, PhonebookContext db) =>
        {
            db.Contact.Add(contact);
            await db.SaveChangesAsync();
            return Results.Created($"/Contacts/{contact.Id}", contact);
        })
        .WithName("CreateContact")
        .Produces<Contact>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Contact/{id}", async (int id, PhonebookContext db) =>
        {
            if (await db.Contact.FindAsync(id) is Contact contact)
            {
                db.Contact.Remove(contact);
                await db.SaveChangesAsync();
                return Results.Ok(contact);
            }

            return Results.NotFound();
        })
        .WithName("DeleteContact")
        .Produces<Contact>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}