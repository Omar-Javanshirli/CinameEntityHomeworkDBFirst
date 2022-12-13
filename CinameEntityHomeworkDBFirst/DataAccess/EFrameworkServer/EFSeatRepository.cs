using CinameEntityHomeworkDBFirst.Domain.Abstractions;
using CinameEntityHomeworkDBFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinameEntityHomeworkDBFirst.DataAccess.EFrameworkServer
{
    public class EFSeatRepository : ISeatRepository
    {
        public void AddData(Seat data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Seats.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Seat data)
        {
            using (var context=new CinemaPlusEntities())
            {
                context.Entry(data).State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ICollection<Seat> GetAll()
        {
            List<Seat> seats = null;
            using (var context = new CinemaPlusEntities())
            {
                seats=context.Seats.ToList();
            }
            return seats;
        }

        public Seat Getdata(int id)
        {
            using(var context=new CinemaPlusEntities())
            {
                var data=context.Seats.Include(nameof(Seat.Times)).FirstOrDefault(s=>s.Id==id);
                return data;
            }
        }

        public void UpdateData(Seat data)
        {
            using (var context=new CinemaPlusEntities())
            {
                context.Entry(data).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
