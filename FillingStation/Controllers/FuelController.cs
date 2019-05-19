using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FillingStation.DTOs;
using FillingStation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FillingStation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private IFuelService _fuelService;
        public FuelController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<FuelDTO>> Get()
        {
            //await Response.WriteAsync(JsonConvert.SerializeObject(dto, 
            //new JsonSerializerSettings { Formatting = Formatting.Indented }));
            return await _fuelService.GetFuel(); ;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
