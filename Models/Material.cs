using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ServiceProject3.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Range(1,100000)]
        public int Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public int? MaterialCategoryId { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
    }
}
