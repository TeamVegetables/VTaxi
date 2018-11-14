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
    /// <summary>
    /// Class which works with orders
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        /// <summary>
        /// Constructor with parametres
        /// </summary>
        /// <param name="db">database</param>
        public OrderService(IUnitOfWork db)
        {
            _database = db;
        }
        /// <summary>
        /// Make order status in progress if it's is existing 
        /// </summary>
        /// <param name="orderId">id of order</param>
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
        /// <summary>
        /// Makes trip ended and updata data in database
        /// </summary>
        /// <param name="orderId">orderId</param>
        /// <param name="driverId">driverId</param>
        /// <param name="travelTime">time of trip</param>
        /// <param name="tariff">Cash</param>
        /// <returns></returns>
        public double FinishTrip(int orderId, int driverId, double travelTime, double tariff)
        {
            var order = _database.Orders.Get(orderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order does not exists!");
            }

            var driver = _database.Users.Get(driverId);
            driver.SuccessfulTrips++;
            _database.Users.Update(driver);
            order.Status = OrderStatus.Finished;
            _database.Orders.Update(order);
            return travelTime * tariff;
        }
        /// <summary>
        /// Method to show all trips information
        /// </summary>
        /// <returns>all trips information</returns>
        public IEnumerable<OrderDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDto>>(_database.Orders.GetAll());
        }
        /// <summary>
        /// Method for find out information about trip
        /// </summary>
        /// <param name="id"></param>
        /// <returns>order data transfer object</returns>
        public OrderDto Get(int id)
        {
            var order = _database.Orders.Get(id);
            if (order == null)
                throw new ValidationException("Order does not exits");

            return new OrderDto { Id = order.Id, FinishPoint = order.FinishPoint, PassengerName = order.PassengerName, StartPoint = order.StartPoint, Status = order.Status};
        }
    }
}
