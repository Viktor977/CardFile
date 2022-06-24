using CardFile.BAL.Interfaces;
using CardFile.BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
    
}
