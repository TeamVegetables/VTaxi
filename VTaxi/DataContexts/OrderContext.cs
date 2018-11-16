using System.Collections.Generic;
using VTaxi.BLL.DTO;

namespace VTaxi.DataContexts
{
    /// <summary>
    ///     Order context class
    /// </summary>
    public static class OrderContext
    {
        public static IEnumerable<OrderDto> Orders { get; set; }

        public static OrderDto SelectedOrder { get; set; }
    }
}