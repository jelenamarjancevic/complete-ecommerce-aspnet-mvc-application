using BeatPass.Data.Base;
using BeatPass.Models;

namespace BeatPass.Data.Services
{
    public class LocationsService : EntityBaseRepository<Location>, ILocationsService
    {
        public LocationsService(AppDbContext context) : base(context)
        {
        }
    }
}
