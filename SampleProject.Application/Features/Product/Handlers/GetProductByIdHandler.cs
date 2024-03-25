using AutoMapper;
using MediatR;
using SampleProject.Application.Features.Product.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly ISampleDatabase _sampleDatabase;
        private readonly IMapper mapper;

        public GetProductByIdHandler(ISampleDatabase sampleDatabase, IMapper mapper) {
            _sampleDatabase = sampleDatabase;
            this.mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Product product = await _sampleDatabase.GetProductById(request.Id);

            if(product == null)
            {

                // throw item not found exception
            }

            return this.mapper.Map<ProductViewModel>(product);
        }
    }
}
