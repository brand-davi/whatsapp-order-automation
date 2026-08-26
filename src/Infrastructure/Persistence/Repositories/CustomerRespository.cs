using Application.Abstractions.Persistence;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> GetByRestaurantAndWhatsAppNumberAsync
            (Guid restaurantId, string whatsAppNumber, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync
                (customer => customer.RestaurantId == restaurantId && customer.WhatsAppNumber == whatsAppNumber, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
        }
    }
}