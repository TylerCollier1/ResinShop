using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResinShop.API.Models;
using ResinShop.Core.Entities;
using ResinShop.Core.Interfaces.DAL;

namespace ResinShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var result = _orderRepository.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                throw new Exception(result.Message);
            }
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            var result = _orderRepository.Get(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                Order o = new Order
                {
                    CustomerId = order.CustomerId,
                    ArtId = order.ArtId,
                    OrderDate = order.OrderDate
                };

                var result = _orderRepository.Insert(o); //ISSUE BECAUSE CORE ERROR

                if (result.Success)
                {
                    return CreatedAtRoute(nameof(GetOrder), new { id = o.OrderId }, o);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult EditOrder(OrderModel orderModel)
        {
            if (ModelState.IsValid && orderModel.OrderId > 0)
            {
                Order order = new Order
                {
                    OrderId = orderModel.OrderId,
                    CustomerId = orderModel.CustomerId,
                    ArtId = orderModel.ArtId,
                    OrderDate = orderModel.OrderDate
                };

                if (!_orderRepository.Get(order.OrderId).Success)
                {
                    return NotFound($"Order {order.OrderId} not found");
                }

                var result = _orderRepository.Update(order);

                if (result.Success)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            else
            {
                if (orderModel.OrderId < 1)
                {
                    ModelState.AddModelError("orderId", "Invalid Order ID");
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (!_orderRepository.Get(id).Success)
            {
                return NotFound($"Order {id} not found");
            }

            var result = _orderRepository.Delete(id);

            if (result.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
