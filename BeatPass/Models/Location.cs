using BeatPass.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BeatPass.Models
{
    public class Location : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Location Logo")]
        [Required(ErrorMessage = "Location logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required")]
        public string Name { get; set; }

        [Display(Name = "Locations Description")]
        [Required(ErrorMessage = "Location description is required")]
        public string Description { get; set; }

        //relationships
        [ValidateNever]
        public List<Festival> Festivals { get; set; }
    }
}
