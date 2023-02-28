using System.ComponentModel.DataAnnotations;

namespace HrSystem.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

    }
}
