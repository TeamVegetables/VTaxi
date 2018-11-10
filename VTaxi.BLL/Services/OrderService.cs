using System;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Enums;
using VTaxi.DAL.Interfaces;

namespace VTaxi.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;

        public OrderService(IUnitOfWork db)
        {
            _database = db;
        }

        public void StartTrip(int orderId)
        {
            var order = _database.Orders.Get(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order does not exists!");
            }

            order.Status = OrderStatus.InProcess;
            _database.Orders.Update(order);
        }

        public double FinishTrip(int orderId, double travelTime, double tariff)
        {
            var order = _database.Orders.Get(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order does not exists!");
            }

            order.Status = OrderStatus.Finished;
            _database.Orders.Update(order);
            return travelTime * tariff;
        }
    }
}
