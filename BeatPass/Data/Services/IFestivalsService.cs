using BeatPass.Data.Base;
using BeatPass.Data.ViewModels;
using BeatPass.Models;

namespace BeatPass.Data.Services
{
    public interface IFestivalsService :IEntityBaseRepository<Festival>
    {
        Task<Festival> GetFestivalByIdAsync(int id);
        Task<NewFestivalDropdownsVM> GetNewFestivalDropdownsValues();
    }
}
