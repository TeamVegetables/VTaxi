using System.Data.Entity;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.EF
{
    /// <summary>
    ///     Taxi context class contain objects
    /// </summary>
    public class TaxiContext : DbContext
    {
        static TaxiContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public TaxiContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
    }
}