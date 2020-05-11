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
    public class OfficesController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public OfficesController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/Offices/OfficesDetails/5
        [HttpGet("[action]/{OfficesID}")]
        public IActionResult OfficesDetails(string OfficesID)
        {

            var Offices = _dbContext.Offices.Where(Offices => Offices.OfficeID.ToString() == OfficesID).OrderByDescending(o => o.OfficeName);
            return Ok(Offices);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Offices Offices)
        {
            var userWithSameEmail = _dbContext.Offices.SingleOrDefault(u => u.EmailID == Offices.EmailID);
            if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var OfficesObj = new Offices
            {
                OfficeID = Guid.NewGuid(),
                OfficeName = Offices.OfficeName,
                Address = Offices.Address,
                LocationMAP = Offices.LocationMAP,
                EmailID = Offices.EmailID,
                Phone1 = Offices.Phone1,
                Phone2 = Offices.Phone2,
                CityID = Offices.CityID,
                RegionID = Offices.RegionID,
                NoofSubscribers = Offices.NoofSubscribers,
                Active = "y"
            };
            _dbContext.Offices.Add(OfficesObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{OfficesID}")]
        public IActionResult Delete(string OfficesID)
        {
            var Offices = _dbContext.Offices.Where(s => s.OfficeID.ToString() == OfficesID);
            _dbContext.Offices.RemoveRange(Offices);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string OfficesID)
        {
            var entity = _dbContext.Offices.Find(OfficesID);
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
