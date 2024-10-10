using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Models.Data;
using Core.AutorService;
using Microsoft.AspNetCore.Authorization;

namespace AdminBookShop.Controllers
{
    public class AutorsController : Controller
    {
        private readonly AutorService _autorService;

        public AutorsController(AutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            return View(await _autorService.GetAutors());
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorById(id.Value);
               
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }
        [Authorize]
        // GET: Autors/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Autor autor)
        {
            if (ModelState.IsValid)
            {
              await _autorService.CreateAutor(autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorById(id.Value);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _autorService.UpdateAutor(autor);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _autorService.GetAutorById(id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _autorService.GetAutorById(id);


            await _autorService.DeleteAutor(autor);
            

           
            return RedirectToAction(nameof(Index));
        }

      
    }
}
