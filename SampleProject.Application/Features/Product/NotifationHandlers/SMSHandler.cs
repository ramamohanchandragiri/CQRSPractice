using MediatR;
using SampleProject.Application.Features.Product.Commands;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.NotifationHandlers
{
    public class SMSHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly ISampleDatabase sampleDatabase;
        public SMSHandler(ISampleDatabase sampleDatabase) => this.sampleDatabase = sampleDatabase;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            Domain.Product product = new() { Id = notification.ProductViewModel.Id, Name = notification.ProductViewModel.Name };

            await sampleDatabase.EventOccured(product, "SMS sent");

            await Task.CompletedTask;
        }
    }
}
