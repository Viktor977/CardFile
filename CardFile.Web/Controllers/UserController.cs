using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _service.GetByIdWithDetailsAsync(id);
            return Ok(user);
        }
        [HttpGet("validation")]
        public async Task<ActionResult<bool>>CheckUser([FromBody]UserDto user)
        {
            var result = await _service.CheckUser(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult>Add([FromBody]UserDto user)
        {
            await _service.AddAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult>DeleteById(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();

        }     
       
    }
}
