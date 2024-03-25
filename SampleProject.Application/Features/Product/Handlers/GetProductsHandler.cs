using AutoMapper;
using MediatR;
using SampleProject.Application.Features.Product.Queries;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly ISampleDatabase _sampleDataStore;
        private readonly IMapper _mapper;
        public GetProductsHandler(ISampleDatabase fakeDataStore, IMapper mapper) {

            _sampleDataStore = fakeDataStore;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Product> products = await _sampleDataStore.GetAllProducts();

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
