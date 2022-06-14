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
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _service;

        public HistoryController(IHistoryService service)
        {
            _service = service;
        }

        // GET: api/<HistoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetAllHistory()
        {
            var histories = await _service.GetAllAsync();
            return Ok(histories);
        }

        // GET api/<HistoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryDto>> GetById(int id)
        {
            var history = await _service.GetByIdAsync(id);
            return Ok(history);
        }

        //// POST api/<HistoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<HistoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<HistoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
