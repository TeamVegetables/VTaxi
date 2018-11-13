using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Ninject;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;
using VTaxi.DataContexts;
using VTaxi.Shared.Enums;
using VTaxi.Util;

namespace VTaxi.Pages.Order
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : UserControl
    {
        private readonly IOrderService _orderService;

        private readonly DispatcherTimer _timer;

        private int _currentOrderId;

        private TimeSpan _time;

        public Orders()
        {
            InitializeComponent();
            TripTime.Visibility = Visibility.Hidden;
            TripCost.Visibility = Visibility.Hidden;
            _orderService = Services.Kernel.Get<OrderService>();
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            _timer.Tick += Tick;
            InitializeOrderList();
            OrdersList.SelectedIndex = 0;
        }

        private void InitializeOrderList()
        {
            UpdateOrders();
            foreach (var orderDto in OrderContext.Orders)
            {
                OrdersList.Items.Add($"{orderDto.StartPoint} - {orderDto.FinishPoint}");
            }
        }

        private void UpdateOrders()
        {
            var orders = _orderService.GetAll().ToList();
            OrderContext.Orders = orders;
        }

        private void UpdateUi()
        {
            OrderContext.SelectedOrder = OrderContext.Orders.ElementAt(OrdersList.SelectedIndex);
            FromText.Text = OrderContext.SelectedOrder.StartPoint;
            ToText.Text = OrderContext.SelectedOrder.FinishPoint;
            PassengerName.Text = OrderContext.SelectedOrder.PassengerName;
            State.Text = OrderContext.SelectedOrder.Status.ToString();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUi();
            if (OrderContext.SelectedOrder.Status == OrderStatus.Finished || AuthenticationService.CurrentUser == null)
            {
                StartButton.IsEnabled = false;
                FinishButton.IsEnabled = false;
            }
            else if (OrderContext.SelectedOrder.Status == OrderStatus.InProcess && _currentOrderId == OrderContext.SelectedOrder.Id && _timer.IsEnabled)
            {
                StartButton.IsEnabled = false;
                FinishButton.IsEnabled = true;
            }
            else if (_timer.IsEnabled)
            {
                FinishButton.IsEnabled = false;
                StartButton.IsEnabled = false;
            }
            else
            {
                FinishButton.IsEnabled = true;
                StartButton.IsEnabled = true;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            OrdersList.Focusable = false;
            TripTime.Visibility = Visibility.Visible;
            TripCost.Visibility = Visibility.Hidden;
            _orderService.StartTrip(OrderContext.SelectedOrder.Id);
            _time = TimeSpan.Zero;
            UpdateOrders();
            State.Text = OrderContext.SelectedOrder.Status.ToString();
            _currentOrderId = OrderContext.SelectedOrder.Id;
            UpdateUi();
            _timer.Start();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            FinishButton.IsEnabled = false;
            _timer.Stop();
            TripTime.Visibility = Visibility.Hidden;
            TripCost.Visibility = Visibility.Visible;
            UpdateUi();
            Cost.Text = _orderService.FinishTrip(OrderContext.SelectedOrder.Id, AuthenticationService.CurrentUser.Id, _time.TotalMinutes, 2) + "$";
            UpdateOrders();
            State.Text = OrderContext.SelectedOrder.Status.ToString();
        }

        private void Tick(object sender, EventArgs e)
        {
            Timer.Text = _time.ToString();
            _time = _time.Add(TimeSpan.FromSeconds(1));
        }
    }
}
