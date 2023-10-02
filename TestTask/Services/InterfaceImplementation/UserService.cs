using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.InterfaceImplementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext; // database instance
        // Constructor of a class that accepts a database context 
        public UserService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;           
        }
        public async Task<User> GetUserWithLargestNumberOfOrders()
        {  
           var userWithMostOrders = await dbContext.Users
               .Include(u => u.Orders) // allows you to access user orders
               .Where(u => u.Status == UserStatus.Active)
               .OrderByDescending(u => u.Orders.Count())
               .FirstOrDefaultAsync();

           return userWithMostOrders;
        }
        public async Task<List<User>> GetInactiveUsers()
        {
            var userWithInactiveStatus = await dbContext.Users
                .Where(u => u.Status == UserStatus.Inactive)
                .ToListAsync();

            return userWithInactiveStatus;
        }
    }
}
