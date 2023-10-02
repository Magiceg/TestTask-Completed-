using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.InterfaceImplementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext dbContext; // Database instance
        // Constructor of a class that accepts a database context 
        public OrderService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Order>> GetOrdersWithMoreThan10Items()
        {
            var ordersWithMoreThan10Items = await dbContext.Orders
                .Where(o => o.Quantity > 10)
                .ToListAsync(); // allows you to avoid blocking the thread during the execution of a database query

            return ordersWithMoreThan10Items;
        }

        public async Task<Order> GetOrderWithLargestOrderAmount()
        {
            var OrderWithLargestOrderAmount = await dbContext.Orders
                .OrderByDescending(o => o.Price * o.Quantity)
                .FirstOrDefaultAsync();

            return OrderWithLargestOrderAmount; 
        }
    }
}
