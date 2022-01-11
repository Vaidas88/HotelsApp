using HotelsApp.Data;
using HotelsApp.Dtos;
using HotelsApp.Models;
using System.Collections.Generic;

namespace HotelsApp.Repositories
{
    public class CityRepo : GenericRepo<City>
    {
        public CityRepo(DataContext context) : base(context)
        {
        }
    }
}
