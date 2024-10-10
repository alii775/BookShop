using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Models.Data;
using Core.BookService;
using Core.AutorService;
using Microsoft.AspNetCore.Authorization;

namespace AdminBookShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService ;
        private readonly AutorService _autorService ;

        public BooksController(BookService bookService, AutorService autorService)
        {
            _bookService = bookService;
            _autorService = autorService;
        }

        // GET: Books
        public  async Task< IActionResult> Index()
        {
            var data = await _bookService.GetBooksWithAutors();
            return View(data);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _bookService.GetBooksWithAutors(a  => a.Id == id);
            var book = books.FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [Authorize]
        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AutorId"] = new SelectList(await _autorService.GetAutors(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAutors(), "Id", "Name", book.AutorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookDtoById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAutors(), "Id", "Name", book.AutorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  BookDto book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await _bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAutors(), "Id", "Name", book.AutorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var books = await _bookService.GetBooksWithAutors(a => a.Id == id);
            var book = books.FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _bookService.GetBooksWithAutors(a => a.Id == id);
            var book = books.FirstOrDefault();
          
            
             await  _bookService.DeleteBook(book);
            

            return RedirectToAction(nameof(Index));
        }

      
    }
}
