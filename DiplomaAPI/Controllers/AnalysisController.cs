using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaDBL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly DiplomaDbContext _context;

        public AnalysisController(DiplomaDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, string value)
        {
            return Ok("Works");
        }
    }
}