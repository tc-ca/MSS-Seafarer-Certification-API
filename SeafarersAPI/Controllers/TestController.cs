using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafarersAPI.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {

        public TestController()
        {

        }

        [HttpGet]
        [Route("")]
        public IActionResult GetThing()
        {
            return Ok("TC");
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetThing(int id)
        {
            return Ok(id);
        }

    }
}
