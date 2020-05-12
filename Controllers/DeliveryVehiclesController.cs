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
    public class DeliveryVehiclesController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public DeliveryVehiclesController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/VehicleIDDetails/5
        [HttpGet("[action]/{VehicleID}")]
        public IActionResult DeliveryVehiclesDetails(string VehicleID)
        {

            var DeliveryVehicles = _dbContext.DeliveryVehicles.Where(DeliveryVehicles => DeliveryVehicles.VehicleID.ToString() == VehicleID).OrderByDescending(o => o.VehicleNo);
            return Ok(DeliveryVehicles);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(DeliveryVehicles DeliveryVehicles)
        {
            var VehicleWithSameNo = _dbContext.DeliveryVehicles.SingleOrDefault(u => u.VehicleNo == DeliveryVehicles.VehicleNo);
            if (VehicleWithSameNo != null) return BadRequest("Vehicle with this number already exists");
            var DeliveryVehiclesObj = new DeliveryVehicles
            {
                VehicleID = Guid.NewGuid(),
                Brand = DeliveryVehicles.Brand,
                ChasisNo = DeliveryVehicles.ChasisNo,
                FuelType = DeliveryVehicles.FuelType,
                GPSEnabled = DeliveryVehicles.GPSEnabled,
                Model = DeliveryVehicles.Model,
                VehicleNo = DeliveryVehicles.VehicleNo                
            };
            _dbContext.DeliveryVehicles.Add(DeliveryVehiclesObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{VehicleID}")]
        public IActionResult Delete(string VehicleID)
        {
            var DeliveryVehicles = _dbContext.DeliveryVehicles.Where(s => s.VehicleID.ToString() == VehicleID);
            _dbContext.DeliveryVehicles.RemoveRange(DeliveryVehicles);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string VehicleID)
        {
            var entity = _dbContext.DeliveryVehicles.Find(VehicleID);
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
