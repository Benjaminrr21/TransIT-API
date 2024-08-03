using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransIT.Application.DTOs;
using TransIT.Domain.Interfaces;

namespace TransIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ClientController(IMapper mapper,IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(mapper.Map<IEnumerable<ClientViewDTO>>(await uow.ClientRepository.GetAll()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var client = await uow.ClientRepository.GetById(id);
            if(client == null) { return NotFound("Nije pronadjen klijent."); }
            return Ok(mapper.Map<ClientViewDTO>(client));
        }
        
    }
}
