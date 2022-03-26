using Microsoft.AspNetCore.Identity;

namespace ServiceProject3.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
