using Application.Abstractions.Persistence;
using Domain.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _dbContext;

        public RestaurantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Restaurant?> GetByWhatsAppNumberAsync(
            string whatsAppNumber,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Restaurants
                .AsNoTracking().FirstOrDefaultAsync(restaurant => restaurant.WhatsAppNumber == whatsAppNumber, cancellationToken);
        }
    }
}