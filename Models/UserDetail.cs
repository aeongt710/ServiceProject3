using Microsoft.AspNetCore.Identity;

namespace ServiceProject3.Models
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string ImgSrc { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
