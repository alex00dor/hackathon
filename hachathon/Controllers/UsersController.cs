using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using hachathon.Domain.Models;
using hachathon.Domain.Repositories;
using hachathon.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hachathon.Controllers
{
    [Route("/api/[controller]/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly IPlanRepository planRepository;
        private readonly IStatusRepository statusRepository;
        
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IPhoneRepository phoneRepository, IPlanRepository planRepository, IStatusRepository statusRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.phoneRepository = phoneRepository;
            this.planRepository = planRepository;
            this.statusRepository = statusRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<UserResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await userRepository.ListAsync();
            var resources = mapper.Map<IList<User>, IList<UserResource>>(users);
            return Ok(resources);
        }

        [HttpGet("{id}", Name = "GetUser")]
        [ProducesResponseType(typeof(UserResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userRepository.GetAsync(id);
            if (user == null)
                return NotFound();
            var resource = mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResource), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserResource userIn)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var modelState in ModelState.Values) {
                    foreach (ModelError error in modelState.Errors)
                    {
                        sb.Append(error.ErrorMessage);
                    }
                }
                return BadRequest(sb.ToString());
            }

            var user = mapper.Map<CreateUserResource, User>(userIn);
            user.StatusId = 1;

            try
            {
                await userRepository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtRoute("GetUser", new {id = user.Id});
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(string id, UserResource userIn)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var modelState in ModelState.Values) {
                    foreach (ModelError error in modelState.Errors)
                    {
                        sb.Append(error.ErrorMessage);
                    }
                }
                return BadRequest(sb.ToString());
            }

            if (!await userRepository.IsUserExist(id))
                return NotFound();

            var user = mapper.Map<UserResource, User>(userIn);

            try
            {
                await userRepository.UpdateUserAsync(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}