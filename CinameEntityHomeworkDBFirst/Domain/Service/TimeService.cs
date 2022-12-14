using CinameEntityHomeworkDBFirst.DataAccess.EFrameworkServer;
using CinameEntityHomeworkDBFirst.Domain.Abstractions;
using CinameEntityHomeworkDBFirst.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPCinameEntityHomeworkDBFirstrojectWpf.Domain.Service
{
    public class TimeService
    {
        private readonly IRepository<Time> _timeRepo;

        public TimeService()
        {
            _timeRepo = new EFTimeRepository();
        }

        public Time GetDataSeat(int id)
        {
            using (var context = new CinemaPlusEntities())
            {
                var data = context.Times.Include(nameof(Time.Seats)).FirstOrDefault(x => x.Id == id);
                return data;
            }
        }
    }
}
