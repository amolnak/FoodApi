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
    public class RegionController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public RegionController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/RegionDetails/5
        [HttpGet("[action]/{RegionID}")]
        public IActionResult RegionDetails(string RegionID)
        {

            var Region = _dbContext.Region.Where(Region => Region.RegionID.ToString() == RegionID).OrderByDescending(o => o.RegionName);
            return Ok(Region);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Region Region)
        {
            var RegionWithSameName = _dbContext.Region.SingleOrDefault(u => u.RegionID == Region.RegionID);
            if (RegionWithSameName != null) return BadRequest("Region with this name already exists");
            var RegionObj = new Region
            {
                RegionID = Guid.NewGuid(),
                Active = Region.Active,
                CityID = Region.CityID,
                Pincode = Region.Pincode,
                RegionName = Region.RegionName               
            };
            _dbContext.Region.Add(RegionObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{RegionID}")]
        public IActionResult Delete(string RegionID)
        {
            var Region = _dbContext.Region.Where(s => s.RegionID.ToString() == RegionID);
            _dbContext.Region.RemoveRange(Region);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string RegionID)
        {
            var entity = _dbContext.Region.Find(RegionID);
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
