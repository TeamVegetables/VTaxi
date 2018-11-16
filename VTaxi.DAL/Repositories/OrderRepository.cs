using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VTaxi.DAL.EF;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Repositories
{
    /// <summary>
    ///     Order repository
    /// </summary>
    public class OrderRepository : IRepository<Order>
    {
        private readonly TaxiContext _db;

        /// <summary>
        ///     Constructor with paramentres
        /// </summary>
        /// <param name="context">info</param>
        public OrderRepository(TaxiContext context)
        {
            _db = context;
        }

        /// <summary>
        ///     Show all orders from database
        /// </summary>
        /// <returns>Container</returns>
        public IEnumerable<Order> GetAll()
        {
            return _db.Orders;
        }

        /// <summary>
        ///     Find order by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Existing order</returns>
        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        /// <summary>
        ///     Add order to database
        /// </summary>
        /// <param name="order">existing order</param>
        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        /// <summary>
        ///     Modify existing order in database
        /// </summary>
        /// <param name="order">existing order</param>
        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        /// <summary>
        ///     Find order
        /// </summary>
        /// <param name="predicate">function which check value</param>
        /// <returns>orders with special value</returns>
        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _db.Orders.Where(predicate).ToList();
        }

        /// <summary>
        ///     Remove order from database
        /// </summary>
        /// <param name="id">id order</param>
        public void Delete(int id)
        {
            var order = _db.Orders.Find(id);
            if (order != null)
                _db.Orders.Remove(order);
        }
    }
}