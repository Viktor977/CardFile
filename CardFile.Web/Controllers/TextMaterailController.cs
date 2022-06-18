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
    public class TextMaterailController : ControllerBase
    {

        private ITextMaterialService _service;
        public TextMaterailController(ITextMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextMaterialDto>>> GetAllTextFile()
        {
            //if (search is null)
            //{
            //    var textMaterial = await _service.GetAllAsync();
            //    if (textMaterial is null) return NotFound();
            //    return Ok(textMaterial);

            //}

            var text = await _service.GetAllAsync();
            return Ok(text);

<<<<<<< HEAD
         
          
=======


>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f
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
<<<<<<< HEAD
=======


>>>>>>> f6d2f18323cb5e1e42303d6dd55075c456b8238f

    }
}
