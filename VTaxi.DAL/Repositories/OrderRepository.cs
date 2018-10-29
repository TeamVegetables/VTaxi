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
    public class OrderRepository : IRepository<Order>
    {
        private readonly string _connectionString;

        public OrderRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["VTaxiDB"].ConnectionString;
        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> orders;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                orders = db.Query<Order>("SELECT * FROM Orders").ToList();
            }

            return orders;
        }

        public Order Get(int id)
        {
            Order order;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                order = db.Query<Order>("SELECT * FROM Orders WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return order;
        }

        public void Create(Order order)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Orders (PassengerId, DriverId, Status) VALUES(@PassengerId, @DriverId, @Status); SELECT CAST(SCOPE_IDENTITY() as int)";
                db.Query<int>(sqlQuery, order);
            }
        }

        public void Update(Order order)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Orders SET PassengerId = @PassengerId, DriverId = @DriverId, @Status = Status WHERE Id = @Id";
                db.Execute(sqlQuery, order);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Orders WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}