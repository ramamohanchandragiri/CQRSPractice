using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.API.Controllers
{
    public class BaseController : ControllerBase
    {
        //public BaseController(IMediator mediator)
        //{
        //    Mediator = mediator;
        //}

        //public IMediator Mediator { get; }

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
