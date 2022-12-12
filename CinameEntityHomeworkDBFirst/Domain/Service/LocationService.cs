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
    public class LocationService
    {
        private readonly IRepository<Location> _locationRepo;

        public LocationService()
        {
            _locationRepo = new EFLocationRepositry();
        }

        public Location GetMovieDates(int id)
        {
            using (var context = new CinemaPlusEntities())
            {
                var data = context.Locations.Include(nameof(Location.MovieDates)).FirstOrDefault(x => x.Id == id);
                return data;
            }
        }
    }
}
