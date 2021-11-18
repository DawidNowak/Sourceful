using Domain.Common;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDomainEventPublisher
    {
        Task Publish(DomainEvent @event);
    }
}
