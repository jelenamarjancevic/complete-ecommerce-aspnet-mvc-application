using BeatPass.Data;
using BeatPass.Data.Services;
using BeatPass.Models;
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

            return View(allFestivals);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allFestivals = await _service.GetAllAsync(n => n.Location);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allFestivals.Where(n => n.Name.Contains(searchString)
                || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allFestivals);
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

        [HttpPost]
        public async Task<IActionResult> Create(NewFestivalVM festival)
        {
            if(!ModelState.IsValid)
            {
                var festivalDropdownsData = await _service.GetNewFestivalDropdownsValues();

                ViewBag.Organizations = new SelectList(festivalDropdownsData.Organizations, "Id", "Name");
                ViewBag.Locations = new SelectList(festivalDropdownsData.Locations, "Id", "Name");
                ViewBag.Artists = new SelectList(festivalDropdownsData.Artists, "Id", "FullName");

                return View(festival);
            }
            await _service.AddNewFestivalAsync(festival);
            return RedirectToAction(nameof(Index));
        }

        //GET: Festivals/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var festivalDetails = await _service.GetFestivalByIdAsync(id);
            if(festivalDetails == null) return View("NotFound");
            var response = new NewFestivalVM()
            {
                Id = festivalDetails.Id,
                Name = festivalDetails.Name,
                Description = festivalDetails.Description,
                Price = festivalDetails.Price,
                StartDate = festivalDetails.StartDate,
                EndDate = festivalDetails.EndDate,
                FestivalCategory = festivalDetails.FestivalCategory,
                LocationId = festivalDetails.LocationId,
                OrganizationId = festivalDetails.OrganizationId,
                Logo = festivalDetails.Logo,
                ArtistIds = festivalDetails.Artists_Festivals.Select(n => n.ArtistId).ToList()
            };

            var festivalDropdownsData = await _service.GetNewFestivalDropdownsValues();
            ViewBag.Organizations = new SelectList(festivalDropdownsData.Organizations, "Id", "Name");
            ViewBag.Locations = new SelectList(festivalDropdownsData.Locations, "Id", "Name");
            ViewBag.Artists = new SelectList(festivalDropdownsData.Artists, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewFestivalVM festival)
        {
            if (id != festival.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var festivalDropdownsData = await _service.GetNewFestivalDropdownsValues();

                ViewBag.Organizations = new SelectList(festivalDropdownsData.Organizations, "Id", "Name");
                ViewBag.Locations = new SelectList(festivalDropdownsData.Locations, "Id", "Name");
                ViewBag.Artists = new SelectList(festivalDropdownsData.Artists, "Id", "FullName");

                return View(festival);
            }

            await _service.UpdateNewFestivalAsync(festival);
            return RedirectToAction(nameof(Index));
        }
    }
}
