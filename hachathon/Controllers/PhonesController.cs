using System;
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
    public class PhonesController : ControllerBase
    {
        private readonly IPhoneRepository phoneRepository;
        private readonly IMapper mapper;

        public PhonesController(IPhoneRepository phoneRepository, IMapper mapper)
        {
            this.phoneRepository = phoneRepository;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IList<PhoneResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPhones()
        {
            var phones = await phoneRepository.ListAsync();
            var resource = mapper.Map<IList<Phone>, IList<PhoneResource>>(phones);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePhone(string id, PhoneResource phoneIn)
        {
            var phone = mapper.Map<PhoneResource, Phone>(phoneIn);
            if (!await phoneRepository.IsPhoneExist(id))
                return NotFound();

            try
            {
                phoneRepository.Update(phone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}