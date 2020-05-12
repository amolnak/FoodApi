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
    public class UserSubscriptionsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public UserSubscriptionsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/UserSubscriptions/UserSubscriptionsDetails/5
        [HttpGet("[action]/{UserSubscriptionID}")]
        public IActionResult UserSubscriptionsDetails(string UserSubscriptionID)
        {

            var UserSubscriptions = _dbContext.UserSubscriptions.Where(UserSubscriptions => UserSubscriptions.UserSubscriptionID.ToString() == UserSubscriptionID).OrderByDescending(o => o.SubscriptionStartDate);
            return Ok(UserSubscriptions);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserSubscriptions UserSubscriptions)
        {
            //var userWithSameEmail = _dbContext.ADMINMast.SingleOrDefault(u => u.EmailID == ADMINMast.EmailID);
            //if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var UserSubscriptionsObj = new UserSubscriptions
            {
                UserSubscriptionID = Guid.NewGuid(),
                DiscountApplied = UserSubscriptions.DiscountApplied,
                FamMembID = UserSubscriptions.FamMembID,
                ItemAddOnQty = UserSubscriptions.ItemAddOnQty,
                ItemID = UserSubscriptions.ItemID,
                OfferID = UserSubscriptions.OfferID,
                Quantity = UserSubscriptions.Quantity,
                ScheduledDates = UserSubscriptions.ScheduledDates,
                ScheduledTime = UserSubscriptions.ScheduledTime,
                SubSchID = UserSubscriptions.SubSchID,
                SubscriptionEndDate = UserSubscriptions.SubscriptionEndDate,
                SubscriptionPrice = UserSubscriptions.SubscriptionPrice,
                SubscriptionStartDate = UserSubscriptions.SubscriptionStartDate,
                UserID = UserSubscriptions.UserID
            };
            _dbContext.UserSubscriptions.Add(UserSubscriptionsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{UserSubscriptionID}")]
        public IActionResult Delete(string UserSubscriptionID)
        {
            var UserSubscriptions = _dbContext.UserSubscriptions.Where(s => s.UserSubscriptionID.ToString() == UserSubscriptionID);
            _dbContext.UserSubscriptions.RemoveRange(UserSubscriptions);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string UserSubscriptionID)
        {
            var entity = _dbContext.UserSubscriptions.Find(UserSubscriptionID);
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
