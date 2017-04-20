using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Models
{
    public class BooksForCreationDto
    {
        [Required(ErrorMessage = "You should provide a book name")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

    }
}
