using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using PickMeAMovie.Models;
using PickMeAMovie.Business;
namespace PickMeAMovie.Business
{
    public class MovieJson
    {
        public static List<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Json/");

            string[] fileArray = Directory.GetFiles(path);

            foreach (var file in fileArray)
            {

                using (StreamReader r = new StreamReader(file))
                {
                    string jsonString = r.ReadToEnd();
                    movies.AddRange(Movie.FromJson(jsonString));
                    //movie = Movie.FromJson(jsonString).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                }

            }


            //if (movie != null) movie.Details = Api.SearchOmdb(movie.Const);
            return movies.DistinctBy(f => f.Const).ToList();
        }
    }
}