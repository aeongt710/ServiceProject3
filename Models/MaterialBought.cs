using Microsoft.AspNetCore.Identity;

namespace ServiceProject3.Models
{
    public class MaterialBought
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string SeekerId { get; set; }
        public IdentityUser Seeker { get; set; }
        public string Address { get; set; }
        public bool ApprovalStatus { get; set; }
        public bool DeliveryStatus { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
