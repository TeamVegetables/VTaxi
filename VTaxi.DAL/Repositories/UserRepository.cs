using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using VTaxi.DAL.Interfaces;
using VTaxi.DAL.Models;

namespace VTaxi.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["VTaxiDB"].ConnectionString;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                users = db.Query<User>("SELECT * FROM Users").ToList();
            }

            return users;
        }

        public User Get(int id)
        {
            User user;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                user = db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return user;
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (FirstName, LastName, SuccessfulTrips, Type) VALUES(@FirstName, @LastName, @SuccessfulTrips, @Type); SELECT CAST(SCOPE_IDENTITY() as int)";
                db.Query<int>(sqlQuery, user);
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, @SuccessfulTrips = SuccessfulTrips, @Type = Type WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
