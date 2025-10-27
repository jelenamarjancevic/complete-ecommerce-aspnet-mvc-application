using BeatPass.Data;
using BeatPass.Data.Services;
using BeatPass.Data.Static;
using BeatPass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeatPass.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;
        public LocationsController(ILocationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _service.GetAllAsync();
            return View(allLocations);
        }

        //GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }
            await _service.AddAsync(location);
            return RedirectToAction(nameof(Index));
        }

        //Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);

            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }
            await _service.UpdateAsync(id, location);
            return RedirectToAction(nameof(Index));
        }

        //Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
