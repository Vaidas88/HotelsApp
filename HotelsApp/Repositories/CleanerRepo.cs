using HotelsApp.Data;
using HotelsApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelsApp.Repositories
{
    public class CleanerRepo : GenericRepo<Cleaner>
    {
        public CleanerRepo(DataContext context) : base(context)
        {
        }

        public override List<Cleaner> GetAll()
        {
            return _dbSet.Include(c => c.City).Include(c => c.Rooms).ToList();
        }

        public override Cleaner GetSingle(int id)
        {
            return _dbSet
                    .Include(c => c.Rooms)
                    .Include(c => c.City)
                    .SingleOrDefault(c => c.Id == id);
        }
    }
}
