using Microsoft.AspNetCore.Identity;

namespace HrSystem.Models
{
    public class Applicant 
    {
        public string IdentityUserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
