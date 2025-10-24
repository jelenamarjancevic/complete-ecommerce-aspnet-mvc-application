using BeatPass.Data.Base;
using BeatPass.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeatPass.Models
{
    public class NewFestivalVM
    {
        public int Id { get; set; }

        [Display(Name = "Festival Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Festival Poster")]
        [Required(ErrorMessage = "Poster is required")]
        public string Logo { get; set; }

        [Display(Name = "Festival Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Festival Price")]
        [Required(ErrorMessage = "Price in EUR")]
        public double Price { get; set; }

        [Display(Name = "Festival Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Festival End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Category is required")]
        public FestivalCategory FestivalCategory { get; set; }

        //relationships
        [Display(Name = "Select Artists")]
        [Required(ErrorMessage = "At least one artist is required")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Select Location")]
        [Required(ErrorMessage = "Location is required")]
        public int LocationId { get; set; }

        [Display(Name = "Select Organization")]
        [Required(ErrorMessage = "Organization is required")]
        public int OrganizationId { get; set; }
    }
}
