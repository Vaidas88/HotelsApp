using HotelsApp.Data;
using HotelsApp.Models;

namespace HotelsApp.Repositories
{
    public class CityRepo : GenericRepo<City>
    {
        public CityRepo(DataContext context) : base(context)
        {
        }
    }
}
