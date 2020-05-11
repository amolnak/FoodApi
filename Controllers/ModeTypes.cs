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
    public class ModeTypesController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public ModeTypesController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/ModeTypes/ModeTypesDetails/5
        [HttpGet("[action]/{ModeTypesID}")]
        public IActionResult ModeTypesDetails(string ModeTypesID)
        {

            var ModeTypes = _dbContext.ModeTypes.Where(ModeTypes => ModeTypes.ModeType.ToString() == ModeTypesID).OrderByDescending(o => o.ModeName);
            return Ok(ModeTypes);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ModeTypes ModeTypes)
        {
            var userWithSameEmail = _dbContext.ModeTypes.SingleOrDefault(u => u.ModeType == ModeTypes.ModeType);
            if (userWithSameEmail != null) return BadRequest("ModeType already exists");
            var ModeTypesObj = new ModeTypes
            {
                ModeType = ModeTypes.ModeType,
                ModeName = ModeTypes.ModeName
            };
            _dbContext.ModeTypes.Add(ModeTypesObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{ModeName}")]
        public IActionResult Delete(string ModeName)
        {
            var ModeTypes = _dbContext.ModeTypes.Where(s => s.ModeName.ToString() == ModeName);
            _dbContext.ModeTypes.RemoveRange(ModeTypes);
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}
