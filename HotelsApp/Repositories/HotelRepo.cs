using HotelsApp.Data;
using HotelsApp.Models;

namespace HotelsApp.Repositories
{
    public class HotelRepo : GenericRepo<Hotel>
    {
        public HotelRepo(DataContext context) : base(context)
        {
        }
    }
}
