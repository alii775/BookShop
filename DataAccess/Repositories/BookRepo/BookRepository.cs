using DataAccess.Models;
using DataAccess.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.BookRepo
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await GetById(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Book> GetAll(Expression<Func<Book, bool>> where = null)
        {
            var books = _context.Books.AsQueryable();
            if (where != null)
            {
                books = books.Where(where);
            }

            return books;
        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.Include(a => a.Autor).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}

