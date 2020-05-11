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
    public class AppInstallationsController : ControllerBase
    {
        private FoodDbContext _dbContext;
        public AppInstallationsController(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // GET: api/AppInstallations/AppInstallationsDetails/5
        [HttpGet("[action]/{AppInstallationsID}")]
        public IActionResult AppInstallationsDetails(string UserId)
        {

            var AppInstallations = _dbContext.AppInstallations.Where(AppInstallations => AppInstallations.UserId.ToString() == UserId);
            return Ok(AppInstallations);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AppInstallations AppInstallations)
        {
            var userWithSameEmail = _dbContext.AppInstallations.SingleOrDefault(u => u.UserId == AppInstallations.UserId && u.DeviceID == AppInstallations.DeviceID);
            if (userWithSameEmail != null)
            {
                var AppInstallation = _dbContext.AppInstallations.Where(s => s.AppInstId == userWithSameEmail.AppInstId);
                _dbContext.AppInstallations.RemoveRange(AppInstallations);
                _dbContext.SaveChanges();
            }
            var AppInstallationsObj = new AppInstallations
            {
                AppInstId = Guid.NewGuid(),
                UserId = AppInstallations.UserId,
                DeviceID = AppInstallations.DeviceID,
                DeviceOS = AppInstallations.DeviceOS,
                DeviceOSVersion = AppInstallations.DeviceOSVersion,
                DeviceModel = AppInstallations.DeviceModel,
                DeviceNickName = AppInstallations.DeviceNickName,
                InstallDate = AppInstallations.InstallDate,
                InstallType = AppInstallations.InstallType,
                LastAuthDate = AppInstallations.LastAuthDate,
                AppVersion = AppInstallations.AppVersion,
                RegId = AppInstallations.RegId,
                MasterSyncReq = AppInstallations.MasterSyncReq,
                InstStatus = AppInstallations.InstStatus
            };
            _dbContext.AppInstallations.Add(AppInstallationsObj);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{AppInstallationsID}")]
        public IActionResult Delete(string AppInstallationsID)
        {
            var AppInstallations = _dbContext.AppInstallations.Where(s => s.AppInstId.ToString() == AppInstallationsID);
            _dbContext.AppInstallations.RemoveRange(AppInstallations);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
