using HotelsApp.Data;
using HotelsApp.Models;

namespace HotelsApp.Repositories
{
    public class CleanerRepo : GenericRepo<Cleaner>
    {
        public CleanerRepo(DataContext context) : base(context)
        {
        }
    }
}
