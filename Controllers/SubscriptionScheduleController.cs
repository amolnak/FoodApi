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
    public class SubscriptionScheduleController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public SubscriptionScheduleController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/SubscriptionSchedule/SubscriptionScheduleDetails/5
        [HttpGet("[action]/{SubscriptionScheduleID}")]
        public IActionResult SubscriptionScheduleDetails(string SubscriptionScheduleID)
        {

            var SubscriptionSchedule = _dbContext.SubscriptionSchedule.Where(SubscriptionSchedule => SubscriptionSchedule.SubSchID.ToString() == SubscriptionScheduleID).OrderByDescending(o => o.ScheduleName);
            return Ok(SubscriptionSchedule);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(SubscriptionSchedule SubscriptionSchedule)
        {
            var userWithSameEmail = _dbContext.SubscriptionSchedule.SingleOrDefault(u => u.ScheduleName == SubscriptionSchedule.ScheduleName);
            if (userWithSameEmail != null) return BadRequest("Schedule Name already exists");
            var SubscriptionScheduleObj = new SubscriptionSchedule
            {
                SubSchID = Guid.NewGuid(),
                ScheduleType = SubscriptionSchedule.ScheduleType,
                ScheduleName = SubscriptionSchedule.ScheduleName
            };
            _dbContext.SubscriptionSchedule.Add(SubscriptionScheduleObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{SubscriptionScheduleID}")]
        public IActionResult Delete(string SubscriptionScheduleID)
        {
            var SubscriptionSchedule = _dbContext.SubscriptionSchedule.Where(s => s.SubSchID.ToString() == SubscriptionScheduleID);
            _dbContext.SubscriptionSchedule.RemoveRange(SubscriptionSchedule);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
