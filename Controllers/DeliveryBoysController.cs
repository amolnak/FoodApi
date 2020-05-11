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
    public class DeliveryBoysController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public DeliveryBoysController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/DeliveryBoys/DeliveryBoyDetails/5
        [HttpGet("[action]/{DeliveryBoyID}")]
        public IActionResult DeliveryBoyDetails(string DeliveryBoyID)
        {

            var DeliveryBoy = _dbContext.DeliveryBoys.Where(DeliveryBoys => DeliveryBoys.DeliveryBoyID.ToString() == DeliveryBoyID).OrderByDescending(o => o.DBUserName);
            return Ok(DeliveryBoy);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(DeliveryBoys DeliveryBoy)
        {
            var userWithSameEmail = _dbContext.DeliveryBoys.SingleOrDefault(u => u.DBEmail == DeliveryBoy.DBEmail);
            if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var DeliveryBoyObj = new DeliveryBoys
            {
                DeliveryBoyID = Guid.NewGuid(),
                DBFName = DeliveryBoy.DBFName,
                DBLName = DeliveryBoy.DBLName,
                DBUserName = DeliveryBoy.DBUserName,
                DBPassword = DeliveryBoy.DBPassword,
                DBAddress = DeliveryBoy.DBAddress,
                DBEmail = DeliveryBoy.DBEmail,
                DBPhone1 = DeliveryBoy.DBPhone1,
                DBPhone2 = DeliveryBoy.DBPhone2,
                DBCityID = DeliveryBoy.DBCityID,
                DBRegionID = DeliveryBoy.DBRegionID,
                LicenseNo = DeliveryBoy.LicenseNo,
                VehicleID = DeliveryBoy.VehicleID
            };
            _dbContext.DeliveryBoys.Add(DeliveryBoyObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{DeliveryBoyID}")]
        public IActionResult Delete(string DeliveryBoyID)
        {
            var DeliveryBoy = _dbContext.DeliveryBoys.Where(s => s.DeliveryBoyID.ToString() == DeliveryBoyID);
            _dbContext.DeliveryBoys.RemoveRange(DeliveryBoy);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
