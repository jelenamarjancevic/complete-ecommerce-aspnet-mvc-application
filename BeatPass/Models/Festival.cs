using BeatPass.Data.Base;
using BeatPass.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeatPass.Models
{
    public class Festival : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public FestivalCategory FestivalCategory { get; set; }

        //relationships
        public List<Artist_Festival> Artists_Festivals { get; set; }

        //location
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        //organization
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }




    }
}
