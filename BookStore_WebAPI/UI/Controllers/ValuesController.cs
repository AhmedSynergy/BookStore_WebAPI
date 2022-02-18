using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BookStore_WebAPI.Models;
using PagedList;

namespace BookStore_WebAPI.Controllers

{
    public class ValuesController : ApiController
    {


        ShopContext database = new ShopContext();




        // GET: list of books
    /*    public IEnumerable<Book> Index([FromUri]PagingParameterModel pagingParameterModel)
        {
            var books = from book in database.books
                        select book;


            int count = books.Count();

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pagingParameterModel.pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pagingParameterModel.pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging   
            var items = books.OrderBy(book => book.Id).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            // if CurrentPage is greater than 1 means it has previousPage  
            var previousPage = CurrentPage > 1 ? "Yes" : "No";

            // if TotalPages is greater than CurrentPage means it has nextPage  
            var nextPage = CurrentPage < TotalPages ? "Yes" : "No";

            // Object which we are going to send in header   
            var paginationMetadata = new
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage,
                nextPage
            };
            // return View(books.ToPagedList(pageNumber, pageSize));
            return books;
        }*/

        // GET: most expensive  book

        /*
        public Book MostExpensiveBook()
        {
            var books = database.books.ToList().OrderByDescending(book => book.Price);


            return books.ElementAt(0);
        }
        */
        


        /*
        public IEnumerable<Book> BooksByAuthor(string authorName)
        {
            var books = from book in database.books select book;
            if (!String.IsNullOrEmpty(authorName))
            {
                books = books.Where(book => book.Author.Contains(authorName));
            }

            return books;
        }
        */
        
        // to make create view?
        


        // to add book to database
        
  /*      public string Put(string name,string author,float price,string description)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
                book.Author = author;
                book.Name = name;
                book.Price = price;
                book.Description = description;
                database.books.Add(book);
                 int check = database.SaveChanges();

                 if (check == 1)
                 {
                    return "Data Inserted Successfully.";
                 }
                 else
                 {
                    return "Data insertion failed.";

                 }
                
            }
            return "not valid. insertion failed";


                }


*/

        // EDIT

        /*
                public Book Edit(int id)
                {
                    var book = database.books.Where(b => b.Id == id).FirstOrDefault();

                    return book;
                }


                public string Edit(Book book)
                {
                    if (ModelState.IsValid == true)
                    {
                database.Entry(book).State = System.Data.Entity.EntityState.Modified;
                          int check = database.SaveChanges();
                          if (check == 1)
                          {
                                return "Data updated successfully.";
                                    

                          }
                          else
                          {
                                return "data updation failed.";


                          }


                    }
                    return "s";
                }
        */

                /*

                public Book Delete(int id)
                {
                    var book = database.books.Where(b => b.Id == id).FirstOrDefault();
                    return book;
                }


                [HttpPost]

                public string Delete(Book book)
                {
                    /*    
                        database.Entry(book).State = EntityState.Deleted;
                        int check = database.SaveChanges();
                        if (check == 1)
                        {
                            TempData["DeleteMessage"] = "Data Deletion Successful";
                            return RedirectToAction("Index");
                        }
                        else
                        {

                            TempData["DeleteMessage"] = "Data Deletion Failed ";
                            return RedirectToAction("Index");
                        }


                    return "d";
            //        return View();
                }

                // GET api/values
                public IEnumerable<string> Get()
                {
                    return new string[] { "value1", "value2" };
                }

                // GET api/values/5
                public string Get(int id)
                {
                    return "value";
                }

                // POST api/values
                public void Post([FromBody] string value)
                {
                }

                // PUT api/values/5
                public void Put(int id, [FromBody] string value)
                {
                }


        */
    }

}
