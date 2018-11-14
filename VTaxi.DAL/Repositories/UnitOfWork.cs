using System;
using VTaxi.DAL.EF;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Repositories
{/// <summary>
/// simplify work with different repositories and give assurance that all repositories will use the same data context
/// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaxiContext _db;

        private UserRepository _userRepository;

        private OrderRepository _orderRepository;

        /// <summary>
        /// Constructor with parametres
        /// </summary>
        /// <param name="connectionString"></param>
        public UnitOfWork(string connectionString)
        {
            _db = new TaxiContext(connectionString);
        }
        public IRepository<User> Users => _userRepository ?? (_userRepository = new UserRepository(_db));

        public IRepository<Order> Orders => _orderRepository ?? (_orderRepository = new OrderRepository(_db));
        /// <summary>
        /// Save changes in database
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;
        /// <summary>
        /// Cleaning unmanaged recourses
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _db.Dispose();
            }
            _disposed = true;
        }
        /// <summary>
        /// Cleaning unmanaged recourses
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}