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
        public ActionResult Index()
        {
            var movie = new Movie();

            using (StreamReader r = new StreamReader(Server.MapPath("~/Json/1001Movies.json")))
            {
                string jsonString = r.ReadToEnd();
                movie = Movie.FromJson(jsonString).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (movie != null) movie.Detalhes = Api.SearchOmdb(movie.Const);
            }

           
            return View(movie);
        }

       
    }
}
    