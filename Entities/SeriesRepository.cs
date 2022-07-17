using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dio_dotnet_poo_lab.Interfaces;

namespace dio_dotnet_poo_lab.Entities
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> listSeries = new List<Series>();
        public void Add(Series entity)
        {
            listSeries.Add(entity);
        }

        public Series GetByID(int id)
        {
            if (id < 0 || id >= listSeries.Count)
            {
                return null;
            }
            return listSeries[id];
        }

        public List<Series> List()
        {
            return listSeries;
        }

        public int NextID()
        {
            return listSeries.Count;
        }

        public void Remove(int id)
        {
            listSeries[id].remove();
        }

        public void Update(Series entity)
        {
            listSeries[entity.getID()] = entity;
        }
    }
}