using System;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Interfaces
{
    /// <summary>
    ///     Interface which contains all repositiries from this project
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        void Save();
    }
}