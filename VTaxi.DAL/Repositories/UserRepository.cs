using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VTaxi.DAL.EF;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly TaxiContext _db;

        public UserRepository(TaxiContext context)
        {
            _db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }
    }
}