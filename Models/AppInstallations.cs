using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApi.Models
{
    public class AppInstallations
    {
        [Key]
        public Guid AppInstId { get; set; }
        public Guid userId { get; set; }
        public string DeviceID { get; set; }
        public string DeviceOS { get; set; }
        public string DeviceOSVersion { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceNickName { get; set; }
        public DateTime? InstallDate { get; set; }
        public string InstallType { get; set; }
        public DateTime? LastAuthDate { get; set; }
        public string AppVersion { get; set; }
        public string RegId { get; set; }
        public string MasterSyncReq { get; set; }
        public string InstStatus { get; set; }
    }
}