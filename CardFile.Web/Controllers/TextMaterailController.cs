using CardFile.BAL.Interfaces;
using CardFile.BAL.ModelsDto;
using CardFile.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<TextMaterialDto>>> Get()
        {
            var textMaterialList= await _service.GetAllAsync();
            return Ok(textMaterialList);
        }


        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<TextMaterialDto>> GetAllTextFile([FromQuery] FilterSearchDto filter)
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

            return BadRequest();
           
        }

        [HttpGet("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<ActionResult>Add([FromBody]TextMaterialDto text)
        {
            if(text is null)
            {
                return BadRequest();
            }

            await _service.AddAsync(text);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete([FromBody]TextMaterialDto text)
        {
            if(text is null)
            {
                return BadRequest();
            }

            await _service.DeleteAsync(text);
            return Ok();
        }
    }
}
