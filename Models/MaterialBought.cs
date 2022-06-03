using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ServiceProject3.Models
{
    public class MaterialBought
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string SeekerId { get; set; }
        public IdentityUser Seeker { get; set; }
        public string RiderId { get; set; }
        public IdentityUser Rider { get; set; }
        public bool PickUp { get; set; }
        [Required]
        public string Address { get; set; }
        public bool ApprovalStatus { get; set; }
        public bool DeliveryStatus { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public string? SubCategory { get; set; }
        [Display(Name ="Duration")]
        public string? Note { get; set; }
        [Required]
        [Range(1,100000)]
        public int TotalPrice { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
