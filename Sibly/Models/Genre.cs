using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibly.Models
{
    public class Genre
    {
        public byte GenreId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}