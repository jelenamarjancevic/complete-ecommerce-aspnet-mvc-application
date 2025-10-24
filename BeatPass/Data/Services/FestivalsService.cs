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

        public async Task AddNewFestivalAsync(NewFestivalVM data)
        {
            var newFestival = new Festival()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                FestivalCategory = data.FestivalCategory,
                LocationId = data.LocationId,
                OrganizationId = data.OrganizationId,
                Logo = data.Logo
            };
            await _context.Festivals.AddAsync(newFestival);
            await _context.SaveChangesAsync();

            //Add Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistFestival = new Artist_Festival()
                {
                    FestivalId = newFestival.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Festivals.AddAsync(newArtistFestival);
            }
            await _context.SaveChangesAsync();
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

        public async Task UpdateNewFestivalAsync(NewFestivalVM data)
        {
            var dbFestival = await _context.Festivals.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbFestival != null)
            {
                dbFestival.Name = data.Name;
                dbFestival.Description = data.Description;
                dbFestival.Price = data.Price;
                dbFestival.StartDate = data.StartDate;
                dbFestival.EndDate = data.EndDate;
                dbFestival.FestivalCategory = data.FestivalCategory;
                dbFestival.LocationId = data.LocationId;
                dbFestival.OrganizationId = data.OrganizationId;
                dbFestival.Logo = data.Logo;

                await _context.SaveChangesAsync();
            }
            //Remove existing Artists
            var existingArtistsDb = _context.Artists_Festivals.Where(n => n.FestivalId == data.Id).ToList();
            _context.Artists_Festivals.RemoveRange(existingArtistsDb);
            await _context.SaveChangesAsync();

            //Add Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistFestival = new Artist_Festival()
                {
                    FestivalId = data.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Festivals.AddAsync(newArtistFestival);
            }
            await _context.SaveChangesAsync();
        }
    }
}
