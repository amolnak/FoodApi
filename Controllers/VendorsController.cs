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
    public class VendorsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public VendorsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/Vendors/VendorsDetails/5
        [HttpGet("[action]/{VendorID}")]
        public IActionResult VendorsDetails(string VendorID)
        {

            var Vendors = _dbContext.Vendors.Where(Vendors => Vendors.VendorID.ToString() == VendorID).OrderByDescending(o => o.VendorFName);
            return Ok(Vendors);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Vendors Vendors)
        {
            //var userWithSameEmail = _dbContext.ADMINMast.SingleOrDefault(u => u.EmailID == ADMINMast.EmailID);
            //if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var VendorsObj = new Vendors
            {
                VendorID = Guid.NewGuid(),
                Active = Vendors.Active,
                CityID = Vendors.CityID,
                DeliveryProvision = Vendors.DeliveryProvision,
                LocationMAP = Vendors.LocationMAP,
                Password = Vendors.Password,
                RegionID = Vendors.RegionID,
                UserName = Vendors.UserName,
                VendorAddress = Vendors.VendorAddress,
                VendorCode = Vendors.VendorCode,
                VendorEmail = Vendors.VendorEmail,
                VendorFName = Vendors.VendorFName,
                VendorLName = Vendors.VendorLName,
                VendorPhone1 = Vendors.VendorPhone1,
                VendorPhone2 = Vendors.VendorPhone2
            };
            _dbContext.Vendors.Add(VendorsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{VendorID}")]
        public IActionResult Delete(string VendorID)
        {
            var Vendors = _dbContext.Vendors.Where(s => s.VendorID.ToString() == VendorID);
            _dbContext.Vendors.RemoveRange(Vendors);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string VendorID)
        {
            var entity = _dbContext.Vendors.Find(VendorID);
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
