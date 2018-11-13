using System.Collections.Generic;
using VTaxi.BLL.DTO;

namespace VTaxi.DataContexts
{
    public static class OrderContext
    {
        public static IEnumerable<OrderDto> Orders { get; set; }

        public static OrderDto SelectedOrder { get; set; }
    }
}