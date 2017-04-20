using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfBooks
        {
            get
            {
                return Books.Count;
            }
        }

        public ICollection<BooksDto> Books { get; set; } = new List<BooksDto>();
    }
}
