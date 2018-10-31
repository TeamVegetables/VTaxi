using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTaxi.DAL.Enums;

namespace VTaxi.BLL.DTO
{
    class OrderDTO
    {
        public int Id { get; set; }

        public int PassengerId { get; set; }

        public int DriverId { get; set; }

        public OrderStatus Status { get; set; }
    }
}
