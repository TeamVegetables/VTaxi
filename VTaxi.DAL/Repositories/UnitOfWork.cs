using System;
using VTaxi.DAL.EF;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaxiContext _db;

        private UserRepository _userRepository;

        private OrderRepository _orderRepository;

        public UnitOfWork(string connectionString)
        {
            _db = new TaxiContext(connectionString);
        }
        public IRepository<User> Users => _userRepository ?? (_userRepository = new UserRepository(_db));

        public IRepository<Order> Orders => _orderRepository ?? (_orderRepository = new OrderRepository(_db));

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _db.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}