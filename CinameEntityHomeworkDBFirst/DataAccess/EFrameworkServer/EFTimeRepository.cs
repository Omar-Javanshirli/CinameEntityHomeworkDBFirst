using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinemaProjectWpf.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.DataAccess.EFrameworkServer
{
    public class EFTimeRepository : ITimeRepository
    {
        public void AddData(Time data)
        {
            using(var context = new CinemaPlusEntities())
            {
                context.Times.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Time data)
        {
            using(var context=new CinemaPlusEntities())
            {
                context.Entry(data).State=EntityState.Modified;
                context.SaveChanges();
            }
        }

        public ICollection<Time> GetAll()
        {
            List<Time> times = null;
            using (var context = new CinemaPlusEntities())
            {
                times=context.Times.ToList();
            }
            return times;   
        }

        public Time Getdata(int id)
        {
            using (var context = new CinemaPlusEntities())
            {
                var data=context.Times.Include(nameof(Time)).FirstOrDefault(x => x.Id==id);
                return data;
            }
        }

        public void UpdateData(Time data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Entry(data).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
