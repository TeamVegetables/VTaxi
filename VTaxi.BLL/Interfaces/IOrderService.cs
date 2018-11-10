using System.Collections.Generic;
using VTaxi.BLL.DTO;

namespace VTaxi.BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        OrderDto Get(int id);

        void StartTrip(int orderId);

        double FinishTrip(int orderId, double travelTime, double tariff);
    }
}