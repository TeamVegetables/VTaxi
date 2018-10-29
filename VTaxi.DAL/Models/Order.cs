using VTaxi.DAL.Enums;

namespace VTaxi.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public int DriverId { get; set; }

        public OrderStatus Status { get; set; }
    }
}