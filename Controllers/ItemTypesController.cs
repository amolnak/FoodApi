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
    public class ItemTypesController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public ItemTypesController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/ItemTypesDetails/5
        [HttpGet("[action]/{ItemTypeID}")]
        public IActionResult ItemTypesDetails(string ItemTypeID)
        {
            var ItemTypes = _dbContext.ItemTypes.Where(ItemTypes => ItemTypes.ItemTypeID.ToString() == ItemTypeID).OrderByDescending(o => o.ItemType);
            return Ok(ItemTypes);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ItemTypes ItemTypes)
        {
            var sameItemType = _dbContext.ItemTypes.SingleOrDefault(u => u.ItemType == ItemTypes.ItemType);
            if (sameItemType != null) return BadRequest("Item type already exists.");
            var ItemTypesObj = new ItemTypes
            {
                ItemTypeID = Guid.NewGuid(),
                ItemType = ItemTypes.ItemType               
            };
            _dbContext.ItemTypes.Add(ItemTypesObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{ItemTypeID}")]
        public IActionResult Delete(string ItemTypeID)
        {
            var ItemTypes = _dbContext.ItemTypes.Where(s => s.ItemTypeID.ToString() == ItemTypeID);
            _dbContext.ItemTypes.RemoveRange(ItemTypes);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string ItemTypeID)
        {
            var entity = _dbContext.ItemTypes.Find(ItemTypeID);
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
