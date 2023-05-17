using MediatR;
using Microsoft.AspNetCore.Mvc;
using MobilivaCase.Application.Features.Commands.Order.CreateOrder;
using MobilivaCase.Application.Features.Queries.Product.GetAllProduct;


namespace MobilivaCase.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MobilivaController : ControllerBase
    {
        protected readonly IMediator _mediator;
        

        public MobilivaController(IMediator mediator)
        {
            _mediator = mediator;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]GetAllProductQueryRequest request)
        {
            var response =await  _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
         
            var response = await _mediator.Send(request);
            
            return Ok(response);
        }
    }
}
