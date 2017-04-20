using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{id}")]
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
    }
}