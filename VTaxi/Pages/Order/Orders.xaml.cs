using System.Windows.Controls;
using FirstFloor.ModernUI.Presentation;
using Ninject;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;
using VTaxi.Util;

namespace VTaxi.Pages.Order
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        private readonly IOrderService _orderService;

        public Orders()
        {
            InitializeComponent();
            _orderService = Services.Kernel.Get<OrderService>();
            InitializeOrderList();
        }

        private void InitializeOrderList()
        {
            var orders = _orderService.GetAll();
            LinkCollection links = new LinkCollection();
            foreach (var orderDto in orders)
            {
                links.Add(new Link
                {
                    DisplayName = $"{orderDto.StartPoint} - {orderDto.FinishPoint}"
                });
            }

            OrdersList.Links = links;
        }
    }
}
