using System;

namespace FoodApi.Models
{
    public class FamilyMemberDetails
    {
        public Guid FamMembID { get; set; }
        public string MembType { get; set; }
        public Guid UserId { get; set; }
        public string MembFName { get; set; }
        public string MembLName { get; set; }
        public string MembEmail { get; set; }
        public string MembPhone1 { get; set; }
        public string MembPhone2 { get; set; }
        public DateTime MembBirthDate { get; set; }
        public int? MembAge { get; set; }
        public string ModeType { get; set; }
        public Guid? SchoolID { get; set; }
        public Guid? OfficeID { get; set; }
        public int? Standard { get; set; }
        public string Division { get; set; }
    }
}