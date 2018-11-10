using VTaxi.Shared.Enums;

namespace VTaxi.BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string StartPoint { get; set; }

        public string FinishPoint { get; set; }

        public string PassengerName { get; set; }

        public OrderStatus Status { get; set; }
    }
}