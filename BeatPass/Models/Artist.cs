using BeatPass.Data.Base;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BeatPass.Models
{
    public class Artist : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        //public int Id
        //{
        //    get { return ArtistId; } // ili FestivalId, zavisno od modela
        //    set { ArtistId = value; }
        //}

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Profile picture is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Full Name must be between 2 and 50 characters")]
        public string FullName { get; set; }

        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Profile picture is required")]
        public string Bio { get; set; }

        //relationships
        [ValidateNever]
        public List<Artist_Festival> Artists_Festivals { get; set; }


        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
