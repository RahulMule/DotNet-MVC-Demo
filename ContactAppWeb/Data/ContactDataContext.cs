using ContactAppWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAppWeb.Data
{
    public class ContactDataContext : DbContext
    {
        public ContactDataContext(DbContextOptions<ContactDataContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
