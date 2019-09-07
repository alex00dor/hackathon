using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using hachathon.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hachathon.Controllers
{
    [Route("/api/[controller]/")]
    [ApiController]
    public class Statuses : ControllerBase
    {
        private readonly IStatusRepository statusRepository;
        private readonly IMapper mapper;

        public Statuses(IStatusRepository statusRepository, IMapper mapper)
        {
            this.statusRepository = statusRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IList<StatusResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStatuses()
        {
            var statuses = await statusRepository.ListAsync();
            var resource = mapper.Map<IList<Status>, IList<StatusResource>>(statuses);
            return Ok(resource);
        }
    }
}