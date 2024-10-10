using Core.UploadFile;
using DataAccess.Models;
using DataAccess.Repositories.BookRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.BookService
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploadService _fileUploadService;
        public BookService(IBookRepository bookRepository, IFileUploadService fileUploadService)
        {
            _bookRepository = bookRepository;
            _fileUploadService = fileUploadService;
        }


        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAll().ToListAsync();
        }


        public async Task<IEnumerable<Book>> GetBooksWithAutors(Expression<Func<Book, bool>> where = null)
        {
            return await _bookRepository.GetAll(where).Include(a => a.Autor).ToListAsync();
        }



        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetById(id);
        }




        public async Task CreateBook(BookDto bookdto)
        {
            var book = new Book()
            {
                Name=bookdto.Name,
                AutorId = bookdto.AutorId,
                Title = bookdto.Title,
                Description = bookdto.Description,
                Price = bookdto.Price,
                IsAvail = bookdto.IsAvail,
                ShowHomePage = bookdto.ShowHomePage,
                Created = DateTime.Now,
            };

            book.Img = await _fileUploadService.UploadFileAsync(bookdto.Img);
            await _bookRepository.Add(book);
        }




        public async Task UpdateBook(BookDto bookDto)
        {
           
            var book = await GetBookById(bookDto.Id);
            book.Name = bookDto.Name;
            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Price = bookDto.Price;
            book.AutorId = bookDto.AutorId;
            book.Created = DateTime.Now;
            book.IsAvail = bookDto.IsAvail;
            book.ShowHomePage = bookDto.ShowHomePage;
           
            if (bookDto.Img != null)
            {
                book.Img = await _fileUploadService.UploadFileAsync(bookDto.Img);

            }
            await _bookRepository.Update(book);
        }



        public async Task DeleteBook(Book book)
        {
            await _bookRepository.Delete(book);
        }




        public async Task<BookDto> GetBookDtoById(int id)
        {
            var book = await _bookRepository.GetById(id);
            var bookDto = new BookDto()
            {
                Name = book.Name,
                AutorId = book.AutorId,
                ImgName = book.Img,
                Description = book.Description,
                Id = id,
                Price = book.Price,
                Title = book.Title,
                IsAvail = book.IsAvail,
                ShowHomePage = book.ShowHomePage
            };
            return bookDto;
        }





        public async Task<PagedBookDto> GetBooKPagination(int page, int pageSize, string? search)
        {
            var books = _bookRepository.GetAll();

            if (!String.IsNullOrEmpty(search))
            {
                books = books.Where(a => a.Title.Contains(search) || a.Description.Contains(search));
            }

            int totalCount = books.Count();
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);

            books = books.Skip((page - 1) * pageSize).Take(pageSize);


            books = books.Include(a => a.Autor);

            var bookDtos = await books.Select(s => new BookDto()
            {
                Title = s.Title,
                Price = s.Price,
                AutorId = s.AutorId,
                Description = s.Description,
                Id = s.Id,
                AutorName = s.Autor.Name,
                ImgName = s.Img,
            }).ToListAsync();

            var result = new PagedBookDto()
            {
                Items = bookDtos,
                Page = page,
                TotalPage = totalPage,
            };

            return result;


        }

    }
}
