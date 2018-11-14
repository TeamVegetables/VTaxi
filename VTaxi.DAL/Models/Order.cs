using System.ComponentModel.DataAnnotations;
using VTaxi.Shared.Enums;

namespace VTaxi.DAL.Models
{
    /// <summary>
    /// Class order which contain info about trip
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string StartPoint { get; set; }

        public string FinishPoint { get; set; }

        public string PassengerName { get; set; }

        public OrderStatus Status { get; set; }
    }
}