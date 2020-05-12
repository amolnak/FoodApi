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
    public class VendorItemsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public VendorItemsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/VendorItems/VendorItemsDetails/5
        [HttpGet("[action]/{vendorItemID}")]
        public IActionResult VendorItemsDetails(string vendorItemID)
        {

            var VendorItems = _dbContext.VendorItems.Where(VendorItems => VendorItems.vendorItemID.ToString() == vendorItemID).OrderByDescending(o => o.vendorItemID);
            return Ok(VendorItems);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(VendorItems VendorItems)
        {
            //var userWithSameEmail = _dbContext.ADMINMast.SingleOrDefault(u => u.EmailID == ADMINMast.EmailID);
            //if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var VendorItemsObj = new VendorItems
            {
                vendorItemID = Guid.NewGuid(),
                Capacity = VendorItems.Capacity,
                ItemID = VendorItems.ItemID,
                PerPlateRate = VendorItems.PerPlateRate,
                PreferentialRating = VendorItems.PreferentialRating,
                VendorId = VendorItems.VendorId
            };
            _dbContext.VendorItems.Add(VendorItemsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{vendorItemID}")]
        public IActionResult Delete(string vendorItemID)
        {
            var VendorItems = _dbContext.VendorItems.Where(s => s.vendorItemID.ToString() == vendorItemID);
            _dbContext.VendorItems.RemoveRange(VendorItems);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string vendorItemID)
        {
            var entity = _dbContext.VendorItems.Find(vendorItemID);
            if (entity == null)
            {
                return NotFound("No records found against this id...");
            }
            else
            {
                _dbContext.SaveChanges();
                return Ok("Deactivated");
            }
        }

    }
}
