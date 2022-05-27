using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkScheduler.Data;
using WorkScheduler.Database;

namespace WorkScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseInteraction _databaseInteraction;
        public HomeController(IDatabaseInteraction databaseInteraction)
        {
            _databaseInteraction = databaseInteraction;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var works = await _databaseInteraction.GetAll();
            return View(works);
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var work = await _databaseInteraction.GetById(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkDTO work)
        {
            if (!ModelState.IsValid) return View(work);

            await _databaseInteraction.Create(work);
            return RedirectToAction(nameof(Index));
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var work = await _databaseInteraction.GetById(id);
            if (work == null)
            {
                return NotFound();
            }
            return View(work);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WorkDTO work)
        {

            if (!ModelState.IsValid) return View(work);
            await _databaseInteraction.Update(work);
            return RedirectToAction(nameof(Index));
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task Delete(int id)
        {
            await _databaseInteraction.Delete(id);
        }
    }
}
