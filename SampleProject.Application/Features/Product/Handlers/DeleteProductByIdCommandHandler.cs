using MediatR;
using SampleProject.Application.Features.Product.Commands;
using SampleProject.Domain.Interfaces;

namespace SampleProject.Application.Features.Product.Handlers
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly ISampleDatabase sampleDatabase;

        public DeleteProductByIdCommandHandler(ISampleDatabase sampleDatabase)
        {
            this.sampleDatabase = sampleDatabase;
        }

        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            Domain.Product product = await this.sampleDatabase.GetProductById(command.Id);

            await this.sampleDatabase.DeleteProductById(product);

            return command.Id;
        }
    }
}
