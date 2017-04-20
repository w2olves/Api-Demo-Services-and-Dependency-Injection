using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/Books")]
    public class BooksController : Controller
    {
        [HttpGet("{authorId}/books")]
        public IActionResult Getbooks(int authorId)
        {
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == authorId);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author.Books);
        }

        [HttpGet("{authorId}/books/{bookid}", Name = "GetbookByAuthorId")]
        public IActionResult GetbookByAuthorId(int authorId, int bookid)
        {
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == authorId);

            if (author == null)
            {
                return NotFound("Author was not found");
            }

            var books = author.Books.FirstOrDefault(p => p.Id == bookid);

            if (books == null)
            {
                return NotFound("Author found but no book was found");
            }

            return Ok(books);
        }
    }
}