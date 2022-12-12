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
    public class EFLocationRepositry : ILocationRepository
    {
        public void AddData(Location data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Locations.Add(data);
                context.SaveChanges();
            }
        }

        public void DeleteData(Location data)
        {
            using(var context=new CinemaPlusEntities())
            {
                context.Entry(data).State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public ICollection<Location> GetAll()
        {
            List<Location> locations = null;
            using(var context=new CinemaPlusEntities())
            {
                locations=context.Locations.ToList();
            }
            return locations;
        }

        public Location Getdata(int id)
        {
            using(var context=new CinemaPlusEntities())
            {
                var data=context.Locations.Include(nameof(Location.Movies)).FirstOrDefault(x=> x.Id==id);
                return data;
            }
        }

        public void UpdateData(Location data)
        {
            using (var context = new CinemaPlusEntities())
            {
                context.Entry(data).State= EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
