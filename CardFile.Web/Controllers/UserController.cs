using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardFile.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]  
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _service.GetAllAsync();
            if (users is null) return NotFound();
            return Ok(users);
        }
      
        [HttpGet("{id}")]  
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult>Add([FromBody]UserDto user)
        {
            await _service.AddAsync(user);
            return Ok();
        }
    }
}
