using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.Product.Commands
{
    public record ProductAddedNotification(ProductViewModel ProductViewModel) : INotification;
}
