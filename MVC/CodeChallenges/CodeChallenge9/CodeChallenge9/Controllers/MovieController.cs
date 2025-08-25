using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeChallenge9.Models;
using CodeChallenge9.Repositories;

namespace CodeChallenge9.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        // Extra queries
        public ActionResult ByYear(int year)
        {
            return View("Index", repo.GetMoviesByYear(year));
        }

        public ActionResult ByDirector(string director)
        {
            return View("Index", repo.GetMoviesByDirector(director));
        }
    }

}



