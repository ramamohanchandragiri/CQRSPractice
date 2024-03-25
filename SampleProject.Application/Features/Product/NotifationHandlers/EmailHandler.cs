using MediatR;
using SampleProject.Application.Features.Product.Commands;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.NotifationHandlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly ISampleDatabase sampleDatabase;
        public EmailHandler(ISampleDatabase sampleDatabase) => this.sampleDatabase = sampleDatabase;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            Domain.Product product = new() { Id = notification.ProductViewModel.Id, Name = notification.ProductViewModel.Name };

            await sampleDatabase.EventOccured(product, "Email sent");

            await Task.CompletedTask;
        }
    }
}
