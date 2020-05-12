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
    public class AdminRegionsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public AdminRegionsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/AdminRegionsDetails/5
        [HttpGet("[action]/{AdminRegionID}")]
        public IActionResult AdminRegionsDetails(string AdminRegionID)
        {

            var AdminRegions = _dbContext.AdminRegions.Where(AdminRegions => AdminRegions.AdminRegionID.ToString() == AdminRegionID);
            return Ok(AdminRegions);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AdminRegions AdminRegions)
        {
            var AdminWithSameRegion = _dbContext.AdminRegions.SingleOrDefault(u => u.RegionID == AdminRegions.RegionID);
            if (AdminWithSameRegion != null) return BadRequest("Admin with this region already exists");
            var AdminRegionsObj = new AdminRegions
            {
                AdminRegionID = Guid.NewGuid(),
                AdminID = AdminRegions.AdminID,
                RegionID = AdminRegions.RegionID               
            };
            _dbContext.AdminRegions.Add(AdminRegionsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{AdminRegionID}")]
        public IActionResult Delete(string AdminRegionID)
        {
            var AdminRegions = _dbContext.AdminRegions.Where(s => s.AdminRegionID.ToString() == AdminRegionID);
            _dbContext.AdminRegions.RemoveRange(AdminRegions);
            _dbContext.SaveChanges();
            return Ok();

        }      

    }
}
