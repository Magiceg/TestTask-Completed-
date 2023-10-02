using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrderWithLargestOrderAmount();

        public Task<List<Order>> GetOrdersWithMoreThan10Items();
    }
}
