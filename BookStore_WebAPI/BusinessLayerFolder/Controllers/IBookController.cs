using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore_WebAPI.BusinessLayerFolder.Controllers
{
    interface IBookController
    {
        IEnumerable<BookDTO> GetAllBooks(int page, int ItemsPerPage);

        BookDTO GetMostExpensiveBook();

        IEnumerable<BookDTO> GetBooksByAuthor(string authorName);

        IEnumerable<BookDTO> GetBooksByAuthorByMostExpensiveToLeast(string authorName);

        IEnumerable<BooksAndOrderQuantityDTO> GetBooksByAuthorByMostOrderedToLeast(string authorName);

        string Create(BookDTO book);

        IHttpActionResult EditBook(BookDTO book);

        IHttpActionResult DeleteBook(int bookID);



    }
}
