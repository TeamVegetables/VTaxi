using System.Data.Entity;
using VTaxi.DAL.Models;
using VTaxi.Shared.Enums;

namespace VTaxi.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<TaxiContext>
    {
        protected override void Seed(TaxiContext db)
        {
            db.Users.Add(new User {FirstName = "Admin", LastName = "Admin", SuccessfulTrips = 999, Type = UserType.Driver});
            db.Orders.Add(new Order {PassengerName = "Petro", Status = OrderStatus.Started, StartPoint = "University", FinishPoint = "Airport"});
            db.Orders.Add(new Order { PassengerName = "Ivan", Status = OrderStatus.Started, StartPoint = "Railway Station", FinishPoint = "Rynok Sq." });
            db.Orders.Add(new Order { PassengerName = "Maryan", Status = OrderStatus.Started, StartPoint = "Bus Station", FinishPoint = "Railway Station" });
            db.Orders.Add(new Order { PassengerName = "Julia", Status = OrderStatus.Started, StartPoint = "Victoria Gargens", FinishPoint = "University" });
            db.Orders.Add(new Order { PassengerName = "Nazar", Status = OrderStatus.Started, StartPoint = "Forum Lviv", FinishPoint = "Airport" });
            db.SaveChanges();
        }
    }
}