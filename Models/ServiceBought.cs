using Microsoft.AspNetCore.Identity;

namespace ServiceProject3.Models
{
    public class ServiceBought
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public string SeekerId { get; set; }
        public IdentityUser Seeker { get; set; }
        public string Note { get; set; }
        public bool ApprovalStatus { get; set; }
        public bool CompletionStatus { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

    }
}
