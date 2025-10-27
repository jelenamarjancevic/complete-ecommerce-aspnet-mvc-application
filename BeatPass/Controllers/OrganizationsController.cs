using BeatPass.Data;
using BeatPass.Data.Services;
using BeatPass.Data.Static;
using BeatPass.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BeatPass.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationsService _service;
        public OrganizationsController(IOrganizationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allOrganizations = await _service.GetAllAsync();
            return View(allOrganizations);
        }

        [AllowAnonymous]
        //GET: Organizations/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var organizationDetails = await _service.GetByIdAsync(id);
            if (organizationDetails == null) return View("NotFound");
            return View(organizationDetails);
        }

        //GET: Organizations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }
            await _service.AddAsync(organization);
            return RedirectToAction(nameof(Index));
        }

        //GET: Organizations/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var organizationDetails = await _service.GetByIdAsync(id);
            if (organizationDetails == null) return View("NotFound");
            return View(organizationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return View(organization);
            }

            if(id==organization.Id)
            {
                await _service.UpdateAsync(id, organization);
                return RedirectToAction(nameof(Index));
            }
            return View(organization);
        }

        //GET: Organizations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var organizationDetails = await _service.GetByIdAsync(id);
            if (organizationDetails == null) return View("NotFound");
            return View(organizationDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Console.WriteLine($"Deleting organization {id}");
            var organizationDetails = await _service.GetByIdAsync(id);
            if (organizationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
