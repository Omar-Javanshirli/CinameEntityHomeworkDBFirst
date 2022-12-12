using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinemaProjectWpf.DataAccess.EFrameworkServer;
using CinemaProjectWpf.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Domain.Service
{
    public class MovieDateService
    {
        private readonly IRepository<MovieDate> _movieDateRepo;

        public MovieDateService()
        {
            _movieDateRepo = new EFMovieDateRepository();
        }

        public MovieDate GetTimeDate(int id)
        {
            using (var context = new CinemaPlusEntities())
            {
                var data = context.MovieDates.Include(nameof(MovieDate.Times)).FirstOrDefault(x => x.Id == id);
                return data;
            }
        }
    }
}
