using VTaxi.DAL.Enums;

namespace VTaxi.BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public int DriverId { get; set; }

        public OrderStatus Status { get; set; }
    }
}