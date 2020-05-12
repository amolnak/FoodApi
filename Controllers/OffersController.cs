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
    public class OffersController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public OffersController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ADMINMast/OffersDetails/5
        [HttpGet("[action]/{OfferID}")]
        public IActionResult OffersDetails(string OfferID)
        {

            var Offers = _dbContext.Offers.Where(Offers => Offers.OfferID.ToString() == OfferID).OrderByDescending(o => o.OfferName);
            return Ok(Offers);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Offers Offers)
        {
            var OfferWithSameName = _dbContext.Offers.SingleOrDefault(u => u.OfferName == Offers.OfferName);
            if (OfferWithSameName != null) return BadRequest("Offer with this name already exists");
            var OffersObj = new Offers
            {
                OfferID = Guid.NewGuid(),
                Active = Offers.Active,
                ItemID = Offers.ItemID,
                OfferCode = Offers.OfferCode,
                OfferDescription = Offers.OfferDescription,
                OfferName = Offers.OfferName,
                Offertype = Offers.Offertype,
                Price = Offers.Price
            };
            _dbContext.Offers.Add(OffersObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{OfferID}")]
        public IActionResult Delete(string OfferID)
        {
            var Offers = _dbContext.Offers.Where(s => s.OfferID.ToString() == OfferID);
            _dbContext.Offers.RemoveRange(Offers);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT: api/Orders/MarkOrderComplete/5

        [HttpPut("[action]/{Deactivate}")]
        public IActionResult Deactivate(string OfferID)
        {
            var entity = _dbContext.Offers.Find(OfferID);
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
