using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransIT.Application.DTOs;
using TransIT.Domain.Interfaces;
using TransIT.Domain.Models;

namespace TransIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public OrderController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(mapper.Map<IEnumerable<ViewOrderDTO>>(await uow.OrderRepository.GetAll()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var ord = await uow.OrderRepository.GetById(id);
            if (ord == null)
            {
                return NotFound("Nije pronadjena narudzbina sa ovim brojem.");
            }
            return Ok(mapper.Map<ViewOrderDTO>(ord));
        }
        [HttpPost]
        public async Task<IActionResult> Send(OrderDTO orderDTO)
        {
            return Ok(await uow.OrderRepository.Create(mapper.Map<Order>(orderDTO)));
        }
        [HttpPost("/sendWithPackages")]
        public async Task<IActionResult> SendWithPackages(OrderDTO orderDTO)
        {
            return Ok(await uow.OrderRepository.CreateOrderWithPackages(mapper.Map<Order>(orderDTO)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute]int id)
        {
            var order = await uow.OrderRepository.Delete(id);
            if(order == null)
            {
                return NotFound("Nije pronadjena narudzbina.");

            }
            return Ok(order);
        }
    }
}
