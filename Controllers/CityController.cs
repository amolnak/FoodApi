using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.Data;
using FoodApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public CityController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/CityDetails/5
        [HttpGet("[action]/{CityID}")]
        public IActionResult CityDetails(string CityID)
        {

            var City = _dbContext.City.Where(City => City.CityID.ToString() == CityID).OrderByDescending(o => o.CityName);
            return Ok(City);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(City City)
        {
            var CityWithSameName = _dbContext.City.SingleOrDefault(u => u.CityID == City.CityID);
            if (CityWithSameName != null) return BadRequest("City with this name already exists");
            var CityObj = new City
            {
                CityID = Guid.NewGuid(),
                CityCode = City.CityCode,
                CityName = City.CityName,               
                Active = City.Active
            };
            _dbContext.City.Add(CityObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{CityID}")]
        public IActionResult Delete(string CityID)
        {
            var City = _dbContext.City.Where(s => s.CityID.ToString() == CityID);
            _dbContext.City.RemoveRange(City);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string CityID)
        {
            var entity = _dbContext.City.Find(CityID);
            if (entity == null)
            {
                return NotFound("No records found against this id...");
            }
            else
            {
                entity.Active = "N";
                _dbContext.SaveChanges();
                return Ok("Deactivated");
            }
        }

    }
}
