using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinameEntityHomeworkDBFirst.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        ISeatRepository SeatRepository { get; }
        ITimeRepository TimeRepository { get; }
        ILocationRepository LocationRepository { get; }
        IMovieDateRepository MovieDateRepository { get; }
        IMovieRepository MovieRepository { get; }
    }
}
