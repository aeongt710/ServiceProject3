using Microsoft.AspNetCore.Identity;

namespace ServiceProject3.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int HourlyRate { get; set; }
        public string Description { get; set; }
        public string UserId  { get; set; }
        public IdentityUser User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
