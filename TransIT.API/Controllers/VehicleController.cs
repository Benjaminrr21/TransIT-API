using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using TransIT.Application.DTOs;
using TransIT.Domain.Interfaces;
using TransIT.Domain.Models;

namespace TransIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public VehicleController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
            
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await uow.VehicleRepository.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ob = await uow.VehicleRepository.GetById(id);
            if (ob == null) return NotFound("Nije pronadjeno vozilo.");
            return Ok(ob);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]VehicleDTO vehicle)
        {
            return Ok(await uow.VehicleRepository.Create(mapper.Map<Vehicle>(vehicle)));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var ob = await uow.VehicleRepository.Delete(id);
            if (ob == null) return NotFound("Nije moguce brisanje vozila.");
            return Ok(ob);
        }
    }
}
