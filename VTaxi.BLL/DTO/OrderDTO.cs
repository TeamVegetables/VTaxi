using VTaxi.Shared.Enums;

namespace VTaxi.BLL.DTO
{/// <summary>
/// Order data transfer object used to transfer order between application and database
/// </summary>
    public class OrderDto
    {
        public int Id { get; set; }

        public string StartPoint { get; set; }

        public string FinishPoint { get; set; }

        public string PassengerName { get; set; }

        public OrderStatus Status { get; set; }
    }
}