using Domain.Customers;

namespace Application.Abstractions.Persistence
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByRestaurantAndWhatsAppNumberAsync
            (Guid restaurantId, string whatsAppNumber, CancellationToken cancellationToken = default);

        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
