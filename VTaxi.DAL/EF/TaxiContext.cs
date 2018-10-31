using System.Data.Entity;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.EF
{
    public class TaxiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        static TaxiContext()
        {
            Database.SetInitializer(new StoreDbInitializer());

        }

        public TaxiContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}
