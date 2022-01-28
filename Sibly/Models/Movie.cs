using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibly.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Release Date (MM/DD/YYY)")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }
    }
}