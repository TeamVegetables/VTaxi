namespace VTaxi.BLL.Interfaces
{
    public interface IOrderService
    {
        void StartTrip(int orderId);

        double FinishTrip(int orderId, double travelTime, double tariff);
    }
}