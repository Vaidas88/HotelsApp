using HotelsApp.Data;
using HotelsApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelsApp.Repositories
{
    public class HotelRepo : GenericRepo<Hotel>
    {
        public HotelRepo(DataContext context) : base(context)
        {
        }

        public override List<Hotel> GetAll()
        {
            return _dbSet.Include(c => c.City).Include(r => r.Rooms).ToList();
        }
    }
}
