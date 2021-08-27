using Business.Abstract;
using Business.MediatR.CQRS.Command.ChangeOrderStatus;
using Business.MediatR.CQRS.Command.CreateOrder;
using Business.MediatR.CQRS.Command.DeleteOrder;
using Business.MediatR.CQRS.Command.UpdateOrder;
using Business.MediatR.CQRS.Query.GetAllOrders;
using Business.MediatR.CQRS.Query.GetOrderByCustomerId;
using Business.MediatR.CQRS.Query.GetOrderByOrderId;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        IMediator _mediator;

        public OrdersController(IMediator mediator)
        {

            _mediator = mediator;
        }
        [HttpPost("create")]
        public IActionResult Create(CreateOrderCommand command)
        {
            var result = _mediator.Send(command);
            return result.Result.Success ? Ok(result.Result) : BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(UpdateOrderCommand command)
        {
            var result = _mediator.Send(command);
            return result.Result.Success ? Ok(result) : BadRequest();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Guid orderId)
        {
            var query = new DeleteOrderCommand() { OrderId = orderId };
            var result = _mediator.Send(query);
            return result.Result.Success ? Ok(result) : BadRequest();
        }
        [HttpGet("getallorders")]
        public IActionResult GetAllOrders()
        
        
        
        
        
        {
            var query = new GetAllOrdersQuery();
            var result = _mediator.Send(query);
            return result.Result.Success ? Ok(result.Result) : BadRequest();
        }
        [HttpGet("getordersbycustomerid")]
        public IActionResult GetOrdersByCustomerId(Guid customerId)
        {
            var query = new GetOrderByCustomerIdQuery() { CustomerId = customerId };
            var result = _mediator.Send(query);
            return result.Result.Success ? Ok(result.Result) : BadRequest();
        }
        [HttpGet("getbyorderid")]
        public IActionResult GetOrderByOrderId(Guid orderId)
        {
            var query = new GetOrderByOrderIdQuery() { OrderId = orderId };
            var result = _mediator.Send(query);
            return result.Result.Success ? Ok(result.Result) : BadRequest();
        }
        [HttpGet("changestatus")]
        public IActionResult ChangeStatus(Guid orderId, string status)
        {
            var query = new ChangeOrderStatusCommand() { OrderId = orderId, Status = status };

            var result = _mediator.Send(query);
            return result.Result.Success ? Ok(result.Result) : BadRequest();
        }


    }
}
