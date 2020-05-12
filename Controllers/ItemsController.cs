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
    public class ItemsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public ItemsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/ItemsDetails/5
        [HttpGet("[action]/{ItemID}")]
        public IActionResult ItemsDetails(string ItemID)
        {

            var Items = _dbContext.Items.Where(Items => Items.ItemID.ToString() == ItemID).OrderByDescending(o => o.ItemName);
            return Ok(Items);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Items Items)
        {
            var ItemWithSameSame = _dbContext.Items.SingleOrDefault(u => u.ItemName == Items.ItemName);
            if (ItemWithSameSame != null) return BadRequest("Item with this name already exists");
            var ItemsObj = new Items
            {
                ItemID = Guid.NewGuid(),
                ItemAddOnID = Items.ItemAddOnID,
                ItemCode = Items.ItemCode,
                ItemDescription = Items.ItemDescription,
                ItemImage = Items.ItemImage,
                ItemName = Items.ItemName,
                ItemPrice = Items.ItemPrice,
                ItemTypeID = Items.ItemTypeID,
                StarReceipe = Items.StarReceipe,
                VegNonVeg = Items.VegNonVeg
            };
            _dbContext.Items.Add(ItemsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{ItemID}")]
        public IActionResult Delete(string ItemID)
        {
            var Items = _dbContext.Items.Where(s => s.ItemID.ToString() == ItemID);
            _dbContext.Items.RemoveRange(Items);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string ItemID)
        {
            var entity = _dbContext.Items.Find(ItemID);
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
