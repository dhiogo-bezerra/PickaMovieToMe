using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PickMeAMovie.Models.API;

using RestSharp;


namespace PickMeAMovie.Business
{
    public class Api
    {
        public static Omdb SearchOmdb(string imdbCode)
        {
            var omdb = new Omdb();
            string apikey = "f04047c5";
            var client = new RestClient(String.Format($"http://www.omdbapi.com/?apikey={apikey}&i={imdbCode}"));
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                omdb = Omdb.FromJson(response.Content);
            }

            return omdb;


        }
    }
}