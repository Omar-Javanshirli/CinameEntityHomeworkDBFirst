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
    public class EFMovieRepository : IMovieRepository
    {
        public void AddData(Movy data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Movies.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Movy data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ICollection<Movy> GetAll()
        {
            List<Movy> movies = null;
            using (var context = new CinemaPlusEntities())
            {
                movies = context.Movies.ToList();
            }
            return movies;
        }

        public Movy Getdata(int id)
        {
            using(var context=new CinemaPlusEntities())
            {
                var data=context.Movies.Include(nameof(Movy.Locations)).FirstOrDefault(x=>x.Id==id); 
                return data;
            }
        }

        public void UpdateData(Movy data)
        {
            using (var context =new CinemaPlusEntities())
            {
                context.Entry(data).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
