using BeatPass.Data.Base;
using BeatPass.Models;

namespace BeatPass.Data.Services
{
    public class OrganizationsService: EntityBaseRepository<Organization>, IOrganizationsService
    {
        public OrganizationsService(AppDbContext context) : base(context)
        {
        }
    }
}
