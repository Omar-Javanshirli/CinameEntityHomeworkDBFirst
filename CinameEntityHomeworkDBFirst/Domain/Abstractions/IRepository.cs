using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProjectWpf.Domain.Abstractions
{
    public interface IRepository<T>
    {
        T Getdata(int id);
        ICollection<T> GetAll();
        void AddData(T data);
        void UpdateData(T data);
        void DeleteData(T data);
    }
}
