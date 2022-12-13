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
    public class EFMovieDateRepository : IMovieDateRepository
    {
        public void AddData(MovieDate data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.MovieDates.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(MovieDate data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Entry(data).State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ICollection<MovieDate> GetAll()
        {
            List<MovieDate> movieDates = null;
            using(var context=new CinemaPlusEntities())
            {
                movieDates=context.MovieDates.ToList();
            }
            return movieDates;
        }

        public MovieDate Getdata(int id)
        {
            using(var context=new CinemaPlusEntities())
            {
                var data = context.MovieDates.Include(nameof(MovieDate.Locations)).FirstOrDefault(x => x.Id == id);
                return data;
            }
        }

        public void UpdateData(MovieDate data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Entry(data).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
