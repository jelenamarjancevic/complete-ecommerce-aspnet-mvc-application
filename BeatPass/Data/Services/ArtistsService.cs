using BeatPass.Data.Base;
using BeatPass.Models;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Data.Services
{
    public class ArtistsService :EntityBaseRepository<Artist>, IArtistsService
    {
        public ArtistsService(AppDbContext context) : base(context) { }   
    }
}
