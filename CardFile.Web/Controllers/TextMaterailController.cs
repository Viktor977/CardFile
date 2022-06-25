using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CardFile.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextMaterailController : ControllerBase
    {

        private ITextMaterialService _service;
        public TextMaterailController(ITextMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextMaterialDto>>> GetAllTextFile([FromQuery] FilterSearchDto filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Author))
            {
                var textFilter = await _service.SearchByFilter(filter);
                if (textFilter is null) return BadRequest();
                return Ok(textFilter);
            }
            else if (!string.IsNullOrWhiteSpace(filter.TitleText))
            {
                var textFilter = await _service.SearchByFilter(filter);
                if (textFilter is null) return BadRequest();
                return Ok(textFilter);
            }


            var text = await _service.GetAllAsync();
            return Ok(text);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TextMaterialDto>> GetById(int id)
        {
            var textMaterial = await _service.GetByIdAsync(id);
            if (textMaterial is null)
            {
                return NotFound();
            }
            return Ok(textMaterial);
        }

        [HttpPost]
        public async Task<ActionResult>Add([FromBody]TextMaterialDto text)
        {
            await _service.AddAsync(text);
            return Ok();
        }

    }
}
