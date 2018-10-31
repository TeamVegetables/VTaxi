using System.Data.Entity;
using VTaxi.DAL.Enums;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TaxiContext>
    {
        protected override void Seed(TaxiContext db)
        {
            db.Users.Add(new User {FirstName = "Admin", LastName = "Admin", SuccessfulTrips = 999, Type = UserType.Driver});
            db.SaveChanges();
        }
    }
}