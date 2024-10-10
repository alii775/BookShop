using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.BookRepo
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll(Expression<Func<Book, bool>> where=null);
        Task<Book> GetById(int id);

        Task Add(Book book);
        Task Update(Book  book);
        Task Delete(int id);
        Task Delete(Book book);
    }
}
