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
    ///     User repository
    /// </summary>
    public class UserRepository : IRepository<User>
    {
        private readonly TaxiContext _db;

        /// <summary>
        ///     Constructor with parametres
        /// </summary>
        /// <param name="context">taxi info</param>
        public UserRepository(TaxiContext context)
        {
            _db = context;
        }

        /// <summary>
        ///     Get all users from data base
        /// </summary>
        /// <returns>container</returns>
        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        /// <summary>
        ///     Get User from data base
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>User</returns>
        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        /// <summary>
        ///     Add user to data base
        /// </summary>
        /// <param name="user">User</param>
        public void Create(User user)
        {
            _db.Users.Add(user);
        }

        /// <summary>
        ///     Modify existing user in data base
        /// </summary>
        /// <param name="user">user</param>
        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        /// <summary>
        ///     Find all users with special value
        /// </summary>
        /// <param name="predicate">function wich defines special value</param>
        /// <returns>container of users with special value</returns>
        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        /// <summary>
        ///     Delete user from database
        /// </summary>
        /// <param name="id">id of user</param>
        public void Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }
    }
}