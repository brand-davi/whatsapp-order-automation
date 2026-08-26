using Domain.Restaurants;

namespace Application.Abstractions.Persistence
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetByWhatsAppNumberAsync(string whatsAppNumber, CancellationToken cancellationToken = default);
    }
}
