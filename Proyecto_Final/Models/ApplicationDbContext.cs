using System.Data.Entity;
using Proyecto_Final.Models; 

namespace Proyecto_Final.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }

       
    }
}
