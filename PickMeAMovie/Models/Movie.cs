using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PickMeAMovie.Models.API;

namespace PickMeAMovie.Models
{

    public partial class Movie
    {
        [JsonProperty("Position")]
        public Int16 Position { get; set; }

        [JsonProperty("Const")]
        public string Const { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("IMDb Rating")]
        public double ImDbRating { get; set; }

        [JsonProperty("Runtime (mins)")]
        public long RuntimeMins { get; set; }

        [JsonProperty("Year")]
        public Int16 Year { get; set; }

        [JsonProperty("Genres")]
        public string Genres { get; set; }

        [JsonProperty("Release Date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("Directors")]
        public string Directors { get; set; }

        public DateTime DataLancamento
        {
            get { return DateTime.Parse(ReleaseDate); }
            set { }
        }

        public Omdb Detalhes { get; set; }
    }

    public partial class Movie
    {
        public static List<Movie> FromJson(string json) => JsonConvert.DeserializeObject<List<Movie>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Movie> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}