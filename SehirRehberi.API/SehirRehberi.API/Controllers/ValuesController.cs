using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SehirRehberi.API.Data;

namespace SehirRehberi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
       private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            //injekte ediyoruz
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(v=>v.Id==id);
            return Ok(value);
        }
       

    }
}
