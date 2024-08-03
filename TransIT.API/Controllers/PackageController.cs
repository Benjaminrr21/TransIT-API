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
    public class PackageController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public PackageController(IMapper mapper, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.uow = uow;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await uow.PackageRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackageDTO packageDTO)
        {
            return Ok(await uow.PackageRepository.Create(mapper.Map<Package>(packageDTO)));
        }

        [HttpPost("/SendByDispatcher/{id}")]
        public async Task<IActionResult> SendByDispatcher([FromRoute] int id, [FromBody] PackageWeightDTO packageDTO)
        {
            var p = await uow.PackageRepository.GetById(id);
            if(p != null)
            {
                return Ok(await uow.PackageRepository.SendFromDispatcher(p.Id, packageDTO.Weight));
            }
            return NotFound();
          
        }
    }
}
