using Core.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Component
{
    public class HomeBook:ViewComponent
    {
        private readonly BookService _bookService;
        public HomeBook(BookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IViewComponentResult> InvokeAsync (bool ShowHome,bool IsNew) 

        {
            if (IsNew)
            {
                var data = await _bookService.GetBooksWithAutors(a => a.ShowHomePage == ShowHome);
                data = data.OrderByDescending(a => a.Created).ToList();
                return View("~/Views/Shared/Component/HomeBook.cshtml", data);



            }
            else 
            {

                var data = await _bookService.GetBooksWithAutors(a => a.ShowHomePage == ShowHome);
                
                return View("~/Views/Shared/Component/HomeBook.cshtml", data);


            }


        }
    }
}
