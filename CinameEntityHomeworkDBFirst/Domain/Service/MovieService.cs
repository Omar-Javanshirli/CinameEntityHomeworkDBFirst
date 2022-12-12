
using CinameEntityHomeworkDBFirst.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Service
{
    public class MovieService
    {
        public static dynamic Data { get; set; }
        public static dynamic SingleData { get; set; }
        public static List<Movy> GetMovies(string movie)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={movie}&plot=full").Result;
            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);

            List<Movy> movies = new List<Movy>();

            try
            {

                for (int i = 0; i < 5; i++)
                {

                    response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[i].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);
                    var mymovie = new Movy
                    {
                        Description = SingleData.Plot,
                        ImagePath = SingleData.Poster,
                        Name = SingleData.Title,
                        Rating = SingleData.imdbRating
                    };
                    movies.Add(mymovie);
                }
            }
            catch (Exception ex)
            {

            }
            return movies;

        }

    }
}
