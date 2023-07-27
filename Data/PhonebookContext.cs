using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Data
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        public DbSet<PhonebookDB.Contact> Contact { get; set; } = default!;
    }
}
