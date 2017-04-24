using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/Authors")]
    [EnableCors("CorsPolicy")]
    public class AuthorsController : Controller
    {
        [HttpGet()]
        public IActionResult GetAuthors()
        {

            return Ok(AuthorsDatastore.Current.Authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var authorToReturn = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Id == id);
            if (authorToReturn == null)
            {
                return NotFound("This author ID is invalid");
            }
            return Ok(authorToReturn);
        }

        [HttpGet("GetAuthorByName/{name}", Name = "GetAuthorByName")]
        public IActionResult GetAuthorByName(string name)
        {
            var authorToReturn = AuthorsDatastore.Current.Authors.FirstOrDefault(c => c.Name.Contains(name));
            if (authorToReturn == null)
            {
                return NotFound("There is no Author by that name");
                }
            return Ok(authorToReturn);
        }

        [HttpPost("CreateAuthor/{name}", Name = "CreateAuthor")]
        public IActionResult CreateAuthor([FromBody] AuthorsForCreationDto author)
        {
            //Validations
            if (author == null)
            {
                return BadRequest("No Author Info available");
            }

            if (author.Name == author.Description)
            {
                ModelState.AddModelError("Description", "The author name and the description cannot be the same");
            }

            //Is the model in a valid state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            //Demo Purpose will be improved
            //Get Max Book Id
            var maxAuthorId = AuthorsDatastore.Current.Authors.Select(a => a.Id).Max();
            //The above method is slow 
            //The above method does not take into account scenarios where multiple users will try to get an ID simultaneously


            var newAuthor = new AuthorDto()
            {
                Id = ++maxAuthorId,
                Name = author.Name,
                Description = author.Description,
                Books = author.Books
            };

            AuthorsDatastore.Current.Authors.Add(newAuthor);

            //return Ok(author.Books);

            //For Post the advised response is 201 Created
              return CreatedAtRoute("GetAuthor", new { id = newAuthor.Id }, newAuthor);

          //  return Ok(newAuthor);

        }
    }
}