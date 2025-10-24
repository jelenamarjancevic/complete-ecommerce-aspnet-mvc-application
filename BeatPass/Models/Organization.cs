using BeatPass.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeatPass.Models
{
    public class Organization:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Organization Logo")]
        [Required(ErrorMessage = "Organization logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Organization name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Organization Description")]
        [Required(ErrorMessage = "Organization description is required")]
        
        public string Description { get; set; }

        [ValidateNever]
        //relationships
        public List<Festival> Festivals { get; set; }
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
