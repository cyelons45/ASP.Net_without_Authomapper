using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sibly.Models;
using System.Data.Entity;
using Sibly.ViewModels;

namespace Sibly.Controllers
{
    public class MoviesController : Controller
    {

        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }



        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



      //GET: /Movies/
          [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movies)
        {
          
            if (!ModelState.IsValid)
            {
                if (Movies.MovieId==0)
                {
                    var genresmodel = _context.Genres.ToList();

                    var genresviewmodel = new MovieFormViewModel()
                    {
                        Genres = genresmodel
                    };
                    return View("MovieForm", genresviewmodel);
                }
                else
                {
                    var genresmodel = _context.Genres.ToList();
                    var movie = _context.Movies.Single(c => c.MovieId == Movies.MovieId);
                    var genresviewmodel = new MovieFormViewModel(movie)
                    {
                        Genres = genresmodel
                    };
                    return View("MovieForm", genresviewmodel);


                }


            }

            if (Movies.MovieId==0)
            {
                _context.Movies.Add(Movies);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.MovieId == Movies.MovieId);
                movieInDB.Name = Movies.Name;
                movieInDB.NumberInStock = Movies.NumberInStock;
                movieInDB.ReleaseDate = Movies.ReleaseDate;
                movieInDB.GenreId = Movies.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }



        public ActionResult New()
        {

            var genresmodel = _context.Genres.ToList();
         
            var genresviewmodel = new MovieFormViewModel()
            {
                Genres = genresmodel
            };
            return View("MovieForm", genresviewmodel);
        }




                 //GET: /Movies/Details/
        public ActionResult Edit(int id)
        {

            var genresmodel = _context.Genres.ToList();
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            var genresviewmodel = new MovieFormViewModel(movie)
            {
                Genres = genresmodel
            };
            return View("MovieForm",genresviewmodel);
        }


        //
        // GET: /Movies/
         //GET: /Movies/
        public ActionResult Index()
        {
            var movies2 = _context.Movies.ToList();
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
	}
}