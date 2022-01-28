using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sibly.Models;
namespace Sibly.ViewModels
{
    public class MovieFormViewModel
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

        [Required]
        [Display(Name = "Release Date (MM/DD/YYY)")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title { get 
        {
            return MovieId == 0 ? "New Movie" : "Edit Movie";
        } }

        public MovieFormViewModel()
        {
            MovieId = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
     
        }


    }
}

