using Application.Contracts;
using Application.Models;
using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly ILogger<DomainEventPublisher> _logger;
        private readonly IPublisher _mediator;

        public DomainEventPublisher(ILogger<DomainEventPublisher> logger, IPublisher mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);

            var notification = GetNotificationCorrespondingToDomainEvent(domainEvent);

            if (notification is null)
            {
                return;
            }

            await _mediator.Publish(notification);
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            try
            {
                return (INotification)Activator.CreateInstance(
                    typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            };

            return null;
        }
    }
}
