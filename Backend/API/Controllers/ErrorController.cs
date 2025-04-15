using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {

        [HttpGet("not-found")]
        public IActionResult NotFoundError()
        {
            return NotFound();
        }


          [HttpGet("bad-request")]
          public IActionResult BadRequestError()
        {
            return BadRequest();
        }


          [HttpGet("unauthorized")]
          public IActionResult unauthorizedError()
        {
            return Unauthorized();
        }
         [HttpGet("validation-error")]
          public IActionResult ValidationError()
        {
            ModelState.AddModelError("validation error 1", "validation error details");
            ModelState.AddModelError("validation error 2", "validation error details2");
            return ValidationProblem();
        }
          [HttpGet("server-error")]
          public IActionResult ServerError()
        {
            
            throw  new Exception("server error");
        }
    }
}