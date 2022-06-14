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
        
        

    }
}
