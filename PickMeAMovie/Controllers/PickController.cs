using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PickMeAMovie.Models;
using PickMeAMovie.Business;


namespace PickMeAMovie.Controllers
{
    public class PickController : Controller
    {
        // GET: Pick
        //Get
        public ActionResult Index()
        {
            var movies = MovieJson.GetMovies();

            if (movies.Count > 0)
            {
                var movie = movies.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (movie != null) movie.Details = Api.SearchOmdb(movie.Const);
                return View(movie);
            }
            else
            {
                throw new FileLoadException();
            }
            
        }

    }
}
    