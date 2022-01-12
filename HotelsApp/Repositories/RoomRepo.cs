using HotelsApp.Data;
using HotelsApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelsApp.Repositories
{
    public class RoomRepo : GenericRepo<Room>
    {
        public RoomRepo(DataContext context) : base(context)
        {
        }

        public override List<Room> GetAll()
        {
            return _dbSet.Include(r => r.Hotel).ToList();
        }
    }
}
