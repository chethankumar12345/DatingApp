using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _pDataContext;

        public ValuesController(DataContext pDataContext)
        {
            _pDataContext = pDataContext;
        }         

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _pDataContext.Values.ToList();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<string> GetValue(int id)
        {
            var values = _pDataContext.Values.FirstOrDefault(pX=>pX.Id == id);
            return Ok(values);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
