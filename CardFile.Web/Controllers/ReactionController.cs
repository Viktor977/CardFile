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
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _service;

        public ReactionController(IReactionService service)
        {
            _service = service;
        }

        [HttpGet]
      
        public async Task<ActionResult<IEnumerable<ReactionDto>>> GetAll()
        {
            var reactions = await _service.GetAllAsync();
            return Ok(reactions);
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult>GetById(int id)
        {
            var reaction = await _service.GetByIdAsync(id);
            if(reaction is null)
            {
                return BadRequest();
            }

            return Ok(reaction);
        }

        [HttpPost]      
        public async Task<ActionResult> Add([FromBody] ReactionDto reaction)
        {
            if (reaction.TextId == 0)
            {
                return BadRequest();
            }

            await _service.AddAsync(reaction);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult>Update([FromBody] ReactionDto reaction)
        {
            if (reaction.TextId == 0)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(reaction);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult>Delete([FromBody] ReactionDto reaction)
        {
            if(reaction is null)
            {
                return BadRequest();
            }

            await _service.DeleteAsync(reaction);
            return Ok();
        }
    }   
}
