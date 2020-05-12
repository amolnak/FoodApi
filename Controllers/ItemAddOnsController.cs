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
    public class ItemAddOnsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public ItemAddOnsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/ItemAddOnsDetails/5
        [HttpGet("[action]/{ItemAddOnID}")]
        public IActionResult ItemAddOnsDetails(string ItemAddOnID)
        {

            var ItemAddOns = _dbContext.ItemAddOns.Where(ItemAddOns => ItemAddOns.ItemAddOnID.ToString() == ItemAddOnID).OrderByDescending(o => o.AddOnName);
            return Ok(ItemAddOns);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ItemAddOns ItemAddOns)
        {
            var ItemAddOnsObj = new ItemAddOns
            {
                ItemAddOnID = Guid.NewGuid(),
                AddOnName = ItemAddOns.AddOnName,
                AddOnPrice = ItemAddOns.AddOnPrice                
            };
            _dbContext.ItemAddOns.Add(ItemAddOnsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{ItemAddOnID}")]
        public IActionResult Delete(string ItemAddOnID)
        {
            var ItemAddOns = _dbContext.ItemAddOns.Where(s => s.ItemAddOnID.ToString() == ItemAddOnID);
            _dbContext.ItemAddOns.RemoveRange(ItemAddOns);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string ItemAddOnID)
        {
            var entity = _dbContext.ItemAddOns.Find(ItemAddOnID);
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
