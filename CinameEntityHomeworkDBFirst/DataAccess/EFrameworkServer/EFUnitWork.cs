using CinemaProjectWpf.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.DataAccess.EFrameworkServer
{
    public class EFUnitWork : IUnitOfWork
    {
        public ISeatRepository SeatRepository => new EFSeatRepository();

        public ITimeRepository TimeRepository => new EFTimeRepository();

        public ILocationRepository LocationRepository => new EFLocationRepositry();

        public IMovieDateRepository MovieDateRepository => new EFMovieDateRepository();

        public IMovieRepository MovieRepository => new EFMovieRepository();
    }
}
