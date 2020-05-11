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
    public class ADMINMastController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public ADMINMastController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/ADMINMastDetails/5
        [HttpGet("[action]/{ADMINMastID}")]
        public IActionResult ADMINMastDetails(string ADMINMastID)
        {

            var ADMINMast = _dbContext.ADMINMast.Where(ADMINMast => ADMINMast.AdminID.ToString() == ADMINMastID).OrderByDescending(o => o.Name);
            return Ok(ADMINMast);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ADMINMast ADMINMast)
        {
            var userWithSameEmail = _dbContext.ADMINMast.SingleOrDefault(u => u.EmailID == ADMINMast.EmailID);
            if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var ADMINMastObj = new ADMINMast
            {
                AdminID = Guid.NewGuid(),
                Name = ADMINMast.Name,
                UserName = ADMINMast.UserName,
                Password = ADMINMast.Password,
                EmailID = ADMINMast.EmailID,
                CityID = ADMINMast.CityID,
                Accesslevel = ADMINMast.Accesslevel,
                Active = ADMINMast.Active
            };
            _dbContext.ADMINMast.Add(ADMINMastObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{ADMINMastID}")]
        public IActionResult Delete(string ADMINMastID)
        {
            var ADMINMast = _dbContext.ADMINMast.Where(s => s.AdminID.ToString() == ADMINMastID);
            _dbContext.ADMINMast.RemoveRange(ADMINMast);
            _dbContext.SaveChanges();
            return Ok();

        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string ADMINMastID)
        {
            var entity = _dbContext.ADMINMast.Find(ADMINMastID);
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
