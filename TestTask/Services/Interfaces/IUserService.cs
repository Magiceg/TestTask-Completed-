using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserWithLargestNumberOfOrders();

        public Task<List<User>> GetInactiveUsers();
    }
}
