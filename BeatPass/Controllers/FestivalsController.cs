using BeatPass.Data;
using BeatPass.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Controllers
{
    public class FestivalsController : Controller
    {
        private readonly IFestivalsService _service;
        public FestivalsController(IFestivalsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allFestivals = await _service.GetAllAsync(n=>n.Location);
            //var allFestivals = await _context.Festivals
            //.Include(f => f.Location)      // povezana destinacija
            //.Include(f => f.Organization)     // povezana agencija
            //.Include(f => f.Artists_Festivals)
            //.ThenInclude(af => af.Artist)   // vodiči koji rade na tom aranžmanu
            //.ToListAsync();

            return View(allFestivals);
        }

        //GET: Festivals/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var festivalDetail = await _service.GetFestivalByIdAsync(id);
            return View(festivalDetail);
        }

        //GET: Festivals/Create
        public async Task<IActionResult> Create()
        {
            var festivalDropdownsData = await _service.GetNewFestivalDropdownsValues();
            ViewBag.Organizations = new SelectList(festivalDropdownsData.Organizations, "Id", "Name");
            ViewBag.Locations = new SelectList(festivalDropdownsData.Locations, "Id", "Name");
            ViewBag.Artists = new SelectList(festivalDropdownsData.Artists, "Id", "FullName");

            return View();
        }
    }
}
