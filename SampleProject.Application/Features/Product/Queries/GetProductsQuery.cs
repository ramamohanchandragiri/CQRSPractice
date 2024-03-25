using MediatR;
using SampleProject.Application.ViewModels;

namespace SampleProject.Application.Features.Product.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductViewModel>>;
}
