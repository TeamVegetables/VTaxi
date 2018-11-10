using System.Data.Entity;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.EF
{
    public class TaxiContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

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
