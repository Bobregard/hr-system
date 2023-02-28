using HrSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HrSystem.VIewModels
{
    public class JobViewModel
    {
        public Job Job { get; set; }
        public IEnumerable<SelectListItem>? CategoriesList { get; set; }
        public IEnumerable<SelectListItem>? CompaniesList { get; set; }
    }
}
