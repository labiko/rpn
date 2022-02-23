using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class rpn : ControllerBase
    {
        Stack<int> _numbers = new Stack<int>();

        [HttpGet]
        [Route("[action]")]
        public IActionResult op()
        {
            return Ok(_numbers);
        }

        [HttpPost("{id}")]
        public IActionResult GetById(string id)
        {
            // _numbers.Push(id); ok
            return Ok(100);
        }
    }
}