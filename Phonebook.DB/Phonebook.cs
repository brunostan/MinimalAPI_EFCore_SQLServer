namespace Phonebook.DB
{
    public record Contact
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DDD { get; set; } = string.Empty;
    }

    public class PhonebookDB
    {
        private static List<Contact> _phonebook = new()
        {
            new Contact{ Id = 1, FirstName = "Pedro", LastName = "Silva", DDD = "11", PhoneNumber = "36301230" },
            new Contact{ Id = 2, FirstName = "João", LastName = "Batista", DDD = "51", PhoneNumber = "34535355"},
            new Contact{ Id = 3, FirstName ="Maria", LastName = "Matos", DDD = "24", PhoneNumber = "38444333"}
        };

        public static List<Contact> GetAllContacts()
        {
            return _phonebook;
        }

        public static Contact? GetContact(int id)
        {
            return _phonebook.SingleOrDefault(contact => contact.Id == id);
        }

        public static Contact CreateContact(Contact contact)
        {
            _phonebook.Add(contact);
            return contact;
        }

        public static Contact UpdateContact(Contact update)
        {
            _phonebook = _phonebook.Select(contact =>
            {
                if (contact.Id == update.Id)
                {
                    contact.FirstName = update.FirstName;
                    contact.LastName = update.LastName;
                    contact.PhoneNumber = update.PhoneNumber;
                    contact.DDD = update.DDD;
                }

                return contact;
            }).ToList();
            return update;
        }

        public static void RemoveContact(int id)
        {
            _phonebook = _phonebook.FindAll(contact => contact.Id != id).ToList();
        }
    }
}