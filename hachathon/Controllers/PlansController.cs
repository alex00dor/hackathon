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
    public class PlansController : ControllerBase
    {
        private readonly IPlanRepository planRepository;
        private readonly IMapper mapper;

        public PlansController(IPlanRepository planRepository, IMapper mapper)
        {
            this.planRepository = planRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IList<PlanResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await planRepository.ListAsync();
            var resource = mapper.Map<IList<Plan>, IList<PlanResource>>(plans);
            return Ok(resource);
        }
    }
}