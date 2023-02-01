using Microsoft.AspNetCore.Identity;

namespace HrSystem.Models
{
    public class Hr : IdentityUser
    {
        public int CompanyId { get; set; }
    }
}
