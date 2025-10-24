using BeatPass.Data.Base;
using BeatPass.Data.ViewModels;
using BeatPass.Models;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Data.Services
{
    public class FestivalsService : EntityBaseRepository<Festival>, IFestivalsService
    {
        private readonly AppDbContext _context;
        public FestivalsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Festival> GetFestivalByIdAsync(int id)
        {
            var festivalDetails = await _context.Festivals
                .Include(l => l.Location)      
                .Include(o => o.Organization)    
                .Include(af => af.Artists_Festivals)
                .ThenInclude(a => a.Artist)   
                .FirstOrDefaultAsync(n => n.Id == id);

            return festivalDetails;
        }

        public async Task<NewFestivalDropdownsVM> GetNewFestivalDropdownsValues()
        {
            var response = new NewFestivalDropdownsVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync(),
                Locations = await _context.Locations.OrderBy(n => n.Name).ToListAsync(),
                Organizations = await _context.Organizations.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }
    }
}
