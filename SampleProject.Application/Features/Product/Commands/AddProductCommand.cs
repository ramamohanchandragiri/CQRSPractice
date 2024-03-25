using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.Product.Commands
{
    // public record AddProductCommand(Product Product) : IRequest<Product>;

    public class AddProductCommand : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
