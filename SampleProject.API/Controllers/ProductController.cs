using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Features.Product.Commands;
using SampleProject.Application.Features.Product.Queries;
using SampleProject.Application.ViewModels;

namespace SampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        //public ProductController(IMediator mediator) : base(mediator)
        //{

        //}

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            IEnumerable<ProductViewModel> products = await Mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            ProductViewModel productViewModel = await Mediator.Send(new GetProductByIdQuery(id));

            return Ok(productViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductViewModel productViewModel)
        {
            var productToReturn = await Mediator.Send(new AddProductCommand() { Id = productViewModel.Id, Name = productViewModel.Name });

            await Mediator.Publish(new ProductAddedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand {  Id = id }));
        }
    }
}
