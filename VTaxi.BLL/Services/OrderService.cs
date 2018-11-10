using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;
using VTaxi.Shared.Enums;

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

        public IEnumerable<OrderDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDto>>(_database.Orders.GetAll());
        }

        public OrderDto Get(int id)
        {
            var order = _database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Order does not exits");

            return new OrderDto { Id = order.Id, FinishPoint = order.FinishPoint, PassengerName = order.PassengerName, StartPoint = order.StartPoint, Status = order.Status};
        }
    }
}
