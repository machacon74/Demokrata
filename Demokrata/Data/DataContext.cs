using Demokrata.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demokrata.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
