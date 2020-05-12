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
    public class SchoolsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public SchoolsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/Schools/SchoolsDetails/5
        [HttpGet("[action]/{SchoolID}")]
        public IActionResult SchoolsDetails(string SchoolID)
        {

            var Schools = _dbContext.Schools.Where(Schools => Schools.SchoolID.ToString() == SchoolID).OrderByDescending(o => o.SchoolName);
            return Ok(Schools);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Schools Schools)
        {
            var SchoolsWithSameName = _dbContext.Schools.SingleOrDefault(u => u.SchoolName == Schools.SchoolName);
            if (SchoolsWithSameName != null) return BadRequest("School with this name already exists");
            var SchoolsObj = new Schools
            {
                SchoolID = Guid.NewGuid(),
                Active = Schools.Active,
                Address = Schools.Address,
                CityID = Schools.CityID,
                EmailID = Schools.EmailID,
                LocationMAP = Schools.LocationMAP,
                NoofSubscribers = Schools.NoofSubscribers,
                Phone1 = Schools.Phone1,
                Phone2 = Schools.Phone2,
                RegionID = Schools.RegionID,
                SchoolName = Schools.SchoolName
            };
            _dbContext.Schools.Add(SchoolsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{SchoolID}")]
        public IActionResult Delete(string SchoolID)
        {
            var Schools = _dbContext.Schools.Where(s => s.SchoolID.ToString() == SchoolID);
            _dbContext.Schools.RemoveRange(Schools);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string SchoolID)
        {
            var entity = _dbContext.Schools.Find(SchoolID);
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
