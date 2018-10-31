using System;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}