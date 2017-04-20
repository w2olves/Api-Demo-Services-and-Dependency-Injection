using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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


        [HttpPost("{authorId}/books", Name = "CreateBook")]
        public IActionResult CreateBook(int authorId, [FromBody] BooksForCreationDto book)
        {
            //Validations
            if (book == null)
            {
                return BadRequest();
            }

            if (book.Name == book.Description)
            {
                ModelState.AddModelError("Description", "The book name and the description cannot be the same");
            }

            //Is the model in a valid state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == authorId);

            if (author == null)
            {
                return NotFound("Author was not found");
            }

            //Demo Purpose will be improved
            //Get Max Book Id
            var maxBookId = AuthorsDatastore.Current.Authors.SelectMany(a => a.Books).Max(b => b.Id);
            //The above method is slow 
            //The above method does not take into account scenarios where multiple users will try to get an ID simultaneously
            

            var newBook = new BooksDto()
            {
                Id = ++maxBookId,
                Name = book.Name,
                Description = book.Description
            };
            author.Books.Add(newBook);

            //return Ok(author.Books);
            
            //For Post the advised response is 201 Created
            return CreatedAtRoute("GetbookByAuthorId", new {authorId = authorId, bookid = newBook.Id}, newBook);

        }

        


        [HttpPatch("{authorId}/books/{id}", Name = "UpdateBook")]
        public IActionResult UpdateBook(int authorId, int id, [FromBody] JsonPatchDocument<BooksForCreationDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(a => a.Id == authorId);
            {
                if (author == null)
                {
                    return NotFound();
                }
            }

            var book = author.Books.FirstOrDefault(a => a.Id == id);
            {
                if (book == null)
                {
                    return NotFound();
                }
            }

           
             var bookToPatch = new BooksForCreationDto()
            {
                Name = book.Name,
                Description = book.Description
            };

            patchDocument.ApplyTo(bookToPatch, ModelState);


            TryValidateModel(bookToPatch);

            //Is the model in a valid state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            book.Name = bookToPatch.Name;
            book.Description = bookToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{authorId}/books/{id}", Name = "UpdateBook")]
        public IActionResult DeleteBook(int authorId, int id)
        {
         
            var author = AuthorsDatastore.Current.Authors.FirstOrDefault(a => a.Id == authorId);
            {
                if (author == null)
                {
                    return NotFound();
                }
            }

            var book = author.Books.FirstOrDefault(a => a.Id == id);
            {
                if (book == null)
                {
                    return NotFound();
                }
            }

            //Is the model in a valid state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            author.Books.Remove(book);

       
            return NoContent();
        }
    }
}