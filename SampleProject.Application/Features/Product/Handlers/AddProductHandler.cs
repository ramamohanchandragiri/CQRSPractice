using MediatR;
using SampleProject.Application.Features.Product.Commands;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductViewModel>
    {
        private readonly ISampleDatabase _sampleDatabase;

        public AddProductHandler(ISampleDatabase sampleDatabase) => _sampleDatabase = sampleDatabase;

        public async Task<ProductViewModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Product product = new Domain.Product() { Id = request.Id, Name = request.Name };
            
            await _sampleDatabase.AddProduct(product);

            return new ProductViewModel { Id = request.Id, Name = request.Name };
        }
    }
}
