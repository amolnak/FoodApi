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
    public class FamilyMemberDetailsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public FamilyMemberDetailsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/FamilyMemberDetails/FamilyMemberDetailsDetails/5
        [HttpGet("[action]/{FamilyMemberDetailsID}")]
        public IActionResult FamilyMemberDetailsDetails(string FamilyMemberDetailsID)
        {

            var FamilyMemberDetails = _dbContext.FamilyMemberDetails.Where(FamilyMemberDetails => FamilyMemberDetails.FamMembID.ToString() == FamilyMemberDetailsID).OrderByDescending(o => o.Name);
            return Ok(FamilyMemberDetails);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(FamilyMemberDetails FamilyMemberDetails)
        {
            var userWithSameEmail = _dbContext.FamilyMemberDetails.SingleOrDefault(u => u.MembEmail == FamilyMemberDetails.MembEmail);
            if (userWithSameEmail != null) return BadRequest("User with this email already exists");
            var FamilyMemberDetailsObj = new FamilyMemberDetails
            {
                FamMembID = Guid.NewGuid(),
                MembType = FamilyMemberDetails.MembType,
                UserId = FamilyMemberDetails.UserId,
                MembFName = FamilyMemberDetails.MembFName,
                MembLName = FamilyMemberDetails.MembLName,
                MembEmail = FamilyMemberDetails.MembEmail,
                MembPhone1 = FamilyMemberDetails.MembPhone1,
                MembPhone2 = FamilyMemberDetails.MembPhone2,
                MembBirthDate = FamilyMemberDetails.MembBirthDate,
                MembAge = FamilyMemberDetails.MembAge,
                ModeType = FamilyMemberDetails.ModeType,
                SchoolID = FamilyMemberDetails.SchoolID,
                OfficeID = FamilyMemberDetails.OfficeID,
                Standard = FamilyMemberDetails.Standard,
                Division = FamilyMemberDetails.Division
            };
            _dbContext.FamilyMemberDetails.Add(FamilyMemberDetailsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{FamilyMemberDetailsID}")]
        public IActionResult Delete(string FamilyMemberDetailsID)
        {
            var FamilyMemberDetails = _dbContext.FamilyMemberDetails.Where(s => s.FamMembID.ToString() == FamilyMemberDetailsID);
            _dbContext.FamilyMemberDetails.RemoveRange(FamilyMemberDetails);
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}
