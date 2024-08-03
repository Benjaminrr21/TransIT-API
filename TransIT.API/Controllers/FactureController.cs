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
    public class FactureController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public FactureController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await uow.FactureRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var ob = await uow.FactureRepository.GetById(id);
            if(ob == null) return NotFound("Nije pronadjena faktura.");
            return Ok(ob);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FactureDTO facture)
        {
            return Ok(await uow.FactureRepository.Create(mapper.Map<Facture>(facture)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ob = await uow.FactureRepository.Delete(id);
            if (ob == null) return NotFound("Nije moguce brisanje fakture.");
            return Ok(ob);
        }
    }
}
