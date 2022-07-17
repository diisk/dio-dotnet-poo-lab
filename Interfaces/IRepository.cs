using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dio_dotnet_poo_lab.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T GetByID(int id);

        void Add(T entity);

        void Remove(int id);

        void Update(T entity);

        int NextID();
    }
}