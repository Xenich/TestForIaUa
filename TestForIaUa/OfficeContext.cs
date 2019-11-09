
using System.Data.Entity;

namespace TestForIaUa
{
    class OfficeContext : DbContext
    {
        public OfficeContext(): base("DBConnection")
        {
        }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
