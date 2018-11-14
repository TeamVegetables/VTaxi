using System;
using System.Collections.Generic;

namespace VTaxi.DAL.Interfaces
{
    /// <summary>
    /// The interface that implements the repository of template class
    /// </summary>
    /// <typeparam name="T">template class</typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}