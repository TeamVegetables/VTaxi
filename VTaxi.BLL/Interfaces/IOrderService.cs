using System.Collections.Generic;
using VTaxi.BLL.DTO;

namespace VTaxi.BLL.Interfaces
{/// <summary>
/// Order Service interface
/// </summary>
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        OrderDto Get(int id);

        void StartTrip(int orderId);

        double FinishTrip(int orderId, int driverId, double travelTime, double tariff);
    }
}