using MediatR;

namespace SampleProject.Application.Features.Product.Commands
{
    public class DeleteProductByIdCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
