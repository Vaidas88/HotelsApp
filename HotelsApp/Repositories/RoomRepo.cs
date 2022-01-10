using HotelsApp.Data;
using HotelsApp.Models;

namespace HotelsApp.Repositories
{
    public class RoomRepo : GenericRepo<Room>
    {
        public RoomRepo(DataContext context) : base(context)
        {
        }
    }
}
